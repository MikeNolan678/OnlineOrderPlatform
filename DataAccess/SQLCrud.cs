using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SQLCrud
    {
        private SQLDataAccess db = new SQLDataAccess();
        private readonly string _connectionString;

        public SQLCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<InventoryModel> GetAllInventory()
        {
            string sql = "select * from dbo.OnHandInventory";

            return db.LoadData<InventoryModel, dynamic>(sql, new { }, _connectionString);
        }

        public List<InventoryModel> GetInventoryByItem(string upcCode)
        {
            string sql = "select * from dbo.OnHandInventory OH where OH.UPC = @upcCode";

            return db.LoadData<InventoryModel, dynamic>(sql, new { upcCode = upcCode }, _connectionString);
        }

    }
}
