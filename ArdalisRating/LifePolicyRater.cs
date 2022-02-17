using System;

namespace ArdalisRating
{
    public class LifePolicyRater : Rater
    {
        public LifePolicyRater(IRatingContext context)
            : base(context)
        {
        }

        public override void Rate(Policy policy)
        {
            _context.Log("Rating LIFE policy...");
            _context.Log("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _context.Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _context.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                _context.Log("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {                
                _context.UpdateRating(baseRate * 2);
                return;
            }
            _context.UpdateRating(baseRate);
        }
    }
}
