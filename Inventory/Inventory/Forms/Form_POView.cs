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
                    return;
                }
            }
        }

        private void FCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
