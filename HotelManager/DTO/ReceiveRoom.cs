using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ReceiveRoom
    {
        private int idBookRoom;
        private int idRoom;
        private int amount;

        public ReceiveRoom(int idBookRoom, int idRoom, int amount)
        {
            this.IdBookRoom = idBookRoom;
            this.IdRoom = IdRoom;
            this.Amount = amount;
        }
        public ReceiveRoom(DataRow row)
        {
            this.Amount = (int)row["Amount"];
            this.IdBookRoom = (int)row["ID"];
            this.IdRoom = (int)row["IDRoom"];
        }

        public int Amount { get => amount; set => amount = value; }
        public int IdBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
    }
}
