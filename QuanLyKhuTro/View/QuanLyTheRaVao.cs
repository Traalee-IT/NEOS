using QuanLyKhuTro.CustomDesign;
using QuanLyKhuTro.DAO;
using QuanLyKhuTro.Model;
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

namespace QuanLyKhuTro.View
{
    public partial class QuanLyTheRaVao : Form
    {
        public QuanLyTheRaVao()
        {
            InitializeComponent();
        }

        private void QuanLyTheRaVao_Load(object sender, EventArgs e)
        {
            dtgvTheRaVao.DataSource = TheRaVaoDao.getInstance().GetListTheRaVao().Tables[0];
        }
        private void refreshForm()
        {

            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Nhập mã thẻ";

            txtMaThe.Text = "";
            txtMaKhachHang.Text = "";
            dtNgayTao.Value = DateTime.Now;
            dtNgayHetHan.Value = DateTime.Now;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            dtgvTheRaVao.DataSource = TheRaVaoDao.getInstance().GetListTheRaVao().Tables[0];

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text.Length == 0)
            {
                CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else if (dtNgayHetHan.Value < dtNgayTao.Value)
            {
                CustomMessageBox.Show("Ngày hết hạn phải lớn hơn ngày tạo");
            }
            else
            {
                TheRaVao theravao = new TheRaVao();
               
                theravao.MaKH =Convert.ToInt32(txtMaKhachHang.Text);
                theravao.NgayTao = dtNgayTao.Value;
                theravao.NgayHetHan = dtNgayHetHan.Value; 


                bool check = TheRaVaoDao.getInstance().insertTheRaVao(theravao);
                if (check)
                {
                    CustomMessageBox.Show("Thêm thành công.");
                    refreshForm();
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                    "Error",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text.Length == 0)
            {
                CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }else if(dtNgayHetHan.Value < dtNgayTao.Value)
            {
                CustomMessageBox.Show("Ngày hết hạn phải lớn hơn ngày tạo");
            }
            else
            {
                TheRaVao theravao = new TheRaVao();
                theravao.MaThe = Convert.ToInt32(txtMaThe.Text);
                theravao.MaKH = Convert.ToInt32(txtMaKhachHang.Text);
                theravao.NgayTao = dtNgayTao.Value;
                theravao.NgayHetHan = dtNgayHetHan.Value;


                bool check = TheRaVaoDao.getInstance().updateTheRaVao(theravao);
                if (check)
                {
                    CustomMessageBox.Show("Cập nhật thành công.");
                    refreshForm();
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                    "Error",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void dtgvTheRaVao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtMaThe.Text = dtgvTheRaVao.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMaKhachHang.Text = dtgvTheRaVao.Rows[e.RowIndex].Cells[1].Value.ToString();
              
                // Chuyển đổi chuỗi ngày sang DateTime
                if (DateTime.TryParseExact(dtgvTheRaVao.Rows[e.RowIndex].Cells[3].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
                {
                    dtNgayTao.Value = startDate;
                }
                // Chuyển đổi chuỗi ngày sang DateTime
                if (DateTime.TryParseExact(dtgvTheRaVao.Rows[e.RowIndex].Cells[4].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDate))
                {
                    dtNgayHetHan.Value = endDate;
                }
              
            }
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Nhập mã thẻ")
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
                txtSearch.Text = "Nhập mã thẻ";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show("Bạn có chắc muốn xóa thẻ này?",
                   "Xác nhận",
                   MessageBoxButtons.OKCancel,
                      MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (TheRaVaoDao.getInstance().delete(Convert.ToInt32(txtMaThe.Text)))
                {
                    refreshForm();
                    CustomMessageBox.Show("Xóa thành công.");
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                    "Error",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                }

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Nhập mã thẻ")
            {
                CustomMessageBox.Show("Nhập thẻ cần tìm");
            }
            else
            {
                dtgvTheRaVao.DataSource = TheRaVaoDao.getInstance().searchTheRaVao(Convert.ToInt32(txtSearch.Text)).Tables[0];
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn ngừa ký tự không phải số được nhập vào TextBox
            }
        }
    }
}
