namespace OptimizationDemo.Models
{
    public class Album
    {
        public enum AlbumType
        {
            Unknown,
            Album,
            Compilation,
            Single
        }

        /// <summary>
        /// The internal ID of the album
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the album
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the album, when available
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The album type
        /// </summary>
        public AlbumType Type { get; set; }

        /// <summary>
        /// The total bumber of tracks in the album
        /// </summary>
        public int TotalTracks { get; set; }

        /// <summary>
        /// The cover art for the album in various sizes
        /// </summary>
        public List<Image> Images { get; set; } = [];

        /// <summary>
        /// The release date of the album
        /// </summary>
        public DateOnly ReleaseDate { get; set; }

        /// <summary>
        /// The artists that contributed for the album
        /// </summary>
        public List<AlbumArtistInfo> Artists { get; set; } = [];
    }
}
