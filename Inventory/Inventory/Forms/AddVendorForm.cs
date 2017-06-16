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

		private DatabaseController mDatabaseController;

		public AddVendorForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";

			mDatabaseController = new DatabaseController();
			List<VendorsTable> vends = mDatabaseController.GetVendors();
			FillCombo(vends);
		}

		private void FillCombo(List<VendorsTable> vends)
		{
			comboBox1.Items.Clear();

			for (int i = 0; i < vends.Count; i++)
			{
				if (!comboBox1.Items.Contains(vends[i].vendor))
					comboBox1.Items.Add(vends[i].vendor);
			}
			comboBox1.Sorted = true;
		}

		private void okbtn_Click(object sender, EventArgs e)
        {
            string vendor = comboBox1.Text;

			mDatabaseController = new DatabaseController();
			List<VendorsTable> vends = mDatabaseController.GetVendors();
			for (int i = 0; i < vends.Count; i++)
			{
				if (vends[i].vendor.ToLower() == vendor.ToLower())
				{
					MessageBox.Show("The database already contains '" + vendor + "' and blocked the duplicate entry.", "Duplicate Object Blocked");
					return;
				}
			}
			bool valid = true;

            if (null == vendor || "" == vendor) {
                valid = false;
            }


            if (valid) {
                Submit(vendor);
                this.Close();
            }
            else {
                MessageBox.Show("Data Error");
            }
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

        Form_Main parent;
        public void SetParent(Form_Main paraentform)
        {
            parent = paraentform;
        }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			removebutton.Enabled = true;
		}

		private void removebutton_Click(object sender, EventArgs e)
		{
			try
			{
				var command = new OleDbCommand();
				command.Connection = connection;
				command.CommandText = "DELETE FROM Vendors WHERE VENDOR='" + comboBox1.Text + "'";

				connection.Open();
				command.ExecuteNonQuery();

				connection.Close();
				MessageBox.Show(comboBox1.Text + " Vendor Removed");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Removing Vendor: " + ex.ToString());
				connection.Close();
			}
			parent.UpdateLists();
			this.Close();
		}
	}
}
