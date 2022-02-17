using System;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        // public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        // public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        // public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
        public IRatingContext _context { get; set; } = new DefaultRatingContext();
        public RatingEngine() {
                _context.Engine = this;
        }
        public decimal Rating { get; set; }
        public void Rate()
        {
            _context.Log("Starting rate.");

            _context.Log("Loading policy.");

            string policyJson = _context.LoadPolicyFromFile();

            var policy = _context.GetPolicyFromJsonString(policyJson);

            var rater = _context.CreateRaterForPolicy(policy, _context);
            
            rater.Rate(policy);

            _context.Log("Rating completed.");
        }
    }
}
