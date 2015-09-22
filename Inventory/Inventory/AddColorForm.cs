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
        

        public AddColorForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";
            DatabaseController databaseController = new DatabaseController();
            
            // fill vendors
            List<VendorsTable> vendors = databaseController.GetVendors();
            for (int i = 0; i < vendors.Count; i++)
            {
                vendorcmb.Items.Add(vendors[i].vendor);
            }

            // fill colors
            List<ColorTable> colors = databaseController.GetColor();
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
            string color = colorcmb.Text;
            string vendor = vendorcmb.Text;
            string type = typecmb.Text;
            bool valid = true;

            if (null == color || "" == color) { valid = false; }
            if (null == vendor || "" == vendor) { valid = false; }
            if (null == type || "" == type) { valid = false; }
            if (valid) { Submit(color, vendor, type); }
            else { MessageBox.Show("Data Error"); }
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

        Form1 parent;
        public void SetParent(Form1 paraentform)
        {
            parent = paraentform;
        }
    }
}
