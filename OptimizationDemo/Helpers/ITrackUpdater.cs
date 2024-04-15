using OptimizationDemo.Models;

namespace OptimizationDemo.Helpers
{
    public interface ITrackUpdater
    {
        void Update(Track oldTrack, Track newTrack);
    }
}
