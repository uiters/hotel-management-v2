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
        private int id;
        private string idCard;
        private int idCustomerType;
        private string customerName;
        private DateTime dateOfBirth;
        private string address;
        private int phoneNumber;
        private string sex;
        private string nationality;
        public Customer()
        {

        }
        public Customer(int id, string idCard, string customerName, int idCustomerType , string address, int phoneNumber, string sex, string nationality, DateTime dateOfBirth)
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
            this.Id = (int)row["id"];
            this.IdCard = (string)row["IDCard"];
            this.IdCustomerType = (int)row["IDCustomerType"];
            this.CustomerName = row["Name"].ToString();
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Address = row["Address"].ToString();
            this.PhoneNumber = (int)row["PhoneNumber"];
            this.Sex = row["Sex"].ToString();
            this.Nationality = row["Nationality"].ToString();
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Customer);
        }
        public bool Equals(Customer customerPre)
        {
            if (customerPre == null)
                return false;
            if (this.idCard != customerPre.idCard) return false;
            if (this.idCustomerType != customerPre.idCustomerType) return false;
            if (this.customerName != customerPre.customerName) return false;
            if (this.dateOfBirth != customerPre.dateOfBirth) return false;
            if (this.address != customerPre.address) return false;
            if (this.phoneNumber != customerPre.phoneNumber) return false;
            if (this.sex != customerPre.sex) return false;
            if (this.nationality != customerPre.nationality) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string CustomerName { get => customerName; set => customerName = value; }
        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int IdCustomerType { get => idCustomerType; set => idCustomerType = value; }
        public int Id { get => id; set => id = value; }
    }
}
