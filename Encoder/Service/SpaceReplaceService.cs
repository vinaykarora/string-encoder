namespace Encoder.Service
{
    public class SpaceReplaceService : ReplaceService<char>
    {
        private static readonly char SpaceConsonant = ' ';

        protected override bool AppliesTo(char model)
        {
            return model == SpaceConsonant;
        }

        protected override char DoReplace(char model)
        {
            return 'y';
        }
    }
}
