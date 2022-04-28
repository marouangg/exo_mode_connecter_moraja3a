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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection getcnx()
        {
            string sc = @"Data source=DESKTOP-IF3P216\SQLEXPRESS;Initial catalog=s_entrainement;User ID=sa;Password=123456";
            // string sfc= @"Data Source=DESKTOP-IF3P216\SQLEXPRESS;Initial Catalog=s_entrainement;User ID=sa;Password=123456";

            return new SqlConnection(sc);
        }

        void Projet()
        {
            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com=new SqlCommand("select * from projet",cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(dr);
            combo_projects.DisplayMember = "nom_prj";
            combo_projects.ValueMember = "num_prj";
            combo_projects.DataSource = t;
        }
        void tache()
        {
            lst_taches.Items.Clear();
            dgv_emps.Rows.Clear();
            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from Tache where num_prj="+combo_projects.SelectedValue, cn);
            SqlCommand com2 = new SqlCommand("select nom,SUM(Nombre_heure) as nb,(SUM(Nombre_heure)*100)/(select sum(Nombre_heure) from Projet p inner join Tache t on p.Num_prj=t.Num_prj inner join Travaille tr on tr.num_tache=t.Num_tach where p.Num_prj=@num_prj)  as total from Employe e inner join Travaille t on e.Matricule=t.Matricule inner join Tache ta on ta.num_tach=t.num_tache inner join Projet p on p.Num_prj=ta.Num_prj where p.Num_prj=@num_prj group by nom", cn);
            com2.Parameters.AddWithValue("@num_prj", combo_projects.SelectedValue);
            SqlCommand com3 = new SqlCommand("select sum(nombre_heure) from Projet p inner join Tache t on t.num_prj=p.num_prj inner join Travaille tr on tr.num_tache=t.num_tach where p.num_prj="+combo_projects.SelectedValue, cn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                lst_taches.Items.Add(dr["nom_tache"]);
            }
            dr.Close();
          dr=  com2.ExecuteReader();
            while (dr.Read())
            {
                dgv_emps.Rows.Add(dr[0], dr[1], dr[2] + "%");
            }
            dr.Close();
            double totale =Convert.ToDouble( com3.ExecuteScalar());
            txt_total.Text = totale.ToString();
            //DataTable t = new DataTable();
            //t.Load(dr);
            //lst_taches.DisplayMember = "nom_tache";
            //lst_taches.ValueMember = "num_tach";
            //lst_taches.DataSource = t;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Projet();
        }

        private void combo_projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            tache();
        }
    }
}
