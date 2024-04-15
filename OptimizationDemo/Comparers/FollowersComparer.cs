using OptimizationDemo.Models;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class FollowersComparer : IEqualityComparer<Followers>
    {
        public bool Equals(Followers? x, Followers? y)
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

            return x.Total == y.Total;
        }

        public int GetHashCode([DisallowNull] Followers obj)
        {
            return HashCode.Combine(obj.Total);
        }
    }
}
