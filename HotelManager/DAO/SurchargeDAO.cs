using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class SurchargeDAO
    {
        private SurchargeDAO instance;
        public bool InsertSurcharge(string name, float value, string describe = "")
        {
            string query = "exec USP_InsertSurcharge @name , @value , @describe";
            return DataProvider.Instance.ExecuteNoneQuery(query, new object[] { name, value, describe }) > 0;
        }

        public bool UpdateSurcharge(string name, float value, string describe)
        {
            string query = "exec USP_UpdateSurcharge @name , @value , @describe";
            return DataProvider.Instance.ExecuteNoneQuery(query, new Object[] { name, value, describe }) > 0;
        }
        public bool UpdateSurcharge(Surcharge surcharge)
        {
            return UpdateSurcharge(surcharge.Name, surcharge.Value, surcharge.Describe);
        }

        private SurchargeDAO() { }
        public SurchargeDAO Instance { get { if (instance == null) instance = new SurchargeDAO(); return instance; } }
    }
}
