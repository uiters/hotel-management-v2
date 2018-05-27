using HotelManager.DTO;
using System.Collections.Generic;
using System.Data;

namespace HotelManager.DAO
{
    public class CustomerTypeDAO
    {
        private static CustomerTypeDAO instance;

        #region Method
        private CustomerTypeDAO() { }
        public List<CustomerType> LoadListCustomerType()
        {
            string query = "select * from CustomerType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<CustomerType> listCustomerType = new List<CustomerType>();
            foreach (DataRow item in data.Rows)
            {
                CustomerType CustomerType = new CustomerType(item);
                listCustomerType.Add(CustomerType);
            }
            return listCustomerType;
        }
        public string GetNameByIdCard(string idCard)
        {
            string query = "USP_GetCustomerTypeNameByIdCard @idCard";
            DataRow dataRow = DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows[0];
            return dataRow["Name"].ToString();
        }
        internal bool UpdateCustomerType(CustomerType customerTypeNow)
        {
            string query = "USP_UpdateCustomerType @id , @name";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customerTypeNow.Id, customerTypeNow.Name }) > 0;
        }

        internal DataTable LoadFullCustomerType()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullCustomerType");
        }
        #endregion
        public static CustomerTypeDAO Instance { get { if (instance == null) instance = new CustomerTypeDAO();return instance; }
            private set => instance = value; }
        
    }
}
