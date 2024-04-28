using QuanLyKhuTro.Config;
using QuanLyKhuTro.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.DAO
{
    class ChiTieuDao
    {
        public bool Insert(QuanLyChiTieu ct)
        {
            try
            {
                string sql = string.Format("INSERT INTO QuanLyChiTieu(IDService,TimePayment,TotalMoney,Note) " +
                    "VALUES ({0},'{1}',{2},N'{3}')",ct.IdService,ct.TimePayment.ToString("yyyy-MM-dd"),ct.TotalMoney,ct.Note);

                return ConnectSQL.getInstance().CRUD(sql);
            }catch(Exception e)
            {
                Console.WriteLine("Eror add Chitieu: " + e.ToString());
                return false;
            }
        }

        public DataSet SelectByTime(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                string sql = string.Format("SELECT ID, TenDichVu AS N'Tên dịch vụ', FORMAT(TimePayment,'dd-MM-yyyy') AS N'Thời gian', FORMAT(TotalMoney,'#,###') AS N'Thanh toán'," +
                    " Note AS N'Ghi chú' " +
                    " FROM QuanLyChiTieu qlct JOIN DichVu" +
                    " ON qlct.IDService = DichVu.MaDichVu " +
                    " WHERE TimePayment >= '{0}'" +
                    " AND TimePayment <= '{1}'",dateStart,dateEnd);

                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Eror add Chitieu: " + e.ToString());
                return null;
            }
        }


        public bool Update(QuanLyChiTieu qlct)
        {
            try
            {
                string sql = string.Format("UPDATE QuanLyChiTieu" +
                    " SET " +
                    " IDService = {0}," +
                    " TimePayment = '{1}'," +
                    " TotalMoney = {2}," +
                    " Note = N'{3}'" +
                    " WHERE ID = {4}", qlct.IdService,qlct.TimePayment,qlct.TotalMoney,qlct.Note,qlct.ID);
                return ConnectSQL.getInstance().CRUD(sql);
            }catch(Exception e)
            {
                Console.WriteLine("Eror add Chitieu: " + e.ToString());
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                string sql = string.Format("DELETE FROM QuanLyChiTieu WHERE ID = {0}", id);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Eror add Chitieu: " + e.ToString());
                return false;
            }
        }
    }
}
