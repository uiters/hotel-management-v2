using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Account
    {
        #region Properties
        private string userName;
        private string displayName;
        private string passWord;
        private int idStaffType;
        private string idCard;
        private DateTime dateOfBirth;
        private string sex;
        private string address;
        private int phoneNumber;
        private DateTime startDay;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int IdStaffType { get => idStaffType; set => idStaffType = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        #endregion

        #region Constructor
        public Account() { }
        public Account(string userName, string displayName, string passWord, int staffType, string idCard, DateTime dateOfBirth, string sex, string address, int phoneNumber, DateTime startDay)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.PassWord = passWord;
            this.IdStaffType = staffType;
            this.DateOfBirth = dateOfBirth;
            this.Sex = sex;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.StartDay = startDay;
            this.IdCard = idCard;
        }
        public Account(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.idStaffType = (int)row["IDStaffType"];
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Sex = row["Sex"].ToString();
            this.Address = row["Address"].ToString();
            this.PhoneNumber = (int)row["PhoneNumber"];
            this.StartDay = (DateTime)row["StartDay"];
            this.IdCard = (string)row["idCard"];
            this.PassWord = row["PassWord"].ToString();

        }
        #endregion

        #region Method
        public bool Equals(Account accountPre)
        {
            if (accountPre == null)
                return false;
            if (userName != accountPre.userName) return false;
            if (displayName != accountPre.displayName) return false;
            if (idStaffType != accountPre.idStaffType) return false;
            if (idCard != accountPre.idCard) return false;
            if (dateOfBirth != accountPre.dateOfBirth) return false;
            if (sex != accountPre.sex) return false;
            if (phoneNumber != accountPre.phoneNumber) return false;
            if (address != accountPre.address) return false;
            if (startDay != accountPre.startDay) return false;
            return true;
        }
        #endregion

        //private string userName;
        //private string displayName;
        //private string passWord;
        //private int idStaffType;
        //private string idCard;
        //private DateTime dateOfBirth;
        //private string sex;
        //private string address;
        //private int phoneNumber;
        //private DateTime startDay;
        //public Account(string username,string displayname,string password,int idstafftype,string idcard, DateTime dateofbirth,string sex,string address,int phonenumber,DateTime startday)
        //{
        //    this.UserName = username;
        //    this.DisplayName = displayname;
        //    this.PassWord = password;
        //    this.IdStaffType = idstafftype;
        //    this.IdCard = idcard;
        //    this.DateOfBirth = dateofbirth;
        //    this.Sex = sex;
        //    this.Address = address;
        //    this.PhoneNumber = phonenumber;
        //    this.StartDay = startday;
        //}

        //public Account(DataRow row)
        //{
        //    this.UserName = row["username"].ToString();
        //    this.DisplayName = row["displayname"].ToString();
        //    this.PassWord = row["password"].ToString();
        //    this.IdStaffType = (int)row["IdStaffType"];
        //    this.DateOfBirth = (DateTime)row["DateOfBirth"];
        //    this.Sex = row["Sex"].ToString();
        //    this.Address = row["Address"].ToString();
        //    this.PhoneNumber = (int)row["PhoneNumber"];
        //    this.StartDay = (DateTime)row["StartDay"];
        //    this.IdCard = row["IdCard"].ToString();
        //}
        //public string UserName { get => userName; set => userName = value; }
        //public string DisplayName { get => displayName; set => displayName = value; }
        //public string PassWord { get => passWord; set => passWord = value; }
        //public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        //public string Sex { get => sex; set => sex = value; }
        //public string Address { get => address; set => address = value; }
        //public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        //public DateTime StartDay { get => startDay; set => startDay = value; }
        //public int IdStaffType { get => idStaffType; set => idStaffType = value; }
        //public string IdCard { get => idCard; set => idCard = value; }
    }
}
