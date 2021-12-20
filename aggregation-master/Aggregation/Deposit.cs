namespace Aggregation
{
    public abstract class Deposit
    {
        public decimal Amount { get; private set; }

        public int Period { get; private set; }

        public Deposit(decimal Amount, int Period)
        {
            this.Amount = Amount;
            this.Period = Period;
        }

        public abstract decimal Income();
    }
}