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
namespace SIP4
{
    public partial class Update1 : Form
    {
        string connectionMysql = "server=localhost;user=root;pwd=ThieN181201@;database=payroll1;port=3306;";
        string connectionSqlSever = @"Data Source=DESKTOP-B0D0J2Q\DUCTHIEN;Initial Catalog=HR;Integrated Security=True";
        public Update1()
        {
            
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_comeback(object sender, EventArgs e)
        {
            Lobby a = new Lobby();
            this.Hide();
            a.ShowDialog();
        }

        private void btn_home(object sender, EventArgs e)
        {

        }
        private string maxidMYSQL(string a)
        {
            MySqlConnection conn_mySql = new MySqlConnection(connectionMysql);
            string cmd = a;
            MySqlCommand commandd = new MySqlCommand(cmd, conn_mySql);

            // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ truy vấn
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(commandd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            string benefitid = "";
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    benefitid = row[column].ToString();
                }
            }
            return benefitid;
        }
        private string maxidSQL(string a)
        {
            SqlConnection conn_SqlSV = new SqlConnection(connectionSqlSever);
            string cmd = a;
            SqlCommand commandd = new SqlCommand(cmd, conn_SqlSV);

            // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ truy vấn
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            string benefitid = "";
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    benefitid = row[column].ToString();
                }
            }
            return benefitid;
        }
        private string add(string a)
        {
            
            int number = int.Parse(a);
            int result = number + 1;
            string newString = result.ToString();
            return newString;
        }
        private void btn_update(object sender, EventArgs e)
        {


            SqlConnection conn_SqlSV = new SqlConnection(connectionSqlSever);
            MySqlConnection conn_MySql = new MySqlConnection(connectionMysql);
            conn_MySql.Open();
            conn_SqlSV.Open();
            /*INSERT [dbo].[Employment] ([Employee_ID], [Employment_Status], [Hire_Date], [Workers_Comp_Code], 
             * [Termination_Date], [Rehire_Date], [Last_Review_Date]) 
             * VALUES (CAST(1001 AS Numeric(18, 0)), N'1', CAST(N'2000-01-20T00:00:00.000' AS DateTime),
             * N'1231', CAST(N'2005-02-20T00:00:00.000' AS DateTime), CAST(N'2009-05-20T00:00:00.000' AS DateTime),
             * CAST(N'2009-05-20T00:00:00.000' AS DateTime))


            "select MAX (Benefit_Plan_ID) from dbo.[Benefit_Plans] "
             */

            string benefitid = add(maxidSQL("select MAX (Benefit_Plan_ID) from dbo.[Benefit_Plans] "));
            string smd_Benefit_Plans = "SET IDENTITY_INSERT [dbo].[Benefit_Plans] ON " +
                "INSERT[dbo].[Benefit_Plans]([Benefit_Plan_ID], [Plan_Name], [Deductable], [Percentage_CoPay])" +
                " VALUES(CAST("+ benefitid + " AS Numeric(18, 0)), N'"+chucvu.Text+"', " +
                "CAST(10 AS Numeric(18, 0)), 12) SET IDENTITY_INSERT [dbo].[Benefit_Plans] OFF ";


            string employeeid = add(maxidSQL("select MAX (Employee_ID) from dbo.[Personal] "));
            string Personal = " INSERT [dbo].[Personal] ([Employee_ID], [First_Name], [Last_Name], [Middle_Initial], [Address1], " +
                "[Address2], [City], [State], [Zip], [Email], [Phone_Number], [Social_Security_Number], " +
                "[Drivers_License], [Marital_Status]," +
                " [Gender], [Shareholder_Status], [Benefit_Plans], [Ethnicity]) " +
                "VALUES (CAST("+ employeeid + " AS Numeric(18, 0)), N'"+ten.Text+"', N'"+ho.Text+"', N'"+tdvt.Text+"'," +
                " N'"+dc1.Text+"', N'"+dc2.Text+"', N'"+tp.Text+"', N'"+tb.Text+"', CAST("+zip.Text+" AS Numeric(18, 0))," +
                " N'"+email.Text+"'," +
                " N'"+sdt.Text+"', N'"+sanxh.Text+"'" +
                ", N'1212345677', N'"+((docthan.Checked) ? "1":"0")+"', " + ((nam.Checked) ? "1" : "0") +", "+ttcd.Text+", CAST("+benefitid+" AS Numeric(18, 0)), N'"+dantoc.Text+"') ";

       
            string Update_cmd_SqlSV = smd_Benefit_Plans + Personal;

            string emplid = add(maxidMYSQL("  SELECT `idEmployee` FROM `payroll1`.`employee` ORDER BY `idEmployee` DESC LIMIT 1; "));
            string cmd_epl = "INSERT INTO `employee` VALUES ("+employeeid+","+emplid+",'"+ten.Text+"','"+ho.Text+"',201482421,'"+tlctra.Text+"',"+idtylechitra.Text+",5,99,99);";
            //string cmd_payrate = "";
            string Update_cmd_Mysql = cmd_epl ;
                /*
                "SET IDENTITY_INSERT [dbo].[Benefit_Plans] ON INSERT[dbo].[Benefit_Plans]([Benefit_Plan_ID], [Plan_Name], [Deductable], [Percentage_CoPay]) VALUES(CAST(1 AS Numeric(18, 0)), N'Shareholder', CAST(10 AS Numeric(18, 0)), 12) SET IDENTITY_INSERT [dbo].[Benefit_Plans] OFF"
                + " INSERT [dbo].[Personal] ([Employee_ID], [First_Name], [Last_Name], [Middle_Initial], [Address1], [Address2], [City], [State], [Zip], [Email], [Phone_Number], [Social_Security_Number], [Drivers_License], [Marital_Status], [Gender], [Shareholder_Status], [Benefit_Plans], [Ethnicity]) VALUES (CAST(1001 AS Numeric(18, 0)), N'Dao', N'Nguyen', N'Thi Anh', N'2 Nguyen Van Linh', N'137 Nguyen Van Linh', N'Da Nang', N'Viet Nam', CAST(55000 AS Numeric(18, 0)), N'daonguyen123@gmail.com', N'123321123', N'123456789', N'1212345677', N'1', 0, 1, CAST(1 AS Numeric(18, 0)), N'Kinh')"
                + " INSERT [dbo].[Emergency_Contacts] ([Employee_ID], [Emergency_Contact_Name], [Phone_Number], [Relationship]) VALUES (CAST(1001 AS Numeric(18, 0)), N'Tuan huynh', N'12345678', N'husband')"
                + " INSERT [dbo].[Employment] ([Employee_ID], [Employment_Status], [Hire_Date], [Workers_Comp_Code], [Termination_Date], [Rehire_Date], [Last_Review_Date]) VALUES (CAST(1001 AS Numeric(18, 0)), N'1', CAST(N'2000-01-20T00:00:00.000' AS DateTime), N'1231', CAST(N'2005-02-20T00:00:00.000' AS DateTime), CAST(N'2009-05-20T00:00:00.000' AS DateTime), CAST(N'2009-05-20T00:00:00.000' AS DateTime))"
                + " SET IDENTITY_INSERT [dbo].[Job_History] ON INSERT[dbo].[Job_History]([ID], [Employee_ID], [Department], [Division], [Start_Date], [End_Date], [Job_Title], [Supervisor], [Job_Category], [Location], [Departmen_Code], [Salary_Type], [Pay_Period], [Hours_per_Week], [Hazardous_Training]) VALUES(CAST(1 AS Numeric(18, 0)), CAST(1001 AS Numeric(18, 0)), N'Policies', N'HR', CAST(N'2000-04-11T00:00:00.000' AS DateTime), CAST(N'2005-02-20T00:00:00.000' AS DateTime), N'Staff', CAST(0 AS Numeric(18, 0)), N'1', N'Danang', CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), N'month', CAST(40 AS Numeric(18, 0)), 1) SET IDENTITY_INSERT [dbo].[Job_History] OFF"
                
                ;
            /*
            "INSERT [dbo].[Employment] ([Employee_ID], [Employment_Status]," +
            " [Hire_Date], [Workers_Comp_Code], [Termination_Date], [Rehire_Date], [Last_Review_Date]) " +
            "VALUES("+ "CAST(1004 AS Numeric(18, 0)" + ten.Text+"," + ttvl.Text + "," + " CAST(N'"+ntd.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff")
            +"' AS DateTime)," +mbccn.Text + ","+ " CAST(N'2005-02-20T00:00:00.000' AS DateTime), CAST(N'2009-05-20T00:00:00.000' AS DateTime),"
            + "CAST(N'2009-05-20T00:00:00.000' AS DateTime))";*/
            using (SqlCommand command = new SqlCommand(Update_cmd_SqlSV, conn_SqlSV))
            {
                command.ExecuteNonQuery();
            }
            using (MySqlCommand command = new MySqlCommand(Update_cmd_Mysql, conn_MySql))
            {
                command.ExecuteNonQuery();
            }

            conn_SqlSV.Close();
            conn_MySql.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
