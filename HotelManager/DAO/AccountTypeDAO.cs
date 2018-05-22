using System.Data;

namespace HotelManager.DAO
{
    class AccountTypeDAO
    {
        #region Constructor & properties
        private static AccountTypeDAO instance;
        public static AccountTypeDAO Instance { get { if (instance == null) instance = new AccountTypeDAO(); return instance; } }
        private AccountTypeDAO() { }
        #endregion

        #region Method
        internal DataTable LoadFullStaffType()
        {
            string query = "USP_LoadFullStaffType";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        #endregion
    }
}
