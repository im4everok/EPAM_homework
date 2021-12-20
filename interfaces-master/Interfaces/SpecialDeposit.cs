using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal Amount, int Period) : base(Amount, Period)
        {
        }

        public bool CanToProlong()
        {
            return Amount > 1000;
        }

        public override decimal Income()
        {
            decimal result = 0m;
            for (int i = base.Period; i > 0; i--)
            {
                result += decimal.Round((base.Amount + result) * i / 100, 2, System.MidpointRounding.AwayFromZero);
            }
            return result;
        }
    }
}
