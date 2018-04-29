using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class CustomerTypeDAO
    {
        private static CustomerTypeDAO instance;
        private CustomerTypeDAO() { }
        public bool InsertCustomerType(string name)
        {
            string query = "USP_InsertCustomerType @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name }) > 0;
        }
        public bool UpdateCustomerType(CustomerType customerTypeNow)
        {
            string query = "USP_UpdateCustomerType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customerTypeNow.Id, customerTypeNow.Name }) > 0;
        }

        public static CustomerTypeDAO Instance { get { if (instance == null) instance = new CustomerTypeDAO();return instance; }
            private set => instance = value; }
        public List<CustomerType> LoadListCustomerType()
        {
            string query = "select * from CustomerType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<CustomerType> listCustomerType = new List<CustomerType>();
            foreach (DataRow item in data.Rows)
            {
                CustomerType customerType = new CustomerType(item);
                listCustomerType.Add(customerType);
            }
            return listCustomerType;
        }
        public object GetIDCustomerType(int id)
        {
            object obj = DataProvider.Instance.ExecuteScalar("exec USP_GetIDCustomerType @idCustomer", new object[] { id });
            return obj;
        }
        public object GetCustomerTypeName(int id)
        {
            object obj = DataProvider.Instance.ExecuteScalar("exec USP_GetCustomerTypeName @idCustomerType", new object[] { id });
            return obj;
        }
        public DataTable LoadFullCustomerType()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullCustomerType");
        }
    }
}
