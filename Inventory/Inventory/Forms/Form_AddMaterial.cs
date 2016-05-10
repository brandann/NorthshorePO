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
    public partial class Form_AddMaterial : Form
    {
        private Form_Main mParentForm;
        private int mIndex;

        List<MaterialTable> materials;

        public Form_AddMaterial()
        {
            InitializeComponent();

            // INIT
            FillDesignation();
            FillStatus();

            fillMaterialComboBox();
            fillGaugeComboBox();
            fillColorComboBox();
            fillSizeUnitComboBox();
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
            unittxt.Text = ioi.unit;
            unitpricetxt.Text = ioi.unit_price.ToString();
            itemtotaltxt.Text = ioi.total.ToString();

            designationcmb.SelectedItem = ioi.designation;
            statuscmb.SelectedItem = ioi.status;

            materialcmb.SelectedText = ioi.material;
            gaugecmb.SelectedItem = ioi.gauge;
            colorcmb.SelectedItem = ioi.color;
            widthtxt.Text = ioi.width.ToString();
            heighttxt.Text = ioi.height.ToString();
            sizeunitcmb.SelectedItem = ioi.size_unit;
        }

        // SAVE BUTTON
        private void itemsavebtn_Click(object sender, EventArgs e)
        {
            if (descriptiontxt.Text == "")
            {
                //descriptiontxt.Text = buildItem().GetMaterialDescription();
            }

            if(ValidateForm())
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
            if (widthtxt.Text == "")
            {
                widthtxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                widthtxt.BackColor = Color.White;
            }

            // #################################################################
            if (heighttxt.Text == "")
            {
                heighttxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                heighttxt.BackColor = Color.White;
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
            if (materialcmb.Text == "")
            {
                materialcmb.BackColor = Color.Red;
                label23.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                materialcmb.BackColor = Color.White;
                label23.BackColor = Color.White;
            }

            // #################################################################
            if (gaugecmb.Text == "")
            {
                gaugecmb.BackColor = Color.Red;
                label24.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                gaugecmb.BackColor = Color.White;
                label24.BackColor = Color.White;
            }

            // #################################################################
            if (colorcmb.Text == "")
            {
                colorcmb.BackColor = Color.Red;
                label25.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                colorcmb.BackColor = Color.White;
                label25.BackColor = Color.White;
            }

            return valid;
        }

        private InventoryOrderItem buildItem()
        {
            InventoryOrderItem Item = new InventoryOrderItem();

            Item.description = descriptiontxt.Text;

            Item.quantity = quantitytxt.Text;
            Item.unit = (string) unittxt.SelectedItem;
            Item.unit_price = ParseFloat(unitpricetxt.Text);
            Item.total = ParseFloat(itemtotaltxt.Text);

            Item.designation = designationcmb.Text;
            Item.category = "Flat Sheets";
            Item.status = statuscmb.Text;

            Item.material = materialcmb.Text;
            Item.gauge = gaugecmb.Text;
            Item.color = colorcmb.Text;
            Item.width = ParseFloat(widthtxt.Text);
            Item.height = ParseFloat(heighttxt.Text);
            Item.size_unit = sizeunitcmb.Text;

            Item.isMaterial = true;

            return Item;
        }

        // CLEAR BUTTON
        private void clearbtn_Click(object sender, EventArgs e)
        {
            descriptiontxt.ResetText();
            quantitytxt.ResetText();
            unitpricetxt.ResetText();
            itemtotaltxt.ResetText();

            designationcmb.SelectedIndex = -1;
            statuscmb.SelectedIndex = -1;
            materialcmb.SelectedIndex = -1;
            gaugecmb.SelectedIndex = -1;
            colorcmb.SelectedIndex = -1;
            unittxt.SelectedIndex = -1;
            sizeunitcmb.SelectedIndex = -1;

            widthtxt.ResetText();
            heighttxt.ResetText();
    }

        // CANCEL BUTTON
        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void fillMaterialComboBox()
        {
            materialcmb.Items.Clear();
            DatabaseController dc = new DatabaseController();
            materials = dc.GetMaterial();

            for (int i = 0; i < materials.Count; i++)
            {
                materialcmb.Items.Add(materials[i].material_type);
            }
        }

        private void fillGaugeComboBox()
        {
            gaugecmb.Items.Clear();
            DatabaseController dc = new DatabaseController();
            List<ThicknessTable> gauges = dc.GetThickness();

            for (int i = 0; i < gauges.Count; i++)
            {
                gaugecmb.Items.Add(gauges[i].thickness + " " + gauges[i].type.ToLower());
            }
        }

        private void fillColorComboBox()
        {
            colorcmb.Items.Clear();
            DatabaseController dc = new DatabaseController();
            List<ColorTable> colors = dc.GetColor();

            colors.Sort();

            for (int i = 0; i < colors.Count; i++)
            {
                if (!colorcmb.Items.Contains(colors[i].color))
                {
                    colorcmb.Items.Add(colors[i].color);
                }
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

        private void materialcmb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                widthtxt.Text = materials[materialcmb.SelectedIndex].width;
                heighttxt.Text = materials[materialcmb.SelectedIndex].height;
            }
            catch (Exception ex) { }
        }

        private void quantitytxt_TextChanged_1(object sender, EventArgs e)
        {
            genTotal();
        }

        private void unitpricetxt_TextChanged(object sender, EventArgs e)
        {
            genTotal();
        }

        private void Form_AddMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mParentForm.Show();
        }

        private void materialcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                widthtxt.Text = materials[materialcmb.SelectedIndex].width;
                heighttxt.Text = materials[materialcmb.SelectedIndex].height;
            }
            catch (Exception ex) { }
        }

        private void DesButton_Click(object sender, EventArgs e)
        {
            descriptiontxt.Text = buildItem().GetMaterialDescription();
        }
    }
}
