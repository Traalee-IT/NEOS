using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.Config
{
     class ConnectSQL
    {
        private static readonly string person_one = @"PHUC";
        private static readonly string person_two = @"DESKTOP-H5OKHH4\SQLEXPRESS";
        public static readonly string url = @"Data Source=DESKTOP-UCK7P15\SQLEXPRESS;Initial Catalog=QuanLyKhuTro;Persist Security Info=True;Integrated Security = true";

        private static ConnectSQL instance;

        public static ConnectSQL getInstance()
        {
            if (instance == null)
            {
                instance = new ConnectSQL();
            }
            return instance;
        }
       
        /// <summary>
        /// Mehtod này chỉ thực hiện nhiệm vụ lấy dữ liệu ra, select * from table
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet selectData(string sql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(url))
            {
                try
                {
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, connection))
                    {
                        da.Fill(ds);
                        da.Dispose();
                    }
                    
                }
                catch(Exception e)
                {
                    Console.WriteLine("Lỗi: " + e.ToString());
                    return null;
                }      
            }
           
            return ds;

        }

        /// <summary>
        /// Method thực hiện nhiệm vụ thêm, xóa, sửa, đọc
        /// Sử dụng using để tự giải phóng dữ liệu sau khi hoàn thành hoặc lỗi, tránh việc các connect không được đóng đúng cách
        /// và đảm bảo chương trình mượt mà
        /// Ngoài ra sử dụng giao dịch transaction để đảm bảo không có lỗi xảy ra khi tương tác với SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool CRUD(string sql)
        {
            bool check = false;
      
            using (SqlConnection connection = new SqlConnection(url))
            {
                connection.Open();
                // Bắt đầu một giao dịch
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                   
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Transaction = transaction;      
                        check = cmd.ExecuteNonQuery() > 0;
                    }
                    // Commit giao dịch nếu không có lỗi
                    transaction.Commit();

                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                    // Thực hiện rollback nếu có lỗi
                    transaction.Rollback();
                }   
            }
            return check;
        }

        public object excuteScalar(string sql)
        {
            object result =null;
            using (SqlConnection connection = new SqlConnection(url))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Sử dụng ExecuteScalar để lấy giá trị ID lớn nhất
                     result = command.ExecuteScalar();
                }
            }
            return result;
        }

    }
}
