using OptimizationDemo.Models;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class TrackArtistInfoComparer : IEqualityComparer<TrackArtistInfo>
    {
        private static readonly FollowersComparer _followersComparer = new();
        private static readonly ImageComparer _imagesComparer = new();

        private static readonly MultiSetComparer<string> _msGenresComparer = new(null);
        private static readonly MultiSetComparer<Image> _msImagesComparer = new(_imagesComparer);

        public bool Equals(TrackArtistInfo? x, TrackArtistInfo? y)
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
                && x.Popularity == y.Popularity
                && _msGenresComparer.Equals(x.Genres, y.Genres)
                && _msImagesComparer.Equals(x.Images, y.Images)
                && _followersComparer.Equals(x.Followers, y.Followers);
        }

        public int GetHashCode([DisallowNull] TrackArtistInfo obj)
        {
            var hashGenres = new HashCode();
            foreach (var item in obj.Genres)
            {
                hashGenres.Add(item);
            }

            var hashImages = new HashCode();
            foreach (var item in obj.Images)
            {
                hashImages.Add(_imagesComparer.GetHashCode(item));
            }

            var hashCode = new HashCode();
            hashCode.Add(obj.Id);
            hashCode.Add(obj.Name);
            hashCode.Add(obj.Popularity);
            hashCode.Add(hashGenres.ToHashCode());
            hashCode.Add(hashImages.ToHashCode());
            hashCode.Add(_followersComparer.GetHashCode(obj.Followers));

            return hashCode.ToHashCode();
        }
    }
}
