using HotelManager.DTO;
using System.Data;

namespace HotelManager.DAO
{
    class ServiceDAO
    {
        private static ServiceDAO instance;

        internal bool InsertService(string name, int idtype, int price)
        {
            string query = "USP_InsertService @name , @idServiceType , @price";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[]
            {
                name, idtype, price
            }) > 0;
        }
        internal bool InsertService(Service serviceNow)
        {
            return InsertService(serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
        internal bool UpdateService(int id, string name, int idServiceType, int price)
        {
            string query = "USP_UpdateService @id , @name , @idServiceType , @price";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name, idServiceType, price }) > 0;
        }
        internal bool UpdateService(Service serviceNow, Service servicePre)
        {
            return UpdateService(serviceNow.Id, serviceNow.Name, serviceNow.IdServiceType, serviceNow.Price);
        }
        internal bool DeleteService(int id)
        {
            string query = "USP_DeleteService @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id }) > 0;
        }
        internal DataTable LoadFullService()
        {
            string query = "USP_LoadFullService";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        internal DataTable Search(string name, int id)
        {
            string query = "USP_SearchService @string , @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { name, id });
        }

        internal static ServiceDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceDAO();
                return instance;
            }
        }
        private ServiceDAO() { }
    }
}
