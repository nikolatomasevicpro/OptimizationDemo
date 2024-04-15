using OptimizationDemo.Models;
using System.Diagnostics.CodeAnalysis;

namespace OptimizationDemo.Comparers
{
    public class TrackComparer : IEqualityComparer<Track>
    {
        private static readonly AlbumComparer _albumComparer = new();
        private static readonly TrackArtistInfoComparer _trackArtistInfoComparer = new();
        private static readonly ExternalIdsComparer _externalIdsComparer = new();

        private static readonly MultiSetComparer<TrackArtistInfo> _msTrackArtistInfoComparer = new(_trackArtistInfoComparer);

        public bool Equals(Track? x, Track? y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null))
            {
                return false;
            }

            if (ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Id == y.Id
                   && x.Name == y.Name
                   && x.Description == y.Description
                   && _albumComparer.Equals(x.Album, y.Album)
                   && x.DiscNumber == y.DiscNumber
                   && x.TrackNumber == y.TrackNumber
                   && _msTrackArtistInfoComparer.Equals(x.Artists, y.Artists)
                   && x.Explicit == y.Explicit
                   && x.Duration == y.Duration
                   && x.ReleaseDate == y.ReleaseDate
                   && x.Popularity == y.Popularity
                   && _externalIdsComparer.Equals(x.ExternalIds, y.ExternalIds);
        }

        public int GetHashCode([DisallowNull] Track obj)
        {
            var hashArtists = new HashCode();
            foreach (var artist in obj.Artists)
            {
                hashArtists.Add(_trackArtistInfoComparer.GetHashCode(artist));
            }

            var hashCode = new HashCode();
            hashCode.Add(obj.Id);
            hashCode.Add(obj.Name);
            hashCode.Add(obj.Description);
            hashCode.Add(_albumComparer.GetHashCode(obj.Album));
            hashCode.Add(obj.DiscNumber);
            hashCode.Add(obj.TrackNumber);
            hashCode.Add(hashArtists.ToHashCode());
            hashCode.Add(obj.Explicit);
            hashCode.Add(obj.Duration);
            hashCode.Add(obj.ReleaseDate);
            hashCode.Add(obj.Popularity);
            hashCode.Add(_externalIdsComparer.GetHashCode(obj.ExternalIds));
            return hashArtists.ToHashCode();
        }
    }
}
