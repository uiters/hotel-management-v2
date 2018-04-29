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
        private fStatusRoom _fStatusRoom;
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (btnAddRoom.ButtonText.Contains("Thêm"))
                InsertRoom();
            else
                UpdateRoom();
        }
        private void btnRoomType_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fRoomtType.ShowDialog();
            this.LoadFullRoom();
            comboBoxRoomType.DataSource = _fRoomtType.TableRoomType;
            //comboBoxRoomType.Refresh();
            this.Show();
        }
        private void btnStatusRoom_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fStatusRoom.ShowDialog();
            comboBoxStatusRoom.DataSource = _fStatusRoom.TableStatusRoom;
            //comboBoxStatusRoom.re
            this.Show();
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
            _fStatusRoom = new fStatusRoom(table);
        }
        private void LoadFullRoomType()
        {
            DataTable table = GetFullRoomType();
            comboBoxRoomType.DataSource = table;
            comboBoxRoomType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                comboBoxRoomType.SelectedIndex = 0;
            _fRoomtType = new fRoomType(table);
        }
        #endregion

        #region Method
        private void InsertRoom()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbNameRoom, comboBoxStatusRoom, comboBoxRoomType }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Room roomNow = GetRoomNow();
                if (RoomDAO.Instance.InsertRoom(roomNow))
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFullRoom();
                }
                else
                    MessageBox.Show("Phòng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateRoom()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txbNameRoom, comboBoxStatusRoom, comboBoxRoomType }))
            {
                MessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = RoomDAO.Instance.UpdateCustomer(roomNow, roomPre);
                        if (check)
                        {
                            MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoom.Tag = roomNow;
                            LoadFullRoom();
                        }
                        else
                            MessageBox.Show("Phòng đã tồn tại\nTrùng số chứng minh nhân dân", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if(row.IsNewRow)
            {
                txbID.Text = "Tự Động";
                txbNameRoom.Text = string.Empty;
                btnAddRoom.ButtonText = "Thêm Phòng";
            }
            else
            {
                txbID.Text = row.Cells["colIDRoom"].Value.ToString();
                txbNameRoom.Text = row.Cells["colName"].Value.ToString();
                comboBoxRoomType.Text = row.Cells["colNameRoomType"].Value.ToString();
                comboBoxStatusRoom.Text = row.Cells["colStatus"].Value.ToString();
                Room room = new Room(((DataRowView)row.DataBoundItem).Row);
                groupRoom.Tag = room;
                btnAddRoom.ButtonText = "Cập nhật";
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
