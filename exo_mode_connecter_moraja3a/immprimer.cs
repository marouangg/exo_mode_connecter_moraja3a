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
    public partial class immprimer : Form
    {
        ReportClass r;
        string m;
        public immprimer(ReportClass r,string m="")
        {
            InitializeComponent();
            this.r = r;
            this.m = m;
        }

        private void frm_reporting_1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.SelectionFormula = m;
        }

       
    }
}
