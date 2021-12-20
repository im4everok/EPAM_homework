using System.Linq;

namespace Aggregation
{
    public class Client
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            for(int i = 0; i < deposits.Length; i++)
            {
                if(deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }
            return false;
        }

        public decimal TotalIncome()
        {
            decimal total = 0m;
            foreach(var deposit in deposits)
            {
                if(deposit != null)
                {
                    total += deposit.Income();
                }
            }
            return total;
        }

        public decimal MaxIncome()
        {
            decimal max = 0m;
            for(int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] != null && deposits[i].Income() > max)
                {
                    max = deposits[i].Income();
                }
            }
            return max;
        }

        public decimal GetIncomeByNumber(int number)
        {
            if(deposits[number-1] != null)
            {
                return deposits[number - 1].Income();
            }
            return 0;
        }
    }
}