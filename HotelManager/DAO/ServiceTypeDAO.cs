using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ServiceTypeDAO
    {
        private static ServiceTypeDAO instance;

        public static ServiceTypeDAO Instance {
            get { if (instance == null) instance = new ServiceTypeDAO();return instance; }
            private set => instance = value; }

        public List<ServiceType> GetServiceTypes()
        {
            string query = "select * from ServiceType";
            List<ServiceType> serviceTypes = new List<ServiceType>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ServiceType serviceType = new ServiceType(item);
                serviceTypes.Add(serviceType);
            }
            return serviceTypes;
        }
    }
}
