using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fRoom : Form
    {
        #region Properties
        private fRoomType _fRoomtType;
        #endregion

        #region Constructor
        public fRoom()
        {
            InitializeComponent();
            LoadFullRoom();
            LoadFullRoomType();
            LoadFullStatusRoom();
            dataGridViewRoom.SelectionChanged += DataGridViewRoom_SelectionChanged;
        }

        #endregion

        #region Kick
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnAddRoom_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn thêm phòng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertRoom();
        }
        private void BtnRoomType_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fRoomtType.ShowDialog();
            this.LoadFullRoom();
            comboBoxRoomType.DataSource = _fRoomtType.TableRoomType;
            //comboBoxRoomType.Refresh();
            this.Show();
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txbID.Text = "Tự Động";
            txbNameRoom.Text = string.Empty;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MetroFramework.MetroMessageBox.Show(this, "Bạn có muốn cập nhật lại phòng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateRoom();
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            if (saveRoom.ShowDialog() == DialogResult.Cancel)
                return;
            else
            {
                bool check;
                try
                {
                    switch (saveRoom.FilterIndex)
                    {
                        case 2:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.XLSX);
                            break;
                        case 3:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.PDF);
                            break;
                        default:
                            check = ExportToExcel.Instance.Export(dataGridViewRoom, saveRoom.FileName, ModeExportToExcel.XLS);
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

        #endregion

        #region Load
        private void LoadFullRoom()
        {
            DataTable table = GetFullRoom();
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewRoom.DataSource = source;
            bindingRoom.BindingSource = source;
        }
        private void LoadFullStatusRoom()
        {
            DataTable table = GetFullStatusRoom();
            comboBoxStatusRoom.DataSource = table;
            comboBoxStatusRoom.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxStatusRoom.SelectedIndex = 0;
        }
        private void LoadFullRoomType()
        {
            DataTable table = GetFullRoomType();
            comboBoxRoomType.DataSource = table;
            comboBoxRoomType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxRoomType.SelectedIndex = 0;
            _fRoomtType = new fRoomType(table);
            txbPrice.DataBindings.Add(new Binding("Text", table, "price"));
            txbLimitPerson.DataBindings.Add(new Binding("Text", table, "limitPerson"));
        }
        #endregion

        #region Method
        private void InsertRoom()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbNameRoom, comboBoxStatusRoom, comboBoxRoomType }))
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Room roomNow = GetRoomNow();
                if (RoomDAO.Instance.InsertRoom(roomNow))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullRoom();
                }
                else
                    MetroFramework.MetroMessageBox.Show(this, "Phòng này đã tồn tại(Trùng mã số phòng)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MetroFramework.MetroMessageBox.Show(this, "Lỗi không thêm được phòng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateRoom()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbNameRoom, comboBoxStatusRoom, comboBoxRoomType }))
            {
                MetroFramework.MetroMessageBox.Show(this, "Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Room roomPre = groupRoom.Tag as Room;
                try
                {
                    Room roomNow = GetRoomNow();
                    if (roomNow.Equals(roomPre))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = RoomDAO.Instance.UpdateCustomer(roomNow, roomPre);
                        if (check)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoom.Tag = roomNow;
                            LoadFullRoom();
                        }
                        else
                            MetroFramework.MetroMessageBox.Show(this, "Phòng này chưa tồn tại\n", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MetroFramework.MetroMessageBox.Show(this, "Lỗi cập nhật phòng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if(row.IsNewRow)
            {
                txbID.Text = "Tự Động";
                txbNameRoom.Text = string.Empty;
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                txbID.Text = row.Cells["colIDRoom"].Value.ToString();
                txbNameRoom.Text = row.Cells["colName"].Value.ToString();
                comboBoxRoomType.SelectedIndex = (int)row.Cells["colIdRoomType"].Value - 1;
                comboBoxStatusRoom.SelectedIndex = (int)row.Cells["colIdStatus"].Value - 1;
                Room room = new Room(((DataRowView)row.DataBoundItem).Row);
                groupRoom.Tag = room;
            }
        }
        #endregion

        #region Get Data
        private DataTable GetFullRoom()
        {
            return RoomDAO.Instance.LoadFullRoom();
        }
        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        private DataTable GetFullStatusRoom()
        {
            return StatusRoomDAO.Instance.LoadFullStatusRoom();
        }
        private Room GetRoomNow()
        {
            Room room = new Room();
            try
            {
                room.Id = int.Parse(txbID.Text);
            }
            catch
            {
                room.Id = -1;
            }
            room.RoomName = txbNameRoom.Text;
            int index = comboBoxRoomType.SelectedIndex;
            room.IdRoomType = (int)((DataTable)comboBoxRoomType.DataSource).Rows[index]["id"];
            index = comboBoxStatusRoom.SelectedIndex;
            room.IdStatusRoom = (int)((DataTable)comboBoxStatusRoom.DataSource).Rows[index]["id"];
            return room;
        }
        #endregion

        #region Change
        private void DataGridViewRoom_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridViewRoom.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewRoom.SelectedRows[0];
                ChangeText(row);
            }
        }
        #endregion

    }
}
