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
    class TheRaVaoDao
    {
        private static TheRaVaoDao instance;

        public static TheRaVaoDao getInstance()
        {
            if (instance == null)
            {
                instance = new TheRaVaoDao();
            }
            return instance;
        }

        private TheRaVaoDao() { }

        public DataSet GetListTheRaVao()
        {
            try
            {
                string sql = "SELECT MaThe AS N'Mã thẻ', Theravao.MaKH as N'Mã Khách Hàng',Hoten AS N'Tên khách hàng'," +
                    " FORMAT(NgayTao,'dd-MM-yyyy') AS N'Ngày tạo', FORMAT(NgayHetHan,'dd-MM-yyyy') AS N'Ngày hết hạn' " +
                    " FROM theravao join KhachHang" +
                    " ON theravao.MaKH = KhachHang.MaKH";
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return null;

            }
        }


        /// <summary>
        /// Do trong SQL lưu theo định dạng năm - tháng - ngày , nên cần phải chuyển đổi lại theo định dạng đó
        /// </summary>
        /// <param name="theravao"></param>
        /// <returns></returns>
        public bool insertTheRaVao(TheRaVao theravao)
        {
            try
            {
                string sql = string.Format("insert into TheRaVao(MaKH,NgayTao,NgayHetHan) " +
                    " values ('{0}','{1}','{2}')", theravao.MaKH, theravao.NgayTao.ToString("yyyy-MM-dd"), theravao.NgayHetHan.ToString("yyyy-MM-dd"));
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return false;

            }
        }

        public bool updateTheRaVao(TheRaVao theravao)
        {
            try
            {
                string sql = string.Format("UPDATE TheRaVao" +
                    " SET " +
                    " MaKH = {0}," +
                    " NgayTao = '{1}'," +
                    " NgayHetHan = '{2}' " +
                    " WHERE MaThe = {3}", theravao.MaKH, theravao.NgayTao.ToString("yyyy-MM-dd"), theravao.NgayHetHan.ToString("yyyy-MM-dd"),theravao.MaThe);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return false;

            }
        }

        public bool delete(int maThe)
        {
            try
            {
                string sql = string.Format("DELETE FROM TheRaVao WHERE MaThe = {0}", maThe);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return false;

            }
        }


        public DataSet searchTheRaVao(int input)
        {
            try
            {
                string sql = string.Format("SELECT MaThe AS N'Mã thẻ', Theravao.MaKH as N'Mã Khách Hàng',Hoten AS N'Tên khách hàng'," +
                    " FORMAT(NgayTao,'dd-MM-yyyy') AS N'Ngày tạo', FORMAT(NgayHetHan,'dd-MM-yyyy') AS N'Ngày hết hạn' " +
                    " FROM theravao join KhachHang" +
                    " ON theravao.MaKH = KhachHang.MaKH" +
                    " WHERE MaThe = {0}" +
                    " OR TheRaVao.MaKH = {1}", input,input);
                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return null;

            }
        }



    }


}
