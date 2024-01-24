using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using System.Linq;

using SQLite;
using System;
using System.Collections.Generic;

namespace Salguero_Progreso3.Model
{
    public class DatabaseService : IDisposable
    {
        readonly SQLiteConnection database;

        public DatabaseService(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<ResultModel>();
        }

        List<ResultModel> GetResults()
        {
            return database.Table<ResultModel>().ToList();
        }

        void AddResult(ResultModel result)
        {
            database.Insert(result);
        }

        public void Dispose()
        {
            database.Close();
        }
    }
}


