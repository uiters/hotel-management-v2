using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class Surcharge
    {
        private string name;
        private double value;
        private string describe;
        public Surcharge(string name, double value, string describe)
        {
            this.Name = name;
            this.Value = value;
            this.Describe = describe;
        }
        public Surcharge(DataRow row)
        {
            this.Value = (int)row["Value"];
            this.Name = row["Name"].ToString();
            this.Describe = (string)row["Describe"];
        }

        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
        public string Describe { get => describe; set => describe = value; }
    }
}
