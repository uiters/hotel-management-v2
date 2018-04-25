using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    class Surcharge
    {
        private string name;
        private float value;
        private string describe;
        public Surcharge(string name, float value, string describe)
        {
            this.Name = name;
            this.Value = value;
            this.Describe = describe;
        }

        public string Name { get => name; set => name = value; }
        public float Value { get => value; set => this.value = value; }
        public string Describe { get => describe; set => describe = value; }
    }
}
