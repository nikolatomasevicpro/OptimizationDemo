using BenchmarkDotNet.Attributes;
using OptimizationDemo.Helpers;
using OptimizationDemo.Models;
using OptimizationDemo.Providers;

namespace OptimizationDemo
{
    [MemoryDiagnoser]
    [Orderer]
    [RankColumn]
    public class Benches
    {
        private int _existing = 500;
        private int _batch = 100;
        private int _new = 100;

        private IEnumerable<Track> _initialList;
        private IEnumerable<Track> _reversedList;
        private IEnumerable<Track> _batchList;
        private IEnumerable<Track> _realisticList;
        private IEnumerable<Track> _newList;

        private IDbContext _dbContext;
        private ITrackUpdater _trackUpdater;

        private ITrackProvider _originalProvider;
        private ITrackProvider _improvedProvider;

        [GlobalSetup]
        public void Setup()
        {
            _initialList = DataGeneration.GenerateDummyList<Track>(_existing);
            _reversedList = _initialList.Reverse();
            _batchList = _initialList.Take(_batch);
            _newList = DataGeneration.GenerateDummyList<Track>(_new);
            //10% of the full list seems to be the average of new entries
            _realisticList = _initialList.Take(90).Concat(_newList.Take(10)).ToList();

            _dbContext = new DbContextMock();
            _trackUpdater = new TrackUpdaterMock();

            _originalProvider = new OriginalProvider(_dbContext, _trackUpdater);
            _improvedProvider = new ImprovedProvider(_dbContext, _trackUpdater);
        }

        [Benchmark]
        public void CompareOriginalExisting()
        {
            Compare(_originalProvider, _initialList, _batchList);
        }

        [Benchmark]
        public void CompareOriginalRealistic()
        {
            Compare(_originalProvider, _initialList, _realisticList);
        }

        [Benchmark]
        public void CompareOriginalNew()
        {
            Compare(_originalProvider, _initialList, _newList);
        }

        [Benchmark]
        public void CompareOriginalReversedExisting()
        {
            Compare(_originalProvider, _reversedList, _batchList);
        }

        [Benchmark]
        public void CompareOriginalReversedRealistic()
        {
            Compare(_originalProvider, _reversedList, _realisticList);
        }

        [Benchmark]
        public void CompareOriginalReversedNew()
        {
            Compare(_originalProvider, _reversedList, _newList);
        }

        [Benchmark]
        public void CompareImprovedExisting()
        {
            Compare(_improvedProvider, _initialList, _batchList);
        }

        [Benchmark]
        public void CompareImprovedRealistic()
        {
            Compare(_improvedProvider, _initialList, _realisticList);
        }

        [Benchmark]
        public void CompareImprovedNew()
        {
            Compare(_improvedProvider, _initialList, _newList);
        }

        [Benchmark]
        public void CompareImprovedReversedExisting()
        {
            Compare(_improvedProvider, _reversedList, _batchList);
        }

        [Benchmark]
        public void CompareImprovedReversedRealistic()
        {
            Compare(_improvedProvider, _reversedList, _realisticList);
        }

        [Benchmark]
        public void CompareImprovedReversedNew()
        {
            Compare(_improvedProvider, _reversedList, _newList);
        }

        private void Compare(ITrackProvider provider, IEnumerable<Track> existingTracks, IEnumerable<Track> queryTracks)
        {
            _dbContext.Tracks = existingTracks;
            provider.UpdateOrCreateTracks(queryTracks);
        }
    }
}
