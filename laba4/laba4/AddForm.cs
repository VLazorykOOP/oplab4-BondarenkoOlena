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
    public partial class AddForm : Form
    {
        private DatabaseHelper dbHelper;
        private MainForm mainForm;
        public AddForm(MainForm mainForm)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.mainForm = mainForm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string processorType = textBox2.Text;
            string clockSpeed = textBox3.Text;
            string ram = textBox4.Text;
            string hdd = textBox5.Text;
            string videoCard = textBox6.Text;
            string soundCard = textBox7.Text;

            dbHelper.AddComputer(name, processorType, clockSpeed, ram, hdd, videoCard, soundCard);

            mainForm.LoadComputers();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
