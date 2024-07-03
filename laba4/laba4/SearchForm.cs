using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public partial class SearchForm : Form
    {
        private DatabaseHelper dbHelper;
        public SearchForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text;
            DataTable results = dbHelper.SearchComputers(searchQuery);
            dataGridView1.DataSource = results;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
