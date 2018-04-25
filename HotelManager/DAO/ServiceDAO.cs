using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    class ServiceDAO
    {
        private static ServiceDAO instance = new ServiceDAO();
        public bool InsertService(string name, int idtype, int price)
        {
            string query = "USP_InsertService @name , @idServiceType , @price";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[]
            {
                name, idtype, price
            }) > 0;
        }
        public bool UpdateService(Service service)
        {
            string query = "USP_UpdateService @id , @name , @idServiceType , @price";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { service.Id, service.Name, service.IdServiceType, service.Price }) > 0;
        }
        public static ServiceDAO Instance { get => instance;}
    }
}
