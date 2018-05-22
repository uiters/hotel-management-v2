using HotelManager.DTO;
using System.Collections.Generic;
using System.Data;

namespace HotelManager.DAO
{
    public class CustomerTypeDAO
    {
        #region Constructor & Properties
        private static CustomerTypeDAO instance;
        private CustomerTypeDAO() { }
        internal static CustomerTypeDAO Instance
        {
            get { if (instance == null) instance = new CustomerTypeDAO(); return instance; }
            private set => instance = value;
        }

        #endregion

        #region Method
        internal bool UpdateCustomerType(CustomerType customerTypeNow)
        {
            string query = "USP_UpdateCustomerType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customerTypeNow.Id, customerTypeNow.Name }) > 0;
        }

        internal List<CustomerType> LoadListCustomerType()
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
        internal object GetIDCustomerType(int id)
        {
            object obj = DataProvider.Instance.ExecuteScalar("exec USP_GetIDCustomerType @idCustomer", new object[] { id });
            return obj;
        }
        internal object GetCustomerTypeName(int id)
        {
            object obj = DataProvider.Instance.ExecuteScalar("exec USP_GetCustomerTypeName @idCustomerType", new object[] { id });
            return obj;
        }
        internal DataTable LoadFullCustomerType()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullCustomerType");
        }
        #endregion

    }
}
