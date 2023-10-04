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
    public partial class Lobby : Form
    {
        string connectionMysql = "server=localhost;user=root;pwd=ThieN181201@;database=payroll1;port=3306;";
        string connectionSqlSever = @"Data Source=DESKTOP-B0D0J2Q\DUCTHIEN;Initial Catalog=HR;Integrated Security=True";
        public Lobby()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Update1 a = new Update1();
            this.Hide();
            a.ShowDialog();
        }
        
        private void btn_bangluong(object sender, EventArgs e)
        {


            
            TongQuat a = new TongQuat();
            this.Hide();
            a.ShowDialog();
        }
    }
}
