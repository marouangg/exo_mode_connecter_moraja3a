using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace exo_mode_connecter_moraja3a
{
    public partial class Form1 : Form
    {
        string role = "";
        public Form1(string role)
        {
            InitializeComponent();
            this.role = role;
        }
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection getcon()
        {
            string sc = @"Data Source=DESKTOP-IF3P216\SQLEXPRESS;Initial Catalog=s_entrainement;User ID=sa;Password=123456";

            return new SqlConnection(sc);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string role = "";
            SqlConnection cn = getcon();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from utilisateure where login =@l", cn);
            com.Parameters.AddWithValue("@l",textBox1.Text);
            SqlDataReader dr = com.ExecuteReader();           
            while (dr.Read())
            {
                if(dr[5].ToString()==textBox2.Text && Convert.ToDateTime(dr[3]) > DateTime.Today)
                {
                    role = dr[4].ToString();
                }
            }
            cn.Close();
            if (role != "")
            {
                Form2 f = new Form2();
                f.Show();
            }
            else MessageBox.Show("error");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
