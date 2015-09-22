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
    public partial class AddVendorForm : Form
    {

        private OleDbConnection connection = new OleDbConnection();
        public AddVendorForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";
        }

        private void okbtn_Click(object sender, EventArgs e)
        {
            string vendor = textBox1.Text;
            bool valid = true;

            if (null == vendor || "" == vendor) { valid = false; }
            if (valid) { Submit(vendor); }
            else { MessageBox.Show("Data Error"); }
        }

        private void Submit(string vendor)
        {
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Vendors (VENDOR, CONTACT) VALUES('" + vendor + "', '" + "-" + "')";

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Vendor Inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                connection.Close();
            }
            parent.UpdateLists();
        }

        Form1 parent;
        public void SetParent(Form1 paraentform)
        {
            parent = paraentform;
        }
    }
}
