using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class AccountType
    {
        private int id;
        private string name;
        public AccountType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public AccountType(DataRow row)
        {
            id = (int)row["ID"];
            Name = (string)row["Name"];
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
