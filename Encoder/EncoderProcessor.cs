using Encoder.Service;
using System.Collections.Generic;

namespace Encoder
{
    public class EncoderProcessor
    {
        private readonly IEnumerable<IReplaceService> replaceServices;
        public EncoderProcessor(IEnumerable<IReplaceService> replaceServices)
        {
            this.replaceServices = replaceServices;
        }

        public string Encode(string message)
        {
            IReplaceStrategy replaceStrategy = new ReplaceStrategy(this.replaceServices);
            var returnMsg = replaceStrategy.Replace(message);
            return returnMsg;
        }
    }
}