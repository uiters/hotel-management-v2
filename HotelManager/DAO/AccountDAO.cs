using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class AccountDAO
    {

        private static AccountDAO instance;
        public string HashPass(string text)
        {
            MD5 md5 = MD5.Create();
            byte[] temp = Encoding.ASCII.GetBytes(text);
            byte[] hashData = md5.ComputeHash(temp);
            string hashPass = "";
            foreach (var item in hashData)
            {
                hashPass += item.ToString("x2");
            }
            return hashPass;
        }
        public bool Login(string userName, string passWord)
        {
            string hashPass = HashPass(passWord);
            string query = "USP_Login @userName , @passWord";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashPass });
            return data.Rows.Count>0;
        }
        public Account LoadStaffInforByUserName(string username)
        {
            //string query = "USP_GetNameStaffTypeByUserName @username";
            //DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { username });
            string query = "select * from Staff where UserName='" + username + "'";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            Account account = new Account(dataTable.Rows[0]);
            return account;
        }
        public bool IsIdCardExists(string idCard)
        {
            string query = "USP_IsIdCardExistsAcc @idCard";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idCard }).Rows.Count > 0;
        }
        public bool UpdateDisplayName(string username,string displayname)
        {
            string query = "USP_UpdateDisplayName @username , @displayname";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { username, displayname }) > 0;
        }
        public bool UpdatePassword(string username, string password)
        {
            string query = "USP_UpdatePassword @username , @password";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { username, HashPass(password) }) > 0;
        }
        public bool UpdateInfo(string username,string address, int phonenumber,string idCard)
        {
            string query = "USP_UpdateInfo @username , @address , @phonenumber";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { username, address, phonenumber,idCard }) > 0;
        }
        public Account GetStaffSetUp(int idBill)
        {
            string query = "USP_GetStaffSetUp @idBill";
            Account account = new Account(DataProvider.Instance.ExecuteQuery(query, new object[] { idBill }).Rows[0]);
            return account;
        }
        public static AccountDAO Instance {
            get { if (instance == null) instance = new AccountDAO();return instance; }
            private set => instance = value; }
        private AccountDAO() { }
    }
}
