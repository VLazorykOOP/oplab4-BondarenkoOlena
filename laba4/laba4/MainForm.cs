using System;
using System.Windows.Forms;

namespace laba4
{
    public partial class MainForm : Form
    {
        private DatabaseHelper dbHelper;
        public MainForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadComputers();
        }
        public void LoadComputers()
        {
            dataGridView1.DataSource = dbHelper.GetAllComputers();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                dbHelper.DeleteComputer(id);
                LoadComputers();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
        }
    }
}
