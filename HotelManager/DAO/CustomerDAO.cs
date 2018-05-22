using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        private CustomerDAO() { }
        public bool IsIdCardExists(string idCard)
        {
            string query = "USP_IsIdCardExists @idCard";
            int count = DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows.Count;
            return count > 0;
        }
        public bool InsertCustomer(string idCard, string name,int idCustomerType,DateTime dateofBirth,string address,int phonenumber,string sex,string nationality)
        {
            string query = "USP_InsertCustomer_ @idCard , @name , @idCustomerType , @dateOfBirth , @address , @phoneNumber , @sex , @nationality";
            return DataProvider.Instance.ExecuteNoneQuery(query,new object[] { idCard, name, idCustomerType, dateofBirth, address, phonenumber, sex, nationality })>0;
        }
        public Customer GetInfoByIdCard(string idCard)
        {
            string query = "USP_IsIdCardExists @idCard";
            Customer customer =new Customer(DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows[0]);
            return customer;

        }
        public static CustomerDAO Instance { get { if (instance == null) instance = new CustomerDAO();return instance; }
            private set => instance = value; }
        
    }
}
