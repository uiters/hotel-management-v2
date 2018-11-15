using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class BookRoomInfoDAO
    {
        private static BookRoomInfoDAO instance;
        private BookRoomInfoDAO() { }
        public bool InsertBookRoom()
        {
            return true;
        }
        public static BookRoomInfoDAO Instance { get
            {
                if (instance == null)
                    instance = new BookRoomInfoDAO();
                return instance;
            }
            private set => instance = value; }
    }
}
