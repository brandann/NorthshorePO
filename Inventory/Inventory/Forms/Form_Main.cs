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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel; 

namespace Inventory
{
    public partial class Form_Main : Form
    {
        #region Members
        private List<Purchaser> mPurchasers;
        private List<InventoryOrderItem> mOrderItems;
        private List<PurchaseOrderItem> mPurchaseOrderResults;
        private string mPurchaseOrderNumber;
        private string mInitials;
        private Form_Home mParentForm;

        private OleDbConnection connection = new OleDbConnection();
        
        public enum eSearchByTerms { ePONumber, eProjectNumber, eMaterialType, eMaterialColor}
        public enum eDataViewType { eInventory, eVendor, eColor, eMaterial, eThickness, ePurchaser, ePurchseOrder }
        private DatabaseController mDatabaseController;

        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        #endregion

        #region constructor
        public Form_Main()
        {
            InitializeComponent();
            connection.ConnectionString = InventoryDatabase.ConnectionString;
            mDatabaseController = new DatabaseController();
            
            reset();
            //start with create right now
            initNewPO();
        }
        #endregion

        #region init
        private void reset() { }

        public void initNewPO()
        {
            reset();

            POPanel.Visible = true;

            fillPurchaserComboBox();
            fillVendorComboBox();
            fillShippingAddressComboBox();

            ClearCreateForm();
            SetPoNumber();

            mOrderItems = new List<InventoryOrderItem>();
        }

        public void initLookup()
        {
            reset();
        }

        public void SetParent(Form_Home f)
        {
            this.mParentForm = f;
        }

        private void ClearCreateForm()
        {
            mOrderItems = new List<InventoryOrderItem>();
            PoNumbertxt.Text = "";

            purchasercmb.SelectedIndex = -1;
            initialtxt.Text = "";

            vendorcmb.SelectedIndex = -1;
            attntxt.Text = "";

            projecttxt.Text = "";
            jobnumbertxt.Text = "";

            shippingcmb.SelectedIndex = 0;
            address1txt.Text = "11831 Beverly Park RD. Bldg C.";
            address2txt.Text = "Everett, WA 98204";

            orderitemlist.Items.Clear();
            mOrderItems.Clear();

            orderdate.ResetText();
            deliverydate.ResetText();

            totaltxt.Text = "";

            notetxt.Text = "";
        }

        private void fillShippingAddressComboBox()
        {
            shippingcmb.Items.Add(NAME_NORTHSHORE);
            shippingcmb.Items.Add(NAME_NORTHCLAD);
            shippingcmb.Items.Add(NAME_FACADE);
			shippingcmb.Items.Add(NAME_HAWAII);

            shippingcmb.Items.Add(NAME_NORTHSHORE + " Shop 2");
            shippingcmb.Items.Add(NAME_NORTHCLAD + " Shop 2");
            shippingcmb.Items.Add(NAME_FACADE + " Shop 2");

            shippingcmb.Items.Add("Jobsite Delivery");

            shippingcmb.SelectedIndex = 0;
        }

		private const string NAME_NORTHSHORE = "Northshore Exteriors, Inc.";
		private const string NAME_NORTHCLAD = "Northclad, Inc.";
		private const string NAME_FACADE = "Facade Supply";
		private const string NAME_HAWAII = "Northshore Exteriors, Inc. (HI)";

		private void shippingcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (shippingcmb.Text == NAME_NORTHSHORE)
            {
                address1txt.Text = "11831 Beverly Park RD. Bldg C.";
                address2txt.Text = "Everett, WA 98204";
            }
            else if (shippingcmb.Text == NAME_NORTHCLAD)
            {
                address1txt.Text = "11831 Beverly Park RD. Bldg C.";
                address2txt.Text = "Everett, WA 98204";
            }
            else if (shippingcmb.Text == NAME_FACADE)
            {
                address1txt.Text = "11831 Beverly Park RD. Bldg C.";
                address2txt.Text = "Everett, WA 98204";
            }
            else if (shippingcmb.Text == NAME_NORTHSHORE + " Shop 2")
            {
                address1txt.Text = "2822 119th Street SW";
                address2txt.Text = "Everett, WA 98204";
            }
            else if (shippingcmb.Text == NAME_NORTHCLAD + " Shop 2")
            {
                address1txt.Text = "2822 119th Street SW";
                address2txt.Text = "Everett, WA 98204";
            }
            else if (shippingcmb.Text == NAME_FACADE + " Shop 2")
            {
                address1txt.Text = "2822 119th Street SW";
                address2txt.Text = "Everett, WA 98204";
            }
            else if (shippingcmb.Text == "Jobsite Delivery")
            {
                address1txt.Text = "";
                address2txt.Text = "";
            }
			else if (shippingcmb.Text == NAME_HAWAII)
			{
				address1txt.Text = "1714 Homerule STR";
				address2txt.Text = "Honolulu, HI 96819";
			}
        }

        private POInformation MakePOInformation()
        {
            POInformation p = new POInformation();
            p.OrderNumber = PoNumbertxt.Text;
            p.Purchaser = purchasercmb.Text;
            p.Vendor = vendorcmb.Text;
            p.JobNumber = jobnumbertxt.Text;
            p.OrderDate = orderdate.Value.Year + "-" + orderdate.Value.Month + "-" + orderdate.Value.Day;
            p.Total = ParseFloat(totaltxt.Text);
            p.Note = GetNoteStringForDB();
            p.ProjectName = projecttxt.Text;
            p.DeliveryDate = deliverydate.Value.Year + "-" + deliverydate.Value.Month + "-" + deliverydate.Value.Day;
            return p;
        }

        private void fillVendorComboBox()
        {
            vendorcmb.Items.Clear();

            List<VendorsTable> vendors = mDatabaseController.GetVendors();
            for(int i = 0; i < vendors.Count; i++)
            {
				if(!vendorcmb.Items.Contains(vendors[i].vendor))
					vendorcmb.Items.Add(vendors[i].vendor);
            }
        }

        private void fillPurchaserComboBox()
        {
            purchasercmb.Items.Clear();
            mPurchasers = new List<Purchaser>();
            List<PurchasersTable> p = mDatabaseController.GetPurchasers();
            for (int i = 0; i < p.Count; i++)
            {
                if(p[i].isActive)
                {
                    Purchaser purchaser = new Purchaser();
                    purchaser.name = p[i].name_last + ", " + p[i].name_first;
                    purchaser.initials = p[i].initials;
                    mPurchasers.Add(purchaser);
                    purchasercmb.Items.Add(p[i].name_last + ", " + p[i].name_first);
                }
            }
        }
        #endregion

        #region Events
        private void edititem_Click(object sender, EventArgs e)
        {
            if(orderitemlist.SelectedIndex != -1)
            {
                if(mOrderItems[orderitemlist.SelectedIndex].isMaterial)
                {
                    Form_AddMaterial form = new Form_AddMaterial();
                    form.Show();
                    form.SetParent(this, orderitemlist.SelectedIndex, mOrderItems[orderitemlist.SelectedIndex]);
                }
                else
                {
                    Form_AddItem form = new Form_AddItem();
                    form.Show();
                    form.SetParent(this, orderitemlist.SelectedIndex, mOrderItems[orderitemlist.SelectedIndex]);
                }
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }
            
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            POInformation p = MakePOInformation();
            if(!isPOValid())
            {
                MessageBox.Show("ERROR: Purchase Order Not Valid, Please Check Fields");
                return;
            }

            if (!SubmitPO(p))
            {
                MessageBox.Show("ERROR: Purchase Order Not inserted into database");
                return;
            }

            if (!SavePO())
            {
                MessageBox.Show("ERROR: Purchase Order Not Saved");
                return;
            }
        }

        private void purchasercmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < mPurchasers.Count; i++)
            {
                if (mPurchasers[i].name == purchasercmb.SelectedItem as string)
                {
                    initialtxt.Text = mInitials = mPurchasers[i].initials;
                    formatPoNumber();
                }
            }
        }

        private void getponumbtn_Click(object sender, EventArgs e)
        {
            SetPoNumber();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearCreateForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initNewPO();
        }

        private void lookupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initLookup();
        }
        #endregion

        #region private Methods
        private void SetPoNumber()
        {
            int year = DateTime.Now.Year - 2000;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
			int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

			//var NUM = year + month + day + hour + min + sec + 100;

            string po = "";
			//string po = "" + NUM;

			po += (month < 10) ? "0" + month.ToString() : month.ToString();
			po += (day < 10) ? "0" + day.ToString() : day.ToString();
			po += (min < 10) ? "0" + min.ToString() : min.ToString();

			PoNumbertxt.Text = mPurchaseOrderNumber = po;
            formatPoNumber();
        }

        private void formatPoNumber()
        {
			if (mInitials == null || mInitials == "")
			{
				PoNumbertxt.Text = mPurchaseOrderNumber;
				return;
			}

			if (mPurchaseOrderNumber == null || mPurchaseOrderNumber == "")
			{
				return;
			}

			PoNumbertxt.Text = mPurchaseOrderNumber + "" + mInitials;

			//PoNumbertxt.Text = jobnumbertxt.Text + mPurchaseOrderNumber + initialtxt.Text;
		}

        private void calctotal()
        {
            float total = 0f;
            for (int i = 0; i < mOrderItems.Count; i++)
            {
                total += mOrderItems[i].total;
            }

            totaltxt.Text = "" + total; // "$" + total
        }

        private bool SubmitPO(POInformation p)
        {
            string queue = BuildQueue.buildQueuePO(p);
            mPurchasers = new List<Purchaser>();
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = queue;

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Submitting PO Information");
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
            }

            int materialcount = 0;
            for (int i = 0; i < mOrderItems.Count; i++)
            {
                SubmitMaterialItem(mOrderItems[i], p);
                materialcount++;

                /*if (OrderItems[i].isMaterial)
                {
                    SubmitMaterialItem(OrderItems[i], p);
                    materialcount++;
                }*/
            }
            MessageBox.Show("Purchase Order submitted (" + materialcount + ")");
            return true;
        }
        
        private void SubmitMaterialItem(InventoryOrderItem ioi, POInformation p)
        {
            string queue = BuildQueue.buildQueueMaterial(ioi, p);
            mPurchasers = new List<Purchaser>();
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = queue;

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Submitting Material Item. " + ex);
            }
            finally
            {
                connection.Close();
            }
        }
        
        private string GetNoteStringForDB()
        {
            // this is a test of the textbox length, we are testing that when the text it longer 
            // than 255 characters anything over 250 will be cut off and replaced with a "..." 
            // in the database and the full text will be daved in the file version of the 
            // purchase order. thank you

            string textBox = notetxt.Text;
            if(textBox.Length == 0)
            {
                return " ";
            }
            else if(textBox.Length >= 255)
            {
                return textBox.Substring(0, 252) + "...";
            }
            return textBox;
        }

        private bool isPOValid()
        {
            bool valid = true;

            // #################################################################
            if (PoNumbertxt.Text == "" || PoNumbertxt.TextLength <= 3) 
            {
                PoNumbertxt.BackColor = Color.Red;
                valid =  false; 
            }
            else
            {
                PoNumbertxt.BackColor = Color.White;
            }

            // #################################################################
            if (purchasercmb.Text == "")
            {
                purchasercmb.BackColor = Color.Red;
                label2.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                purchasercmb.BackColor = Color.White;
                label2.BackColor = Color.White;
            }

            // #################################################################
            if (vendorcmb.Text == "")
            {
                vendorcmb.BackColor = Color.Red;
                label6.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                vendorcmb.BackColor = Color.White;
                label6.BackColor = Color.White;
            }

            // #################################################################
            if (initialtxt.TextLength == 0)
            {
                initialtxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                initialtxt.BackColor = Color.White;
            }

            // #################################################################
            if (jobnumbertxt.TextLength == 0)
            {
                jobnumbertxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                jobnumbertxt.BackColor = Color.White;
            }

            // #################################################################
            if (projecttxt.TextLength == 0)
            {
                projecttxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                projecttxt.BackColor = Color.White;
            }

            // #################################################################
            if (orderitemlist.Items.Count == 0)
            {
                orderitemlist.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                orderitemlist.BackColor = Color.White;
            }

            // #################################################################
            if (totaltxt.TextLength == 0)
            {
                totaltxt.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                totaltxt.BackColor = Color.White;
            }
            
            return valid;
        }
        
        private bool SavePO()
        {
            string databasefilename = InventoryDatabase.PurchaseOrderDatabaseCopySave + PoNumbertxt.Text + ".xlsx";
            int SaveAttemptCount = 0;

            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            string day = DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();

            string datetime = year + month + day + hour + minute + second;

            databasefilename = InventoryDatabase.PurchaseOrderDatabaseCopySave + datetime + "_" + PoNumbertxt.Text + ".xlsx";

            try
            {
                System.IO.File.Copy(InventoryDatabase.PurchaseOrderTemplateLocation + InventoryDatabase.PurchaseOrderTemplateFileName, databasefilename);

                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyBook = MyApp.Workbooks.Open(databasefilename);
                MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here

                MySheet.Cells[3, 3] = PoNumbertxt.Text;
                MySheet.Cells[3, 6] = GetName(purchasercmb.Text);

                MySheet.Cells[4, 3] = projecttxt.Text;
                MySheet.Cells[4, 6] = jobnumbertxt.Text;

                MySheet.Cells[5, 3] = vendorcmb.Text;
                MySheet.Cells[5, 6] = attntxt.Text;

                MySheet.Cells[6, 3] = shippingcmb.Text;
                MySheet.Cells[7, 3] = address1txt.Text;
                MySheet.Cells[8, 3] = address2txt.Text;

                MySheet.Cells[7, 6] = orderdate.Value.Year + "-" + orderdate.Value.Month + "-" + orderdate.Value.Day;
                MySheet.Cells[8, 6] = deliverydate.Value.Year + "-" + deliverydate.Value.Month + "-" + deliverydate.Value.Day;

                int row = 13;

                for (int i = 0; i < mOrderItems.Count; i++)
                {
                    MySheet.Cells[row, 2] = mOrderItems[i].description;
                    MySheet.Cells[row, 4] = mOrderItems[i].quantity;
                    MySheet.Cells[row, 5] = mOrderItems[i].unit;
                    MySheet.Cells[row, 6] = mOrderItems[i].unit_price;
                    MySheet.Cells[row, 7] = mOrderItems[i].total;

                    MySheet.Cells[row, 10] = mOrderItems[i].designation;
                    MySheet.Cells[row, 11] = mOrderItems[i].category;
                    MySheet.Cells[row, 12] = mOrderItems[i].status;
                    MySheet.Cells[row, 13] = mOrderItems[i].gauge;
                    MySheet.Cells[row, 14] = mOrderItems[i].material;
                    MySheet.Cells[row, 15] = mOrderItems[i].color;
                    MySheet.Cells[row, 16] = mOrderItems[i].width;
                    MySheet.Cells[row, 17] = mOrderItems[i].height;
                    MySheet.Cells[row, 18] = mOrderItems[i].size_unit;

                    row++;
                }

                MySheet.Cells[34, 2] = notetxt.Text;

                MyBook.Save();
                MyBook.Close();

                DialogResult result = MessageBox.Show("Do you want a copy of the purchase order?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                    saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
					saveFileDialog1.FileName = PoNumbertxt.Text + jobnumbertxt.Text + vendorcmb.Text;

					if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.Copy(databasefilename, saveFileDialog1.FileName);
                        System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving Excel PO" + ex);
            }
            finally
            {
                
            }
           
            return false;
        }

        private string GetName(string n)
        {
            string str;
            string[] ss = n.Split(',');
            str = ss[1].Remove(0,1) + " " + ss[0];
            
            return str;
        }
        #endregion

        #region public Methods
        public void ReturnItem(InventoryOrderItem ioi, int index)
        {
            if(index < 0)
            {
                // item is new
                mOrderItems.Add(ioi);
            }
            else
            {
                // item is existing
                mOrderItems[index] = ioi;
            }

            orderitemlist.Items.Clear();
            for(int i = 0; i < mOrderItems.Count; i++)
            {
                string price = "$" + mOrderItems[i].total;
                int steps = 15 - price.Length;
                string str = price;
                for(int j = 0; j < steps; j++)
                {
                    str += " ";
                }

                string qty = mOrderItems[i].quantity;
                steps = 10 - qty.Length;
                str += qty;
                for (int k = 0; k < steps; k++)
                {
                    str += " ";
                }
                str += mOrderItems[i].description;
                orderitemlist.Items.Add(str);
               // orderitemlist.Items.Add(mOrderItems[i].description);
            }

            calctotal();
        }
        #endregion

        #region ITEM PANEL Events
        private void removeitem_Click(object sender, EventArgs e)
        {
            int index = orderitemlist.SelectedIndex;

            if (index > -1)
            {
                orderitemlist.Items.RemoveAt(index);
                mOrderItems.RemoveAt(index);
            }
        }

        private void loadprojectbtn_Click(object sender, EventArgs e)
        {
            var jobform = new LoadJobInformation();
            jobform.Show();
            jobform.init(this);
        }

        public void SetJobFromLoader(string jobname, string jobnumber)
        {
            jobnumbertxt.Text = jobnumber;
            projecttxt.Text = jobname;
        }

        private void addcatbtn_Click(object sender, EventArgs e)
        {
            AddCategoryForm form = new AddCategoryForm();
            form.Show();
        }

        private void addmatbtn_Click(object sender, EventArgs e)
        {
            AddMaterialForm form = new AddMaterialForm();
            form.Show();
        }

        private void addgaugebtn_Click(object sender, EventArgs e)
        {
            AddGaugeForm form = new AddGaugeForm();
            form.Show();
        }

        private void addcolorbtn_Click(object sender, EventArgs e)
        {
            AddColorForm form = new AddColorForm();
            form.Show();
        }
        #endregion

        #region ITEM PANEL Private
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
        #endregion

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"N:\Receiving and current inventory\InventoryData\help.docx");
        }

        private void openReadOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update Excel Inventory by pressing Data>Connections>Refresh All to see the current Inventory data");
            System.Diagnostics.Process.Start(@"N:\Receiving and current inventory\InventoryData\InventoryView.xlsm");
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategoryForm form = new AddCategoryForm();
            form.Show();
            form.SetParent(this);
        }

        private void addMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddMaterialForm form = new AddMaterialForm();
            form.Show();
            form.SetParent(this);
        }

        private void addGaugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddGaugeForm form = new AddGaugeForm();
            form.Show();
            form.SetParent(this);
        }

        private void addColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddColorForm form = new AddColorForm();
            form.Show();
            form.SetParent(this);
        }

        private void addVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddVendorForm form = new AddVendorForm();
            form.Show();
            form.SetParent(this);
        }

        public void UpdateLists()
        {
            fillVendorComboBox();
            fillPurchaserComboBox();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mParentForm.Show();
        }

        private void AddMaterialButton_Click(object sender, EventArgs e)
        {
            Form_AddMaterial form = new Form_AddMaterial();
            form.Show();
            form.SetParent(this, -1);
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            Form_AddItem form = new Form_AddItem();
            form.Show();
            form.SetParent(this, -1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SavePO();
        }

		private void Form_Main_Load(object sender, EventArgs e)
		{

		}
	}
}