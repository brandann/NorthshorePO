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

		private DatabaseController mDatabaseController;
		private List<string> MaterialItems;

		public AddMaterialForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";

			mDatabaseController = new DatabaseController();
			List<MaterialTable> mats = mDatabaseController.GetMaterial();
			FillCombo(mats);
		}

		private void FillCombo(List<MaterialTable> mats)
		{
			comboBox1.Items.Clear();
			MaterialItems = new List<string>();

			for (int i = 0; i < mats.Count; i++)
			{
				if (!comboBox1.Items.Contains(mats[i].material_type))
				{
					comboBox1.Items.Add(mats[i].material_type);
					MaterialItems.Add(mats[i].material_type);
				}
			}
			comboBox1.Sorted = true;
		}

		private void addbtn_Click(object sender, EventArgs e)
        {
            string type = comboBox1.Text;
            string width = TextWidth.Text;
            string height = TextHeight.Text;

			List<MaterialTable> mats = mDatabaseController.GetMaterial();
			for (int i = 0; i < mats.Count; i++)
			{
				if (mats[i].material_type == type)
				{
					MessageBox.Show("Sorry, This material is already added to the database");
					return;
				}
			}

			Submit(type, width, height);
            this.Close();
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
            parent.UpdateLists();
        }

        Form_Main parent;
        public void SetParent(Form_Main paraentform)
        {
            parent = paraentform;
        }

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<MaterialTable> mats = mDatabaseController.GetMaterial();
			for(int i = 0; i < mats.Count; i++)
			{
				if(mats[i].material_type == comboBox1.Text)
				{
					TextWidth.Text = mats[i].width;
					TextHeight.Text = mats[i].height;
				}
			}
		}
	}
}
