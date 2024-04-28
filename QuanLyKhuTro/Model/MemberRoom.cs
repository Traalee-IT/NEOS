using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyKhuTro.Model
{
    public class MemberRoom
    {
        public Customer customer { get; set; }
        public string chucVu { get; set; }

        public MemberRoom(DataRow row)
        {
            customer = new Customer(row);
            this.chucVu = row["ChucVu"].ToString();
        }
    }
}
