using System;

namespace Encoder.Service
{
    public interface IReplaceService
    {
        T Replace<T>(T model) where T : IEquatable<T>, IComparable, IConvertible;
        bool AppliesTo<T>(T model) where T : IEquatable<T>, IComparable, IConvertible;
    }
}
