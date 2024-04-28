using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhuTro.CustomDesign;
using QuanLyKhuTro.DAO;
using QuanLyKhuTro.Model;
namespace QuanLyKhuTro.View
{
    public partial class QuanLyDichVuChoPhong : Form
    {

        private List<int> listServiceSelected = new List<int>();
        private List<int> listServiceUnChecked = new List<int>();

        public QuanLyDichVuChoPhong()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Room room;

        private void button1_Click(object sender, EventArgs e)
        {
            if(listServiceSelected.Count <= 0)
            {
                MessageBox.Show("Chọn dịch vụ cần thêm trước khi thao tác!");
            }
            else
            {
                DialogResult result = CustomMessageBox.Show("Bạn nên thêm dịch vụ vào đầu mỗi tháng để thống kê luôn được chính xác.\nBấm Yes để thêm",
                "Cảnh báo",
                MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (DichVuDao.getInstance().addServiceForRoom(room.ID_Room, listServiceSelected))
                    {
                        CustomMessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                        "Error-Stop Icon",
                                        MessageBoxButtons.RetryCancel,
                                        MessageBoxIcon.Error);
                    }
                }
                refreshForm();

            }
        }

        public void refreshForm()
        {
            loadData();
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            listServiceSelected.Clear();
            listServiceUnChecked.Clear();

        }

        public void loadData()
        {
            gridViewNotUse.DataSource = DichVuDao.getInstance().getServiceNotUse(room.ID_Room);
            gridViewUsed.DataSource = DichVuDao.getInstance().getServiceUsed(room.ID_Room);
            if (gridViewUsed.Rows.Count <= 0)
            {
                btnDeleteAll.Enabled = false;
            }
            else
            {
                btnDeleteAll.Enabled = true;
            }
            lbCountService.Text = gridViewUsed.Rows.Count.ToString();
        }

        private void QuanLyDichVuChoPhong_Load(object sender, EventArgs e)
        {
            // Tạo một cột kiểu DataGridViewCheckBoxColumn
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.HeaderText = "Chọn";
            checkboxColumn.Name = "CheckboxColumn";
            checkboxColumn.Width = 55; // Độ rộng của cột

            DataGridViewCheckBoxColumn checkboxColumn2 = new DataGridViewCheckBoxColumn();
            checkboxColumn2.HeaderText = "Chọn";
            checkboxColumn2.Name = "CheckboxColumn";
            checkboxColumn2.Width = 55; // Độ rộng của cột

            // Thêm cột vào DataGridView
            gridViewNotUse.Columns.Insert(0, checkboxColumn);
            gridViewUsed.Columns.Insert(0, checkboxColumn2);

            loadData();

            lbNameRoom.Text = room.name_Room;
        }



    
  

        private void gridViewNotUse_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem ô dữ liệu đã thay đổi có phải là ô của CheckBox không
            if (e.RowIndex>=0 && e.ColumnIndex >= 0 && gridViewNotUse.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                // Lấy thông tin dòng đã chọn
                DataGridViewRow selectedRow = gridViewNotUse.Rows[e.RowIndex];

                // Lấy giá trị của CheckBox
                bool isChecked = (bool)selectedRow.Cells[e.ColumnIndex].Value;

                // Kiểm tra xem CheckBox có được chọn hay không
                if (isChecked)
                {
                    listServiceSelected.Add(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                    btnAdd.Enabled = true;
                }
                else
                {
                    listServiceSelected.Remove(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                }

                if (listServiceSelected.Count == 0)
                {
                    btnAdd.Enabled = false;
                }
           
            }
        }

        private void gridViewUsed_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem ô dữ liệu đã thay đổi có phải là ô của CheckBox không
            if (e.ColumnIndex >= 0 && gridViewUsed.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                // Lấy thông tin dòng đã chọn
                DataGridViewRow selectedRow = gridViewUsed.Rows[e.RowIndex];

                // Lấy giá trị của CheckBox
                bool isChecked = (bool)selectedRow.Cells[e.ColumnIndex].Value;

                // Kiểm tra xem CheckBox có được chọn hay không
                if (isChecked)
                {
                    listServiceUnChecked.Add(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                    btnUpdate.Enabled = true;
                }
                else
                {
                    listServiceUnChecked.Remove(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                }

                if (listServiceUnChecked.Count == 0)
                {
                    btnUpdate.Enabled = false;
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listServiceUnChecked.Count <= 0)
            {
                CustomMessageBox.Show("Chọn dịch vụ cần bỏ trước khi thao tác!");
                
            }
            else
            {
            
                DialogResult result = CustomMessageBox.Show("Bạn chắc chắn muốn hủy dịch vụ này cho phòng",
                 "Huỷ dịch vụ",
                 MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (DichVuDao.getInstance().removeServiceOfRoom(room.ID_Room, listServiceUnChecked))
                    {     
                        CustomMessageBox.Show("Đã xóa dịch vụ thành công");
                    }
                    else
                    {
                        CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                        "Error-Stop Icon",
                                        MessageBoxButtons.RetryCancel,
                                        MessageBoxIcon.Error);
                    }
                }
                refreshForm();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.Show("Bạn chắc chắn muốn hủy tất cả dịch vụ mà phòng này đang sử dụng?",
               "Quản lý dịch vụ",
               MessageBoxButtons.YesNo);
          
            if (result == DialogResult.Yes)
            {
                if (DichVuDao.getInstance().deleteAllServiceOfTheRoom(room.ID_Room))
                {
                    refreshForm();
                    CustomMessageBox.Show("Đã hủy tất cả dịch vụ");
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                    "Error-Stop Icon",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
