using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fCustomerType : Form
    {
        #region Properties
        private DataTable table;
        public DataTable Table
        {
            get => table;
            private set
            {
                table = value;
                BindingSource source = new BindingSource();
                source.DataSource = table;
                dataGridViewCustomerType.DataSource = source;
                bindingCustomerType.BindingSource = source;
            }
        }
        #endregion

        #region Constructor
        public fCustomerType()
        {
            InitializeComponent();
        }
        public fCustomerType(DataTable table)
        {
            InitializeComponent();
            this.Table = table;
        }

        #endregion

        #region Load
        private void LoadFullCustomerType()
        {
            this.Table = GetFullCustomerType();
        }
        #endregion

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAddCustomerType_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn thêm loại khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertCustomerType();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật loại khách hàng này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateCustomerType();
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbID.Text = "Tự Động";
            txbName.Text = string.Empty;
        }
        #endregion

        #region Method
        private void InsertCustomerType()
        {
            if (CheckFill(new Control[] { txbName }))
            {
                try
                {
                    if (CustomerTypeDAO.Instance.InsertCustomerType(txbName.Text))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadFullCustomerType();
                    }
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Loại khách hàng này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi Nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateCustomerType()
        {
            if(!CheckFill(new Control[] { txbName}))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CustomerType customerTypePre = groupCutomerType.Tag as CustomerType;
                try
                {
                    CustomerType customerTypeNow = GetCustomerTypeNow();
                    if (customerTypeNow.Equals(customerTypePre))
                        MetroFramework.MetroMessageBox.Show(this, "Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = CustomerTypeDAO.Instance.UpdateCustomerType(customerTypeNow);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupCutomerType.Tag = customerTypeNow;
                            LoadFullCustomerType();
                        }
                        else
                            MetroFramework.MetroMessageBox.Show(this, "Loại khách hàng này chưa tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi nhập liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                txbID.Text = "Tự Động";
                txbName.Text = string.Empty;
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                CustomerType customerType = new CustomerType(((DataRowView)row.DataBoundItem).Row);
                groupCutomerType.Tag = customerType;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }
        private CustomerType GetCustomerTypeNow()
        {
            if (txbID.Text.Contains("T"))
                return new CustomerType(0, txbName.Text);
            else
                return new CustomerType(int.Parse(txbID.Text), txbName.Text);
        }
        public bool CheckFill(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == "")
                    return false;
            }
            return true;
        }

        #endregion

        #region GetData
        private DataTable GetFullCustomerType()
        {
            return CustomerTypeDAO.Instance.LoadFullCustomerType();
        }
        #endregion
  
        #region Change
        private void DataGridViewCustomerType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomerType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewCustomerType.SelectedRows[0];
                ChangeText(row);
            }
        }


        #endregion

        #region Key
        private void FCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnAddCustomerType_Click(sender, e);
            }
        }


        #endregion

    }
}
