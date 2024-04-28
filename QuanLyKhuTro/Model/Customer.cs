using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyKhuTro.Model
{
    public class Customer
    {
        
        public int ID_Customer { get; set; }
        public string FullName { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string gender { get; set; }
        public string CCCD { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
        public DateTime ThoiGianDenO { get; set; }

   

        public Customer() { }

        public Customer(DataRow row)
        {
            this.ID_Customer = Convert.ToInt32(row["MaKH"]);
            this.FullName = row["HoTen"].ToString();
            this.BirthOfDate = ((DateTime)row["NgaySinh"]).Date;
            this.gender = row["GioiTinh"].ToString();
            this.CCCD = row["CanCuocCongDan"].ToString();
            this.Email = row["Email"].ToString();
            this.NumberPhone = row["SoDienThoai"].ToString();
            this.Address = row["DiaChi"].ToString();
            this.ThoiGianDenO = (DateTime)row["ThoiGianDenO"];
           

        }

       
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
