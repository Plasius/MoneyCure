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

        public Task<List<Transaction>> GetExpenses()
        {
            return db.Table<Transaction>().Where(i => i.CatId>=0).ToListAsync();
        }

        public Task<List<Transaction>> GetSavings()
        {
            return db.Table<Transaction>().Where(i => i.CatId == (int) Data.Utils.Categories.Savings).ToListAsync();
        }

        public Task<List<Transaction>> GetIncomes() {
            return db.Table<Transaction>().Where(i => i.CatId == (int)Data.Utils.Categories.Income).ToListAsync();
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