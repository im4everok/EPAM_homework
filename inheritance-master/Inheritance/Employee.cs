using System;

namespace InheritanceTask
{
    public class Employee
    {
        protected string name;
        private decimal salary;
        private decimal bonus;
        public string Name { get => name;}
        public decimal Salary {
            get => salary;
            set => salary = value; 
        }
        public Employee(string name, decimal salary)
        {
            this.name = name;
            Salary = salary;
        }
        public virtual void SetBonus(decimal bonus)
        {
            this.bonus = bonus;
        }
        public decimal ToPay() => Salary + bonus;
    }
}

