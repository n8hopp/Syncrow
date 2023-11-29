using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Syncrow.Models;

namespace Syncrow
{
    public class TodoDB
    {
        string _dbPath;

        private SQLiteConnection conn;

        private void Init()
        {
            if(conn != null)
            {
                return;
            }

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<CrowTask>();
            conn.CreateTable<QuickTask>();

        }
    }
}
