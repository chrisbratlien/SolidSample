namespace ArdalisRating {
    public class RatingEngineRate {
        private RatingEngine _engine;
        private ILogger _logger;
        public RatingEngineRate() {
            _logger = new FakeLogger();
            _engine = new RatingEngine(_logger);
        }
    }
}