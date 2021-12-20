﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceTask
{
    public class Manager : Employee
    {
        private readonly int quantity;

        public Manager(string name, decimal salary, int clientAmount) : base(name, salary)
        {
            quantity = clientAmount;
        }

        public override void SetBonus(decimal bonus)
        {
            if(quantity >= 150)
            {
                base.SetBonus(bonus + 1000);
                return;
            }
            if(quantity >= 100)
            {
                base.SetBonus(bonus + 500);
            }
            else
            {
                base.SetBonus(bonus);
            }
        }
    }
}

