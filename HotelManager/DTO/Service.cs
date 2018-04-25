using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Service
    {
        private int id;
        private int idServiceType;
        private string name;
        private int price;

        public int Id { get => id; set => id = value; }
        public int IdServiceType { get => idServiceType; set => idServiceType = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }

        public Service(int id, int idServiceType, int price, string name)
        {
            this.Id = id;
            this.IdServiceType = IdServiceType;
            this.Price = price;
            this.name = name;
        }
        public Service(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdServiceType = (int)row["IDServiceType"];
            this.Price = (int)row["price"];
            this.Name = (string)row["Name"];
        }
    }
}
