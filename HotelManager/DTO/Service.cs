using System.Data;

namespace HotelManager.DTO
{
    public class Service
    {
        #region Properties
        private int id;
        private int idServiceType;
        private string name;
        private int price;

        public int Id { get => id; set => id = value; }
        public int IdServiceType { get => idServiceType; set => idServiceType = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        #endregion

        #region Constructor
        public Service() { }
        public Service(int id, int idServiceType, int price, string name)
        {
            this.Id = id;
            this.IdServiceType = IdServiceType;
            this.Price = price;
            this.name = name;
        }
        public Service(DataRow row)
        {
            this.Id = (int)row["id"];
            this.IdServiceType = (int)row["IDServiceType"];
            this.Price = (int)row["price"];
            this.Name = (string)row["Name"];
        }
        #endregion

        #region Method
        public bool Equals(Service servicePre)
        {
            if (servicePre == null) return false;
            if (servicePre.idServiceType != this.idServiceType) return false;
            if (servicePre.name != this.name) return false;
            if (servicePre.price != this.price) return false;
            return true;
        }
        #endregion
    }
}
