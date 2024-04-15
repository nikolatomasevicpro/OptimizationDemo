using OptimizationDemo.Comparers;
using OptimizationDemo.Helpers;
using OptimizationDemo.Models;

namespace OptimizationDemo.Providers
{
    internal class ImprovedProvider(IDbContext context, ITrackUpdater trackUpdater) : ITrackProvider
    {
        private readonly IDbContext _context = context;
        private readonly ITrackUpdater _trackUpdater = trackUpdater;
        private readonly TrackComparer _trackComparer = new();

        public void UpdateOrCreateTracks(IEnumerable<Track> tracks)
        {
            if (!tracks.Any()) { return; }

            foreach (var track in tracks)
            {
                UpdateOrCreateTrack(track);
            }
        }

        public void UpdateOrCreateTrack(Track track)
        {
            var oldTrack = _context.GetById(track.Id);
            if (oldTrack != null && !_trackComparer.Equals(track, oldTrack))
            {
                _trackUpdater.Update(oldTrack, track);
                _context.Save(track);
            }

            if (oldTrack is null) 
            { 
                _context.Save(track);
            }
        }
    }
}
