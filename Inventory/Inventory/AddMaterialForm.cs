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
    public partial class AddMaterialForm : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public AddMaterialForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string type = textBox1.Text;
            string width = textBox2.Text;
            string height = textBox3.Text;
            
            Submit(type, width, height);
        }

        private void Submit(string type, string width, string height)
        {
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Materials (MATERIAL_TYPE, DEFAULT_WIDTH, DEFAULT_HEIGHT) VALUES('" + type + "', '" + width + "', '" + height + "')";

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
