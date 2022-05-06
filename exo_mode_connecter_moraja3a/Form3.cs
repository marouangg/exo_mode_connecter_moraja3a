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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection getcnx()
        {
            string sc = @"Data Source=DESKTOP-IF3P216\SQLEXPRESS;Initial Catalog=s_entrainement;User ID=sa;Password=123456";
            return new SqlConnection(sc);
        }

        //this function add new service
        void service()
        {
            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from service", cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(dr);
            combo_service.DisplayMember = "nom_serv";
            combo_service.ValueMember = "num_serv";
            combo_service.DataSource = t;
        }

        //had functoin kat3amar list box 
        void employe()
        {
            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from employe where num_service=" + combo_service.SelectedValue , cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(dr);
            lst.DisplayMember = "nom";
            lst.ValueMember = "Matricule";
            lst.DataSource = t;
        }




        //had functon kat3amar textbox
        void employe2()
        {
            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from Employe  where Matricule = " + Convert.ToInt32(lst.SelectedValue), cn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                txt_matricule.Text = dr[0].ToString();
                txt_nom.Text = dr[1].ToString();
                txt_prenom.Text = dr[2].ToString();
                txt_date.Text = dr[3].ToString();
                txt_adresse.Text = dr[4].ToString();
                txt_salaire.Text = dr[5].ToString();
                txt_grade.Text = dr[6].ToString();
            }
        }




        private void Form3_Load(object sender, EventArgs e)
        {
            service();
          //  employe();
        }

        //evinement dyal fax kanbadlo fa combobox kitbadlo les employe dyal listbox
        private void combo_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            employe();
           //employe2();
        }

        //evinemet dyal listbox fax kan selectiniw xi7ad fa list ki t afficha fa textbox
        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            employe2();
        }

        //button rechercher
        private void btn_find_Click(object sender, EventArgs e)
        {
            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from employe where num_service=" + combo_service.SelectedValue+"and nom like '%"+txt_find.Text+"%'", cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable t = new DataTable();
            t.Load(dr);
            lst.DisplayMember = "nom";
            lst.ValueMember = "Matricule";
            lst.DataSource = t;
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            lst.SelectedIndex=lst.Items.Count-1;
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            lst.SelectedIndex = 0;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if(lst.SelectedIndex == lst.Items.Count - 1)
                lst.SelectedIndex = 0;
            else
                lst.SelectedIndex++;
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex ==0)
                lst.SelectedIndex = lst.Items.Count - 1;
            else
            lst.SelectedIndex--;

        }
        void clear()
        {
            txt_matricule.Text = "";
            txt_nom.Text = "";
            txt_prenom.Text = "";
            txt_date.Text = "";
            txt_adresse.Text = "";
            txt_salaire.Text = "";
            txt_grade.Text = "";
            txt_nom.Focus();
        }
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            //clear();

            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into employe values(@n,@p,@d,@a,@s,@g,@num_ser)", cn);
            com.Parameters.AddWithValue("@n",txt_nom.Text);
            com.Parameters.AddWithValue("@p",txt_prenom.Text);
            com.Parameters.AddWithValue("@d",txt_date.Text);
            com.Parameters.AddWithValue("@a",txt_adresse.Text);
            com.Parameters.AddWithValue("@s",txt_salaire.Text);
            com.Parameters.AddWithValue("@g",txt_grade.Text);
            com.Parameters.AddWithValue("@num_ser",combo_service.SelectedValue);

            com.ExecuteNonQuery();

            employe();
            clear();
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            SqlConnection cn = getcnx();
            cn.Open();
            SqlCommand com = new SqlCommand("update employe set nom=@n,prenom=@p,dateNaissance=@d,Adresse=@a,salaire=@s,Grade=@g where Matricule=@m", cn);
            com.Parameters.AddWithValue("@n", txt_nom.Text);
            com.Parameters.AddWithValue("@p", txt_prenom.Text);
            com.Parameters.AddWithValue("@d", txt_date.Text);
            com.Parameters.AddWithValue("@a", txt_adresse.Text);
            com.Parameters.AddWithValue("@s", txt_salaire.Text);
            com.Parameters.AddWithValue("@g", txt_grade.Text);
            com.Parameters.AddWithValue("@m", lst.SelectedValue);

            com.ExecuteNonQuery();

            employe();
            clear();
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            SqlConnection cn = getcnx();
            cn.Open();
           // SqlCommand com = new SqlCommand("delete employe where matricule="+lst.SelectedValue, cn);
            SqlCommand com = new SqlCommand("delete employe where matricule=@m", cn);
            com.Parameters.AddWithValue("@m", lst.SelectedValue);
            com.ExecuteNonQuery();
            employe();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
