using OptimizationDemo.Models;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class AlbumComparer : IEqualityComparer<Album>
    {
        private static readonly ImageComparer _imageComparer = new();
        private static readonly AlbumArtistInfoComparer _albumArtistInfoComparer = new();

        private static readonly MultiSetComparer<Image> _msImageComparer = new(_imageComparer);
        private static readonly MultiSetComparer<AlbumArtistInfo> _msAlbumArtistInfoComparer = new(_albumArtistInfoComparer);

        public bool Equals(Album? x, Album? y)
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

            return x.Id == y.Id
                && x.Name == y.Name
                && x.Description == y.Description
                && x.Type == y.Type
                && x.TotalTracks == y.TotalTracks
                && _msImageComparer.Equals(x.Images, y.Images)
                && x.ReleaseDate == y.ReleaseDate
                && _msAlbumArtistInfoComparer.Equals(x.Artists, y.Artists);
        }

        public int GetHashCode([DisallowNull] Album obj)
        {
            var hashImages = new HashCode();
            foreach (var item in obj.Images)
            {
                hashImages.Add(_imageComparer.GetHashCode(item));
            }

            var hashArtists = new HashCode();
            foreach (var item in obj.Artists)
            {
                hashArtists.Add(_albumArtistInfoComparer.GetHashCode(item));
            }    

            var hashCode = new HashCode();
            hashCode.Add(obj.Id);
            hashCode.Add(obj.Name);
            hashCode.Add(obj.Description);
            hashCode.Add(obj.Type);
            hashCode.Add(obj.TotalTracks);
            hashCode.Add(hashImages.ToHashCode());
            hashCode.Add(obj.ReleaseDate);
            hashCode.Add(hashArtists.ToHashCode());

            return hashCode.ToHashCode();
        }
    }
}
