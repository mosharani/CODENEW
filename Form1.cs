using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        DBAccess db = new DBAccess();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sid = int.Parse(textBox1.Text);
            String sname = textBox2.Text;

            db.add_student(sid, sname);

            FillGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sid = int.Parse(textBox1.Text);
            String sname = textBox2.Text;

            db.update_student(sid, sname);

            FillGrid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sid = int.Parse(textBox1.Text);
            String sname = textBox2.Text;

            db.delete_student(sid, sname);

            FillGrid();
        }

        public void FillGrid()
        {
            DataSet ds = db.getAllJobs();
            dataGridView1.DataSource = ds.Tables["new_student"].DefaultView;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.Show();
        }
    }
}
