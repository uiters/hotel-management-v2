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
        private static ServiceTypeDAO instance = new ServiceTypeDAO();
        public bool InsertServiceType(string name)
        {
            string query = "USP_InsertServiceType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        }
        public bool UpdateServiceType(ServiceType serviceType)
        {
            string query = "USP_UpdateServiceType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { serviceType.Id, serviceType.Name }) > 0;
        }
        

        public DataTable LoadListService()
        {
            string query = "select * from ServiceType";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        public static ServiceTypeDAO Instance { get => instance;}
    }

}
