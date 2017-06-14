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
    public partial class Form_POView : Form
    {
        private Form_Home mParentForm;
        private List<POInformation> mPurchaseOrders;

        public Form_POView()
        {
            InitializeComponent();

            //GET ALL THE PO'S FROM THE DATABASE AND PUT THEM
            // INTO FPONUMBER COMBO BOX

            LoadPoNumbers();
        }

        public void SetParent(Form_Home f)
        {
            this.mParentForm = f;
        }

        private void Form_POView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mParentForm.Show();
        }

        private void LoadPoNumbers()
        {
            DatabaseController d = new DatabaseController();
            mPurchaseOrders = d.GetPurchaseOrders();
            for(int i = 0; i < mPurchaseOrders.Count; i++)
            {
                if(!Fponumber.Items.Contains(mPurchaseOrders[i].OrderNumber))
                {
                    Fponumber.Items.Add(mPurchaseOrders[i].OrderNumber);
                }
            }
			Fponumber.Sorted = true;
        }

        private void Fponumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Flist.Items.Clear();
            for(int i = 0; i < mPurchaseOrders.Count; i++)
            {
                if(mPurchaseOrders[i].OrderNumber == (string) Fponumber.SelectedItem)
                {
                    Fproject.Text = mPurchaseOrders[i].ProjectName;
                    Fvendor.Text = mPurchaseOrders[i].Vendor;
                    Fpurchaser.Text = mPurchaseOrders[i].Purchaser;
                    Fprojectnumber.Text = mPurchaseOrders[i].JobNumber;
                    Fdate.Text = mPurchaseOrders[i].OrderDate;
					//Fshipto1.Text = mPurchaseOrders[i].ShippingInfo.ShippingName;
					//Fshipto2.Text = mPurchaseOrders[i].ShippingInfo.ShippingStreet;
					//Fshipto3.Text = mPurchaseOrders[i].ShippingInfo.ShippingLocation;
					Fdateeta.Text = mPurchaseOrders[i].DeliveryDate;
                    Fproject.Text = mPurchaseOrders[i].ProjectName;
                    Fattn.Text = mPurchaseOrders[i].Attention;
                    Ftotal.Text = mPurchaseOrders[i].Total.ToString();
                    Fnote.Text = mPurchaseOrders[i].Note;

                    DatabaseController d = new DatabaseController();
                    var ioi = d.GetMaterialItems(mPurchaseOrders[i].OrderNumber);
					float total = 0;
                    for (int j = 0; j < ioi.Count; j++)
                    {
						string s = ioi[j].description;
						if (ioi[j].isMaterial)
						{
							s += "\t|" + ioi[j].quantity + "qty";
							s += "\t|" + ioi[j].material;
							s += "\t|" + ioi[j].sheetsize;
							s += "\t|$" + ioi[j].unit_price + "ea";
							s += "\t|" + ioi[j].color;
						}
						total += ioi[j].total;
						Flist.Items.Add(s);
                    }
					Ftotal.Text = "" + total;
					//FEditButton.Visible = true;

					return;
                }
            }
        }

        private void FCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void FEditButton_Click(object sender, EventArgs e)
		{


			EnableEdit();
		}

		private void EnableEdit()
		{
			buttonSave.Visible = true;
			FSaveButton.Visible = false;
			FEditButton.Visible = false;
			canceleditbutton.Visible = true;

			Fponumber.Enabled = false;

			Fproject.Enabled = true;
			Fvendor.Enabled = true;
			Fpurchaser.Enabled = true;
			Fprojectnumber.Enabled = true;
			Fdate.Enabled = true;
			Fshipto1.Enabled = true;
			Fshipto2.Enabled = true;
			Fshipto3.Enabled = true;
			Fdateeta.Enabled = true;
			Fproject.Enabled = true;
			Fattn.Enabled = true;
			Ftotal.Enabled = true;
			Fnote.Enabled = true;
			Flist.Enabled = true;
		}

		private void EnableView()
		{
			buttonSave.Visible = false;
			FSaveButton.Visible = true;
			FEditButton.Visible = true;
			canceleditbutton.Visible = false;

			Fponumber.Enabled = true;

			Fproject.Enabled = false;
			Fvendor.Enabled = false;
			Fpurchaser.Enabled = false;
			Fprojectnumber.Enabled = false;
			Fdate.Enabled = false;
			Fshipto1.Enabled = false;
			Fshipto2.Enabled = false;
			Fshipto3.Enabled = false;
			Fdateeta.Enabled = false;
			Fproject.Enabled = false;
			Fattn.Enabled = false;
			Ftotal.Enabled = false;
			Fnote.Enabled = false;
			Flist.Enabled = false;
		}

		private void canceleditbutton_Click(object sender, EventArgs e)
		{
			EnableView();
		}

		private void FSaveButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
			saveFileDialog1.FilterIndex = 2;
			saveFileDialog1.RestoreDirectory = true;
			saveFileDialog1.FileName = Fponumber.Text;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				//System.IO.File.Copy(mExcelFiles[FList.SelectedIndex], saveFileDialog1.FileName);
				//System.Diagnostics.Process.Start(saveFileDialog1.FileName);
			}
		}
	}
}
