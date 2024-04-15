using OptimizationDemo.Models;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class ExternalIdsComparer : IEqualityComparer<ExternalIds>
    {
        public bool Equals(ExternalIds? x, ExternalIds? y)
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

            return x.Ean == y.Ean
                && x.Isrc == y.Isrc
                && x.Upc == y.Upc;
        }

        public int GetHashCode([DisallowNull] ExternalIds obj)
        {
            return HashCode.Combine(obj.Ean, obj.Isrc, obj.Upc);
        }
    }
}
