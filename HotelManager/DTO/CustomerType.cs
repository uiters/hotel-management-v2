using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class CustomerType
    {
        private int id;
        private string name;
        public CustomerType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public CustomerType(DataRow row)
        {
            Id = (int)row["id"];
            Name = row["Name"].ToString();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as CustomerType);
        }
        public bool Equals(CustomerType customerTypePre)
        {
            if (customerTypePre == null) return false;
            return (this.name == customerTypePre.name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
