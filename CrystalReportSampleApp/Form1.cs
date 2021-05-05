using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CrystalReportSampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int16));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Result", typeof(string));

            dataGridView1.DataSource = dt;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int16));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Result", typeof(string));
            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                dt.Rows.Add(dgr.Cells[0].Value, dgr.Cells[1].Value, dgr.Cells[2].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("Sample.xml");
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
        }
    }
}
