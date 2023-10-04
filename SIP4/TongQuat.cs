using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization;
namespace SIP4
{
    public partial class TongQuat : Form
    {
        string connectionMysql = "server=localhost;user=root;pwd=ThieN181201@;database=payroll1;port=3306;";
        string connectionSqlSever = @"Data Source=DESKTOP-B0D0J2Q\DUCTHIEN;Initial Catalog=HR;Integrated Security=True";

        

        public TongQuat()
        {
            InitializeComponent();
        }

        private void btn_backwalk(object sender, EventArgs e)
        {
            Lobby a = new Lobby();
            this.Hide();
            a.ShowDialog();
        }
        private void InsertDatadt()
        {
            SqlConnection conn_SqlSV = new SqlConnection(connectionSqlSever);
            MySqlConnection conn_MySql = new MySqlConnection(connectionMysql);
            conn_MySql.Open();
            conn_SqlSV.Open();



            // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ truy vấn

            string cmd_add = " ";

            try
            {
                // Lấy dữ liệu từ bảng A
                string selectQuery = "select Employee_ID, Ethnicity from dbo.Personal; ";
                SqlCommand selectCommand = new SqlCommand(selectQuery, conn_SqlSV);
                SqlDataReader reader = selectCommand.ExecuteReader();

                string selectQueryMy = "SELECT Employee_Number,Pay_Amount, Paid_To_Date, Pay_Rate,Tax_Percentage,Last_Name,First_Name FROM payroll1.employee " +
                     "join payroll1.pay_rates on" +
                     " payroll1.employee.PayRates_id = payroll1.pay_rates.idPay_Rates; ";
                MySqlCommand selectCommandmy = new MySqlCommand(selectQueryMy, conn_MySql);
                MySqlDataReader readermy = selectCommandmy.ExecuteReader();



                while (reader.Read() && readermy.Read())
                {
                    //INSERT [dbo].[Personal] ([Employee_ID], [First_Name], [Last_Name], [Middle_Initial],
                    //[Address1], [Address2], [City], [State], [Zip], [Email], [Phone_Number], [Social_Security_Number],
                    //[Drivers_License], [Marital_Status], [Gender], [Shareholder_Status], [Benefit_Plans], [Ethnicity]) 
                    //VALUES (CAST(1001 AS Numeric(18, 0)), N'Dao', N'Nguyen', N'Thi Anh', N'2 Nguyen Van Linh', N'137 
                    //Nguyen Van Linh', N'Da Nang', N'Viet Nam', CAST(55000 AS Numeric(18, 0)), N'daonguyen123@gmail.com', 
                    //N'123321123', N'123456789', N'1212345677', N'1', 0, 1, CAST(1 AS Numeric(18, 0)), N'Kinh')"

                    // Đọc giá trị từ mỗi dòng dữ liệu
                    string id = reader.GetDecimal(0).ToString();
                    string dantoc = reader.GetString(1);

                    int payamount = Convert.ToInt32(readermy.GetDecimal(1));
                    int paidtodate = Convert.ToInt32(readermy.GetDecimal(2));
                    int payrate = (int)float.Parse(readermy.GetString(3));
                    int tax = Convert.ToInt32(readermy.GetDecimal(4));
                    string lname = readermy.GetString(5);
                    string fname = readermy.GetString(6);
                    int salary = Math.Abs(payamount * (tax - payrate));
                    cmd_add += "INSERT dbo.dan_toc ([id],[name],[luong],[dan_toc])" +
                        " values (N'" + id + "', N'" + lname + " " + fname + "' , " + salary + " ,N'" + dantoc + "' );";



                    //int id1 = readermy.GetInt32(0);
                    /*
                    decimal payamount = readermy.GetDecimal(1);
                    decimal paidtodate = readermy.GetDecimal(2);           
                    string payrate = readermy.GetString(3);*/

                    // Sử dụng dữ liệu theo nhu cầu của bạn (ví dụ: hiển thị, lưu trữ, xử lý...)

                    // Ví dụ: In ra giá trị của cột 1 và cột 2
                    //Console.WriteLine("Column1: " + id);
                    //Console.WriteLine("Column2: " + dantoc);

                    /* Console.WriteLine("Column1: " + payamount);
                     Console.WriteLine("Column2: " + paidtodate);
                     Console.WriteLine("Column3: " + payrate);*/



                }

                reader.Close();
            }
            finally
            {

                // Đóng kết nối sau khi hoàn thành
                //conn_SqlSV.Close();
            }
            using (SqlCommand command = new SqlCommand(cmd_add, conn_SqlSV))
            {
                //Console.WriteLine(cmd_add);
                command.ExecuteNonQuery();
            }
            /*string s = "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1001, Tuan Huynh , 42000000 ,Kinh );" +
                "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1002, Dao Nguyen , 105000000 ,Kinh );" +
                "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1003, Hoang Tran , 42000000 ,Kinh );" +
                "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1004, Huynh Hoang , 105000000 ,Hoa );";
*/






            conn_SqlSV.Close();
            conn_MySql.Close();
        }
        private void InsertDatagt()
        {
            SqlConnection conn_SqlSV = new SqlConnection(connectionSqlSever);
            MySqlConnection conn_MySql = new MySqlConnection(connectionMysql);
            conn_MySql.Open();
            conn_SqlSV.Open();



            // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ truy vấn

            string cmd_add = " ";

            try
            {
                // Lấy dữ liệu từ bảng A
                string selectQuery = "select Employee_ID, Gender from dbo.Personal; ";
                SqlCommand selectCommand = new SqlCommand(selectQuery, conn_SqlSV);
                SqlDataReader reader = selectCommand.ExecuteReader();

                string selectQueryMy = "SELECT Employee_Number,Pay_Amount, Paid_To_Date, Pay_Rate,Tax_Percentage,Last_Name,First_Name FROM payroll1.employee " +
                     "join payroll1.pay_rates on" +
                     " payroll1.employee.PayRates_id = payroll1.pay_rates.idPay_Rates; ";
                MySqlCommand selectCommandmy = new MySqlCommand(selectQueryMy, conn_MySql);
                MySqlDataReader readermy = selectCommandmy.ExecuteReader();



                while (reader.Read() && readermy.Read())
                {
                    //INSERT [dbo].[Personal] ([Employee_ID], [First_Name], [Last_Name], [Middle_Initial],
                    //[Address1], [Address2], [City], [State], [Zip], [Email], [Phone_Number], [Social_Security_Number],
                    //[Drivers_License], [Marital_Status], [Gender], [Shareholder_Status], [Benefit_Plans], [Ethnicity]) 
                    //VALUES (CAST(1001 AS Numeric(18, 0)), N'Dao', N'Nguyen', N'Thi Anh', N'2 Nguyen Van Linh', N'137 
                    //Nguyen Van Linh', N'Da Nang', N'Viet Nam', CAST(55000 AS Numeric(18, 0)), N'daonguyen123@gmail.com', 
                    //N'123321123', N'123456789', N'1212345677', N'1', 0, 1, CAST(1 AS Numeric(18, 0)), N'Kinh')"

                    // Đọc giá trị từ mỗi dòng dữ liệu
                    string id = reader.GetDecimal(0).ToString();
                    string gioitinh = reader.GetBoolean(1).ToString();

                    int payamount = Convert.ToInt32(readermy.GetDecimal(1));
                    int paidtodate = Convert.ToInt32(readermy.GetDecimal(2));
                    int payrate = (int)float.Parse(readermy.GetString(3));
                    int tax = Convert.ToInt32(readermy.GetDecimal(4));
                    string lname = readermy.GetString(5);
                    string fname = readermy.GetString(6);
                    int salary = Math.Abs(payamount * (tax - payrate));
                    cmd_add += "INSERT dbo.gioi_tinh ([id],[name],[gioi_tinh],[luong])" +
                        " values (N'" + id + "', N'" + lname + " " + fname + "' , N'" +((gioitinh)== "True"? "Nu":"Nam" ) + "' ," +salary + ");";



                    //int id1 = readermy.GetInt32(0);
                    /*
                    decimal payamount = readermy.GetDecimal(1);
                    decimal paidtodate = readermy.GetDecimal(2);           
                    string payrate = readermy.GetString(3);*/

                    // Sử dụng dữ liệu theo nhu cầu của bạn (ví dụ: hiển thị, lưu trữ, xử lý...)

                    // Ví dụ: In ra giá trị của cột 1 và cột 2
                    //Console.WriteLine("Column1: " + id);
                    //Console.WriteLine("Column2: " + dantoc);

                    /* Console.WriteLine("Column1: " + payamount);
                     Console.WriteLine("Column2: " + paidtodate);
                     Console.WriteLine("Column3: " + payrate);*/



                }

                reader.Close();
            }
            finally
            {

                // Đóng kết nối sau khi hoàn thành
                //conn_SqlSV.Close();
            }
            using (SqlCommand command = new SqlCommand(cmd_add, conn_SqlSV))
            {
                //Console.WriteLine(cmd_add);
                command.ExecuteNonQuery();
            }
            /*string s = "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1001, Tuan Huynh , 42000000 ,Kinh );" +
                "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1002, Dao Nguyen , 105000000 ,Kinh );" +
                "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1003, Hoang Tran , 42000000 ,Kinh );" +
                "INSERT dbo.dantoc ([id],[name],[luong],[dan_toc]) values (1004, Huynh Hoang , 105000000 ,Hoa );";
*/






            conn_SqlSV.Close();
            conn_MySql.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InsertDatadt();
            InsertDatagt();
            using (SqlConnection connection = new SqlConnection(connectionSqlSever))
            {
                connection.Open();



                // Thực hiện truy vấn để lấy dữ liệu từ cơ sở dữ liệu
                string sqlQuery = "SELECT * FROM dbo.dan_toc";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ truy vấn
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                // Tạo một DataTable để chứa dữ liệu từ cơ sở dữ liệu
                DataTable dataTable = new DataTable();

                // Sử dụng phương thức Fill của SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu vào DataTable
                dataAdapter.Fill(dataTable);

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dataGridView1.DataSource = dataTable;



                // Thực hiện truy vấn để lấy dữ liệu từ cơ sở dữ liệu
                string sqlQuerygt = "SELECT * FROM dbo.gioi_tinh";
                SqlCommand commandgt = new SqlCommand(sqlQuerygt, connection);

                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ truy vấn
                SqlDataAdapter dataAdaptergt = new SqlDataAdapter(commandgt);

                // Tạo một DataTable để chứa dữ liệu từ cơ sở dữ liệu
                DataTable dataTablegt = new DataTable();

                // Sử dụng phương thức Fill của SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu vào DataTable
                dataAdaptergt.Fill(dataTablegt);

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dataGridView2.DataSource = dataTablegt;
                connection.Close();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
