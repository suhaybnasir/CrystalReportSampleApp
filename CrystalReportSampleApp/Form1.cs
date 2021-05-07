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
            BindData2();
        }

        private void BindData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Result", typeof(string));

            dataGridView1.DataSource = dt;
        }

        private void BindData2()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Lambar", typeof(string));
            dt.Columns.Add("Magac", typeof(string));
            dt.Columns.Add("Natiijo", typeof(string));

            dataGridView2.DataSource = dt;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Result", typeof(string));
            foreach (DataGridViewRow dgr in dataGridView1.Rows)
            {
                dt.Rows.Add(dgr.Cells[0].Value, dgr.Cells[1].Value, dgr.Cells[2].Value);
            }
            ds.Tables.Add(dt);
            ds.WriteXmlSchema("Sample.xml");


            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Lambar", typeof(string));
            dt1.Columns.Add("Magac", typeof(string));
            dt1.Columns.Add("Natiijo", typeof(string));
            foreach (DataGridViewRow dgr1 in dataGridView2.Rows)
            {
                dt.Rows.Add(dgr1.Cells[0].Value, dgr1.Cells[1].Value, dgr1.Cells[2].Value);
            }
            ds1.Tables.Add(dt1);
            ds1.WriteXmlSchema("Sample1.xml");


            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds1);

            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();


        }
    }
}
