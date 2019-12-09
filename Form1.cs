using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        PrintDocument printDocument = new PrintDocument();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        DataSet ds = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            /*DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.Items.Add("terma");
            cmb.Items.Add("tabon");
            dataGridView1.Columns.Add(cmb);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = "hawi";
            btn.HeaderText = "click for fuck";
            btn.Name = "btn";
            dataGridView1.Columns.Add(btn);*/
            /*ComboBox comboBoxHeaderCell1 = new ComboBox();
            comboBoxHeaderCell1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHeaderCell1.Visible = true;
            comboBoxHeaderCell1.Items.Add("Column1");
            comboBoxHeaderCell1.Items.Add("Column2");
            dataGridView1.Controls.Add(comboBoxHeaderCell1);
            comboBoxHeaderCell1.Location = this.dataGridView1.GetCellDisplayRectangle(1, -1, true).Location;
            comboBoxHeaderCell1.Size = this.dataGridView1.Columns[0].HeaderCell.Size;
            comboBoxHeaderCell1.Text = "Column1";*/

            printPreviewDialog1.ShowDialog();

        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            table = new DataTable();
            table.Columns.Add(new DataColumn("id", typeof(int)));
            table.Columns.Add(new DataColumn("nom", typeof(string)));
            for(int i = 0; i < 20; i++)
            {
                table.Rows.Add(i, "abdu");
            }
            dataGridView1.DataSource = table;

        }

        private void afficher()
        {
            table = new DataTable();
            table.Columns.Add(new DataColumn("id",typeof(int)));
            table.Columns.Add(new DataColumn("nom",typeof(string)));
            table.Rows.Add(1, "abdu");
            table.Rows.Add(2, "gg");
            table.Rows.Add(1, "ftr");
            table.Rows.Add(3, "rob");


            
            table2.Columns.Add(new DataColumn("id", typeof(int)));
            table2.Rows.Add(1);
            table2.Rows.Add(2);
            table2.Rows.Add(3);
            
            ds.Tables.Add(table);
            ds.Tables.Add(table2);

            ds.Relations.Add("rl", ds.Tables[1].Columns[0], ds.Tables[0].Columns[0]);
            foreach(DataRow rowdt in table2.Rows)
            {
                comboBox1.Items.Add(rowdt[0]);
            }


         

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(CustomMsgBox msgBox = new CustomMsgBox())
            {
                msgBox.ShowDialog();
                string result = msgBox.id;
                MessageBox.Show(result);
                DataView dt = new DataView(table, "nom = '1'", "type = Desc", DataViewRowState.CurrentRows);
                //dataGridView1.DataSource = dt;

            }
            //((ToolStripMenuItem)contextMenuStrip1.Items[0]).Checked = true; //false;
            redToolStripMenuItem.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] rows = ds.Tables[1].Rows[comboBox1.SelectedIndex].GetChildRows("rl");
            DataTable tempTble = new DataTable();
            tempTble.Columns.Add("id");
            tempTble.Columns.Add("nom");
            foreach(DataRow row in rows)
            {
                tempTble.Rows.Add(row[0],row[1]);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = tempTble;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 20, 20, e.PageBounds.Width - 40, e.PageBounds.Height - 40);
            float mrg = 20;
            float colHeight = 60;
            e.Graphics.DrawLine(Pens.Black, mrg, mrg+colHeight, e.PageBounds.Width - mrg, mrg+colHeight);
            float col1Width = (e.PageBounds.Width - 40) / 2;
            e.Graphics.DrawLine(Pens.Black, mrg+col1Width, mrg, mrg+col1Width, e.PageBounds.Height - mrg);
        }
    }
}
