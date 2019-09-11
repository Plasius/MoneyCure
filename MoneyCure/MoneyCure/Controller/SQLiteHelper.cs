using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using MoneyCure.Model;

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

        //CRUD
        public Task<int> CreateTransaction(Transaction transaction) {
                return db.InsertAsync(transaction);
        }

        public Task<Transaction> GetTransaction(int transId) {
            return db.Table<Transaction>().Where(i => i.Id == transId).FirstOrDefaultAsync();
        }

        public Task<Transaction> GetCheckingTransactions()
        {
            return db.Table<Transaction>().FirstOrDefaultAsync();
        }

     /*   public Task<Transaction> GetSavingsTransactions(int transId)
        {
            return db.Table<Transaction>().Where(i => i.IsSavings == true).FirstOrDefaultAsync();
        }*/

        public Task<int> DeleteTransaction(int transId) {
            return db.DeleteAsync<Transaction>(GetTransaction(transId));

        }

        public Task<int> DeleteAllTransactions() {
            return db.DeleteAllAsync<Transaction>();

        }



    }
}