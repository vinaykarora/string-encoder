using System;

namespace Encoder.Service
{
    public interface IReplaceStrategy
    {
        T Replace<T>(T model) where T : IEquatable<T>, IComparable, IConvertible;
        IReplaceService GetReplaceService<TPaymentModel>(TPaymentModel model) where TPaymentModel : IEquatable<TPaymentModel>, IComparable, IConvertible;
    }
}
