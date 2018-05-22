using HotelManager.DTO;
using System;
using System.Data;

namespace HotelManager.DAO
{
    public class CustomerDAO
    {
        #region Properties & constructor
        private static CustomerDAO instance;
        internal static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }

        private CustomerDAO() { }
        #endregion


        #region Method
        internal bool CheckIDCardExists(string idCard)
        {
            string query = "exec USP_CheckIdCardExists @idCard";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idCard });
            return data.Rows.Count > 0;
        }
        internal bool InsertCustomer(string customerName, int idCustomerType, string idCard, string address, DateTime dateOfBirth, int phoneNumber, string sex, string nationality)
        {
            string query = "exec USP_InsertCustomer @customerName , @idCustomerType , @idCard , @address , @dateOfBirth , @phoneNumber , @sex , @nationality";
            int count = DataProvider.Instance.ExecuteNoneQuery(query, new object[] { customerName, idCustomerType, idCard, address, dateOfBirth, phoneNumber, sex, nationality });
            return count > 0;
        }
        internal bool InsertCustomer(Customer customer)
        {
            return InsertCustomer(customer.CustomerName, customer.IdCustomerType, customer.IdCard, customer.Address,
                customer.DateOfBirth, customer.PhoneNumber, customer.Sex, customer.Nationality);
        }
        internal Customer GetIDCustomer(string idCard)
        {
            string query = "exec USP_GetIDCustomer @idCard";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idCard });
            Customer customer = new Customer(data.Rows[0]);
            return customer;
        }
        internal bool UpdateCustomer1(int phoneNumber, string address, string idCard)
        {
            string query = "exec USP_UpdateCustomer1 @phoneNumber , @address , @idCard";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { phoneNumber, address, idCard }) > 0;
        }
        internal bool UpdateCustomer(Customer customerNow, Customer customerPre)
        {
            string query = "USP_UpdateCustomer @id , @customerName , @idCustomerType ," +
                            " @idCardNow , @address , @dateOfBirth , " +
                            "@phoneNumber , @sex , @nationality , @idCardPre";
            object[] parameter = new object[] {customerNow.Id, customerNow.CustomerName, customerNow.IdCustomerType, customerNow.IdCard,
                                    customerNow.Address, customerNow.DateOfBirth, customerNow.PhoneNumber,
                                    customerNow.Sex, customerNow.Nationality, customerPre.IdCard};
            return DataProvider.Instance.ExecuteNoneQuery(query, parameter) > 0;
        }
        internal object GetIDCustomerFromBookRoom(int idBookRoom)
        {
            object obj = DataProvider.Instance.ExecuteScalar("exec USP_GetIDCustomerFromBookRoom @idBookRoom", new object[] { idBookRoom });
            return obj;
        }
        internal Customer ShowCustomerInfo(int idCustomer)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_ShowCustomerInfo @idCustomer", new object[] { idCustomer });
            Customer customer = new Customer(data.Rows[0]);
            return customer;
        }
        internal DataTable LoadFullCustomer()
        {
            string query = "USP_LoadFullCustomer";
            return DataProvider.Instance.ExecuteQuery(query);
        }
        internal DataTable Search(string text, int phoneNumber)
        {
            string query = "USP_SearchCustomer @string , @int";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { text, phoneNumber });
        }
        #endregion

    }
}
