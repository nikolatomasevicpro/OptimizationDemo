using OptimizationDemo.Models;

namespace OptimizationDemo.Helpers
{
    public interface IDbContext
    {
        IEnumerable<Track> Tracks { get; set; }
        Track? GetById(Guid id);
        void Save(Track track);
    }
}
