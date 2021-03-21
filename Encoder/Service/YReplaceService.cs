namespace Encoder.Service
{
    public class YReplaceService : ReplaceService<char>
    {
        private static readonly char YConsonant = 'y';

        protected override bool AppliesTo(char model)
        {
            return model == YConsonant;
        }

        protected override char DoReplace(char model)
        {
            return ' ';
        }
    }
}
