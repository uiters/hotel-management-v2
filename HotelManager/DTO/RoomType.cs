using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class RoomType
    {
        private int id;
        private string name;
        private int price;
        private int limitPerson;
        public RoomType(int id, string name, int price, int limitPerson)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.LimitPerson = limitPerson;
        }
        public RoomType(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Price = (int)row["price"];
            this.LimitPerson= (int)row["limitPerson"];
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int LimitPerson { get => limitPerson; set => limitPerson = value; }
    }
}
