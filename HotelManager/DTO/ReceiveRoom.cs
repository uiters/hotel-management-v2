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
        private int id;
        private int idBookRoom;
        private int idRoom;
        public ReceiveRoom(DataRow row)
        {
            Id = (int)row["id"];
            IdBookRoom = (int)row["idBookRoom"];
            IdRoom = (int)row["idroom"];
        }
        public int Id { get => id; set => id = value; }
        public int IdBookRoom { get => idBookRoom; set => idBookRoom = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
    }
}
