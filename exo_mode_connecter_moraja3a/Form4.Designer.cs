namespace exo_mode_connecter_moraja3a
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lst_taches = new System.Windows.Forms.ListBox();
            this.combo_projects = new System.Windows.Forms.ComboBox();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.dgv_emps = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pourcentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_emps)).BeginInit();
            this.SuspendLayout();
            // 
            // lst_taches
            // 
            this.lst_taches.FormattingEnabled = true;
            this.lst_taches.Location = new System.Drawing.Point(53, 86);
            this.lst_taches.Name = "lst_taches";
            this.lst_taches.Size = new System.Drawing.Size(263, 472);
            this.lst_taches.TabIndex = 3;
            // 
            // combo_projects
            // 
            this.combo_projects.FormattingEnabled = true;
            this.combo_projects.Location = new System.Drawing.Point(51, 44);
            this.combo_projects.Name = "combo_projects";
            this.combo_projects.Size = new System.Drawing.Size(266, 21);
            this.combo_projects.TabIndex = 2;
            this.combo_projects.SelectedIndexChanged += new System.EventHandler(this.combo_projects_SelectedIndexChanged);
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(858, 582);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(128, 20);
            this.txt_total.TabIndex = 5;
            // 
            // dgv_emps
            // 
            this.dgv_emps.AllowUserToAddRows = false;
            this.dgv_emps.AllowUserToDeleteRows = false;
            this.dgv_emps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_emps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.nb,
            this.pourcentage});
            this.dgv_emps.Location = new System.Drawing.Point(377, 86);
            this.dgv_emps.Name = "dgv_emps";
            this.dgv_emps.ReadOnly = true;
            this.dgv_emps.Size = new System.Drawing.Size(590, 483);
            this.dgv_emps.TabIndex = 4;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            this.Nom.Width = 250;
            // 
            // nb
            // 
            this.nb.FillWeight = 150F;
            this.nb.HeaderText = "nombre des heures ";
            this.nb.Name = "nb";
            this.nb.ReadOnly = true;
            this.nb.Width = 170;
            // 
            // pourcentage
            // 
            this.pourcentage.FillWeight = 110F;
            this.pourcentage.HeaderText = "Pourcentage ";
            this.pourcentage.Name = "pourcentage";
            this.pourcentage.ReadOnly = true;
            this.pourcentage.Width = 110;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 703);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.dgv_emps);
            this.Controls.Add(this.lst_taches);
            this.Controls.Add(this.combo_projects);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_emps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_taches;
        private System.Windows.Forms.ComboBox combo_projects;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.DataGridView dgv_emps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn nb;
        private System.Windows.Forms.DataGridViewTextBoxColumn pourcentage;
    }
}