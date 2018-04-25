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
        private DateTime dateOfBirth;
        private string sex;
        private string address;
        private int phoneNumber;
        private DateTime startDay;

        public Account(string userName, string displayName, string passWord,int staffType, DateTime dateOfBirth, string sex, string address, int phoneNumber,DateTime startDay)
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
        }
        public Account(DataRow row)
        {
            this.UserName =row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.PassWord = row["PassWord"].ToString();
            this.idStaffType = (int)row["IDStaffType"];
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Sex = row["Sex"].ToString();
            this.Address = row["Address"].ToString();
            this.PhoneNumber = (int)row["PhoneNumber"];
            this.StartDay = (DateTime)row["StartDay"];
        }
        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int IdStaffType { get => idStaffType; set => idStaffType = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
    }
}
