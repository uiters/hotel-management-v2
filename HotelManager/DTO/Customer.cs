using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Customer
    {
        private string idCard;
        private int idCustomerType;
        private string customerName;
        private DateTime dateOfBirth;
        private string address;
        private int phoneNumber;
        private string sex;
        private string nationality;
        public Customer(string idCard, string customerName, int idCustomerType , string address, int phoneNumber, string sex, string nationality, DateTime dateOfBirth)
        {
            this.CustomerName = customerName;
            this.IdCustomerType = idCustomerType;
            this.IdCard = idCard;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Sex = sex;
            this.Nationality = nationality;
        }
        public Customer(DataRow row)
        {
            this.IdCard = row["IDCard"].ToString();
            this.IdCustomerType = (int)row["IDCustomerType"];
            this.CustomerName = row["Name"].ToString();
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Address = row["Address"].ToString();
            this.PhoneNumber = (int)row["PhoneNumber"];
            this.Sex = row["Sex"].ToString();
            this.Nationality = row["Nationality"].ToString();
        }

        public string CustomerName { get => customerName; set => customerName = value; }
        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int IdCustomerType { get => idCustomerType; set => idCustomerType = value; }
    }
}
