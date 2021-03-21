namespace Encoder.Service
{
    public class DefaultReplaceService : ReplaceService<char>
    {
        protected override bool AppliesTo(char model)
        {
            return true;
        }

        protected override char DoReplace(char model)
        {
            return model;
        }
    }
}
