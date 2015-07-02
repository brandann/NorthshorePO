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
    public partial class Form2 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private InventoryOrderItem item;
        private bool newItem;
        private Form1 parentForm;
        private int item_index;

        public Form2()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\Receiving and current inventory\NssmInventory.mdb; Persist Security Info=False;";
            fillMaterialComboBox();
            fillGaugeComboBox();
            fillColorComboBox();
            fillSizeUnitComboBox();
            fillDesignationComboBox();
            fillCategoryComboBox();
            fillStatusComboBox();

            hidecmb.Items.Add("YES");
            hidecmb.Items.Add("NO");
            
        }

        public void NewItem(bool isMaterial, Form1 parent)
        {
            item = new InventoryOrderItem();
            item.isMaterial = isMaterial;
            //init(item, parent);

            if (item != null && item.isMaterial)
            {
                categorycmb.SelectedText = "Material";
            }
            statuscmb.SelectedItem = "Shipping/Receiving";

            newItem = true;
            item_index = -1;

            parentForm = parent;
            materialpanel.Enabled = item.isMaterial;

            widthtxt.Text = "48";
            heighttxt.Text = "96";
            sizeunitcmb.SelectedItem = "IN";

            hidecmb.SelectedItem = "NO";
        }

        public void EditItem(InventoryOrderItem ioi, Form1 parent, int index)
        {
            item = ioi;
            init(item, parent);

            newItem = false;
            item_index = index;
        }

        private void init(InventoryOrderItem ioi, Form1 parent)
        {
            this.item = ioi;
            descriptiontxt.Text = item.description;
            quantitytxt.Text = item.quantity;
            //unittxt.Text = item.unit;
            unitpricetxt.Text = item.unit_price.ToString();
            totaltxt.Text = item.total.ToString();

            designationcmb.SelectedItem = item.designation;
            categorycmb.SelectedItem = item.category;
            statuscmb.SelectedItem = item.status;

            materialpanel.Enabled = item.isMaterial;
            materialcmb.SelectedText = item.material;
            gaugecmb.SelectedItem = item.gauge;
            colorcmb.SelectedItem = item.color;
            widthtxt.Text = item.width.ToString();
            heighttxt.Text = item.height.ToString();
            sizeunitcmb.SelectedItem = item.size_unit;

            parentForm = parent;
        }

        #region Events
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void descriptionbtn_Click(object sender, EventArgs e)
        {
            if(item.isMaterial)
            {
                descriptiontxt.Text = buildItem().GetMaterialDescription();
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (descriptiontxt.Text == "")
            {
                descriptiontxt.Text = buildItem().GetMaterialDescription();
            }

            parentForm.ReturnItem(buildItem(), item_index);
            this.Close();
        }

        private void unittxt_TextChanged(object sender, EventArgs e)
        {
            genTotal();
        }

        private void unitpricetxt_TextChanged(object sender, EventArgs e)
        {
            genTotal();
        }
        #endregion

        private InventoryOrderItem buildItem()
        {
            InventoryOrderItem Item = new InventoryOrderItem();

            Item.description = descriptiontxt.Text;

            Item.quantity = quantitytxt.Text;
            Item.unit = " ";
            Item.unit_price = float.Parse(unitpricetxt.Text);
            Item.total = float.Parse(totaltxt.Text);

            Item.designation = designationcmb.Text;
            Item.category = categorycmb.Text;
            Item.status = statuscmb.Text;

            Item.material = materialcmb.Text;
            Item.gauge = gaugecmb.Text;
            Item.color = colorcmb.Text;
            Item.width = float.Parse(widthtxt.Text);
            Item.height = float.Parse(heighttxt.Text);
            Item.size_unit = sizeunitcmb.Text;

            Item.isMaterial = item.isMaterial;

            return Item;
        }

        private void fillMaterialComboBox()
        {
            List<string> str = new List<string>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select MATERIAL_TYPE from Material";
                var reader = command.ExecuteReader();

                List<string> vendors = new List<string>();
                while (reader.Read())
                {
                    str.Add(reader.GetString(0));
                }

                str.Sort();

                for (int i = 0; i < str.Count; i++)
                {
                    materialcmb.Items.Add(str[i].ToString());
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void fillGaugeComboBox()
        {
            List<Thickness> str = new List<Thickness>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Thickness";
                var reader = command.ExecuteReader();

                List<string> vendors = new List<string>();
                while (reader.Read())
                {
                    Thickness t = new Thickness();
                    t.thickness = reader.GetString(1);
                    t.type = reader.GetString(2);
                    str.Add(t);
                }

                str.Sort();

                for (int i = 0; i < str.Count; i++)
                {
                    gaugecmb.Items.Add(str[i].ToString());
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void fillColorComboBox()
        {
            List<string> str = new List<string>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select COLOR from Color";
                var reader = command.ExecuteReader();

                List<string> vendors = new List<string>();
                while (reader.Read())
                {
                    if(!str.Contains(reader.GetString(0)))
                    {
                        str.Add(reader.GetString(0));
                    }
                }

                str.Sort();

                for (int i = 0; i < str.Count; i++)
                {
                    colorcmb.Items.Add(str[i].ToString());
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void fillSizeUnitComboBox()
        {
            sizeunitcmb.Items.Add("IN");
            sizeunitcmb.Items.Add("FT");
            sizeunitcmb.Items.Add("MM");
            sizeunitcmb.Items.Add("CM");

            sizeunitcmb.Sorted = true;
        }

        private void fillDesignationComboBox()
        {
            designationcmb.Items.Add("Northshore");
            designationcmb.Items.Add("Northclad");
            designationcmb.Items.Add("Stock/Shop");

            designationcmb.Sorted = true;
        }

        private void fillCategoryComboBox()
        {
            List<string> str = new List<string>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select TYPE from Category";
                var reader = command.ExecuteReader();

                List<string> vendors = new List<string>();
                while (reader.Read())
                {
                    if (!str.Contains(reader.GetString(0)))
                    {
                        str.Add(reader.GetString(0));
                    }
                }

                str.Sort();

                for (int i = 0; i < str.Count; i++)
                {
                    categorycmb.Items.Add(str[i].ToString());
                }

                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private void fillStatusComboBox()
        {
            statuscmb.Items.Add("Inventory");
            statuscmb.Items.Add("Shipping/Receiving");
            statuscmb.Items.Add("Jobsite Delivery");

            statuscmb.Sorted = true;
        }

        private class Thickness : IComparable<Thickness>
        {
            public string thickness;
            public string type;

            public int CompareTo(Thickness other)
            {
                if(type == other.type)
                {
                    return float.Parse(thickness).CompareTo(float.Parse(other.thickness));
                }

                return this.type.CompareTo(other.type);
            }

            public override string ToString()
            {
                return thickness + " " + type;
            }
        }

        private void genTotal()
        {
            try
            {
                float quantity = (quantitytxt.Text == "") ? 0f : float.Parse(quantitytxt.Text);
                float price = (unitpricetxt.Text == "") ? 0f : float.Parse(unitpricetxt.Text);
                totaltxt.Text = (quantity * price).ToString();
            } catch (Exception e)
            {

            }
            
        }
    }
}
