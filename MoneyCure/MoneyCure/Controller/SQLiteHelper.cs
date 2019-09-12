using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using MoneyCure.Model;
using MoneyCure.Data;

namespace MoneyCure.Controller
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Transaction>().Wait();
        }

        //Create
        public Task<int> CreateTransaction(Transaction transaction) {
                return db.InsertAsync(transaction);
        }

        //Read
        public Task<Transaction> GetTransaction(int transId) {
            return db.Table<Transaction>().Where(i => i.Id == transId).FirstOrDefaultAsync();
        }

        public Task<Transaction> GetExpenses()
        {
            return db.Table<Transaction>().Where(i => i.CatId>=0).FirstOrDefaultAsync();
        }

        public Task<Transaction> GetSavings()
        {
            return db.Table<Transaction>().Where(i => i.CatId == (int) Data.Utils.Categories.Savings).FirstOrDefaultAsync();
        }

        public Task<Transaction> GetIncomes() {
            return db.Table<Transaction>().Where(i => i.CatId == (int) Data.Utils.Categories.Income).FirstOrDefaultAsync();
        }

        //Delete
        public Task<int> DeleteTransaction(int transId) {
            return db.DeleteAsync<Transaction>(GetTransaction(transId));

        }

        public Task<int> DeleteAllTransactions() {
            return db.DeleteAllAsync<Transaction>();

        }


    }
}