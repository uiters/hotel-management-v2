using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAO
{
    public class ParameterDAO
    {
        #region Properties
        private static ParameterDAO instance;
        public static ParameterDAO Instance { get { if (instance == null) instance = new ParameterDAO(); return instance; } }
        #endregion



        public bool UpdateParameter(string name, double value, string describe)
        {
            string query = "exec USP_UpdateSurcharge @name , @value , @describe";
            return DataProvider.Instance.ExecuteNoneQuery(query, new Object[] { name, value, describe }) > 0;
        }
        public bool UpdateParameter(Parameter surcharge)
        {
            return UpdateParameter(surcharge.Name, surcharge.Value, surcharge.Describe);
        }

        public DataTable LoadFullParameter()
        {
            return DataProvider.Instance.ExecuteQuery("USP_LoadFullSurcharge");
        }


        private ParameterDAO() { }
    }
}
