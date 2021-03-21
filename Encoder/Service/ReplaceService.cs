using System;

namespace Encoder.Service
{
    public abstract class ReplaceService<TModel> : IReplaceService where TModel : IEquatable<TModel>, IComparable, IConvertible
    {
        public virtual bool AppliesTo<T>(T model) where T : IEquatable<T>, IComparable, IConvertible
        {
            return AppliesTo((TModel)(object)model);
        }

        public T Replace<T>(T model) where T : IEquatable<T>, IComparable, IConvertible
        {
            var t = ConvertValue<TModel, T>(model);
            //return DoReplace((TModel)(object)model);
            var y = DoReplace(t);
            var z = ConvertValue<T, TModel>(y);
            return z;
        }

        protected abstract TModel DoReplace(TModel model);
        protected abstract bool AppliesTo(TModel model);

        public static T ConvertValue<T, U>(U value) where U : IConvertible
        {
            return (T)ConvertValue(value, typeof(T));
        }

        public static object ConvertValue(IConvertible value, Type targetType)
        {
            return Convert.ChangeType(value, targetType);
        }
    }
}
