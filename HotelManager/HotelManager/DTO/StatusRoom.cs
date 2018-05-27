using System.Data;

namespace HotelManager.DTO
{
    public class StatusRoom
    {
        #region Properties
        private int id;
        private string name;
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        #endregion

        #region Constructor
        public StatusRoom(){ }
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
        #endregion

        #region Method
        public bool Equals(StatusRoom statusRoomPre)
        {
            return this.name == statusRoomPre.name;
        }
        #endregion
    }
}
