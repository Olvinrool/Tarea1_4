using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Tarea1_4.Models;

namespace Tarea1_4.Services
{
    public class DatabaseService
    {
        readonly SQLiteAsyncConnection database;

        public DatabaseService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Foto>().Wait();
        }

        public Task<List<Foto>> GetFotosAsync()
        {
            return database.Table<Foto>().ToListAsync();
        }

        public Task<int> SaveFotoAsync(Foto foto)
        {
            return database.InsertAsync(foto);
        }
    }





}
