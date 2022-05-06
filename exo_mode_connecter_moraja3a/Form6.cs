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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btn_employees_Click(object sender, EventArgs e)
        {
            rpt_tous_employe ee = new rpt_tous_employe();
            ee.SetDatabaseLogon("sa", "123456");
            Form5 f = new Form5(ee, "");
            f.Show();
        }

        private void btn_taches_Click(object sender, EventArgs e)
        {
            rpt_tache_projet ee = new rpt_tache_projet();
            ee.SetDatabaseLogon("sa", "123456");
            Form5 f = new Form5(ee, "");
            f.Show();
        }

        private void btn_projets_Click(object sender, EventArgs e)
        {
            rpt_projet_employe ee = new rpt_projet_employe();
            ee.SetDatabaseLogon("sa", "123456");
            Form5 f = new Form5(ee, "");
            f.Show();
        }
        SqlConnection getcon()
        {
            string sc = @"Data Source=DESKTOP-IF3P216\SQLEXPRESS;Initial Catalog=s_entrainement;User ID=sa;Password=123456";

            return new SqlConnection(sc);
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection sc = getcon();
            sc.Open();
            SqlCommand com = new SqlCommand("select nom from employe", sc);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
                combo_employee.Items.Add(dr[0].ToString());
        }

        private void btn_carteTravail_Click(object sender, EventArgs e)
        {
            rpt_tous_employe r = new rpt_tous_employe();
            r.SetParameterValue("chemin", Application.StartupPath + "\\photos\\");
            string f;
            if (combo_employee.Text == "Tout les employes")
                f = "";
            else
                f = "{employe.nom} like '*" + combo_employee.Text + "*'";

            r.SetDatabaseLogon("sa", "123456");
            Form5 ff = new Form5(r, f);
            ff.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //rp ee = new rp_graphique();
            //ee.SetDatabaseLogon("sa", "123456");
            //Form5 f = new Form5(ee, "");
            //f.Show();
        }
    }
}
