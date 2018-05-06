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
       public bool InsertServiceType(ServiceType serviceTypeNow)
        {
            return InsertServiceType(serviceTypeNow.Name);
        }
        public bool UpdateServiceType(int id, string name)
        {
            string query = "USP_UpdateServiceType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { id, name }) > 0;
        }
        public bool UpdateServiceType(ServiceType serviceTypeNow, ServiceType serviceTypePre)
        {
            return UpdateServiceType(serviceTypeNow.Id, serviceTypeNow.Name);
        }
        public bool DeleteServiceType(int id)
        {
            string query = "USP_DeleteServiceType @id";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { query }) > 0;
        }
        internal DataTable LoadFullServiceType()
        {
            string query = "USP_LoadFullServiceType";
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
