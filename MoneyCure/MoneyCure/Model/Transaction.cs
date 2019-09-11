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
        public DateTime Date { get; set; }

        public string Name { get; set; }

        [NotNull]
        public int CatId { get; set; }

        [NotNull]
        public bool IsSavings { get; set; }
    }


}
