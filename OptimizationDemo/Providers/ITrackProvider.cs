using OptimizationDemo.Models;

namespace OptimizationDemo.Providers
{
    internal interface ITrackProvider
    {
        void UpdateOrCreateTracks(IEnumerable<Track> tracks);
    }
}
