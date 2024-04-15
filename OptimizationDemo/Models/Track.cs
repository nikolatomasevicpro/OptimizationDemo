namespace OptimizationDemo.Models
{
    public class Track
    {
        /// <summary>
        /// The internal ID of the track
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the track
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the track, when available
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The album the track is associated with
        /// </summary>
        public Album Album { get; set; }

        /// <summary>
        /// The disc number (usually 1 unless the album consists of multiple discs)
        /// </summary>
        public int DiscNumber { get; set; } = 1;

        /// <summary>
        /// The track number in the album. If an album has several discs, the number is the track number of the specified disc.
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// The artists who performed the track.
        /// </summary>
        public List<TrackArtistInfo> Artists { get; set; } = [];

        /// <summary>
        /// Is track explicit? True for yes, false for no or unknown
        /// </summary>
        public bool Explicit { get; set; } = false;

        /// <summary>
        /// The duration of the track in milliseconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The release date of the track
        /// </summary>
        public DateOnly ReleaseDate { get; set; } = DateOnly.MinValue;

        /// <summary>
        /// The popularity of the track. The value is between 0 and 100 included, 100 being the most popular
        /// </summary>
        public int Popularity { get; set; } = 0;

        /// <summary>
        /// Known external IDs of the track
        /// </summary>
        public ExternalIds ExternalIds { get; set; }
    }
}
