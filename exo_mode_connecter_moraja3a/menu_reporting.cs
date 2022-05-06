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
    public partial class menu_reporting : Form
    {
        public menu_reporting()
        {
            InitializeComponent();
        }

        private void btn_employees_Click(object sender, EventArgs e)
        {
            la_list_employe_rp r = new la_list_employe_rp();
            r.SetDatabaseLogon("sa", "123456");
            immprimer m = new immprimer(r);
            m.Show();
        }

        private void btn_taches_Click(object sender, EventArgs e)
        {
            la_list_tach_regrouper_rp r = new la_list_tach_regrouper_rp();
            r.SetDatabaseLogon("sa", "123456");
            immprimer m = new immprimer(r);
            m.Show();
        }

        private void btn_projets_Click(object sender, EventArgs e)
        {
            CrystalReport1 r = new CrystalReport1();
            r.SetDatabaseLogon("sa", "123456");
            immprimer m = new immprimer(r);
            m.Show();
        }

        private void btn_carteTravail_Click(object sender, EventArgs e)
        {
            CrystalReport2 r = new CrystalReport2();
            r.SetParameterValue("chemin", Application.StartupPath + "\\photos\\");
            string f;
            if (combo_employee.Text == "Tout les employes")
                f = "";
            else
                f = "{employe.nom} like '*" + combo_employee.Text + "*'";

            r.SetDatabaseLogon("sa", "123456");
            immprimer m = new immprimer(r,f);
            m.Show();
        }

        private void menu_reporting_Load(object sender, EventArgs e)
        {
            string sc = @"Data Source=DESKTOP-IF3P216\SQLEXPRESS;Initial Catalog=s_entrainement;User ID=sa;Password=123456";
            SqlConnection cn = new SqlConnection(sc);
            cn.Open();
            SqlCommand com = new SqlCommand("select nom from employe", cn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
                combo_employee.Items.Add(dr[0].ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport3 r = new CrystalReport3();
            r.SetDatabaseLogon("sa", "123456");
            immprimer m = new immprimer(r);
            m.Show();
        }

        private void btn_lstprojetes_Click(object sender, EventArgs e)
        {
            CrystalReport4 ff = new CrystalReport4();
            ff.SetParameterValue("chemin", Application.StartupPath + "\\photos\\");
            ff.SetDatabaseLogon("sa", "123456");
            immprimer m = new immprimer(ff);
            m.Show();
        }
    }
}
