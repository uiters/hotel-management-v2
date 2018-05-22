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
        public Account(string username,string displayname,string password,int idstafftype,string idcard, DateTime dateofbirth,string sex,string address,int phonenumber,DateTime startday)
        {
            this.UserName = username;
            this.DisplayName = displayname;
            this.PassWord = password;
            this.IdStaffType = idstafftype;
            this.IdCard = idcard;
            this.DateOfBirth = dateofbirth;
            this.Sex = sex;
            this.Address = address;
            this.PhoneNumber = phonenumber;
            this.StartDay = startday;
        }
        
        public Account(DataRow row)
        {
            this.UserName = row["username"].ToString();
            this.DisplayName = row["displayname"].ToString();
            this.PassWord = row["password"].ToString();
            this.IdStaffType = (int)row["IdStaffType"];
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Sex = row["Sex"].ToString();
            this.Address = row["Address"].ToString();
            this.PhoneNumber = (int)row["PhoneNumber"];
            this.StartDay = (DateTime)row["StartDay"];
            this.IdCard = row["IdCard"].ToString();
        }
        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        public int IdStaffType { get => idStaffType; set => idStaffType = value; }
        public string IdCard { get => idCard; set => idCard = value; }
    }
}
