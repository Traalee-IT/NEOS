using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhuTro.Model;
using QuanLyKhuTro.Config;
using System.Data;
namespace QuanLyKhuTro.DAO
{
    class CustomerDAO
    {

        private static CustomerDAO instance;

        public static CustomerDAO getInstance()
        {
            if(instance == null)
            {
                instance = new CustomerDAO();
            }
            return instance;
        }

        private CustomerDAO() { }

        public List<Customer> getListCustomer()
        {
            List<Customer> list = new List<Customer>();
            try
            {
               DataSet data =  ConnectSQL.getInstance().selectData("SELECT * FROM KhachHang");
                foreach(DataRow item in data.Tables[0].Rows)
                {
                    Customer cs = new Customer(item);
                    list.Add(cs);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error get list Customer: "+e.ToString());
                return null;

            }

            return list;
        }

        public bool insertCustomer(Customer customer)
        {
            try
            {
                string sql = string.Format("insert into KhachHang(HoTen,GioiTinh,CanCuocCongDan,Email,SoDienThoai,DiaChi,NgaySinh) " +
                    " values (N'{0}',N'{1}','{2}','{3}','{4}',N'{5}','{6}')",customer.FullName,customer.gender,customer.CCCD,customer.Email,customer.NumberPhone,customer.Address,customer.BirthOfDate.ToString("yyyy-MM-dd"));
               return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get list Customer: " + e.ToString());
                return false;

            }
        }
        public bool update(Customer customer)
        {
            if (customer.ID_Customer <= 0)
            {
                return false;
            }
            try
            {
                string sql = string.Format("UPDATE KhachHang SET " +
                    " HoTen = N'{0}'," +
                    " GioiTinh =N'{1}'," +
                    " CanCuocCongDan = '{2}'," +
                    " Email='{3}',"+
                    " SoDienThoai='{4}',"+
                    " DiaChi = N'{5}', " +
                    " NgaySinh='{6}' "+
                    " WHERE MaKH = {7} ",
                    customer.FullName, customer.gender, customer.CCCD, customer.Email, customer.NumberPhone, customer.Address, customer.BirthOfDate.ToString("yyyy-MM-dd"),customer.ID_Customer);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error update: " + e.ToString());
                return false;
            }

        }
        public bool deleteCustomer(int id)
        {
            try
            {
                string sql = string.Format(" DELETE FROM ThanhVienPhong WHERE  MaKH = {0} " +
                    " DELETE FROM KhachHang WHERE MaKH = {1}", id,id);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error delete: " + e.ToString());
                return false;
            }
        }

        //Lấy khách hàng chưa thuê phòng
        public DataSet ListKhachHangChuaThuePhong()
        {
            try
            {
                string sql = string.Format("SELECT MaKH,HoTen,SoDienThoai FROM KhachHang " +
                    " WHERE MaKH NOT IN ( " +
                    " SELECT MAKH FROM HopDong JOIN ThanhVienPhong tv " +
                    " ON tv.MaHopDong = HopDong.MaHopDong" +
                    " WHERE NgayHetHan > GETDATE() )");
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Insert: " + e.ToString());
                return null;
            }
        }

        public List<Customer> searchByName(string input)
        {
            List<Customer> list = new List<Customer>();
            try
            {
                string sql = string.Format("SELECT * FROM KhachHang WHERE HoTen LIKE N'%{0}%'", input);
                DataSet data = ConnectSQL.getInstance().selectData(sql);
                foreach (DataRow item in data.Tables[0].Rows)
                {
                    Customer cs = new Customer(item);
                    list.Add(cs);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get list Customer: " + e.ToString());
                return null;

            }

            return list;
        }

        //Kiểm tra chức vụ
     public bool checkChucVu(int id)
        {
            try
            {
                string sql = string.Format("SELECT count(*) FROM ThanhVienPhong WHERE MaKH = {0} AND ChucVu = N'Trưởng phòng'", id);
                int result = (int)ConnectSQL.getInstance().excuteScalar(sql);
                return result > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get list Customer: " + e.ToString());
                return false;

            }
        }
    }
}
