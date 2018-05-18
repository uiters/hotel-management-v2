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
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật nhân viên này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                UpdateSurcharge();
            }
        }
        #endregion

        #region Method
        private void UpdateSurcharge()
        {
            bool isFill = fCustomer.CheckFillInText(new Control[] { txbValue, txbDescribe });
            if (!isFill)
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Surcharge surchargePre = groupSurcharge.Tag as Surcharge;
                try
                {
                    Surcharge surchargeNow = GetSurchargeNow();
                    if (surchargeNow.Equals(surchargePre))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "bạn chưa thay đổi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = SurchargeDAO.Instance.UpdateSurcharge(surchargeNow);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupSurcharge.Tag = surchargeNow;
                            LoadFullSurcharge();
                        }
                        else
                            MetroFramework.MetroMessageBox.Show(this, "Không thể cập nhật", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi không xác định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
