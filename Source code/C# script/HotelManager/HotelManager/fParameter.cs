using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fParameter : Form
    {
        #region Constructor
        public fParameter()
        {
            InitializeComponent();
            LoadFullParameter(GetFullParameter());
            comboboxName.DisplayMember = "Name";
            dataGridViewParameter.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        #endregion

        #region Load
        private void LoadFullParameter(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewParameter.DataSource = source;
            bindingSurcharge.BindingSource = source;
            comboboxName.DataSource = source;
            txbValue.Enter += Txb_Enter;
            txbValue.Leave += Txb_Leave;
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
            DialogResult result = MessageBox.Show( "Bạn có muốn cập nhật không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
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
                        MessageBox.Show( "Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show( "Lỗi xuất thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show( "Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbDescribe.Text = string.Empty;
            txbValue.Text = "0";
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbValue.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadFullParameter(GetFullParameter());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        #endregion

        #region Method
        private void UpdateSurcharge()
        {
            if(comboboxName.Text == string.Empty)
            {
                MessageBox.Show( "Không thể cập nhật (Không có phụ thu này)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            bool isFill = fCustomer.CheckFillInText(new Control[] { txbValue });
            if (isFill)
            {
                Parameter surchargePre = groupParameter.Tag as Parameter;
                try
                {
                    Parameter surchargeNow = GetSurchargeNow();
                    if (surchargeNow.Equals(surchargePre))
                    {
                        MessageBox.Show( "bạn chưa thay đổi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = ParameterDAO.Instance.UpdateParameter(surchargeNow);
                        if (check)
                        {
                            MessageBox.Show( "Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupParameter.Tag = surchargeNow;
                            if (btnCancel.Visible == false)
                            {
                                int index = dataGridViewParameter.SelectedRows[0].Index;
                                LoadFullParameter(GetFullParameter());
                                comboboxName.SelectedIndex = index;
                            }
                            else BtnCancel_Click(null, null);
                        }
                        else
                            MessageBox.Show( "Không thể cập nhật (Không có phụ thu này)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show( "Lỗi không xác định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show( "Không được để trống giá trị", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Search()
        {
            LoadFullParameter(GetSearchParameter());
        }
        #endregion

        #region GetData
        private DataTable GetFullParameter()
        {
            return ParameterDAO.Instance.LoadFullParameter();
        }
        private Parameter GetSurchargeNow()
        {
            fStaff.Trim(new Bunifu.Framework.UI.BunifuMetroTextbox[] { txbDescribe });
            return new Parameter(comboboxName.Text, double.Parse(txbValue.Text), txbDescribe.Text);
        }
        private DataTable GetSearchParameter()
        {
            return ParameterDAO.Instance.Search(txbSearch.Text);
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

        #region Key
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        private void FParameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }
        #endregion

        #region Enter & Leave
        private void Txb_Enter(object sender, EventArgs e)
        {
            var textBox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            textBox.Tag = textBox.Text;
        }
        private void Txb_Leave(object sender, EventArgs e)
        {
            var textBox = sender as Bunifu.Framework.UI.BunifuMetroTextbox;
            if(textBox.Text == string.Empty)
            {
                textBox.Text = textBox.Tag as string;
            }
        }
        #endregion

        #region Close
        private void FParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnCancel_Click(sender, null);
        }
        #endregion
    }
}
