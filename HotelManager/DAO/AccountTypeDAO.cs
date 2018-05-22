using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class AccountTypeDAO
    {
        private static AccountTypeDAO instance;
        public AccountType GetStaffTypeByUserName(string username)
        {
            string query = "USP_GetNameStaffTypeByUserName @username";
            AccountType staffType = new AccountType(DataProvider.Instance.ExecuteQuery(query,new object[] { username }).Rows[0]);
            return staffType;
        }
        public static AccountTypeDAO Instance {
            get { if (instance == null) instance = new AccountTypeDAO(); return instance; }
            private set => instance = value; }
    }
}
