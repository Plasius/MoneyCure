using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoneyCure.Data
{
    class Utils
    {
        static Utils instance;

        public static Utils GetInstance() {
            if (instance == null)
                instance = new Utils();

            return instance;
        }

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


        /*
         STORED DATA:
            PINCode - int - 4-digit pin code of the user
            StayLoggedIn - bool - keeps track of the user preference whether to log in automatically

            CheckingBalance - double - current user balance

            SavingsGoal - int - a user-defined target to reach through saving up money
            SavingsBalance - double - amount of money saved up by the user
        */

        public int GetInt(string key, int def) {
            if(Application.Current.Properties.ContainsKey(key)){
                return (int)Application.Current.Properties[key];
            }


            return def;
        }

        public bool GetBool(string key, bool def) {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return (bool)Application.Current.Properties[key];
            }

            return def;
        }

        public void SetInt(string key, int value) {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties[key] = value;
            else
                Application.Current.Properties.Add(key, value);
        }

        public void SetBool(string key, bool value) {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties[key] = value;
            else
                Application.Current.Properties.Add(key, value);
        }


    }
}
