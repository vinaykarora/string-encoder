using System.Collections.Generic;

namespace Encoder.Service
{
    public class ConsonantReplaceService : ReplaceService<char>
    {
        private readonly IDictionary<char, char> _vowel = new Dictionary<char, char>();
        private static readonly char StartConsonant = 'a';
        private static readonly char EndConsonant = 'z';

        public ConsonantReplaceService()
        {
            _vowel.Add('a', '1');
            _vowel.Add('e', '2');
            _vowel.Add('i', '3');
            _vowel.Add('o', '4');
            _vowel.Add('u', '5');
        }

        protected override bool AppliesTo(char model)
        {
            return !_vowel.ContainsKey(model) && model >= StartConsonant && model <= EndConsonant;
        }

        protected override char DoReplace(char model)
        {
            return (char)(model - 1);
        }
    }
}
