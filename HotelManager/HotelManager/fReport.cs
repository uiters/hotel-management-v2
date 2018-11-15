using HotelManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();
        }

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DataTable table = GetFulReport(int.Parse(comboBoxMonth.Text), (int)(numericYear.Value));
            dataGridReport.DataSource = table;
        }
        #endregion

        #region Data
        private DataTable GetFulReport(int month, int year)
        {
            return ReportDAO.Instance.LoadFullReport(month, year);
        }

        #endregion


    }
}
