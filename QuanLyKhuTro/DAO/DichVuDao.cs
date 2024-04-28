using QuanLyKhuTro.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhuTro.Model;
namespace QuanLyKhuTro.DAO
{
    class DichVuDao
    {
        private static DichVuDao instance;

        public static DichVuDao getInstance()
        {
            if (instance == null)
            {
                instance = new DichVuDao();
            }
            return instance;
        }

        private DichVuDao() { }


        public List<DichVu> selectAll()
        {
            List<DichVu> list = new List<DichVu>();

            try
            {
                DataSet data = ConnectSQL.getInstance().selectData("SELECT * FROM DichVu");

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    DichVu room = new DichVu(item);
                    list.Add(room);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi lấy data: " + e.ToString());
                return null;
            }
            return list;

        }
        //Lấy tất cả dịch vụ 
        // N : cho phép viết tiếng việt có dấu
        // as N'' là định nghĩa nó sang 1 tên khác
        
        public DataSet GetListDichVu()
        {
            List<DichVu> list = new List<DichVu>();
            try
            {
                string sql = "SELECT MaDichVu as N'Mã dịch vụ', TenDichVu N'Tên dịch vụ', " +
                    "DonViTinh N'Đơn vị tính'," +
                    " FORMAT(GiaTien,'#,###') AS  N'Đơn giá' FROM DichVu";
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get list DichVu: " + e.ToString());
                return null;

            }
        }

        //Thêm dịch vụ

        public bool insertDichVu(DichVu dichVu)
        {
            try
            {
                string sql = string.Format("insert into DichVu(TenDichVu,DonViTinh,GiaTien) " +
                    " values (N'{0}','{1}','{2}')", dichVu.TenDichVu, dichVu.DonViTinh, dichVu.GiaTien);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error get list DichVu: " + e.ToString());
                return false;

            }
        }
        //Sửa dịch vụ

        public bool update(DichVu dichVu)
        {
            if (dichVu.MaDichVu <= 0)
            {
                return false;
            }
            try
            {
                string sql = string.Format("UPDATE DichVu SET " +
                    " TenDichVu = N'{0}'," +
                    " DonViTinh ='{1}'," +
                    " GiaTien = '{2}'" +
                    " WHERE MaDichVu = {3} ",
                    dichVu.TenDichVu, dichVu.DonViTinh, dichVu.GiaTien, dichVu.MaDichVu);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error update: " + e.ToString());
                return false;
            }

        }

        public bool DeleteService(int id)
        {
            try
            {
                string sql = string.Format("DELETE FROM DichVu WHERE MaDichVu ={0}", id);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error update: " + e.ToString());
                return false;
            }
        }

        //tìm kiếm dịch vụ
        public List<DichVu> searchByName(string name)
        {
            List<DichVu> list = new List<DichVu>();
            try
            {
                string sql = string.Format("SELECT * FROM DichVu WHERE TenDichVu LIKE N'%{0}%'", name);

                DataSet data = ConnectSQL.getInstance().selectData(sql);

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    DichVu dichVu = new DichVu(item);
                    list.Add(dichVu);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi lấy data: " + e.ToString());
                return null;
            }
            return list;
        }



        //Dịch vụ khách hàng chưa sử  dụng
        public List<DichVu> getServiceNotUse(int idRoom)
        {
            List<DichVu> list = new List<DichVu>();

            try
            {
                string sql = string.Format("EXEC PRC_ListDichVuPhongChuaSuDung @MaPhong =  {0}", idRoom);
                DataSet data = ConnectSQL.getInstance().selectData(sql);

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    DichVu room = new DichVu(item);
                    list.Add(room);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi lấy data: " + e.ToString());
                return null;
            }
            return list;
        }


        //Dịch vụ khách hàng đã sử  dụng
        public List<DichVu> getServiceUsed(int idRoom)
        {
            List<DichVu> list = new List<DichVu>();

            try
            {
                string sql = string.Format("EXEC PRC_getListDichVuPhongDangSuDung @MaPhong =  {0}", idRoom);
                DataSet data = ConnectSQL.getInstance().selectData(sql);

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    DichVu room = new DichVu(item);
                    list.Add(room);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Get List Data: " + e.ToString());
                return null;
            }
            return list;
        }

        //Thêm  dịch vụ cho phòng
        public bool addServiceForRoom(int idRoom, List<int> listService)
        {

            try
            {

                foreach (int idService in listService)
                {

                    ConnectSQL.getInstance().CRUD(string.Format("EXEC PRC_AddServiceForRoom @MaPhong = {0}, @MaDichVu = {1}", idRoom, idService));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error Add Service of The Room: " + e.ToString());
                return false;
            }

            return true;
        }

        //Xóa  dịch vụ cho phòng
        public bool removeServiceOfRoom(int idRoom, List<int> listService)
        {

            try
            {

                foreach (int idService in listService)
                {

                    if (!ConnectSQL.getInstance().CRUD(string.Format("EXEC PRC_HuyDichVuChoPhong @MaPhong = {0}, @MaDichVu = {1}", idRoom, idService)))
                    {
                        return false;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error Remove Service of the Room: " + e.ToString());
                return false;
            }

            return true;
        }

        //Hủy tất cả dịch vụ mà phòng đanng sử dụng
        public bool deleteAllServiceOfTheRoom(int idRoom)
        {
            try
            {
                string sql = string.Format("EXEC PRC_RemoveAllServiceOfRoom @MaPhong = {0}", idRoom);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Remove All Service: " + e.ToString());
                return false;
            }
        }


        //Lấy mã dịch vụ và tên dịch vụ
        public DataSet IdAndNameService()
        {
            try
            {
                return ConnectSQL.getInstance().selectData("SELECT MaDichVu,TenDichVu FROM DichVu");
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi lấy data: " + e.ToString());
                return null;
            }

        }
    }
}
