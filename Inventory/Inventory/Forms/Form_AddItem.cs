using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form_AddItem : Form
    {
        private Form_Main mParentForm;
        private int mIndex;

        public Form_AddItem()
        {
            InitializeComponent();

            FillDesignation();
            FillStatus();
            FillCategory();
        }

        public void SetParent(Form_Main p, int i)
        {
            this.mParentForm = p;
            this.mIndex = i;
            this.mParentForm.Hide();
        }

        public void SetParent(Form_Main p, int i, InventoryOrderItem ioi)
        {
            this.mParentForm = p;
            this.mIndex = i;
            this.mParentForm.Hide();

            descriptiontxt.Text = ioi.description;
            quantitytxt.Text = ioi.quantity;
            //unittxt.Text = item.unit;
            unitpricetxt.Text = ioi.unit_price.ToString();
            itemtotaltxt.Text = ioi.total.ToString();

            designationcmb.SelectedItem = ioi.designation;
            categorycmb.SelectedItem = ioi.category;
            statuscmb.SelectedItem = ioi.status;
        }

        // SAVE BUTTON
        private void itemsavebtn_Click(object sender, EventArgs e)
        {
            if (descriptiontxt.Text == "")
            {
                //descriptiontxt.Text = buildItem().GetMaterialDescription();
            }

            if (ValidateForm())
            {
                mParentForm.ReturnItem(buildItem(), mIndex);
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR: Please Check Fields");
            }
        }

        private bool ValidateForm()
        {
            bool valid = true;

            // #################################################################
            if (descriptiontxt.Text == "")
            {
                descriptiontxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                descriptiontxt.BackColor = Color.White;
            }

            // #################################################################
            if (quantitytxt.Text == "")
            {
                quantitytxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                quantitytxt.BackColor = Color.White;
            }

            // #################################################################
            if (unitpricetxt.Text == "")
            {
                unitpricetxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                unitpricetxt.BackColor = Color.White;
            }

            // #################################################################
            if (itemtotaltxt.Text == "")
            {
                itemtotaltxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                itemtotaltxt.BackColor = Color.White;
            }
            
            // #################################################################
            if (designationcmb.Text == "")
            {
                designationcmb.BackColor = Color.Red;
                label31.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                designationcmb.BackColor = Color.White;
                label31.BackColor = Color.White;
            }

            // #################################################################
            if (statuscmb.Text == "")
            {
                statuscmb.BackColor = Color.Red;
                label28.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                statuscmb.BackColor = Color.White;
                label28.BackColor = Color.White;
            }

            // #################################################################
            if (categorycmb.Text == "")
            {
                categorycmb.BackColor = Color.Red;
                label30.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                categorycmb.BackColor = Color.White;
                label30.BackColor = Color.White;
            }

            return valid;
        }

        private InventoryOrderItem buildItem()
        {
            InventoryOrderItem Item = new InventoryOrderItem();

            Item.description = descriptiontxt.Text;

            Item.quantity = quantitytxt.Text;
            Item.unit = unittxt.Text;
            Item.unit_price = ParseFloat(unitpricetxt.Text);
            Item.total = ParseFloat(itemtotaltxt.Text);

            Item.designation = designationcmb.Text;
            Item.category = categorycmb.Text;
            Item.status = statuscmb.Text;

            Item.material = "-";
            Item.gauge = "-";
            Item.color = "-";
            Item.width = 0;
            Item.height = 0;
            Item.size_unit = "-";

            Item.isMaterial = false;

            return Item;
        }

        private float ParseFloat(string tb)
        {
            float value = 0;

            if (tb == "")
            {
                return 0;
            }

            if (float.TryParse(tb, out value))
            {
                return value;
            }

            return 0;
        }

        // CLEAR BUTTON
        private void clearbtn_Click(object sender, EventArgs e)
        {
            descriptiontxt.ResetText();
            quantitytxt.ResetText();
            unitpricetxt.ResetText();
            itemtotaltxt.ResetText();

            designationcmb.SelectedIndex = -1;
            categorycmb.SelectedIndex = -1;
            statuscmb.SelectedIndex = -1;
    }

        // CANCEL BUTTON
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillDesignation()
        {
            designationcmb.Items.Add("Northshore");
            designationcmb.Items.Add("Northclad");
            designationcmb.Items.Add("Stock/Shop");
            designationcmb.Sorted = true;
        }

        private void FillStatus()
        {
            statuscmb.Items.Add("Inventory");
            statuscmb.Items.Add("Shipping/Receiving");
            statuscmb.Items.Add("Jobsite Delivery");
            statuscmb.Items.Add("Safety Stock");
            statuscmb.Sorted = true;
        }

        private void FillCategory()
        {
            categorycmb.Items.Clear();
            DatabaseController dc = new DatabaseController();
            List<CategoryTable> categories = dc.GetCategory();

            for (int i = 0; i < categories.Count; i++)
            {
                categorycmb.Items.Add(categories[i].type);
            }
        }

        private void quantitytxt_TextChanged(object sender, EventArgs e)
        {
            genTotal();
        }

        private void genTotal()
        {
            try
            {
                float quantity = ParseFloat(quantitytxt.Text);
                float price = ParseFloat(unitpricetxt.Text);
                itemtotaltxt.Text = (quantity * price).ToString();
            }
            catch (Exception e) { }
        }

        private void unitpricetxt_TextChanged(object sender, EventArgs e)
        {
            genTotal();
        }

        private void Form_AddItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mParentForm.Show();
        }

        private void DesButton_Click(object sender, EventArgs e)
        {
            descriptiontxt.Text = (string) categorycmb.SelectedItem;
        }
    }
}
