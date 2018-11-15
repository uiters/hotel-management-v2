using HotelManager.DTO;
using System.Data;

namespace HotelManager.DAO
{
    public class AccountTypeDAO
    {
        private static AccountTypeDAO instance;

        #region Method
        internal DataTable LoadFullStaffType()
        {
            string query = "USP_LoadFullStaffType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public AccountType GetStaffTypeByUserName(string username)
        {
            string query = "USP_GetNameStaffTypeByUserName @username";
            AccountType staffType = new AccountType(DataProvider.Instance.ExecuteQuery(query, new object[] { username }).Rows[0]);
            return staffType;
        }
        internal bool Delete(int idStaffType)
        {
            string query = "USP_DeleteStaffType @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idStaffType }) > 0;
        }
        internal bool Update(int idStaffType, string text)
        {
            string query = "USP_UpdateStaffType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idStaffType, text }) > 0;
        }

        internal bool Insert(string text)
        {
            string query = "USP_InsertStaffType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { text }) > 0;
        }
        #endregion

        public static AccountTypeDAO Instance {
            get { if (instance == null) instance = new AccountTypeDAO(); return instance; }
            private set => instance = value; }
    }
}
