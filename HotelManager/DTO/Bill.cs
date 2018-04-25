using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Bill
    {
        private int id;
        private string staffSetUp;
        private DateTime dateOfCreate;
        private int totalPrice;
        private int discount;
        private string status;
        public Bill(int id, string staffSetUp, DateTime dateOfcrate, int totalPrice, int discount, string status)
        {
            this.Id = id;
            this.StaffSetUp = staffSetUp;
            this.DateOfCreate = dateOfcrate;
            this.TotalPrice = totalPrice;
            this.Discount = discount;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.StaffSetUp = (string)row["StaffSetUp"];
            this.DateOfCreate = (DateTime)row["DateOfCreate"];
            this.TotalPrice = (int)row["TotalPrice"];
            this.Discount = (int)row["Discount"];
            this.Status = (string)row["Status"];
        }
        public int Id { get => id; set => id = value; }
        public string StaffSetUp { get => staffSetUp; set => staffSetUp = value; }
        public DateTime DateOfCreate { get => dateOfCreate; set => dateOfCreate = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int Discount { get => discount; set => discount = value; }
        public string Status { get => status; set => status = value; }
    }
}
