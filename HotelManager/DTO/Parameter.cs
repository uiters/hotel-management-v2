using System.Data;

namespace HotelManager.DTO
{
    public class Parameter
    {
        private string name;
        private double value;
        private string describe;
        public Parameter(string name, double value, string describe)
        {
            this.Name = name;
            this.Value = value;
            this.Describe = describe;
        }
        public Parameter(DataRow row)
        {
            this.Value = (double)row["Value"];
            this.Name = row["Name"] as string;
            this.Describe = row["Describe"] as string;
        }

        public bool Equals(Parameter parameterPre)
        {
            if (parameterPre == null)
                return false;
            if (this.value != parameterPre.value) return false;
            if (this.describe != parameterPre.describe) return false;
            return true;
        }

        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
        public string Describe { get => describe; set => describe = value; }
    }
}
