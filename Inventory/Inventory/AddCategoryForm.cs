using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Inventory
{
    public partial class AddCategoryForm : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public AddCategoryForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            string category = textBox1.Text;
            bool valid = true;

            if (null == category || "" == category) { valid = false; }
            if (valid) { Submit(category); }
            else { MessageBox.Show("Data Error"); }
        }

        private void Submit(string category)
        {
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Category (TYPE) VALUES('" + category + "')";

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Category Inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                connection.Close();
            }
        }
    }
}
