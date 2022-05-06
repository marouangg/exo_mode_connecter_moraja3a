namespace exo_mode_connecter_moraja3a
{
    partial class menu_reporting
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_lstprojetes = new System.Windows.Forms.Button();
            this.combo_employee = new System.Windows.Forms.ComboBox();
            this.btn_carteTravail = new System.Windows.Forms.Button();
            this.btn_projets = new System.Windows.Forms.Button();
            this.btn_taches = new System.Windows.Forms.Button();
            this.btn_employees = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(29, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(728, 85);
            this.button1.TabIndex = 20;
            this.button1.Text = "Un graphique histogramme ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_lstprojetes
            // 
            this.btn_lstprojetes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lstprojetes.Location = new System.Drawing.Point(29, 455);
            this.btn_lstprojetes.Name = "btn_lstprojetes";
            this.btn_lstprojetes.Size = new System.Drawing.Size(728, 85);
            this.btn_lstprojetes.TabIndex = 19;
            this.btn_lstprojetes.Text = "La liste des projets triés par les nombre d’heures ";
            this.btn_lstprojetes.UseVisualStyleBackColor = true;
            this.btn_lstprojetes.Click += new System.EventHandler(this.btn_lstprojetes_Click);
            // 
            // combo_employee
            // 
            this.combo_employee.FormattingEnabled = true;
            this.combo_employee.Location = new System.Drawing.Point(29, 331);
            this.combo_employee.Name = "combo_employee";
            this.combo_employee.Size = new System.Drawing.Size(323, 21);
            this.combo_employee.TabIndex = 18;
            this.combo_employee.Text = "Tout les employes";
            // 
            // btn_carteTravail
            // 
            this.btn_carteTravail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_carteTravail.Location = new System.Drawing.Point(29, 365);
            this.btn_carteTravail.Name = "btn_carteTravail";
            this.btn_carteTravail.Size = new System.Drawing.Size(728, 85);
            this.btn_carteTravail.TabIndex = 17;
            this.btn_carteTravail.Text = "La carte de travail ";
            this.btn_carteTravail.UseVisualStyleBackColor = true;
            this.btn_carteTravail.Click += new System.EventHandler(this.btn_carteTravail_Click);
            // 
            // btn_projets
            // 
            this.btn_projets.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_projets.Location = new System.Drawing.Point(29, 227);
            this.btn_projets.Name = "btn_projets";
            this.btn_projets.Size = new System.Drawing.Size(728, 85);
            this.btn_projets.TabIndex = 16;
            this.btn_projets.Text = "La liste des projets avec pour chaque projet la liste des employés ";
            this.btn_projets.UseVisualStyleBackColor = true;
            this.btn_projets.Click += new System.EventHandler(this.btn_projets_Click);
            // 
            // btn_taches
            // 
            this.btn_taches.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_taches.Location = new System.Drawing.Point(29, 123);
            this.btn_taches.Name = "btn_taches";
            this.btn_taches.Size = new System.Drawing.Size(728, 85);
            this.btn_taches.TabIndex = 15;
            this.btn_taches.Text = "La liste des tâches regroupées par projet";
            this.btn_taches.UseVisualStyleBackColor = true;
            this.btn_taches.Click += new System.EventHandler(this.btn_taches_Click);
            // 
            // btn_employees
            // 
            this.btn_employees.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employees.Location = new System.Drawing.Point(29, 22);
            this.btn_employees.Name = "btn_employees";
            this.btn_employees.Size = new System.Drawing.Size(728, 85);
            this.btn_employees.TabIndex = 14;
            this.btn_employees.Text = "La liste de tous les employés";
            this.btn_employees.UseVisualStyleBackColor = true;
            this.btn_employees.Click += new System.EventHandler(this.btn_employees_Click);
            // 
            // menu_reporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 669);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_lstprojetes);
            this.Controls.Add(this.combo_employee);
            this.Controls.Add(this.btn_carteTravail);
            this.Controls.Add(this.btn_projets);
            this.Controls.Add(this.btn_taches);
            this.Controls.Add(this.btn_employees);
            this.Name = "menu_reporting";
            this.Text = "menu_reporting";
            this.Load += new System.EventHandler(this.menu_reporting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_lstprojetes;
        private System.Windows.Forms.ComboBox combo_employee;
        private System.Windows.Forms.Button btn_carteTravail;
        private System.Windows.Forms.Button btn_projets;
        private System.Windows.Forms.Button btn_taches;
        private System.Windows.Forms.Button btn_employees;
    }
}