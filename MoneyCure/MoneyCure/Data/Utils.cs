using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyCure.Data
{
    class Utils
    {
        public enum Categories
        {
            Income = -1,
            Savings = 0,
            Other = 1,
            Personal = 2,
            Food = 3,
            Social = 4,
            Education = 5,
            Transport = 6,
            Household = 7,
            Apparel = 8,
            Health = 9
        }

        public int PINCode { get; set; }
        public int SavingsGoal { get; set; }

    }
}
