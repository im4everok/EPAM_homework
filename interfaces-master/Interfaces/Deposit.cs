using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; private set; }

        public int Period { get; private set; }

        public Deposit(decimal Amount, int Period)
        {
            this.Amount = Amount;
            this.Period = Period;
        }

        public abstract decimal Income();
        public int CompareTo([AllowNull] Deposit other)
        {
            if (other != null)
            {
                if (Amount + Income() < other.Amount + other.Income())
                {
                    return -1;
                }
                if (Amount + Income() == other.Amount + other.Income())
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
