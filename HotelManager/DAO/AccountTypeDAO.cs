using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    class AccountTypeDAO
    {
        private static AccountTypeDAO instance;
        public bool InsertStaffType(string name)
        {
            string query = "exec USP_InsertStaffType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        }
        public bool UpdateStaffType(AccountType staffType)
        {
            string query = "EXEC USP_UpdateStaffType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { staffType.Id, staffType.Name }) > 0;
        }
        public bool DeleteStaffType(int id)
        {
            string query = "Exec USP_DeleteStaffType @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id }) > 0;
        }
        public DataTable LoadListStaffType()
        {
            string query = "select * from stafftype";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static AccountTypeDAO Instance { get { if (instance == null) instance = new AccountTypeDAO(); return instance; }}
    }
}
