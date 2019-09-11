using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MoneyCure.Model
{


    public class Transaction
    {
       [PrimaryKey, AutoIncrement, NotNull, Unique]
        public int Id { get; set; }

        [NotNull]
        public double Amount { get; set; }

        [NotNull]
        public DateTime DT { get; set; }

        public string Name { get; set; }

        [NotNull]
        public int CatId { get; set; }

        public Transaction(double amount, DateTime dateTime, string name, int catId) {
            Amount = amount;
            DT = dateTime;
            Name = name;
            CatId = catId;
            

        }

        public Transaction() { }
    }


}
