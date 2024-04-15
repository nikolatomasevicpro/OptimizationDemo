using OptimizationDemo.Models;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class ImageComparer : IEqualityComparer<Image>
    {
        public bool Equals(Image? x, Image? y)
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

            return x.Url == y.Url
                && x.Width == y.Width
                && x.Height == y.Height;
        }

        public int GetHashCode([DisallowNull] Image obj)
        {
            return HashCode.Combine(obj.Url, obj.Width, obj.Height);
        }
    }
}
