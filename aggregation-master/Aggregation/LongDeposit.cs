namespace Aggregation
{
    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal Amount, int Period) : base(Amount, Period)
        {
        }

        public override decimal Income()
        {
            decimal result = 0m;
            if(Period <= 6)
            {
                return 0;
            }
            for (int i = Period; i > 6; i--)
            {
                result += decimal.Round((Amount+result)*15/100, 2, System.MidpointRounding.AwayFromZero);
            }
            return result;
        }
    }
}