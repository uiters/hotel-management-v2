using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class BillDetailsDAO
    {
        private static BillDetailsDAO instance;
        public bool IsExistsBillDetails(int idRoom,int idService)// >0 Service đã có BillDetails, chỉ cần update lại thôi, <0 tạo BillDetails
        {
            string query = "USP_IsExistBillDetailsOfRoom @idRoom , @idservice";
            return DataProvider.Instance.ExecuteQuery(query, new object[] { idRoom, idService }).Rows.Count > 0;
        }
        public bool InsertBillDetails(int idBill,int idService, int count)
        {
            string query = "USP_InsertBillDetails @idBill , @idService , @count";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill, idService, count }) > 0;
        }
        public bool UpdateBillDetails(int idBill, int idService, int _count)
        {
            string query = "USP_UpdateBillDetails @idBill , @idService , @_count";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { idBill, idService, _count }) > 0;
        }
        public static BillDetailsDAO Instance { get { if (instance == null) instance = new BillDetailsDAO();return instance; }
                private set => instance = value; }
    }
}
