using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhuTro.CustomDesign;
using QuanLyKhuTro.DAO;
using QuanLyKhuTro.Model;

namespace QuanLyKhuTro.View
{
    public partial class QuanLyHopDong : Form
    {
        private List<int> listIdCustomerSelected = new List<int>();
        private ContractDao contractDao = new ContractDao();
        public QuanLyHopDong()
        {
            InitializeComponent();
            
        }

        private void InitView()
        {
            cbRoom.DataSource = RoomDao.getInstance().ListRoomChuaThue().Tables[0];
            cbRoom.DisplayMember = "TenPhong";
            cbRoom.ValueMember = "MaPhong";
            
            dtgvContract.DataSource = contractDao.selectListContract().Tables[0];
            dtgvCustomer.DataSource = CustomerDAO.getInstance().ListKhachHangChuaThuePhong().Tables[0];
        }

        private void CustomDatagridview()
        {
            //Custom cho hiển thị khách hàng chưa thuê phòng
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.DataPropertyName = "IsSelected"; 
            checkbox.HeaderText = "Chọn";
            checkbox.Width = 55;
          

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "MaKH"; 
            idColumn.HeaderText = "ID";
            idColumn.ReadOnly = true;
        

            DataGridViewTextBoxColumn fullNameColumn = new DataGridViewTextBoxColumn();
            fullNameColumn.DataPropertyName = "HoTen"; 
            fullNameColumn.HeaderText = "Họ tên";
            idColumn.ReadOnly = true;

            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.DataPropertyName = "SoDienThoai"; 
            phoneColumn.HeaderText = "Số điện thoại";
            idColumn.ReadOnly = true;

            dtgvCustomer.Columns.Add(checkbox);
            dtgvCustomer.Columns.Add(idColumn);
            dtgvCustomer.Columns.Add(fullNameColumn);
            dtgvCustomer.Columns.Add(phoneColumn);

        }

        private void QuanLyHopDong_Load(object sender, EventArgs e)
        {
            CustomDatagridview();
            InitView();
            
        }

        private void refreshForm()
        {
            dtgvContract.DataSource = null;
            dtgvCustomer.DataSource = null;
            InitView();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnKetThucHopDong.Enabled = false;

            txtIDContract.Text = null;
            listIdCustomerSelected.Clear();

     
        }

       

        private void dtgvCustomer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0 && e.ColumnIndex >= 0 && (dtgvCustomer.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) == true)
            {
                // Lấy thông tin dòng đã chọn
                DataGridViewRow selectedRow = dtgvCustomer.Rows[e.RowIndex];

                // Lấy giá trị của CheckBox
                bool isChecked = (bool)selectedRow.Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    listIdCustomerSelected.Add(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                }
                else
                {
                    listIdCustomerSelected.Remove(Convert.ToInt32(selectedRow.Cells[1].Value.ToString()));
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dateEnd.Value < dateStart.Value)
            {
                CustomMessageBox.Show("Thời gian hết hợp đồng phải lớn hơn ngày làm hợp đông.");
            
            }else if (listIdCustomerSelected.Count <= 0)
            {
                CustomMessageBox.Show("Bạn chưa chọn người thuê phòng.");      
            }
            else
            {
                Contract contract = new Contract();
                contract.MaPhong = (int)cbRoom.SelectedValue;
                contract.NgayLamHopDong = dateStart.Value;
                contract.NgayHetHan = dateEnd.Value;
                contract.SoTienDatCoc = (float)nbDatCoc.Value;
               
                if (contractDao.AddContract(contract, listIdCustomerSelected))
                {
                    refreshForm();

                    DialogResult result = CustomMessageBox.Show("Đã tạo hợp đồng mới thành công, Bạn có muốn xuất hợp đồng?.",
                        "Hợp đồng",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);     
                    if(result == DialogResult.Yes)
                    {

                    }
                  
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

        private void dtgvContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {


                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnKetThucHopDong.Enabled = true;
               

                txtIDContract.Text = dtgvContract.Rows[index].Cells[0].Value.ToString();
                lbIDRoom.Text = dtgvContract.Rows[index].Cells[1].Value.ToString();
               
                // dtgvContract.Rows[index].Cells[2].Value.ToString();
                // Chuyển đổi chuỗi ngày sang DateTime
                if (DateTime.TryParseExact(dtgvContract.Rows[index].Cells[3].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                {
                    dateStart.Value = startDate;
                }

                if (DateTime.TryParseExact(dtgvContract.Rows[index].Cells[4].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                {
                    dateEnd.Value = endDate;
                }            
                nbDatCoc.Text = dtgvContract.Rows[index].Cells[5].Value.ToString();
              
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dateEnd.Value < dateStart.Value)
            {
                CustomMessageBox.Show("Thời gian hết hợp đồng phải lớn hơn ngày làm hợp đông.");

            }
            else
            {
                bool resultUpdate = false;

                Contract contract = new Contract();
                contract.MaHopDong = Convert.ToInt32(txtIDContract.Text);
                contract.NgayLamHopDong = dateStart.Value;
                contract.NgayHetHan = dateEnd.Value;
                contract.SoTienDatCoc = (float)nbDatCoc.Value;
               if((int)cbRoom.SelectedValue != Convert.ToInt32(lbIDRoom.Text))
                {
                    contract.MaPhong = (int)cbRoom.SelectedValue;

                    var result = CustomMessageBox.Show("Bạn có chắc muốn thay đổi hợp đồng sang phòng mới đã chọn?",
                     "Phát hiện thay đổi",
                     MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if(result == DialogResult.OK)
                    {
       
                            resultUpdate = contractDao.ChangeRoom((int)cbRoom.SelectedValue, Convert.ToInt32(lbIDRoom.Text));
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    contract.MaPhong = Convert.ToInt32(lbIDRoom.Text);
                }

                if (resultUpdate && contractDao.update(contract, listIdCustomerSelected))
                {
                    refreshForm();
                    CustomMessageBox.Show("Dữ liệu đã được cập nhật thành công.");
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

        private void btnKetThucHopDong_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.Show("Bạn có chắc chắn muốn hủy hợp đồng sớm.",
                "Cảnh báo",
                MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                if (contractDao.KetThucHopDong(Convert.ToInt32(txtIDContract.Text),Convert.ToInt32(lbIDRoom.Text))){
                    refreshForm();
                    CustomMessageBox.Show("Dữ liệu đã được cập nhật thành công.");
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
