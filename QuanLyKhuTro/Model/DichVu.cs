using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.Model
{
    public class DichVu
    {
        public int MaDichVu { get; set; }

        public string TenDichVu { get; set; }
        public string DonViTinh { get; set; }
        public float GiaTien { get; set; }

        public DichVu() { }

        public DichVu(DataRow data)
        {
            this.MaDichVu = Convert.ToInt32(data["MaDichVu"]);
            this.TenDichVu = data["TenDichVu"].ToString();
            this.DonViTinh = data["DonViTinh"].ToString();
            this.GiaTien = float.Parse(data["GiaTien"].ToString());
        }
    }
}