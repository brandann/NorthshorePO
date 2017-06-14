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

		private DatabaseController mDatabaseController;
		private List<string> CategoryItems;

		public AddCategoryForm()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";

			mDatabaseController = new DatabaseController();
			List<CategoryTable> cats = mDatabaseController.GetCategory();
			FillCombo(cats);
		}

		private void FillCombo(List<CategoryTable> cats)
		{
			comboBox1.Items.Clear();
			CategoryItems = new List<string>();

			for (int i = 0; i < cats.Count; i++)
			{
				if (!comboBox1.Items.Contains(cats[i].type))
				{
					comboBox1.Items.Add(cats[i].type);
					CategoryItems.Add(cats[i].type);
				}
			}
			comboBox1.Sorted = true;
		}

        private void Addbtn_Click(object sender, EventArgs e)
        {
            string category = comboBox1.Text;
			if(CategoryItems.Contains(category))
			{
				MessageBox.Show("Sorry, The Database already contains that Category.");
				return;
			}

            bool valid = true;

            if (null == category || "" == category) {
                valid = false;
            }

            if (valid) {
                Submit(category);
                this.Close();
            }
            else {
                MessageBox.Show("Data Error");
            }
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
            parent.UpdateLists();
        }

        Form_Main parent;
        public void SetParent(Form_Main paraentform)
        {
            parent = paraentform;
        }
    }
}
