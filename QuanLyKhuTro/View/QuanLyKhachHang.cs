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
    public partial class QuanLyKhachHang : Form
    {

        /// <summary>
        /// Lưu ID phòng mỗi khi có 1 KH được chọn từ datagridvew
        /// Mục tiêu để cập nhật và xóa dữ liệu khách hàng
        /// Nó sẽ được xóa mỗi khi reset form
        /// </summary>
        private string ID_selected;
        public QuanLyKhachHang()
        {
            InitializeComponent();

        }


        private void setUpDisplayCustomer()
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
            birthDateColumn.DefaultCellStyle.Format = "dd-MM-yyyy";


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


            // Thêm các cột vào DataGridView

            dtgvCustomer.Columns.Add(idColumn);
            dtgvCustomer.Columns.Add(fullNameColumn);
            dtgvCustomer.Columns.Add(birthDateColumn);
            dtgvCustomer.Columns.Add(genderColumn);
            dtgvCustomer.Columns.Add(cccdColumn);
            dtgvCustomer.Columns.Add(emailColumn);
            dtgvCustomer.Columns.Add(phoneColumn);
            dtgvCustomer.Columns.Add(addressColumn);



        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            setUpDisplayCustomer();
            dtgvCustomer.DataSource = CustomerDAO.getInstance().getListCustomer();
        }


        private void refreshForm()
        {
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Tên khách hàng cần tìm?";
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtCCCD.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
           
            ID_selected = null;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            dtgvCustomer.DataSource = CustomerDAO.getInstance().getListCustomer();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Length == 0 || txtCCCD.Text.Length == 0 || txtDiaChi.Text.Length == 0 || txtEmail.Text.Length == 0 || txtSDT.Text.Length == 0)
            {
                CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin"); 
            }
            else
            {
                Customer customer = new Customer();
                customer.FullName = txtHoTen.Text;
                customer.CCCD = txtCCCD.Text;
                customer.Address = txtDiaChi.Text;
                customer.NumberPhone = txtSDT.Text;
                customer.Email = txtEmail.Text;
                customer.BirthOfDate = dtNgaySinh.Value;
                if (rdNam.Checked)
                {
                    customer.gender = "Nam";
                }
                else
                {
                    customer.gender = "Nữ";
                }
             


                bool check = CustomerDAO.getInstance().insertCustomer(customer);
                if (check)
                {
                    refreshForm();
                    CustomMessageBox.Show("Thêm thành công.");
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Length == 0 || txtCCCD.Text.Length == 0 || txtDiaChi.Text.Length == 0 || txtEmail.Text.Length == 0 || txtSDT.Text.Length == 0)
            {
                CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                Customer customer = new Customer
                {
                    ID_Customer = Convert.ToInt32(ID_selected),
                    FullName = txtHoTen.Text,
                    CCCD = txtCCCD.Text,
                    Address = txtDiaChi.Text,
                    NumberPhone = txtSDT.Text,
                    Email = txtEmail.Text,
                    BirthOfDate = dtNgaySinh.Value
                };

                if (rdNam.Checked)
                {
                    customer.gender = "Nam";
                }
                else
                {
                    customer.gender = "Nữ";
                }


                bool check = CustomerDAO.getInstance().update(customer);
                if (check)
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

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int r = e.RowIndex;
            if (r >= 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;

                txtMaKH.Text = dtgvCustomer.Rows[r].Cells[0].Value.ToString();
                ID_selected = (dtgvCustomer.Rows[r].Cells[0].Value.ToString());
                txtHoTen.Text = dtgvCustomer.Rows[r].Cells[1].Value.ToString();

                //Chuyển đổi date từ dgrv lên datetimepicker
                DateTime dateValue = DateTime.Parse(dtgvCustomer.Rows[r].Cells[2].Value.ToString());
                string formattedDate = dateValue.ToString("dd-MM-yyyy");
                dtNgaySinh.Value = DateTime.ParseExact(formattedDate, "dd-MM-yyyy", null);

                txtCCCD.Text = dtgvCustomer.Rows[r].Cells[4].Value.ToString();
                txtEmail.Text = dtgvCustomer.Rows[r].Cells[5].Value.ToString();
                txtSDT.Text = dtgvCustomer.Rows[r].Cells[6].Value.ToString();
                txtDiaChi.Text = dtgvCustomer.Rows[r].Cells[7].Value.ToString();

                if (dtgvCustomer.Rows[r].Cells[3].Value.ToString().Equals("Nam"))
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CustomerDAO.getInstance().checkChucVu(Convert.ToInt32(ID_selected)))
            {
                CustomMessageBox.Show("Khách hàng này hiện đang là trưởng phòng\nVui lòng vào quản lý phòng xóa thành viên này trước");
            }
            else
            {
                var result = CustomMessageBox.Show("Bạn có chắc muốn xóa khách hàng này?",
                      "Cảnh báo",
                      MessageBoxButtons.OKCancel,
                         MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    if (CustomerDAO.getInstance().deleteCustomer(Convert.ToInt32(ID_selected)))
                    {
                        refreshForm();
                        CustomMessageBox.Show("Xóa thành công.");
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tên khách hàng cần tìm?")
            {
                txtSearch.ForeColor = Color.Black;
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.ForeColor = Color.Gray;
                txtSearch.Text = "Tên khách hàng cần tìm?";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tên khách hàng cần tìm?")
            {
                CustomMessageBox.Show("Vui lòng nhập tên khách hàng cần tìm");
            }
            else
            {

                List<Customer> searchResults = CustomerDAO.getInstance().searchByName(txtSearch.Text);
                dtgvCustomer.DataSource = searchResults;

            }
        }
    }
}
