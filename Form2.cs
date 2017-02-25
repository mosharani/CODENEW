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
    public partial class Form2 : Form
    {
        DBAccess db = new DBAccess();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()
        {
            DataSet ds = db.getAllJobs();
            dataGridView1.DataSource = ds.Tables["new_student"].DefaultView;
        }
    }
}
