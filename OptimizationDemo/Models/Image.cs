namespace OptimizationDemo.Models
{
    public class Image
    {
        /// <summary>
        /// The source URL of the image
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The image height in pixels
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// The image width in pixels
        /// </summary>
        public int? Width { get; set; }
    }
}
