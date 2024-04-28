using QuanLyKhuTro.DAO;
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
using QuanLyKhuTro.CustomDesign;
using System.Globalization;

namespace QuanLyKhuTro.View
{
    public partial class QuanLyChiTieu : Form
    {
        private ChiTieuDao chiTieuDao;
        private DateTime currentTime = DateTime.Now;
        public QuanLyChiTieu()
        {
            InitializeComponent();
            chiTieuDao = new ChiTieuDao();
        }

        public void InitUI()
        {
            
            cbService.DataSource = DichVuDao.getInstance().IdAndNameService().Tables[0];
            cbService.DisplayMember = "TenDichVu";
            cbService.ValueMember = "MaDichVu";
        }

        private void QuanLyChiTieu_Load(object sender, EventArgs e)
        {
            InitUI();

            DateTime dateStart = currentTime.AddMonths(-3);
            dtStart.Value = dateStart;

          dataGridView.DataSource = chiTieuDao.SelectByTime(dateStart,currentTime).Tables[0];
           
        }

        public void refresh()
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            dtStart.Value = currentTime.AddMonths(-3);

            lbID.Text = "0";
            txtNote.Text = "";
            nbPrice.Value = 1000;


            dataGridView.DataSource = chiTieuDao.SelectByTime(dtStart.Value, currentTime).Tables[0];
        
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (nbPrice.Value <= 10000)
            {
                DialogResult result = CustomMessageBox.Show("Số tiền đã thanh toán quá ít, bạn có chắc chắn muốn thêm?",
             "Nhắc nhở",
             MessageBoxButtons.YesNoCancel,
             MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }
            
            Model.QuanLyChiTieu qlct = new Model.QuanLyChiTieu();
            qlct.IdService = (int)cbService.SelectedValue;
            qlct.TimePayment = dtTime.Value;
            qlct.TotalMoney = (float)nbPrice.Value;
            qlct.Note = txtNote.Text;

            if (chiTieuDao.Insert(qlct))
            {
                refresh();
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

        private void btnRestart_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = chiTieuDao.SelectByTime(dtStart.Value, dtEnd.Value).Tables[0];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (nbPrice.Value <= 10000)
            {
                DialogResult result = CustomMessageBox.Show("Số tiền đã thanh toán quá ít, bạn có chắc chắn muốn thêm?",
             "Nhắc nhở",
             MessageBoxButtons.YesNoCancel,
             MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            Model.QuanLyChiTieu qlct = new Model.QuanLyChiTieu();
            qlct.IdService = (int)cbService.SelectedValue;
            qlct.TimePayment = dtTime.Value;
            qlct.TotalMoney = (float)nbPrice.Value;
            qlct.Note = txtNote.Text;
            qlct.ID =Convert.ToInt32(lbID.Text);
            if (chiTieuDao.Update(qlct))
            {
                refresh();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show("Bạn có chắc muốn xóa phiếu chi tiêu này?",
                    "Cảnh báo",
                    MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (chiTieuDao.Delete(Convert.ToInt32(lbID.Text)))
                {
                    refresh();
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
            else
            {
                return;
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lbID.Text = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbService.DisplayMember = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (DateTime.TryParseExact(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime paymentTime))
                {
                    dtTime.Value = paymentTime;
                }
            
                nbPrice.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtNote.Text = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();

                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }
    }
}
