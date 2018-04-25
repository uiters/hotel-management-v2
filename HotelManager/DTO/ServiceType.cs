using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ServiceType
    {
        private int id;
        private string name;
        public ServiceType(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public ServiceType(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.Name = (string)row["Name"];
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
