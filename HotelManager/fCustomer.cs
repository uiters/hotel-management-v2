using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;
namespace HotelManager
{
    public partial class fCustomer : Form
    {
        #region Properties
        private fCustomerType customerType;
        private int id;
        #endregion

        #region Constructor
        public fCustomer()
        {
            InitializeComponent();
            LoadFullCustomer();
            LoadFullCustomerType();
            comboBoxSex.SelectedIndex = 0;
            SaveCustomer.OverwritePrompt = true;
        }

        #endregion

        #region Load
        private void LoadFullCustomer()
        {
            DataTable table = GetFullCustomer();
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewCustomer.DataSource = source;
            bindingCustomer.BindingSource = source;           
        }
        private void LoadFullCustomerType()
        {
            DataTable table = GetFullCustomerType();
            comboBoxCustomerType.DataSource = table;
            comboBoxCustomerType.DisplayMember = "Name";
            if(table.Rows.Count > 0)
                comboBoxCustomerType.SelectedIndex = 0;
            customerType = new fCustomerType(table);
        }
        #endregion

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            bool check;
            if (SaveCustomer.ShowDialog() == DialogResult.Cancel)
                return;
            switch (SaveCustomer.FilterIndex)
            {
                case 2:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.XLSX);
                    break;
                case 3:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.PDF);
                    break;
                default:
                    check = ExportToExcel.Instance.Export(dataGridViewCustomer, SaveCustomer.FileName, ModeExportToExcel.XLS);
                    break;
            }
            if (check)
                MetroFramework.MetroMessageBox.Show(this, "Xuất file thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MetroFramework.MetroMessageBox.Show(this, "Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn thêm khách hàng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                if (CheckDate())
                    InsertCustomer();
                else
                    MetroFramework.MetroMessageBox.Show(this, "Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void BtnCustomerType_Click(object sender, EventArgs e)
        {
            this.Hide();
            customerType.ShowDialog();
            comboBoxCustomerType.DataSource = customerType.Table;
            comboBoxCustomerType.Refresh();
            LoadFullCustomer();
            this.Show();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbFullName.Text = string.Empty;
            txbAddress.Text = string.Empty;
            txbIDCard.Text = string.Empty;
            txbNationality.Text = string.Empty;
            txbPhoneNumber.Text = string.Empty;
        }
        private void BtnClose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                if (CheckDate())
                    UpdateCustomer();
                else
                    MetroFramework.MetroMessageBox.Show(this, "Ngày sinh phải nhỏ hơn ngày hiện tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        #endregion

        #region Method
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
        private void InsertCustomer()
        {
            if (!CheckFillInText(new Control[] { txbPhoneNumber, txbFullName, txbIDCard, txbNationality, txbAddress, comboBoxCustomerType}))
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Customer customer = GetCustomerNow();
                if (CustomerDAO.Instance.InsertCustomer(customer))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullCustomer();
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Khách Hàng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Lỗi thêm khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCustomer()
        {
            if (!CheckFillInText(new Control[] { txbPhoneNumber, txbFullName, txbIDCard, txbNationality, txbAddress, comboBoxCustomerType }))
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Customer customerPre = groupCustomer.Tag as Customer;
                try
                {
                    Customer customerNow = GetCustomerNow();
                    if (customerNow.Equals(customerPre))
                        MetroFramework.MetroMessageBox.Show(this, "Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = CustomerDAO.Instance.UpdateCustomer(customerNow, customerPre);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupCustomer.Tag = customerNow;
                            LoadFullCustomer();
                        }
                        else
                            MetroFramework.MetroMessageBox.Show(this, "Khách hàng này đã tồn tại(Trùng số chứng minh nhân dân)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi câp nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txbFullName.Text = string.Empty;
                txbAddress.Text = string.Empty;
                txbIDCard.Text = string.Empty;
                txbNationality.Text = string.Empty;
                txbPhoneNumber.Text = string.Empty;
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                id = (int)row.Cells["colid"].Value;
                txbFullName.Text = row.Cells["colNameCustomer"].Value.ToString();
                txbAddress.Text = row.Cells["colAddress"].Value.ToString();
                txbIDCard.Text = row.Cells["colIDCard"].Value.ToString();
                txbNationality.Text = row.Cells["colNationality"].Value.ToString();
                txbPhoneNumber.Text = row.Cells["colPhone"].Value.ToString();
                comboBoxCustomerType.SelectedIndex =(int) row.Cells["colIdCustomerType"].Value - 1;
                comboBoxSex.SelectedItem = row.Cells["colSex"].Value;
                datepickerDateOfBirth.Value = (DateTime)row.Cells["colDateOfBirth"].Value;
                Customer customer = new Customer(((DataRowView) row.DataBoundItem).Row);
                groupCustomer.Tag = customer;              
            }
        }

        #endregion

        #region GetData
        private Customer GetCustomerNow()
        {
            Customer customer = new Customer();
            customer.Id = this.id;
            customer.IdCard = txbIDCard.Text;
            int id = comboBoxCustomerType.SelectedIndex;
            customer.IdCustomerType = (int)customerType.Table.Rows[id]["id"];
            customer.CustomerName = txbFullName.Text;
            customer.Sex = comboBoxSex.Text;
            customer.PhoneNumber = int.Parse(txbPhoneNumber.Text);
            customer.DateOfBirth = datepickerDateOfBirth.Value;
            customer.Nationality = txbNationality.Text;
            customer.Address = txbAddress.Text;
            return customer;
        }
        private DataTable GetFullCustomer()
        {
            return CustomerDAO.Instance.LoadFullCustomer();
        }
        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }

        #endregion

        #region Seclection Change
        private void DataGridViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewCustomer.SelectedRows[0];
                ChangeText(row);
            }
        }
        #endregion

        #region Check isDigit
        private void TxbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
                e.Handled = true;
        }
        private bool CheckDate()
        {
            if (DateTime.Now.Subtract(datepickerDateOfBirth.Value).Days <= 0)
                return false;
            else return true;
        }
        #endregion

    }
}
