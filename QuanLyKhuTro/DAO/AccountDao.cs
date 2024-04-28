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
    class AccountDao
    {
       public bool Update(Account a)
        {
            string sql = string.Format("UPDATE TaiKhoan" +
                " SET " +
                " FullName = N'{0}' ," +
                " Password = '{1}' " +
                " WHERE UserName = '{2}'", a.Name, a.Password, a.UserName);
            return ConnectSQL.getInstance().CRUD(sql);
        }


        //Kiểm tra đăng nhập
        public Account login(string userName, string pass)
        {
            Account loggedInAccount = null;
            try
            {
                string sql = string.Format("SELECT * FROM TaiKhoan" +
                    " WHERE UserName = '{0}' " +
                    " AND Password = '{1}'", userName, pass);
                DataSet data = ConnectSQL.getInstance().selectData(sql);
                // Kiểm tra xem có dữ liệu được trả về không
                if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
                {
                    DataRow row = data.Tables[0].Rows[0];

                    // Tạo một đối tượng Account và gán từng cột từ DataRow vào trường tương ứng
                    loggedInAccount = new Account
                    {
                        
                        UserName = row["UserName"].ToString(),
                        Password = row["Password"].ToString(),
                        Name = row["FullName"].ToString(),
                     
                    };

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return null;
            }

            return loggedInAccount;
        }


    }
}
