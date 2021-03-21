using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encoder.Service
{
    public class ReplaceStrategy : IReplaceStrategy
    {
        private readonly IEnumerable<IReplaceService> replaceServices;
        public ReplaceStrategy(IEnumerable<IReplaceService> replaceServices)
        {
            this.replaceServices = replaceServices ??
                throw new ArgumentNullException(nameof(replaceServices));
        }

        public T Replace<T>(T model) where T : IEquatable<T>, IComparable, IConvertible
        {
            if (model == null)
            {
                throw new ArgumentException("Invalid message pass");
            }

            StringBuilder output = new StringBuilder();
            string numberReplaceOutput = new NumberReplaceService().Replace(model.ToString().ToLower());

            foreach (char c in numberReplaceOutput)
            {
                if (char.IsDigit(c))
                {
                    output.Append(c);
                }
                else
                {
                    output.Append(GetReplaceService(c).Replace(c));
                }
            }

            return (T)(object)output.ToString();
        }

        public IReplaceService GetReplaceService<T>(T model) where T : IEquatable<T>, IComparable, IConvertible
        {
            var result = replaceServices.FirstOrDefault(p => p.AppliesTo(model));
            if (result == null)
            {
                throw new InvalidOperationException(
                    $"Payment service for {model.GetType()} not registered.");
            }
            return result;
        }
    }
}
