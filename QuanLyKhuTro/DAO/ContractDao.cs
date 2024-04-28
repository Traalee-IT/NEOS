using System;
using System.Collections.Generic;
using System.Data;
using QuanLyKhuTro.Config;
using QuanLyKhuTro.Model;

namespace QuanLyKhuTro.DAO
{ 
    class ContractDao
    {

        public DataSet selectListContract()
        {
            try
            {
                string sql = string.Format("SELECT MaHopDong AS N'Mã Hợp Đồng',Phong.MaPhong as N'Mã Phòng' , TenPhong AS N'Phòng', " +
                    " Format(NgayLamHopDong,'dd-MM-yyyy') AS N'Ngày Làm Hợp Đồng', " +
                    " Format(NgayHetHan,'dd-MM-yyyy') AS N'Ngày Hết Hạn'," +
                    " FORMAT(SoTienDatCoc,'#,###') AS  N'Đặt Cọc' " +
                    " FROM HopDong JOIN PHONG" +
                    " ON HopDong.MaPhong = PHONG.MaPhong" +
                    " AND GETDATE() < NgayHetHan");

                return ConnectSQL.getInstance().selectData(sql);
            }catch(Exception e)
             {
            Console.WriteLine("Error: " + e.ToString());
            return null;
             }
        }

        public bool AddContract(Contract contract, List<int> listIDCustomer)
        {
            try
            {
                string sqlContract = string.Format("INSERT INTO HopDong (MaPhong,NgayLamHopDong,NgayHetHan,SoTienDatCoc) " +
                    " VALUES({0},'{1}', '{2}',{3})", contract.MaPhong, contract.NgayLamHopDong, contract.NgayHetHan, contract.SoTienDatCoc);

                if (ConnectSQL.getInstance().CRUD(sqlContract))
                {
                    for(int i=0;i<listIDCustomer.Count;i++)
                    {
                        string sql;
                        if (i == 0)
                        {
                            sql = string.Format("INSERT INTO ThanhVienPhong(MaHopDong,MaKH,ChucVu) " +
                                " VALUES((SELECT MAX(MaHopDong) FROM HopDong), {0},N'Trưởng phòng')",listIDCustomer[i]);
                        }
                        else
                        {
                            sql = string.Format("INSERT INTO ThanhVienPhong(MaHopDong,MaKH) " +
                                " VALUES((SELECT MAX(MaHopDong) FROM HopDong), {0})", listIDCustomer[i]);
                        }
                        ConnectSQL.getInstance().CRUD(sql);
                        
                    }
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error add Contract: " + e.ToString());
                return false;
            }
            return false;
        }

        public bool update(Contract contract, List<int> listIDCustomer)
        {
            try
            {
                string sql = string.Format("UPDATE HopDong " +
                    " SET " +
                    " MaPhong = {0}," +
                    " NgayLamHopDong = '{1}',"+
                    " NgayHetHan = '{2}'," +
                    " SoTienDatCoc = {3} " +
                    " WHERE MaHopDong = {4}",contract.MaPhong,contract.NgayLamHopDong, contract.NgayHetHan, contract.SoTienDatCoc, contract.MaHopDong);
                if (ConnectSQL.getInstance().CRUD(sql))
                {
                    foreach (int id in listIDCustomer)
                    {
                        string sqlMember = string.Format("INSERT INTO ThanhVienPhong(MaHopDong,MaKH) " +
                                " VALUES((SELECT MAX(MaHopDong) FROM HopDong), {0})", id);
                        ConnectSQL.getInstance().CRUD(sqlMember);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error update Contract: " + e.ToString());
                return false;
            }
            return false;
        }

        //Chuyển phòng
        public bool ChangeRoom(int idNewRoom, int idOldRoom)
        {

            try
            {
                string sql = string.Format("EXEC PRO_ChangeContract {0},{1}", idNewRoom, idOldRoom);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error update Contract: " + e.ToString());
                return false;
            }         
        }

        public bool KetThucHopDong(int idContract,int idRoom)
        {
            try
            {
                string sql = string.Format("EXEC PRO_FinnishContract {0},{1}", idContract,idRoom);
                return ConnectSQL.getInstance().CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error update Contract: " + e.ToString());
                return false;
            }
        }
    }
}
