using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.Model
{
    public class PhongNoThanhToan
    {

        public Room rooms { get; set; }
        public string Email { get; set; }

        public PhongNoThanhToan(DataRow row)
        {
            rooms = new Room();
            rooms.ID_Room = Convert.ToInt32(row["MaPhong"]);
            rooms.name_Room = row["TenPhong"].ToString();
            rooms.price = float.Parse(row["GiaPhong"].ToString());
            rooms.dienTich = float.Parse(row["DienTich"].ToString());
            rooms.numberPeople = Convert.ToInt32(row["SoNguoiO"]);

            this.Email = row["Email"].ToString();
        }

    }
}
