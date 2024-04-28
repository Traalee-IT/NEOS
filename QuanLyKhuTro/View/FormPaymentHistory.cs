using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhuTro.DAO;
using QuanLyKhuTro.Model;
namespace QuanLyKhuTro.View
{
    public partial class FormPaymentHistory : Form
    {
        private Room room;
        public FormPaymentHistory()
        {
            InitializeComponent();
        }
        public FormPaymentHistory(Room room)
        {
            this.room = room;
            InitializeComponent();
        }

        private void setUpForm()
        {
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            lbNameRoom.Text = room.name_Room;
            dataGridView.DataSource = PaymentHistoryDAO.getInstance().getListPaymentHistoryByID(room.ID_Room).Tables[0];
        }

        private void FormPaymentHistory_Load(object sender, EventArgs e)
        {
            setUpForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            dataGridView.DataSource = PaymentHistoryDAO.getInstance().getListPaymentHistoryByIDForTime(room.ID_Room,dtStart.Value,dtEnd.Value).Tables[0];
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            setUpForm();
        }

        private void btnPrintExcel_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn col1 = new DataColumn("MaGiaoDich");
            DataColumn col2 = new DataColumn("NgayThanhToan");
            DataColumn col3 = new DataColumn("HoTen");
            DataColumn col4 = new DataColumn("SoDien");
            DataColumn col5 = new DataColumn("SoNuoc");
            DataColumn col6 = new DataColumn("ThanhToan");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);

            foreach(DataGridViewRow dtgv in dataGridView.Rows)
            {
                DataRow dtRow = dataTable.NewRow();
                dtRow[0] = dtgv.Cells[0].Value;
                dtRow[1] = dtgv.Cells[1].Value;
                dtRow[2] = dtgv.Cells[2].Value;
                dtRow[3] = dtgv.Cells[3].Value;
                dtRow[4] = dtgv.Cells[4].Value;
                dtRow[5] = dtgv.Cells[5].Value;

                dataTable.Rows.Add(dtRow);
            }

            Model.Excel.ExportFilePaymentHistoryByRoom(dataTable, "Danh sách", "LỊCH SỬ THANH TOÁN - " + room.name_Room);
        }
    }
}
