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
    //255, 192, 192
    public partial class QuanLyDichVu : Form
    {
        public QuanLyDichVu()
        {
            InitializeComponent();
        }


        private void QuanLyDichVu_Load(object sender, EventArgs e)
        {

            dtgvDichVu.DataSource = DichVuDao.getInstance().GetListDichVu().Tables[0];
        }

        private void refreshForm()
        {

            txtMaDichVu.Text = "";
            txtTenDichVu.Text = "";
            txtDonViTinh.Text = "";
            txtGiaTien.Text = "";
            //   ID_selected = null;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            dtgvDichVu.DataSource = DichVuDao.getInstance().GetListDichVu().Tables[0];

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txtTenDichVu.Text.Length == 0 || txtDonViTinh.Text.Length == 0 || txtGiaTien.Text.Length == 0)
            {
                CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                DichVu dichVu = new DichVu();

                dichVu.TenDichVu = txtTenDichVu.Text;
                dichVu.DonViTinh = txtDonViTinh.Text;
                dichVu.GiaTien = float.Parse(txtGiaTien.Text);

                bool check = DichVuDao.getInstance().insertDichVu(dichVu);
                if (check)
                {
                    CustomMessageBox.Show("Thêm thành công.");
                    refreshForm();
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

        private void dtgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;

                txtMaDichVu.Text = dtgvDichVu.Rows[r].Cells[0].Value.ToString();
                txtTenDichVu.Text = dtgvDichVu.Rows[r].Cells[1].Value.ToString();
                txtDonViTinh.Text = dtgvDichVu.Rows[r].Cells[2].Value.ToString();      
                txtGiaTien.Text = dtgvDichVu.Rows[r].Cells[3].Value.ToString().Replace(",", "");

            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaDichVu.Text.Length == 0 || txtTenDichVu.Text.Length == 0 || txtDonViTinh.Text.Length == 0 || txtGiaTien.Text.Length == 0)
            {
                CustomMessageBox.Show("Vui lòng nhập đầy đủ thông tin.");

            }
            else
            {
                DichVu dichVu = new DichVu();
                 dichVu.MaDichVu = Convert.ToInt32(txtMaDichVu.Text);
                dichVu.TenDichVu = txtTenDichVu.Text;
                dichVu.DonViTinh = txtDonViTinh.Text;
                dichVu.GiaTien = float.Parse(txtGiaTien.Text);

                bool check = DichVuDao.getInstance().update(dichVu);
                if (check)
                {
                    CustomMessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                    refreshForm();
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tên dịch vụ cần tìm?")
            {
                CustomMessageBox.Show("Vui lòng nhập tên dịch vụ cần tìm");
            }
            else
            {

                List<DichVu> searchResults = DichVuDao.getInstance().searchByName(txtSearch.Text);
                dtgvDichVu.DataSource = searchResults;

            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tên dịch vụ cần tìm?")
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
                txtSearch.Text = "Tên dịch vụ cần tìm?";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?",
                  "Xác nhận",
                  MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (DichVuDao.getInstance().DeleteService(Convert.ToInt32(txtMaDichVu.Text)))
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
    }
}


