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
        int id;
        string name;
        int idServiceType;
        int price;
        public Service(DataRow data)
        {
            Id = (int)data["id"];
            Name = data["Name"].ToString();
            IdServiceType = (int)data["idServiceType"];
            Price = (int)data["Price"];
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdServiceType { get => idServiceType; set => idServiceType = value; }
        public int Price { get => price; set => price = value; }
    }
}
