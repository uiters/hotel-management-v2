using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fStatusRoom : Form
    {
        #region Properties
        DataTable _tableStatusRoom;
        public DataTable TableStatusRoom
        {
            get => _tableStatusRoom;
            private set
            {
                _tableStatusRoom = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableStatusRoom;
                dataGridViewStatusRoom.DataSource = source;
                bindingStatusRoom.BindingSource = source;
            }
        }
        #endregion

        #region Constructor
        public fStatusRoom()
        {
            InitializeComponent();
        }
        public fStatusRoom(DataTable table)
        {
            InitializeComponent();
            this.TableStatusRoom = table;
        }
        #endregion

        #region Load
        private void LoadFullStatusRoom()
        {
            this.TableStatusRoom = GetFullStatusRoom();
        }
        #endregion

        #region Click
        private void BtnUpdateStatusRoom_Click(object sender, EventArgs e)
        {
                UpdateStatusRoom();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow Row in dataGridViewStatusRoom.SelectedRows)
        //    {
        //        Row.Selected = false;
        //    }
        //    int last = dataGridViewStatusRoom.RowCount - 1;
        //    dataGridViewStatusRoom.Rows[last].Selected = true;
        //}
        #endregion

        #region GetData
        private DataTable GetFullStatusRoom()
        {
            return StatusRoomDAO.Instance.LoadFullStatusRoom();
        }
        private StatusRoom GetStatusRoomNow()
        {
            StatusRoom statusRoom = new StatusRoom();
            try
            {
                statusRoom.Id = int.Parse(txbID.Text);
            }
            catch
            {
                statusRoom.Id = -1;
            }
            statusRoom.Name = txbName.Text;
            return statusRoom;
        }
        #endregion

        #region Method
        //private void InsertStatusRoom()
        //{
        //    if (fCustomer.CheckFillInText(new Control[] { txbName }))
        //    {
        //        try
        //        {
        //            StatusRoom statusRoomNow = GetStatusRoomNow();
        //            if (StatusRoomDAO.Instance.InsertStatusRoom(statusRoomNow))
        //            {
        //                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                this.LoadFullStatusRoom();
        //            }
        //            else
        //                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Lỗi Nhập dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //        MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        private void UpdateStatusRoom()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbName }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                StatusRoom statusRoomPre = groupStatusRoom.Tag as StatusRoom;
                try
                {
                    StatusRoom statusRoomNow = GetStatusRoomNow();
                    if (statusRoomNow.Equals(statusRoomPre))
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = StatusRoomDAO.Instance.UpdateStatusRoom(statusRoomNow, statusRoomPre);
                        if (check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupStatusRoom.Tag = statusRoomNow;
                            LoadFullStatusRoom();
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
            if (!row.IsNewRow)
            {
                txbID.Text = row.Cells["colID"].Value.ToString();
                txbName.Text = row.Cells["colName"].Value.ToString();
                StatusRoom roomType = new StatusRoom(((DataRowView)row.DataBoundItem).Row);
                groupStatusRoom.Tag = roomType;
            }
        }

        #endregion

        #region Change
        private void DataGridViewStatusRoom_SelectionChanged(object sender, System.EventArgs e)
        {
            if (dataGridViewStatusRoom.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewStatusRoom.SelectedRows[0];
                ChangeText(row);
            }
        }

        #endregion
    }
}
