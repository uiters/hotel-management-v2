using System.Data;
using System.Windows.Forms;
using HotelManager.DAO;
using HotelManager.DTO;
using System;

namespace HotelManager
{
    public partial class fServiceType : Form
    {
        #region Properties
        DataTable _tableSerViceType;
        public DataTable TableSerViceType
        {
            get => _tableSerViceType;
            private set
            {
                _tableSerViceType = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableSerViceType;
                dataGridViewServiceType.DataSource = source;
                bindingServiceType.BindingSource = source;
            }
        }

        #endregion

        #region Constructor
        public fServiceType()
        {
            InitializeComponent();
        }
        public fServiceType(DataTable table)
        {
            InitializeComponent();
            this.TableSerViceType = table;
        }
        #endregion

        #region Load
        private void LoadFullServiceType()
        {
            this.TableSerViceType = GetFullServiceType();
        }
        #endregion

        #region Click
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddServiceType_Click(object sender, EventArgs e)
        {
            if (btnAddServiceType.ButtonText.Contains("Thêm"))
                InsertServiceType();
            else
                UpdateServiceType();
        }
        #endregion

        #region GetData
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }
        private ServiceType GetServiceTypeNow()
        {
            ServiceType serviceType = new ServiceType();
            try
            {
                serviceType.Id = int.Parse(txbID.Text);
            }
            catch
            {
                serviceType.Id = -1;
            }
            serviceType.Name = txbName.Text;
            return serviceType;
        }
        #endregion

        #region Method
        private void InsertServiceType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txbName }))
            {
                try
                {
                    ServiceType serviceTypeNow = GetServiceTypeNow();
                    if (ServiceTypeDAO.Instance.InsertServiceType(serviceTypeNow))
                    {
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadFullServiceType();
                    }
                    else
                        MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Lỗi Nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void UpdateServiceType()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ServiceType serviceTypePre = groupServiceType.Tag as ServiceType;
                try
                {
                    ServiceType serviceTypeNow = GetServiceTypeNow();
                    if (serviceTypeNow.Equals(serviceTypePre))
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = ServiceTypeDAO.Instance.UpdateServiceType(serviceTypeNow, serviceTypePre);
                        if (check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupServiceType.Tag = serviceTypeNow;
                            LoadFullServiceType();
                        }
                        else
                            MessageBox.Show("Loại trạng thái đã tồn tại\nTrùng Mã trạng thái", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                txbID.Text = "Tự Động";
                txbName.Text = string.Empty;
                btnAddServiceType.ButtonText = "Thêm";
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                ServiceType roomType = new ServiceType(((DataRowView)row.DataBoundItem).Row);
                groupServiceType.Tag = roomType;
                btnAddServiceType.ButtonText = "Cập Nhật";
            }
        }


        #endregion

        #region Change
        private void dataGridViewServiceType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServiceType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewServiceType.SelectedRows[0];
                ChangeText(row);
            }
        }
        #endregion

    }
}
