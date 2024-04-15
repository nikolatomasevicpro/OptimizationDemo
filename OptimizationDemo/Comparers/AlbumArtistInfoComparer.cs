using OptimizationDemo.Models;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class AlbumArtistInfoComparer : IEqualityComparer<AlbumArtistInfo>
    {
        public bool Equals(AlbumArtistInfo? x, AlbumArtistInfo? y)
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

            return x.Name == y.Name
                && x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] AlbumArtistInfo obj)
        {
            return HashCode.Combine(obj.Name, obj.Id);
        }
    }
}
