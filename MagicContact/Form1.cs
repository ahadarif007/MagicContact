using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace MagicContact
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
            
        }
        public ContactClass a1 = new ContactClass();

        private void Form1_Load(object sender, EventArgs e)
        {

            updateDisplay();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a1.FirstName = textBox2.Text;
            a1.LastName = textBox3.Text;
            a1.ContactNumber = textBox4.Text;
            a1.Address = richTextBox1.Text;
            a1.Gender = comboBox1.Text;

            //inserting data into DB
            bool success = ContactClass.Insert(a1);

            if(success==true)
            {
                MessageBox.Show("Successfully Inserted.");
                clear();
            }
            else
            {
                MessageBox.Show("failed To Add Contact");
            }
            updateDisplay();
        }

        public void clear()
        {
            textBox2.Text="";
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
        }
        public void updateDisplay()
        {
            // Loading data in data grid view 
            DataTable dt = ContactClass.select();
            dataGridView1.DataSource = dt;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get data from datagrid view 
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a1.ContactID = Convert.ToInt32(textBox1.Text);
            a1.FirstName = textBox2.Text;
            a1.LastName = textBox3.Text;
            a1.ContactNumber = textBox4.Text;
            a1.Address = richTextBox1.Text;
            a1.Gender = comboBox1.Text;

            //inserting data into DB
            bool success = ContactClass.Update(a1);

            if (success == true)
            {
                MessageBox.Show("Successfully Updated");
                clear();
            }
            else
            {
                MessageBox.Show("failed To Update Contact");
            }
            updateDisplay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a1.ContactID = int.Parse(textBox1.Text);
            a1.FirstName = textBox2.Text;
            a1.LastName = textBox3.Text;
            a1.ContactNumber = textBox4.Text;
            a1.Address = richTextBox1.Text;
            a1.Gender = comboBox1.Text;

            //inserting data into DB
            bool success = ContactClass.Delete(a1);

            if (success == true)
            {
                MessageBox.Show("Successfully Deleted");
                clear();
            }
            else
            {
                MessageBox.Show("failed To Delete");
            }
            updateDisplay();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tblcontactBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
