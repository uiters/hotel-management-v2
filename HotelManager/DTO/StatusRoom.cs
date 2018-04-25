using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class StatusRoom
    {
        private int id;
        private string name;
        public StatusRoom(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public StatusRoom(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.Name = row["Name"].ToString();
        }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
    }
}
