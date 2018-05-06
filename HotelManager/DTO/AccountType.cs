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
        #region Properties
        private int id;
        private string name;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        #endregion


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

        public bool Equals(AccountType accountTypePre)
        {
            if (accountTypePre == null) return false;
            return this.name == accountTypePre.name;
        }
       
    }
}
