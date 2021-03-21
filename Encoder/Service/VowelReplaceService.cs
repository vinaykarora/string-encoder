using System.Collections.Generic;

namespace Encoder.Service
{
    public class VowelReplaceService : ReplaceService<char>
    {
        private readonly IDictionary<char, char> _vowel = new Dictionary<char, char>();

        public VowelReplaceService()
        {
            _vowel.Add('a', '1');
            _vowel.Add('e', '2');
            _vowel.Add('i', '3');
            _vowel.Add('o', '4');
            _vowel.Add('u', '5');
        }

        protected override bool AppliesTo(char model)
        {
            return _vowel.ContainsKey(model);
        }

        protected override char DoReplace(char model)
        {
            _ = _vowel.TryGetValue(model, out char replacedValue);
            return replacedValue;
        }
    }
}
