namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, IRatingContext context)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(context);

                case PolicyType.Flood:
                    return new FloodPolicyRater(context);

                case PolicyType.Land:
                    return new LandPolicyRater(context);

                case PolicyType.Life:
                    return new LifePolicyRater(context);

                default:
                    // currently this can't be reached 
                    return new UnknownPolicyRater(context);
            }
        }
    }
}
