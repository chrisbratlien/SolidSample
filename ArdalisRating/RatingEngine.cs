namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        private readonly ILogger _logger;
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger)
        {
            Context.Engine = this;
            _logger = logger;
        }
        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy.");

            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater?.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
