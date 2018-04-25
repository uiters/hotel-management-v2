using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    class ServiceTypeDAO
    {
        private static ServiceTypeDAO instance;
        public bool InsertServiceType(string name)
        {
            string query = "USP_InsertServiceType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        }
        public bool UpdateServiceType(int id, string name)
        {
            string query = "USP_UpdateServiceType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        public bool UpdateServiceType(ServiceType serviceType)
        {
            return UpdateServiceType(serviceType.Id, serviceType.Name);
        }
        

        public DataTable LoadListService()
        {
            string query = "select * from ServiceType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static ServiceTypeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceTypeDAO();
                return instance;
            }
        }
        private ServiceTypeDAO() { }
    }

}
