using QuanLyKhuTro.Config;
using QuanLyKhuTro.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.DAO
{
    class PaymentHistoryDAO
    {
        private static PaymentHistoryDAO instance;

        public static PaymentHistoryDAO getInstance()
        {
            if (instance == null)
            {
                instance = new PaymentHistoryDAO();
            }
            return instance;
        }

        private PaymentHistoryDAO() { }
       
        public bool InsertPayment(LichSuThanhToan ls, List<DichVu> listService)
        {
            bool check = false;


            using (SqlConnection connection = new SqlConnection(ConnectSQL.url))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Kiểm tra tính hợp lệ của dữ liệu đầu vào ở đây (ls và listService)

                    string insertPaymentSql = "INSERT INTO LichSuThanhToan (MaPhong, NguoiThanhToan, SoDien, SoNuoc, TrangThai, TongTien) " +
                        "VALUES (@MaPhong, @NguoiThanhToan, @SoDien, @SoNuoc, @TrangThai, @TongTien); SELECT SCOPE_IDENTITY()";

                    using (SqlCommand cmd = new SqlCommand(insertPaymentSql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", ls.IDRoom);
                        cmd.Parameters.AddWithValue("@NguoiThanhToan", ls.NguoiThanhToan);
                        cmd.Parameters.AddWithValue("@SoDien", ls.soDien);
                        cmd.Parameters.AddWithValue("@SoNuoc", ls.soNuoc);
                        cmd.Parameters.AddWithValue("@TrangThai", ls.status);
                        cmd.Parameters.AddWithValue("@TongTien", ls.totalMoney);

                        // Thực hiện truy vấn và lấy ID của bản ghi vừa được chèn
                        object result = cmd.ExecuteScalar();
                        int insertedID = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                        if (insertedID > 0)
                        {
                            foreach (DichVu item in listService)
                            {
                                string insertServiceSql = "INSERT INTO ChiTietThanhToan (MaGiaoDich, MaDichVu, GiaTien) " +
                                    "VALUES (@MaGiaoDich, @MaDichVu, @GiaTien)";
                                using (SqlCommand serviceCmd = new SqlCommand(insertServiceSql, connection, transaction))
                                {
                                    serviceCmd.Parameters.AddWithValue("@MaGiaoDich", insertedID);
                                    serviceCmd.Parameters.AddWithValue("@MaDichVu", item.MaDichVu);
                                    serviceCmd.Parameters.AddWithValue("@GiaTien", item.GiaTien);
                                    serviceCmd.ExecuteNonQuery();
                                }
                            }

                            // Commit giao dịch nếu không có lỗi
                            transaction.Commit();
                            check = true;
                        }
                        else
                        {
                            // Thực hiện rollback nếu không có ID hợp lệ
                            transaction.Rollback();
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("SQL Error: " + e.ToString());
                    // Thực hiện rollback nếu có lỗi
                    transaction.Rollback();
                }
            }

            return check;
        }

        public DataSet getListPaymentHistoryByID(int idRoom)
        {
         
            try
            {
                string sql = string.Format("SELECT ls.MaGiaoDich AS N'Mã Giao Dịch',ls.ThoiGianThanhToan as N'Ngày Thanh Toán', "+
                                " NguoiThanhToan as N'Người Thanh Toán', ls.SoDien as N'Số Điện đã dùng'," +
                                  " ls.SoNuoc as N'Số Nước đã dùng',FORMAT(ls.TongTien,'#,###') as N'Tổng thanh toán',ls.TrangThai AS N'Trạng thái'" +
                                " FROM LichSuThanhToan ls"+
                                " WHERE ls.MaPhong = {0}", idRoom);
                return ConnectSQL.getInstance().selectData(sql);
            }catch(Exception e)
            {
                Console.WriteLine("Error get list Payment History: " + e.ToString());
                return null;
            }
        
        }

        public DataSet getListPaymentHistoryByIDForTime(int idRoom, DateTime start, DateTime end)
        {
            try
            {
                string sql = string.Format("EXEC PRC_SelectPaymentHistory_Room {0},'{1}','{2}'", idRoom,start,end);
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get list Payment History: " + e.ToString());
                return null;
            }
        }

        //Lấy phòng đang nợ thanh toán
        public DataSet PhongNoThanhToan(int month,int year)
        {
            try
            {
                string sql = string.Format("EXEC PRO_PhongNoThanhToan {0},'{1}'", month, year);
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get phong no thanh toan: " + e.ToString());
                return null;
            }
        }

        //Thống kê doanh thu theo từng tháng trong 1 năm
        public DataSet ThongKeDoanhThuMotNam(int year)
        {
            try
            {
                string sql = string.Format("EXEC PRC_ThongKeOneYear {0}", year);
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get phong no thanh toan: " + e.ToString());
                return null;
            }
        }

        //Thống kê doanh thu theo tháng
        public DataSet StatisticalMonth(int month,int year)
        {
            try
            {
                string sql = string.Format("EXEC PRC_StatisticalByMonth {0},{1}", month, year);
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get thong ke doanh thu theo thang: " + e.ToString());
                return null;
            }
        } 
        
        
        public DataSet StatisticalAll()
        {
            try
            {
               
                return ConnectSQL.getInstance().selectData("EXEC PROC_StatisticalAll");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get thong ke doanh thu tat ca: " + e.ToString());
                return null;
            }
        }

        //Tổng doanh thu trong 10 năm

        public DataSet StatisticalForTenYear()
        {
            try
            {

                return ConnectSQL.getInstance().selectData("EXEC PROC_StatisticalForTenYear");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get thong ke doanh thu theo 10 nam: " + e.ToString());
                return null;
            }
        }
    }
}
