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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddCustomerType_Click(object sender, EventArgs e)
        {
                UpdateCustomerType();
        }

        #endregion

        #region Method
        
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
                    CustomerType customerTypeNow = new CustomerType(int.Parse(txbID.Text), txbName.Text);
                    if (customerTypeNow.Equals(customerTypePre))
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = CustomerTypeDAO.Instance.UpdateCustomerType(customerTypeNow);
                        if (check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupCutomerType.Tag = customerTypeNow;
                            LoadFullCustomerType();
                        }
                        else
                            MessageBox.Show("Loại Khách Hàng đã tồn tại\nTrùng Mã Khách Hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            if (!row.IsNewRow)
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
               
                CustomerType customerType = new CustomerType(((DataRowView)row.DataBoundItem).Row);
                groupCutomerType.Tag = customerType;
            }
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
        private void dataGridViewCustomerType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCustomerType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewCustomerType.SelectedRows[0];
                ChangeText(row);
            }
        }

        #endregion


    }
}
