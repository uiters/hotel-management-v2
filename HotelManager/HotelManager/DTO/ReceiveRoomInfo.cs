using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ReceiveRoomInfo
    {
        private int idReceiveRoom;
        private int idCustomer;
        public ReceiveRoomInfo(int idReceiveRoom, int idCustomer)
        {
            IdReceiveRoom = idReceiveRoom;
            IdCustomer = idCustomer;
        }
        public ReceiveRoomInfo(DataRow row)
        {
            IdReceiveRoom = (int)row["idReceiveRoom"];
            IdCustomer = (int)row["idCustomer"];
        }
        public int IdReceiveRoom { get => idReceiveRoom; set => idReceiveRoom = value; }
        public int IdCustomer { get => idCustomer; set => idCustomer = value; }
    }
}
