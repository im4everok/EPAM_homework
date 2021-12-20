using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace InheritanceTask
{
    public class Company
    {
    private readonly Employee[] employees;
    public Company(Employee[] employees)
        {
            this.employees = employees;
        }

    public void GiveEverybodyBonus(decimal companyBonus)
        {
            if(employees != null)
            {
                foreach(var emp in employees)
                {
                    emp.SetBonus(companyBonus);
                }
            }
        }

    public decimal TotalToPay()
        {
            decimal total = 0m;
            if (employees != null)
            { 
                foreach (var emp in employees)
                {
                    total += emp.ToPay();
                }
            }
            return total;
        }
    public string NameMaxSalary()
        {
            int maxIndex = 0;
            decimal maxVal = 0m;
            if (employees != null)
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    if(employees[i].ToPay() > maxVal)
                    {
                        maxVal = employees[i].ToPay();
                        maxIndex = i;
                    }
                }
            }
            if(employees == null)
            {
                return String.Empty;
            }
            return employees[maxIndex].Name;
        }
    }
}
