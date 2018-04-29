using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace HotelManager
{
    public partial class fCustomer : Form
    {
        private fCustomerType customerType;
        private DataTable tableCustomer;
        public fCustomer()
        {
            InitializeComponent();
            LoadFullCustomer();
            LoadFullCustomerType();
            comboBoxSex.SelectedIndex = 0;
            SaveCustomer.OverwritePrompt = true;
        }

        #region Load
        private void LoadFullCustomer()
        {
            tableCustomer = GetFullCustomer();
            BindingSource source = new BindingSource();
            source.DataSource = tableCustomer;
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
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
                MessageBox.Show("Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lỗi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (btnAddCustomer.ButtonText.Contains("Thêm"))
                InsertCustomer();
            else
                UpdateCustomer();
        }
        private void btnCustomerType_Click(object sender, EventArgs e)
        {
            this.Hide();
            customerType.ShowDialog();
            comboBoxCustomerType.DataSource = customerType.Table;
            comboBoxCustomerType.Refresh();
            LoadFullCustomer();
            this.Show();
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
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Customer customer = GetCustomerNow();
                if (CustomerDAO.Instance.InsertCustomer(customer))
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullCustomer();
                }
                else
                    MessageBox.Show("Khách Hàng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCustomer()
        {
            if (!CheckFillInText(new Control[] { txbPhoneNumber, txbFullName, txbIDCard, txbNationality, txbAddress, comboBoxCustomerType }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Customer customerPre = groupCustomer.Tag as Customer;
                try
                {
                    Customer customerNow = GetCustomerNow();
                    if (customerNow.Equals(customerPre))
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = CustomerDAO.Instance.UpdateCustomer(customerNow, customerPre);
                        if (check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupCustomer.Tag = customerNow;
                            LoadFullCustomer();
                        }
                        else
                            MessageBox.Show("Khách Hàng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi Nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                btnAddCustomer.ButtonText = "Thêm Khách Hàng";
            }
            else
            {
                txbFullName.Text = row.Cells["colNameCustomer"].Value.ToString();
                txbAddress.Text = row.Cells["colAddress"].Value.ToString();
                txbIDCard.Text = row.Cells["colIDCard"].Value.ToString();
                txbNationality.Text = row.Cells["colNationality"].Value.ToString();
                txbPhoneNumber.Text = row.Cells["colPhone"].Value.ToString();
                comboBoxCustomerType.Text = row.Cells["colNameCustomerType"].Value.ToString();
                comboBoxSex.SelectedItem = row.Cells["colSex"].Value;
                datepickerDateOfBirth.Value = (DateTime)row.Cells["colDateOfBirth"].Value;
                Customer customer = new Customer(((DataRowView) row.DataBoundItem).Row);
                groupCustomer.Tag = customer;              
                btnAddCustomer.ButtonText = "Cập Nhật";
            }
        }

        #endregion


        #region GetData
        private Customer GetCustomerNow()
        {
            Customer customer = new Customer();
            customer.IdCard = int.Parse(txbIDCard.Text);
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
        private void dataGridViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomer.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewCustomer.SelectedRows[0];
                ChangeText(row);
            }
        }
        #endregion

    }
}
