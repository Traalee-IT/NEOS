using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhuTro.Model;
using QuanLyKhuTro.DAO;
using System.Globalization;
using QuanLyKhuTro.CustomDesign;

namespace QuanLyKhuTro.View
{
    public partial class RoomManagerForm : Form
    {

        private Room roomSelected = null;

        public RoomManagerForm()
        {
            InitializeComponent();
           
        }

        #region Method

        public bool isEmpty(string str)
        {
            return str.Length == 0 || str == "";
        }

        private void loadRoom()
        {
            flowLayoutRoom.Controls.Clear();
            
            List<Room> list = RoomDao.getInstance().loadListRoom();
            showListRoom(list);
        }

        private void showListRoom(List<Room> list)
        {

            foreach (Room room in list)
            {
                Button btn = new Button() { Width = 130, Height = 130 };
                btn.Text = room.name_Room;
                btn.Click += Btn_Click;
                btn.Tag = room;

                if (room.status.Equals("Đã thuê"))
                {
                    btn.Text += "\n " + room.numberPeople + " người";
                    btn.BackColor = Color.FromArgb(0, 255, 0);
                }
                else if (room.status.Equals(Room.listStatus[2]))
                {
                    btn.BackColor = Color.FromArgb(201, 175, 175);
                }
                btn.Text += "\n" + room.status;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.BackgroundImage = Properties.Resources.white_home_icon_png_3;
                btn.Font = new Font("Arial", 9);
                // btn.FlatStyle = FlatStyle.Flat;
                flowLayoutRoom.Controls.Add(btn);
            }
        }

        //Xử lý click vào phòng bất kỳ thì hiển thị thông tin
        private void ShowInforRoom(Room room)
        {

            txtIdRoom.Text = room.ID_Room.ToString();
            txtNameRoom.Text = room.name_Room;
            nbDienTich.Value = (decimal)room.dienTich;

            decimal moneyDecimal = (decimal)room.price;
            nbPrice.Value = Math.Round(moneyDecimal, 2);


            if (room.status.Equals(Room.listStatus[1]))
            {
                cbListStatus.DataSource = Room.listStatus;
                cbListStatus.Enabled = false;
            }
            else
            {
                cbListStatus.DataSource = new List<String> { Room.listStatus[0], Room.listStatus[2] };
                cbListStatus.Enabled = true;
            }

            cbListStatus.Text = room.status;
        }

        private void setUpDisplayMemberOfRoom()
        {
            // Tạo các cột cho DataGridView

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "ID_Customer"; // Thuộc tính ID_Customer của Customer
            idColumn.HeaderText = "ID";
            

            DataGridViewTextBoxColumn fullNameColumn = new DataGridViewTextBoxColumn();
            fullNameColumn.DataPropertyName = "FullName"; // Thuộc tính FullName của Customer
            fullNameColumn.HeaderText = "Họ tên";

            DataGridViewTextBoxColumn birthDateColumn = new DataGridViewTextBoxColumn();
            birthDateColumn.DataPropertyName = "BirthOfDate"; // Thuộc tính BirthOfDate của Customer
            birthDateColumn.HeaderText = "Ngày sinh";

            DataGridViewTextBoxColumn genderColumn = new DataGridViewTextBoxColumn();
            genderColumn.DataPropertyName = "gender"; // Thuộc tính gender của Customer
            genderColumn.HeaderText = "Giới tính";

            DataGridViewTextBoxColumn cccdColumn = new DataGridViewTextBoxColumn();
            cccdColumn.DataPropertyName = "CCCD"; // Thuộc tính gender của Customer
            cccdColumn.HeaderText = "Căn cước công dân";

            DataGridViewTextBoxColumn emailColumn = new DataGridViewTextBoxColumn();
            emailColumn.DataPropertyName = "Email"; // Thuộc tính Email của Customer
            emailColumn.HeaderText = "Email";

            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.DataPropertyName = "NumberPhone"; // Thuộc tính NumberPhone của Customer
            phoneColumn.HeaderText = "Số điện thoại";

            DataGridViewTextBoxColumn addressColumn = new DataGridViewTextBoxColumn();
            addressColumn.DataPropertyName = "Address"; // Thuộc tính Address của Customer
            addressColumn.HeaderText = "Địa chỉ";

            DataGridViewTextBoxColumn checkInDateColumn = new DataGridViewTextBoxColumn();
            checkInDateColumn.DataPropertyName = "ThoiGianDenO"; // Thuộc tính ThoiGianDenO của Customer
            checkInDateColumn.HeaderText = "Ngày đến ở";

            DataGridViewTextBoxColumn chucVu = new DataGridViewTextBoxColumn();
            chucVu.DataPropertyName = "chucVu"; // Thuộc tính ThoiGianDenO của Customer
            chucVu.HeaderText = "Chức vụ";
            // Thêm các cột vào DataGridView

            gridViewMember.Columns.Add(idColumn);
            gridViewMember.Columns.Add(fullNameColumn);
            gridViewMember.Columns.Add(birthDateColumn);
            gridViewMember.Columns.Add(genderColumn);
            gridViewMember.Columns.Add(cccdColumn);
            gridViewMember.Columns.Add(emailColumn);
            gridViewMember.Columns.Add(phoneColumn);
            gridViewMember.Columns.Add(addressColumn);
            gridViewMember.Columns.Add(checkInDateColumn);
            gridViewMember.Columns.Add(chucVu);
           
            gridViewMember.Font = new Font("Times New Roman", 10);
            gridViewMember.ReadOnly = true;
        }


        private void refreshForm()
        {
            loadRoom();
            txtIdRoom.Text = "";
            nbDienTich.Value = 0;
            txtNameRoom.Text = "";
            nbPrice.Value = 0;
            txtSearch.Text = "";
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            btnThanhToan.Enabled = false;
            btnAdd.Enabled = true;
            btnQlDichVu.Enabled = false;
            btnLichSuThanhToan.Enabled = false;
            roomSelected = null;
            gridViewMember.DataSource = null;
            gridViewMember.Rows.Clear();
            btnRemoveMember.Visible = false;
            cbListStatus.DataSource = new List<String> { Room.listStatus[0], Room.listStatus[2] };
            setUpDisplayMemberOfRoom();
        }

        //Load thông tin thành viên của phòng
        private void loadMemberOfTheRoom()
        {

            if (roomSelected.memberList == null)
            {
                roomSelected.memberList = RoomDao.getInstance().getListMember(roomSelected.ID_Room);
            }


            showInforMemberOfRoom();
            btnQlDichVu.Enabled = true;
            if (roomSelected.memberList != null && roomSelected.memberList.Count <= 0)
            {
                btnQlDichVu.Enabled = false;
                btnThanhToan.Enabled = false;

                gridViewMember.ReadOnly = true;
            }
            else if (roomSelected.memberList.Count == 1)
            {
                btnRemoveMember.Visible = false;
            }
            else
            {
                btnRemoveMember.Visible = true;              
                btnThanhToan.Enabled = true;
                gridViewMember.ReadOnly = false;
            }

        }

        public void showInforMemberOfRoom()
        {
            gridViewMember.Rows.Clear();
            foreach (MemberRoom item in roomSelected.memberList)
            {
                // Lấy chỉ mục của hàng hiện tại
                int rowIndex = gridViewMember.Rows.Add();

                // Gán giá trị cho các cột sử dụng chỉ mục của hàng
                gridViewMember.Rows[rowIndex].Cells[1].Value = item.customer.ID_Customer;
                gridViewMember.Rows[rowIndex].Cells[2].Value = item.customer.FullName;
                gridViewMember.Rows[rowIndex].Cells[3].Value = item.customer.BirthOfDate;
                gridViewMember.Rows[rowIndex].Cells[4].Value = item.customer.gender;
                gridViewMember.Rows[rowIndex].Cells[5].Value = item.customer.CCCD;
                gridViewMember.Rows[rowIndex].Cells[6].Value = item.customer.Email;
                gridViewMember.Rows[rowIndex].Cells[7].Value = item.customer.NumberPhone;
                gridViewMember.Rows[rowIndex].Cells[8].Value = item.customer.Address;
                gridViewMember.Rows[rowIndex].Cells[9].Value = item.customer.ThoiGianDenO;
                gridViewMember.Rows[rowIndex].Cells[10].Value = item.chucVu;
            }
        }

        #endregion



        #region Events
        //Clcik vào 1 phòng bất kỳ
        private void Btn_Click(object sender, EventArgs e)
        {
            roomSelected = (sender as Button).Tag as Room;
            ShowInforRoom(roomSelected);
            btnRemove.Enabled = true;
            btnUpdate.Enabled = true;
            btnThanhToan.Enabled = true;
            btnAdd.Enabled = false;
            btnLichSuThanhToan.Enabled = true;

            loadMemberOfTheRoom();


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (isEmpty(txtSearch.Text))
            {
                CustomMessageBox.Show("Nhập tên phòng cần tìm?");
            }
            else
            {
                flowLayoutRoom.Controls.Clear();
                List<Room> list = RoomDao.getInstance().searchByName(txtSearch.Text);
                showListRoom(list);

            }
        }
        private void btnRemoveMember_Click_1(object sender, EventArgs e)
        {
            if (listIDMember.Count == roomSelected.memberList.Count)
            {
                CustomMessageBox.Show("CẢNH BÁO!\nBạn không thể xóa tất cả thành viên hiện có trong phòng. " +
                    "Bạn có thể \"hủy hợp đồng\" để cập nhật trạng thái của phòng.\nMỗi phòng cần phải có 1 trưởng phòng", "Xóa thành viên");
            }
            else
            {
                if (RoomDao.getInstance().RemoveMemberOfRoom(listIDMember, roomSelected.ID_Room))
                {
                    CustomMessageBox.Show("Xóa thành công");
                    refreshForm();
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                        "Lỗi",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
                }
            }

        }

        private void btnQlDichVu_Click(object sender, EventArgs e)
        {
            QuanLyDichVuChoPhong frm = new QuanLyDichVuChoPhong();
            frm.room = roomSelected;
            frm.ShowDialog();
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            FormThanhToan frm = new FormThanhToan(roomSelected);
            frm.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (roomSelected.status.Equals(Room.listStatus[1]))
            {
                var result = CustomMessageBox.Show("Phòng đang được thuê, không thể thực hiện tác vụ này!",
               "",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);

            }
            else
            {

                DialogResult result = CustomMessageBox.Show("Bạn chắc chắn muốn xóa phòng này?\n Không thể hoàn tác tác vụ này.",
              "Cảnh báo",
              MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (RoomDao.getInstance().deleteRoom(roomSelected.ID_Room))
                    {
                        CustomMessageBox.Show("Xóa thành công");
                        refreshForm();
                    }
                    else
                    {
                        CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                "Lỗi",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isEmpty(txtNameRoom.Text))
            {
                CustomMessageBox.Show("Tên phòng không  được để trống.",
                "Thêm phòng", MessageBoxButtons.OK);
            }
            else if (nbDienTich.Value <= 0)
            {
                CustomMessageBox.Show("Giá phòng và diện tích phải không âm.",
                  "Thêm phòng", MessageBoxButtons.OK);
            }
            else
            {
                roomSelected.name_Room = txtNameRoom.Text;
                roomSelected.price = (float)nbPrice.Value;
                roomSelected.dienTich = (float)nbDienTich.Value;
                roomSelected.status = cbListStatus.Text;


                if (RoomDao.getInstance().update(roomSelected))
                {
                    refreshForm();
                    CustomMessageBox.Show("Dữ liệu đã được cập nhật");
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                 "Lỗi",
                 MessageBoxButtons.RetryCancel,
                 MessageBoxIcon.Error);
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isEmpty(txtNameRoom.Text))
            {
                CustomMessageBox.Show("Tên phòng không  được để trống.",
                 "Thêm phòng", MessageBoxButtons.OK);
            }
            else if (nbPrice.Value < 0 || nbDienTich.Value <= 0)
            {
                CustomMessageBox.Show("Giá phòng và diện tích phải không âm.",
                 "Thêm phòng", MessageBoxButtons.OK);
            }
            else
            {
                Room room = new Room();
                room.name_Room = txtNameRoom.Text;
                room.dienTich = (float)nbDienTich.Value;
                room.price = (float)nbPrice.Value;

                bool result = RoomDao.getInstance().insertRoom(room);

                if (result)
                {
                    refreshForm();
                    CustomMessageBox.Show("Thêm thành công");
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                "Lỗi",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
                }
            }
        }

        private void btnLichSuThanhToan_Click(object sender, EventArgs e)
        {
            FormPaymentHistory frm = new FormPaymentHistory(roomSelected);
            frm.ShowDialog();
        }

        #endregion


        private List<int> listIDMember = new List<int>();
        private void gridViewMember_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0 && e.ColumnIndex >= 0 && (gridViewMember.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) == true)
            {
                // Lấy thông tin dòng đã chọn
                DataGridViewRow selectedRow = gridViewMember.Rows[e.RowIndex];

                // Lấy giá trị của CheckBox
                bool isChecked = (bool)selectedRow.Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    listIDMember.Add(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                }
                else
                {
                    listIDMember.Remove(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                }
            }
        }

       
        private void RoomManagerForm_Load(object sender, EventArgs e)
        {
            cbListStatus.DataSource = new List<String> { Room.listStatus[0], Room.listStatus[2] };
            loadRoom();
            setUpDisplayMemberOfRoom();
        }

      
    }
}
