using OptimizationDemo.Models;

namespace OptimizationDemo.Helpers
{
    public class DbContextMock : IDbContext
    {
        public IEnumerable<Track> Tracks { get; set; }
        public int Delay { get; set; } = 144;

        /// <summary>
        /// Simulate DB lookup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Track? GetById(Guid id)
        {
            return Tracks.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Used to simulate the average save time
        /// </summary>
        /// <param name="_">The track to be saved</param>
        public void Save(Track _)
        {
            Thread.Sleep(Delay);
        }
    }
}
