using OptimizationDemo.Helpers;
using OptimizationDemo.Models;

namespace OptimizationDemo.Providers
{
    public class OriginalProvider(IDbContext context, ITrackUpdater trackUpdater) : ITrackProvider
    {
        private readonly IDbContext _context = context;
        private readonly ITrackUpdater _trackUpdater = trackUpdater;

        public void UpdateOrCreateTracks(IEnumerable<Track> tracks)
        {
            if (!tracks.Any()) { return; }

            foreach (var track in tracks)
            {
                UpdateOrCreateTrack(track);
            }
        }

        private void UpdateOrCreateTrack(Track track)
        {
            var oldTrack = _context.GetById(track.Id);
            if (oldTrack != null)
            {
                _trackUpdater.Update(oldTrack, track);
            }

            _context.Save(track);
        }
    }
}
