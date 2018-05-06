using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoomType : Form
    {
        #region Property
        private DataTable _tableRoomType;
        public DataTable TableRoomType
        {
            get => _tableRoomType;
            private set
            {
                _tableRoomType = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableRoomType;
                dataGridViewRoomType.DataSource = source;
                bindingCustomerType.BindingSource = source;
            }
        }

        #endregion

        #region Constructor
        public fRoomType()
        {
            InitializeComponent();
        }
        public fRoomType(DataTable table)
        {
            InitializeComponent();
            TableRoomType = table;
            //LoadFullRoomType();
        }
        #endregion

        #region Load
        private void LoadFullRoomType()
        {
            this.TableRoomType = GetFullRoomType();
        }
        #endregion

        #region Click
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAddRoomType_Click(object sender, EventArgs e)
        {
            if (btnAddRoomType.ButtonText.Contains("Thêm"))
                InsertRoomType();
            else
                UpdateRoomType();
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridViewRoomType.SelectedRows)
            {
                Row.Selected = false;
            }
            int last = dataGridViewRoomType.Rows.Count - 1;
            dataGridViewRoomType.Rows[last].Selected = true;
        }
        #endregion

        #region GetData
        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        private RoomType GetRoomTypeNow()
        {
            RoomType roomType = new RoomType();
            try
            {
                roomType.Id = int.Parse(txbID.Text);
            }
            catch
            {
                roomType.Id = 0;
            }
            roomType.Name = txbName.Text;
            roomType.Price = int.Parse(txbPrice.Text);
            roomType.LimitPerson = int.Parse(txbLimitPerson.Text);
            return roomType;
        }
        #endregion

        #region Method
        private void InsertRoomType()
        {
            if (fCustomer.CheckFillInText(new Control[] { txbName, txbPrice, txbLimitPerson }))
            {
                try
                {
                    RoomType roomTypeNow = GetRoomTypeNow();
                    if (RoomTypeDAO.Instance.InsertRoomType(roomTypeNow))
                    {
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LoadFullRoomType();
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
        private void UpdateRoomType()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName, txbPrice, txbLimitPerson }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RoomType roomTypePre = groupRoomType.Tag as RoomType;
                try
                {
                    RoomType roomTypeNow = GetRoomTypeNow();
                    if (roomTypeNow.Equals(roomTypePre))
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = RoomTypeDAO.Instance.UpdateRoomType(roomTypeNow, roomTypePre);
                        if(check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoomType.Tag = roomTypeNow;
                            LoadFullRoomType();
                        }
                        else
                            MessageBox.Show("Loại Phòng đã tồn tại\nTrùng Mã phòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                txbID.Text = "Auto";
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                txbLimitPerson.Text = string.Empty;
                btnAddRoomType.ButtonText = "Thêm";
            }
            else
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                txbPrice.Text = row.Cells["colPrice"].Value.ToString();
                txbLimitPerson.Text = row.Cells["colLimitPerson"].Value.ToString();
                RoomType roomType = new RoomType(((DataRowView) row.DataBoundItem).Row);
                groupRoomType.Tag = roomType;
                btnAddRoomType.ButtonText = "Cập Nhật";
            }
        }

        #endregion

        #region Change
        private void DataGridViewRoomType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRoomType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewRoomType.SelectedRows[0];
                ChangeText(row);
            }
        }
        #endregion


    }
}
