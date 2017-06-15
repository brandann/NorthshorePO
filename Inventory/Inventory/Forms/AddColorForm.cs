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
	
    public partial class AddColorForm : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private DatabaseController mDatabaseController = new DatabaseController();

		public AddColorForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";
            
            
            // fill vendors
            List<VendorsTable> vendors = mDatabaseController.GetVendors();
            for (int i = 0; i < vendors.Count; i++)
            {
                vendorcmb.Items.Add(vendors[i].vendor);
            }

            // fill colors
            List<ColorTable> colors = mDatabaseController.GetColor();
            List<string> ColorList = new List<string>();
            List<string> TypeList = new List<string>();
            for (int i = 0; i < colors.Count; i++)
            {
                string color = colors[i].color;
                string type = colors[i].type;

                if (!ColorList.Contains(color)) 
                { 
                    ColorList.Add(color);
                    colorcmb.Items.Add(colors[i].color);
                }
                if (!TypeList.Contains(type)) 
                { 
                    TypeList.Add(type);
                    typecmb.Items.Add(colors[i].type);
                }
            }

            vendorcmb.Sorted = true;
            colorcmb.Sorted = true;
            typecmb.Sorted = true;
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
			SubmitButton_New();
        }

		private void SubmitButton_Old()
		{
			string color = colorcmb.Text;
			string vendor = vendorcmb.Text;
			string type = typecmb.Text;
			bool valid = true;

			List<ColorTable> colors = mDatabaseController.GetColor();
			for (int i = 0; i < colors.Count; i++)
			{
				if (colors[i].color == color)
				{
					if (colors[i].vendor == vendor)
					{
						if (colors[i].type == type)
						{
							MessageBox.Show("Color already exists");
							return;
						}
					}
				}
			}

			if (null == color || "" == color)
				valid = false;

			if (null == vendor || "" == vendor)
				valid = false;

			if (null == type || "" == type)
				valid = false;

			if (valid)
			{
				Submit(color, vendor, type);
				this.Close();
			}
			else
			{
				MessageBox.Show("Data Error");
			}
		}

		private void SubmitButton_New()
		{
			string color = colorcmb.Text;
			bool valid = true;

			mDatabaseController = new DatabaseController();
			List<ColorTable> colors = mDatabaseController.GetColor();
			for (int i = 0; i < colors.Count; i++)
			{
				if (colors[i].color.ToLower() == color.ToLower())
				{
					MessageBox.Show("The database already contains '" + color + "' and blocked the duplicate entry.", "Duplicate Object Blocked");
					return;
				}
			}

			if (null == color || "" == color)
				valid = false;

			if (valid)
			{
				Submit(color, "na", "na");
				this.Close();
			}
			else
			{
				MessageBox.Show("Data Error");
			}
		}

        private void Submit(string color, string vendor, string type)
        {
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Color (COLOR, VENDOR, TYPE) VALUES('" + color + "', '" + vendor + "', '" + type + "')";

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
                MessageBox.Show("Color Inserted");
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

		private void colorcmb_SelectedIndexChanged(object sender, EventArgs e)
		{
			removebutton.Enabled = true;
		}

		private void removebutton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Remove feature not yet implemented", "Not Implemented ");
		}
	}
}
