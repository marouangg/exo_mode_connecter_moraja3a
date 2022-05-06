using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace exo_mode_connecter_moraja3a
{
    public partial class Form5 : Form
    {
        ReportClass cr;
       string filter;
        public Form5(ReportClass cr,string filter)
        {
            InitializeComponent();
            this.cr = cr;
            this.filter = filter;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            crv.ReportSource = cr;
            crv.SelectionFormula = filter;
        }
    }
}
