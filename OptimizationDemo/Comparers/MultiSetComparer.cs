using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class MultiSetComparer<T>(IEqualityComparer<T> comparer) : IEqualityComparer<IEnumerable<T>>
    {
        private readonly IEqualityComparer<T> _comparer = comparer;

        public bool Equals(IEnumerable<T>? x, IEnumerable<T>? y)
        {

            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null)
            {
                return false;
            }

            if (y is null)
            {
                return false;
            }

            if (x is ICollection<T> xCollection && y is ICollection<T> yCollection)
            {
                if (xCollection.Count != yCollection.Count)
                {
                    return false;
                }

                if (xCollection.Count == 0)
                {
                    return true;
                }
            }
            var hashX = GetHashCode(x);
            var hashY = GetHashCode(y);
            return hashX == hashY;
        }

        public int GetHashCode([DisallowNull] IEnumerable<T> obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            var hash = 17;

            foreach (var item in obj)
            {
                hash ^= item is null ? 42 : _comparer?.GetHashCode(item) ?? item.GetHashCode();
            }

            return hash;
        }
    }
}
