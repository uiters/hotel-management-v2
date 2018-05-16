using HotelManager.DAO;
using HotelManager.DTO;
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
    public partial class fSurcharge : Form
    {
        #region Constructor
        public fSurcharge()
        {
            InitializeComponent();
            LoadFullSurcharge();
        }
        #endregion

        #region Load
        private void LoadFullSurcharge()
        {
            DataTable table = GetFullSurcharge();
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewSurcharge.DataSource = source;
            bindingSurcharge.BindingSource = source;
        }
        #endregion

        #region Click
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(SurchargeDAO.Instance.UpdateSurcharge(GetSurchargeNow()))
                LoadFullSurcharge();
        }
        #endregion


        #region GetData
        private DataTable GetFullSurcharge()
        {
            return SurchargeDAO.Instance.LoadFullSurcharge();
        }
        private Surcharge GetSurchargeNow()
        {
            return new Surcharge(txbName.Text, double.Parse(txbValue.Text), txbDescribe.Text);
        }
        #endregion

        #region Check isDigit
        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.'))
                e.Handled = true;
        }

        #endregion

        #region ChangeText
        private void DataGridSurcharge_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSurcharge.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewSurcharge.SelectedRows[0];
                ChangeText(row);
            }
        }

        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;


            }
            else
            {
                txbDescribe.Text = row.Cells[colDescribe.Name].Value.ToString();
                txbValue.Text = row.Cells[colValue.Name].Value.ToString();
                txbName.Text = row.Cells[colName.Name].Value.ToString();
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }

        #endregion


    }
}
