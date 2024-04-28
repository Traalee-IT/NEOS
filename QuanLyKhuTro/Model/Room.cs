using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyKhuTro.Model
{
    public class Room
    {
        public int ID_Room { get; set; }
        public string name_Room { get; set; }
        public float price { get; set; }
        public int numberPeople { get; set; }
        public string status { get; set; }

        public float dienTich { get; set; }

        public List<MemberRoom> memberList { get; set; }

        public static List<String> listStatus = new List<string> { "Trống", "Đã thuê","Hỏng" };

        public Room() { }

        public Room(DataRow row)
        {
            this.ID_Room = Convert.ToInt32(row["MaPhong"]);
            this.name_Room = row["TenPhong"].ToString();
            this.price = float.Parse(row["GiaPhong"].ToString());
            this.dienTich = float.Parse(row["DienTich"].ToString());
            this.numberPeople = Convert.ToInt32(row["SoNguoiO"]);
            this.status = row["TrangThai"].ToString();
        }

       
        
    }
}
