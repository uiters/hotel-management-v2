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
