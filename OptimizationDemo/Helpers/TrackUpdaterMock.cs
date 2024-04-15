using OptimizationDemo.Models;

namespace OptimizationDemo.Helpers
{
    public class TrackUpdaterMock : ITrackUpdater
    {
        public int Delay { get; set; } = 36;

        public void Update(Track oldTrack, Track newTrack)
        {
            Thread.Sleep(Delay);
        }
    }
}
