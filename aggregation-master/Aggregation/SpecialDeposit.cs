namespace Aggregation
{
    public class SpecialDeposit : Deposit
    {
        public SpecialDeposit(decimal Amount, int Period) : base(Amount, Period)
        {
        }

        public override decimal Income()
        {
            decimal result = 0m;
            for (int i = base.Period; i > 0; i--)
            {
                result += decimal.Round((base.Amount+result) * i / 100, 2, System.MidpointRounding.AwayFromZero);
            }
            return result;
        }
    }
}