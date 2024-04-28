using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhuTro.Model;
using System.Data;
using QuanLyKhuTro.Config;
namespace QuanLyKhuTro.DAO
{
    class RoomDao
    {
        private static RoomDao instance;
        private ConnectSQL connection;
        public static RoomDao getInstance()
        {
            if(instance == null)
            {
                instance = new RoomDao();
            }
            return instance;
        }

        private RoomDao() {
            connection = ConnectSQL.getInstance();
        }

        public List<Room> loadListRoom()
        {
            List<Room> list = new List<Room>();

            try
            {
                DataSet data = connection.selectData("SELECT * FROM PHONG  WHERE TrangThai !=  'DELETE'"); 

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    Room room = new Room(item);
                    list.Add(room);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Lỗi lấy data: " + e.ToString());
            }
            return list;
        }

        public bool insertRoom(Room room)
        {
            try
            {
                string sql = string.Format("INSERT INTO PHONG(TenPhong,GiaPhong,DienTich) VALUES (N'{0}', {1},{2})",
                    room.name_Room, room.price, room.dienTich);

                return connection.CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Insert: " + e.ToString());
                return false;
            }     
        }

        public bool update(Room room)
        {
            try
            {
                string sql = string.Format("UPDATE PHONG SET " +
                    "TENPHONG = N'{0}'," +
                    " GiaPhong = {1}," +
                    " DienTich = {2}," +
                    " TrangThai = N'{3}'" +
                    " WHERE MaPhong = {4} ",
                    room.name_Room,room.price,room.dienTich,room.status,room.ID_Room);
                return connection.CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Insert: " + e.ToString());
                return false;
            }
        }
        
        public bool deleteRoom(int id)
        {
            try
            {
                string sql = string.Format("UPDATE PHONG  SET TrangThai = 'DELETE'  WHERE MaPhong = {0} ", id);
             
                return connection.CRUD(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Insert: " + e.ToString());
                return false;
            }
        }

        public List<Room> searchByName(string name)
        {
            List<Room> list = new List<Room>();
            try
            {
                string sql = string.Format("SELECT * FROM Phong WHERE TenPhong LIKE N'%{0}%'", name);

                DataSet data = connection.selectData(sql);

                foreach (DataRow item in data.Tables[0].Rows)
                {
                    Room room = new Room(item);
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

        //Láy ra tât cả thành  viên tronng phòng
  
        public List<MemberRoom> getListMember(int idRoom)
        {
            List<MemberRoom> list = new List<MemberRoom>();
            try
            {
                string sql = string.Format("EXEC PRD_MemberInRoom @MaPhong={0}", idRoom);
                DataSet data = connection.selectData(sql);
                foreach(DataRow item in data.Tables[0].Rows)
                {
                    MemberRoom member = new MemberRoom(item);
                    list.Add(member);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi lấy data: " + e.ToString());
                return null;
            }
            return list;
        }

        //Lấy phòng chưa được thuê
        public DataSet ListRoomChuaThue()
        {
            try
            {
                string sql = string.Format("SELECT MaPhong,TenPhong FROM PHONG WHERE TrangThai = N'Trống'");

                return ConnectSQL.getInstance().selectData(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return null;
            }
        }

        //Xóa thành viên phòng
        public bool RemoveMemberOfRoom(List<int> list,int MaPhong)
        {

            try
            {
                string searchIdContract = string.Format("SELECT MaHopDong FROM HopDong WHERE MaPhong = {0}", MaPhong);

                int idContract = (int)ConnectSQL.getInstance().excuteScalar(searchIdContract);

                foreach (int id in list)
                {
                    string sql = string.Format("DELETE FROM ThanhVienPhong " +
                        " WHERE MaHopDong = {0} " +
                        " AND MaKH = {1}", idContract, id);
                    ConnectSQL.getInstance().CRUD(sql);
                }
                string update = string.Format("UPDATE ThanhVienPhong" +
                    " SET ChucVu = N'Trưởng phòng'" +
                    " WHERE MaKH = (SELECT TOP(1) MAKH FROM THANHVIENPHONG WHERE MaHopDong = {0})", idContract);
                return ConnectSQL.getInstance().CRUD(update);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return false ;
            }
        }
    }
}
