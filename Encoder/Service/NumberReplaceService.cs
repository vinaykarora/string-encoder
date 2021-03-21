using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Encoder.Service
{
    public class NumberReplaceService : ReplaceService<string>
    {
        private const string NumbersPattern = @"\d+";

        protected override bool AppliesTo(string model)
        {
            return model.Any(char.IsDigit);
        }

        protected override string DoReplace(string model)
        {
            MatchCollection numbers = Regex.Matches(model, NumbersPattern);
            StringBuilder withNumbers = new StringBuilder(model);
            foreach (Match item in numbers)
            {
                char[] cArray = item.Value.ToCharArray();
                Array.Reverse(cArray);
                withNumbers.Replace(item.Value, new string(cArray));
            }

            return withNumbers.ToString();
        }
    }
}
