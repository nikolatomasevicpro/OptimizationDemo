namespace OptimizationDemo.Models
{
    public class TrackArtistInfo
    {
        /// <summary>
        /// The internal ID of the artist
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the artist
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The popularity of the artist. The value is between 0 and 100 included, 100 being the most popular
        /// </summary>
        public int Popularity { get; set; } = 0;

        /// <summary>
        /// A list of genres the artist is associated with.
        /// </summary>
        public List<string> Genres { get; set; } = [];

        /// <summary>
        /// Images of the artist in various sizes.
        /// </summary>
        public List<Image> Images { get; set; } = [];

        /// <summary>
        /// A summary information about artist's followers.
        /// </summary>
        public Followers Followers { get; set; }
    }
}
