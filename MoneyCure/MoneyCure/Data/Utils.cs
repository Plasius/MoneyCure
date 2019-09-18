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
            PINCode - string - 4-char pin code of the user

            CheckingBalance - double - current user balance

            SavingsGoal - double - a user-defined target to reach through saving up money
            SavingsBalance - double - amount of money saved up by the user

        */

        public int GetInt(string key, int def) {
            if(Application.Current.Properties.ContainsKey(key)){
                return (int)Application.Current.Properties[key];
            }


            return def;
        }

        public void SetInt(string key, int value)
        {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties[key] = value;
            else
                Application.Current.Properties.Add(key, value);
        }


        public bool GetBool(string key, bool def) {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return (bool)Application.Current.Properties[key];
            }

            return def;
        }

        public void SetBool(string key, bool value)
        {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties[key] = value;
            else
                Application.Current.Properties.Add(key, value);
        }




        public string GetString(string key, string def)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return (string)Application.Current.Properties[key];
            }

            return def;
        }
        public void SetString(string key, string value)
        {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties[key] = value;
            else
                Application.Current.Properties.Add(key, value);
        }




        public void SetDouble(string key, double value)
        {
            if (Application.Current.Properties.ContainsKey(key))
                Application.Current.Properties[key] = value;
            else
                Application.Current.Properties.Add(key, value);
        }

        public double GetDouble(string key, double def)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return (double)Application.Current.Properties[key];
            }


            return def;
        }

        public static bool NullorEmpty(string st)
        {
            if (st == null) { return true; }
            if (st == "") { return true; }
            return false;
        }


    }
}
