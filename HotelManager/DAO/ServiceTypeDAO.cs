using HotelManager.DTO;
using System.Data;

namespace HotelManager.DAO
{
    class ServiceTypeDAO
    {
        #region Properties & Constructor
        private static ServiceTypeDAO instance;
        internal static ServiceTypeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceTypeDAO();
                return instance;
            }
        }
        private ServiceTypeDAO() { }
        #endregion

        #region  Method
        internal bool InsertServiceType(string name)
        {
            string query = "USP_InsertServiceType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        }
        internal bool InsertServiceType(ServiceType serviceTypeNow)
        {
            return InsertServiceType(serviceTypeNow.Name);
        }
        internal bool UpdateServiceType(int id, string name)
        {
            string query = "USP_UpdateServiceType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        internal bool UpdateServiceType(ServiceType serviceTypeNow)
        {
            return UpdateServiceType(serviceTypeNow.Id, serviceTypeNow.Name);
        }
        internal DataTable LoadFullServiceType()
        {
            string query = "USP_LoadFullServiceType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        internal DataTable Search(string name, int id)
        {
            string query = "USP_SearchServiceType @string , @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, id });
        }
        #endregion
    }

}
