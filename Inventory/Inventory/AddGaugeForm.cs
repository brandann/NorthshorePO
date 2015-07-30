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
    public partial class AddGaugeForm : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public AddGaugeForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";
            DatabaseController databaseController = new DatabaseController();

            // fill colors
            List<ThicknessTable> gaugetypes = databaseController.GetThickness();
            List<string> TypeList = new List<string>();
            for (int i = 0; i < gaugetypes.Count; i++)
            {
                string type = gaugetypes[i].type;

                if (!TypeList.Contains(type))
                {
                    TypeList.Add(type);
                    labelcmb.Items.Add(type);
                }
            }

            labelcmb.Sorted = true;
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            string thickness = thicknesstxt.Text;
            string type = labelcmb.Text;
            bool valid = true;

            if (null == thickness || "" == thickness) { valid = false; }
            if (null == type || "" == type) { valid = false; }
            if (valid) { Submit(thickness, type); }
            else { MessageBox.Show("Data Error"); }
        }

        private void Submit(string thickness, string type)
        {
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Thicnkess (THICKNESS, TYPE) VALUES('" + thickness + "', '" + type + "')";

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
