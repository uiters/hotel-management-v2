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
    public partial class fParameter : Form
    {
        #region Constructor
        public fParameter()
        {
            InitializeComponent();
            LoadFullSurcharge();
            comboboxName.DisplayMember = "Name";
        }
        #endregion

        #region Load
        private void LoadFullSurcharge()
        {
            DataTable table = GetFullSurcharge();
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewParameter.DataSource = source;
            bindingSurcharge.BindingSource = source;
            comboboxName.DataSource = source;
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
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                UpdateSurcharge();
                comboboxName.Focus();
            }
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveParameter.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveParameter.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewParameter, saveParameter.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewParameter, saveParameter.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewParameter, saveParameter.FileName, ModeExportToExcel.XLS);
                            break;
                    }
                    if (check)
                        MetroFramework.MetroMessageBox.Show(this, "Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Lỗi xuất thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbDescribe.Text = string.Empty;
            txbValue.Text = "0";
        }
        #endregion

        #region Method
        private void UpdateSurcharge()
        {
            bool isFill = fCustomer.CheckFillInText(new Control[] { txbValue });
            if (isFill)
            {
                Parameter surchargePre = groupParameter.Tag as Parameter;
                try
                {
                    Parameter surchargeNow = GetSurchargeNow();
                    if (surchargeNow.Equals(surchargePre))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "bạn chưa thay đổi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = ParameterDAO.Instance.UpdateParameter(surchargeNow);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupParameter.Tag = surchargeNow;
                            int index = dataGridViewParameter.SelectedRows[0].Index;
                            LoadFullSurcharge();
                            comboboxName.SelectedIndex = index;
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
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống giá trị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbDescribe.Text = string.Empty;
                txbValue.Text = "0";
            }
            else
            {
                txbDescribe.Text = row.Cells[colDescribe.Name].Value.ToString();
                txbValue.Text = row.Cells[colValue.Name].Value.ToString();
                Parameter parameter = new Parameter(((DataRowView)row.DataBoundItem).Row);
                groupParameter.Tag = parameter;
            }
        }

        #endregion

        #region GetData
        private DataTable GetFullSurcharge()
        {
            return ParameterDAO.Instance.LoadFullParameter();
        }
        private Parameter GetSurchargeNow()
        {
            return new Parameter(comboboxName.Text, double.Parse(txbValue.Text), txbDescribe.Text);
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
            if (dataGridViewParameter.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewParameter.SelectedRows[0];
                ChangeText(row);
            }
        }


        #endregion


    }
}
