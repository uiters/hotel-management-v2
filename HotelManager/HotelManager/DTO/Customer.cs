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
        private string name;
        private int idCustomerType;
        private DateTime dateOfBirth;
        private string address;
        private int phoneNumber;
        private string sex;
        private string nationality;
        public Customer()
        {

        }
        public Customer(int id,string idCard, string name, int idcustomerType, string address, int phoneNumber, string sex, string nationality,DateTime dateOfBirth)
        {
            this.Id = id;
            this.IdCard = idCard;
            this.Name = name;
            this.IdCustomerType = idcustomerType;
            this.DateOfBirth = dateOfBirth;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Sex = sex;
            this.Nationality = nationality;
        }
        public Customer(DataRow row)
        {
            this.Id= (int)row["id"];
            this.IdCard = row["idcard"].ToString();
            this.Name = row["Name"].ToString();
            this.IdCustomerType =(int)row["idcustomerType"];
            this.DateOfBirth = (DateTime)row["DateOfBirth"];
            this.Address = row["address"].ToString();
            this.PhoneNumber = (int)row["phoneNumber"];
            this.Sex = row["sex"].ToString();
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
            if (this.Name != customerPre.Name) return false;
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

        public string Address { get => address; set => address = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Sex { get => sex; set => sex = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public string Name { get => name; set => name = value; }
        public int IdCustomerType { get => idCustomerType; set => idCustomerType = value; }
        public int Id { get => id; set => id = value; }
    }
}
