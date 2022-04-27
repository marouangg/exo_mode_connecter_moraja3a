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
    public partial class Form2 : Form
    {
        string role = "admin";
        public Form2(string role)
        {
            InitializeComponent();
            this.role = role;
        }
        public Form2()
        {
            InitializeComponent();
        }
       void active(bool b)
        {
            if(role == "admin")
            {
                pnl_lst.Enabled =! b;
                pnl_miseajour.Visible = !b;
                pnl_details.Enabled = b;
                pnl_save.Visible = b;
            }
            else
            {
                pnl_lst.Enabled = !b;
                pnl_miseajour.Visible = b;
                pnl_details.Enabled = b;
                pnl_save.Visible = b;
            }
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
        SqlConnection getcon()
        {
            string sc = @"Data Source=DESKTOP-IF3P216\SQLEXPRESS;Initial Catalog=s_entrainement;User ID=sa;Password=123456";

            return new SqlConnection(sc);
        }
        void closecn(SqlConnection cn , SqlCommand com ,SqlDataReader dr)
        {
            dr.Close();
            dr = null;
            com = null;
            cn.Close();
            cn = null;
        }
        void closecn2(SqlConnection cn, SqlCommand com)
        {
            com = null;
            cn.Close();
            cn = null;
        }

        void service()
        {
            SqlConnection cn = getcon();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from service", cn);
            SqlDataReader dr = com.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            combo_service.DisplayMember = "nom_serv";
            combo_service.ValueMember = "num_serv";
            combo_service.DataSource = table;
            closecn(cn, com, dr);
        }

        void empoye(string f)
        {
            SqlConnection cn = getcon();
            cn.Open();
            SqlCommand com;
            if (f == "")
            {
                com = new SqlCommand("select * from Employe  where num_service =" + combo_service.SelectedValue, cn);
            }
            else
            {
                com = new SqlCommand("select * from Employe  where num_service =" + combo_service.SelectedValue + " and nom like '%" + f + "%'", cn);
            }

            SqlDataReader dr2 = com.ExecuteReader();
            DataTable table2 = new DataTable();
            table2.Load(dr2);
            lst.DisplayMember = "nom";
            lst.ValueMember = "Matricule";
            lst.DataSource = table2;
            //closecn(cn, com, dr);
        }
        void empolye2()
        {
            txt_matricule.Text = "";
            txt_nom.Text = "";
            txt_prenom.Text = "";
            txt_date.Text = "";
            txt_adresse.Text = "";
            txt_salaire.Text = "";
            txt_grade.Text = "";
            SqlConnection cn = getcon();
            cn.Open();
            SqlCommand com = new SqlCommand("select * from Employe  where Matricule = " + Convert.ToInt32(lst.SelectedValue), cn);
            SqlDataReader dr2 = com.ExecuteReader();
            while (dr2.Read())
            {
                txt_matricule.Text = dr2[0].ToString();
                txt_nom.Text = dr2[1].ToString();
                txt_prenom.Text = dr2[2].ToString();
                txt_date.Text = dr2[3].ToString();
                txt_adresse.Text = dr2[4].ToString();
                txt_salaire.Text = dr2[5].ToString();
                txt_grade.Text = dr2[6].ToString();
            }
            dr2.Close();
            cn.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            service();
            empoye("");
            active(false);
        }

        private void combo_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            empoye("");
            empolye2();
        }

        private void lst_SelectedValueChanged(object sender, EventArgs e)
        {
            empolye2();

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
            if(lst.SelectedIndex== lst.Items.Count - 1)
            {
                lst.SelectedIndex = 0;

            }
            else
            {
                lst.SelectedIndex ++;  
            }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex == 0)
            {
                lst.SelectedIndex = lst.Items.Count - 1;

            }
            else
                lst.SelectedIndex--;

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        bool choix = false;
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            clear();
            active(true);
            choix = true;
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            active(true);
            choix = false;
        }

        bool add_employe(string nom,string prenom,DateTime date_naissance,string adress,double salaire,string grade,int num_serv)
        {
            SqlConnection cn = getcon();
            cn.Open();
            SqlCommand com = new SqlCommand("insert into Employe values(@n,@p,@d,@a,@s,@g,@num_serv)", cn);
            com.Parameters.AddWithValue("@n", nom);
            com.Parameters.AddWithValue("@p", prenom);
            com.Parameters.AddWithValue("@d", date_naissance);
            com.Parameters.AddWithValue("@a", adress);
            com.Parameters.AddWithValue("@s", salaire);
            com.Parameters.AddWithValue("@g", grade);
            com.Parameters.AddWithValue("@num_serv", num_serv);
            if (com.ExecuteNonQuery() == 1)
            {
                closecn2(cn,com);
                return true;
            }
            else
            {
                closecn2(cn, com);
                return false;
            }
        }
        bool update_Employe(int matricule,string nom,string prenom,DateTime date_naissance,string adress,double salaire,string grade)
        {
            SqlConnection cn = getcon();
            cn.Open();
            SqlCommand com = new SqlCommand("update Employe set nom=@n,prenom=@p,dateNaissance=@d,Adresse=@a,salaire=@s,Grade=@g where Matricule=@m", cn);
            com.Parameters.AddWithValue("@n", nom);
            com.Parameters.AddWithValue("@p", prenom);
            com.Parameters.AddWithValue("@d", date_naissance);
            com.Parameters.AddWithValue("@a", adress);
            com.Parameters.AddWithValue("@s", salaire);
            com.Parameters.AddWithValue("@g", grade);
            com.Parameters.AddWithValue("@m", matricule);
            if (com.ExecuteNonQuery() == 1)
            {
                closecn2(cn, com);
                return true;
            }
            else
            {
                closecn2(cn, com);
                return false;
            }
        }
        private void btn_valider_Click(object sender, EventArgs e)
        {
            //SqlConnection cn = getcon();
            //cn.Open();
            //SqlCommand com;
            //if(choix == true)
            //{
            //    com = new SqlCommand("insert into Employe values(@n,@p,@d,@a,@s,@g,@num_serv)", cn);
            //}
            //else
            //{
            //    com = new SqlCommand("update Employe set nom =@n,prenom=@p,dateNaissance=@d,Adresse=@a,salaire=@s,Grade=@g where Matricule=@m", cn);
            //}
            if (choix == true)
            {
                //try
                //{
                //    string nom = txt_nom.Text;
                //    string prenom = txt_prenom.Text;
                //    DateTime date = Convert.ToDateTime(txt_date.Text);
                //    string adress = txt_adresse.Text;
                //    double salaire =Convert.ToDouble( txt_salaire.Text);
                //    string grade = txt_grade.Text;
                //    int num_serv = (int)combo_service.SelectedValue;
                //    Boolean insert_Employe = add_employe(nom, prenom, date, adress, salaire, grade, num_serv);
                //    if (insert_Employe == true)
                //    {
                //        MessageBox.Show("New employe save successfuly", "employe suved", MessageBoxButtons.OK);
                //        active(false);
                //        choix = false;

                //        empoye("");
                //    }
                //    else
                //    {
                //        MessageBox.Show("employe not inserted", "error save", MessageBoxButtons.OK);
                //    }

                //}
                //catch(Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                string nom = txt_nom.Text;
                string prenom = txt_prenom.Text;
                DateTime date = Convert.ToDateTime(txt_date.Text);
                string adress = txt_adresse.Text;
                double salaire = Convert.ToDouble(txt_salaire.Text);
                string grade = txt_grade.Text;
                int num_serv =Convert.ToInt32( combo_service.SelectedValue);
                Boolean insert_Employe = add_employe(nom, prenom, date, adress, salaire, grade, num_serv);
                if (insert_Employe == true)
                {
                    MessageBox.Show("New employe save successfuly", "employe suved", MessageBoxButtons.OK);
                    active(false);
                    choix = false;

                    empoye("");
                }
                else
                {
                    MessageBox.Show("employe not inserted", "error save", MessageBoxButtons.OK);
                }
            }
            //button modifier
            else
            {
                try
                {
                    string nom = txt_nom.Text;
                    string prenom = txt_prenom.Text;
                    DateTime date = Convert.ToDateTime(txt_date.Text);
                    string adress = txt_adresse.Text;
                    double salaire = Convert.ToDouble(txt_salaire.Text);
                    string grade = txt_grade.Text;
                    int matricule = Convert.ToInt32(lst.SelectedValue);
                    Boolean update_employe= update_Employe(matricule,nom,prenom,date,adress,salaire,grade);
                    if(update_employe == true)
                    {
                        MessageBox.Show("employe update successfuly", "employe update", MessageBoxButtons.OK);
                        active(false);
                        choix = false;
                        empoye("");
                    }
                    else
                    {
                        MessageBox.Show("employe not update", "error update", MessageBoxButtons.OK);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        bool remove_employe(int matricule)
        {
            SqlConnection cn = getcon();
            cn.Open();
            SqlCommand com = new SqlCommand("delete employe where Matricule =@m", cn);
            com.Parameters.AddWithValue("@m", matricule);
            if (com.ExecuteNonQuery() == 1)
            {
                closecn2(cn, com);
                return true;
            }
            else
            {
                closecn2(cn, com);
                return false;
            }
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int matricule = Convert.ToInt32(lst.SelectedValue);
                Boolean suprimer_employe = remove_employe(matricule);
                if (suprimer_employe)
                {
                    MessageBox.Show("employe removed successfuly", "employe rempve", MessageBoxButtons.OK);
                    empoye("");
                    empolye2();
                }
                else
                {
                    MessageBox.Show("employe not remove", "error remove", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            empoye(txt_find.Text);
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            active(false);
            choix = false;
            service();
            empoye("");
            empolye2();
        }
    }
}
