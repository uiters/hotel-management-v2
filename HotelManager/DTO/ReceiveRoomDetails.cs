using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DTO
{
    public class ReceiveRoomDetails
    {
        private int idReceiveRoom;
        private int idCustomerOther;
        public ReceiveRoomDetails(int idReceiveRoom, int idCustomer)
        {
            this.IDReceiveRoom = idReceiveRoom;
            this.IDCustomerOther = idCustomer;
        }
        public ReceiveRoomDetails(DataRow row)
        {
            this.IDReceiveRoom = (int)row["IDReceiveRoom"];
            this.IDCustomerOther = (int)row["IDCustomerOther"];
        }
        public int IDReceiveRoom { get => idReceiveRoom; set => idReceiveRoom = value; }
        public int IDCustomerOther { get => idCustomerOther; set => idCustomerOther = value; }
    }
}
