using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel; 

namespace Inventory
{
    public partial class Form1 : Form
    {
        #region Members
        private string PurchaseOrderTemplateFileName = "PurchaseOrderTemplate.xlsx";
        private string PurchaseOrderTemplateLocation = @"N:\Receiving and current inventory\InventoryData\";
        private string PurchaseOrderDatabaseCopySave = @"N:\Receiving and current inventory\InventoryData\PurchaseOrders\";
        private OleDbConnection connection = new OleDbConnection();
        private List<Purchaser> purchasers;
        private List<InventoryOrderItem> OrderItems;
        private List<PurchaseOrderItem> PurchaseOrderResults;
        private string ponum;
        private string initials;
        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;
        public enum SearchByTerms { PONumber, ProjectNumber, MaterialType, MaterialColor}
        public enum DataViewType { Inventory, Vendor, Color, Material, Thickness, Purchaser, PurchseOrder }
        private DataViewType currentDataType;
        #endregion

        #region constructor
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\NssmInventory.mdb; Persist Security Info=False;";

            this.Size = new Size(760, 830);
            POPanel.Location = new System.Drawing.Point(12, 35);
            lookupPanel.Location = new System.Drawing.Point(12, 35);
            InventoryViewPanel.Location = new System.Drawing.Point(12, 35);

            reset();
        }

        #region init
        private void reset()
        {
            POPanel.Visible = false;
            lookupPanel.Visible = false;
            LookupResultPanel.Visible = false;
            InventoryViewPanel.Visible = false;
        }

        public void initNewPO()
        {
            reset();
            
            statuslbl.Text = "New purchase order item";

            POPanel.Visible = true;

            fillPurchaserComboBox();
            fillVendorComboBox();
            fillShippingAddressComboBox();

            ClearCreateForm();
            SetPoNumber();
        }

        public void initLookup()
        {
            reset();
            ClearLookupForm();
            lookupPanel.Visible = true;
        }

        private void ClearCreateForm()
        {
            OrderItems = new List<InventoryOrderItem>();
            PoNumbertxt.Text = "";

            purchasercmb.SelectedIndex = -1;
            initialtxt.Text = "";

            vendorcmb.SelectedIndex = -1;
            attntxt.Text = "";

            projecttxt.Text = "";
            jobnumbertxt.Text = "";

            shippingcmb.SelectedIndex = 0;
            address1txt.Text = "18603 Beverly Park RD. Bldg C.";
            address2txt.Text = "Everett, WA 98204";

            orderitemlist.Items.Clear();
            OrderItems.Clear();

            orderdate.ResetText();
            deliverydate.ResetText();

            totaltxt.Text = "";

            notetxt.Text = "";
        }

        private void ClearLookupForm()
        {
            sortbycmb.SelectedIndex = 0;
            termtxta.Text = "";
            termtxtb.Text = "";
            searchtypecmb.SelectedIndex = 0;

            polist.Items.Clear();

            lpotxt.Text = "";
            lpurtxt.Text = "";

            lvendortxt.Text = "";
            lattntxt.Text = "";

            lprojecttxt.Text = "";
            lprojectnumbertxt.Text = "";

            lshippinga.Text = "";
            lshippingb.Text = "";
            lshippingc.Text = "";

            ldateordertxt.Text = "";
            ldatedeliverytxt.Text = "";

            lorderitemlist.Items.Clear();

            lnotestxt.Text = "";
        }

        private void fillShippingAddressComboBox()
        {
            shippingcmb.Items.Add("Northshore Sheet Metal, Inc.");
            shippingcmb.Items.Add("Northclad, Inc.");
            shippingcmb.SelectedIndex = 0;
        }

        private void fillVendorComboBox()
        {
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select VENDOR from Vendors";
                var reader = command.ExecuteReader();

                List<string> vendors = new List<string>();
                while (reader.Read())
                {
                    vendors.Add(reader.GetString(0));
                }

                vendors.Sort();

                for (int i = 0; i < vendors.Count; i++ )
                {
                    vendorcmb.Items.Add(vendors[i]);
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

        private void fillPurchaserComboBox()
        {
            purchasers = new List<Purchaser>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Purchasers";
                var reader = command.ExecuteReader();

                List<string> vendors = new List<string>();
                while (reader.Read())
                {
                    Purchaser p = new Purchaser();
                    p.name = reader.GetString(2) + ", " + reader.GetString(1);
                    p.initials = reader.GetString(3);
                    purchasers.Add(p);
                }

                purchasers.Sort();

                for (int i = 0; i < purchasers.Count; i++)
                {
                    purchasercmb.Items.Add(purchasers[i].ToString());
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

        private bool search(SearchByTerms type, string term)
        {
            PurchaseOrderResults = new List<PurchaseOrderItem>();

            return false;
        }
        #endregion

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nssmInventoryDataSet11.MaterialInventory' table. You can move, or remove it, as needed.
            this.materialInventoryTableAdapter.Fill(this.nssmInventoryDataSet11.MaterialInventory);
            // TODO: This line of code loads data into the 'nssmInventoryDataSet11.PurchaseOrder' table. You can move, or remove it, as needed.
            this.purchaseOrderTableAdapter.Fill(this.nssmInventoryDataSet11.PurchaseOrder);
            // TODO: This line of code loads data into the 'nssmInventoryDataSet1.Thickness' table. You can move, or remove it, as needed.
            this.thicknessTableAdapter.Fill(this.nssmInventoryDataSet1.Thickness);
            // TODO: This line of code loads data into the 'nssmInventoryDataSet1.Purchasers' table. You can move, or remove it, as needed.
            this.purchasersTableAdapter.Fill(this.nssmInventoryDataSet1.Purchasers);
            // TODO: This line of code loads data into the 'nssmInventoryDataSet1.Material' table. You can move, or remove it, as needed.
            this.materialTableAdapter.Fill(this.nssmInventoryDataSet1.Material);
            // TODO: This line of code loads data into the 'nssmInventoryDataSet1.Color' table. You can move, or remove it, as needed.
            this.colorTableAdapter1.Fill(this.nssmInventoryDataSet1.Color);
            // TODO: This line of code loads data into the 'nssmInventoryDataSet1.Vendors' table. You can move, or remove it, as needed.
            this.vendorsTableAdapter.Fill(this.nssmInventoryDataSet1.Vendors);
            // TODO: This line of code loads data into the 'nssmInventoryDataSet1.Inventory' table. You can move, or remove it, as needed.
            this.inventoryTableAdapter1.Fill(this.nssmInventoryDataSet1.Inventory);

        }

        private void edititem_Click(object sender, EventArgs e)
        {
            if(orderitemlist.SelectedIndex != -1)
            {
                var form = new Form2();
                form.Show();
                form.EditItem(OrderItems[orderitemlist.SelectedIndex], this, orderitemlist.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }
            
        }

        private void addmaterial_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
            form.NewItem(true, this);
        }

        private void addother_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
            form.NewItem(false, this);
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            if(isPOValid())
            {
                if(SavePO())
                {
                    SubmitPO();
                    int materialcount = 0;
                    for (int i = 0; i < OrderItems.Count; i++)
                    {
                        if (OrderItems[i].isMaterial)
                        {
                            SubmitMaterialItem(OrderItems[i]);
                            materialcount++;
                        }
                    }
                    MessageBox.Show("Purchase Order and " + materialcount + " material items submitted");
                    return;
                }
                else
                {
                    goto ERROR;
                }
            }
        ERROR:
            MessageBox.Show("ERROR: Purchase Order NOT Submitted.");
        }

        private void purchasercmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < purchasers.Count; i++)
            {
                if (purchasers[i].name == purchasercmb.SelectedItem as string)
                {
                    initialtxt.Text = initials = purchasers[i].initials;
                    formatPoNumber();
                }
            }
        }

        private void getponumbtn_Click(object sender, EventArgs e)
        {
            SetPoNumber();
        }

        

        private void notetxt_TextChanged(object sender, EventArgs e)
        {
            notelengthtxt.Text = "Notes Length: " + notetxt.TextLength;
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

        private void searchbtn_Click(object sender, EventArgs e)
        {

            LookupResultPanel.Visible = true;
        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataViewPost(DataViewType.Inventory);
        }

        private void purchaseOrdersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataViewPost(DataViewType.PurchseOrder);
        }

        private void colorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataViewPost(DataViewType.Color);
        }

        private void vendorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataViewPost(DataViewType.Vendor);
        }

        private void materialsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataViewPost(DataViewType.Material);
        }

        private void thicknessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataViewPost(DataViewType.Thickness);
        }

        private void purchasersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataViewPost(DataViewType.Purchaser);
        }
        #endregion

        #endregion

        #region private Methods
        private void SetPoNumber()
        {
            int year = DateTime.Now.Year - 2015;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

            string po = "";

            po += (month < 10) ? "0" + month.ToString() : month.ToString();
            po += (day < 10) ? "0" + day.ToString() : day.ToString();
            po += (min < 10) ? "0" + min.ToString() : min.ToString();

            PoNumbertxt.Text = ponum = po;
            formatPoNumber();
        }

        private void DataViewPost(DataViewType t)
        {
            switch (t)
            {
                case (DataViewType.Color):
                    dataviewlist.DataSource = colorBindingSource;
                    currentDataType = DataViewType.Color;
                    break;
                case (DataViewType.Purchaser):
                    dataviewlist.DataSource = purchasersBindingSource;
                    currentDataType = DataViewType.Purchaser;
                    break;
                case (DataViewType.Thickness):
                    dataviewlist.DataSource = thicknessBindingSource;
                    currentDataType = DataViewType.Thickness;
                    break;
                case (DataViewType.Material):
                    dataviewlist.DataSource = materialBindingSource;
                    currentDataType = DataViewType.Material;
                    break;
                case (DataViewType.Vendor):
                    dataviewlist.DataSource = vendorsBindingSource;
                    currentDataType = DataViewType.Vendor;
                    break;
                case (DataViewType.PurchseOrder):
                    dataviewlist.DataSource = purchaseOrderBindingSource;
                    currentDataType = DataViewType.PurchseOrder;
                    break;
                case (DataViewType.Inventory):
                    dataviewlist.DataSource = materialInventoryBindingSource;
                    currentDataType = DataViewType.Inventory;
                    break;
            }

            reset();
            InventoryViewPanel.Visible = true;
            dataviewlist.AutoResizeColumns();
        }

        private void formatPoNumber()
        {
            if(initials == null || initials == "")
            {
                PoNumbertxt.Text = ponum;
                return;
            }

            if (ponum == null || ponum == "")
            {
                return;
            }

            PoNumbertxt.Text = ponum + "-" + initials;
        }

        private void calctotal()
        {
            float total = 0f;
            for (int i = 0; i < OrderItems.Count; i++)
            {
                total += OrderItems[i].total;
            }

            totaltxt.Text = "$" + total;
        }

        private void SubmitPO()
        {
            string queue = buildQueuePO();
            purchasers = new List<Purchaser>();
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = queue;

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Inserted: " + queue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private string buildQueuePO()
        {
            string QA, QB;

            QA = "INSERT INTO PurchaseOrder (";
            QB = "VALUES('";

            QA = QA + "PO_NUMBER,";
            QB = QB + PoNumbertxt.Text + "','";

            QA = QA + "PURCHASER,";
            QB = QB + purchasercmb.Text + "','";

            QA = QA + "VENDOR,";
            QB = QB + vendorcmb.Text + "','";

            QA = QA + "PROJECT_NUMBER,";
            QB = QB + jobnumbertxt.Text + "','";

            QA = QA + "PO_DATE,";
            QB = QB + orderdate.Value.Year + "-" + orderdate.Value.Month + "-" + orderdate.Value.Day + "','";

            QA = QA + "TOTAL,";
            QB = QB + totaltxt.Text + "','";

            QA = QA + "FILE,";
            QB = QB + " " + "','";

            QA = QA + "NOTES";
            QB = QB + GetNoteStringForDB();

            QA = QA + ")";
            QB = QB + "')";

            return QA + " " + QB;
        }

        private void SubmitMaterialItem(InventoryOrderItem ioi)
        {
            string queue = buildQueueMaterial(ioi);
            purchasers = new List<Purchaser>();
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = queue;

                connection.Open();
                command.ExecuteNonQuery();

                MessageBox.Show("Inserted: " + queue);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        private string buildQueueMaterial(InventoryOrderItem ioi)
        {
            string QA, QB;

            QA = "INSERT INTO MaterialInventory (";
            QB = "VALUES('";

            QA = QA + "PO_NUMBER,";
            QB = QB + PoNumbertxt.Text + "','";

            QA = QA + "ORDER_BY,";
            QB = QB + purchasercmb.Text + "','";

            QA = QA + "PROJECT,";
            QB = QB + projecttxt.Text + "','";

            QA = QA + "JOB_NUMBER,";
            QB = QB + jobnumbertxt.Text + "','";

            QA = QA + "VENDOR,";
            QB = QB + vendorcmb.Text + "','";

            QA = QA + "ATTN,";
            QB = QB + attntxt.Text + "','";

            QA = QA + "DATE_ORDERED,";
            QB = QB + orderdate.Value.Year + "-" + orderdate.Value.Month + "-" + orderdate.Value.Day + "','";

            QA = QA + "ETA,";
            QB = QB + deliverydate.Value.Year + "-" + deliverydate.Value.Month + "-" + deliverydate.Value.Day + "','";

            QA = QA + "ATA,";
            QB = QB + " " + "','";

            //================================================================

            QA = QA + "DESCRIPTION,";
            QB = QB + ioi.description + "','";

            QA = QA + "QUANTITY,";
            QB = QB + ioi.quantity + "','";

            QA = QA + "UNIT,";
            QB = QB + ioi.unit + "','";

            QA = QA + "UNIT_COST,";
            QB = QB + ioi.unit_price + "','";

            QA = QA + "TOTAL,";
            QB = QB + ioi.total + "','";

            //================================================================

            QA = QA + "STOCK_ITEM,"; //designation;
            QB = QB + ioi.designation + "','";

            QA = QA + "MATERIAL_ITEM,"; //category;
            QB = QB + ioi.category + "','";

            QA = QA + "STATUS,";
            QB = QB + ioi.status + "','";

            //================================================================

            QA = QA + "GAUGE,";
            QB = QB + ioi.gauge + "','";

            QA = QA + "MATERIAL,";
            QB = QB + ioi.material + "','";

            QA = QA + "COLOR,";
            QB = QB + ioi.color + "','";

            QA = QA + "WIDTH,";
            QB = QB + ioi.width + "','";

            QA = QA + "HEIGHT,";
            QB = QB + ioi.height + "','";

            QA = QA + "UNITS";
            QB = QB + ioi.size_unit;

            QA = QA + ")";
            QB = QB + "')";

            return QA + " " + QB;
        }

        private string GetNoteStringForDB()
        {

            //test
            //this is a test of the textbox length, we are testing that when the text it longer than 255 characters anything over 250 will be cut off and replaced with a "..." in the database and the full text will be daved in the file version of the purchase order. thank you

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
            // check the po number
            if (PoNumbertxt.Text == "" || PoNumbertxt.TextLength <= 3) 
            {
                MessageBox.Show("PO Number is Invalid");
                return false; 
            }

            // check the purchaser
            if (purchasercmb.Text == "")
            {
                MessageBox.Show("Purchaser is Invalid");
                return false;
            }
            else if (initialtxt.TextLength == 0)
            {
                MessageBox.Show("Purchaser Initials are missing");
                return false;
            }

            //check job
            if(jobnumbertxt.TextLength == 0 && projecttxt.TextLength == 0)
            {
                MessageBox.Show("Enter Either a Project Name or Project Number");
                return false;
            }

            //check items
            if(orderitemlist.Items.Count == 0)
            {
                MessageBox.Show("At least one item is required for a purchase order");
                return false;
            }

            return true;
        }
        
        private bool SavePO()
        {
            string databasefilename = PurchaseOrderDatabaseCopySave + PoNumbertxt.Text + ".xlsx";
            System.IO.File.Copy(PurchaseOrderTemplateLocation + PurchaseOrderTemplateFileName, databasefilename);

            MyApp = new Excel.Application();
            MyApp.Visible = false;
            MyBook = MyApp.Workbooks.Open(databasefilename);
            MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here

            MySheet.Cells[3,3] = PoNumbertxt.Text;
            MySheet.Cells[3,6] = purchasercmb.Text;

            MySheet.Cells[4, 3] = projecttxt.Text;
            MySheet.Cells[4, 6] = jobnumbertxt.Text;

            MySheet.Cells[5, 3] = vendorcmb.Text;
            MySheet.Cells[5, 6] = attntxt.Text;

            MySheet.Cells[6, 3] = shippingcmb.Text;

            MySheet.Cells[7, 6] = orderdate.Value.Year + "-" + orderdate.Value.Month + "-" + orderdate.Value.Day;
            MySheet.Cells[8, 6] = deliverydate.Value.Year + "-" + deliverydate.Value.Month + "-" + deliverydate.Value.Day;

            int row = 13;

            for (int i = 0; i < OrderItems.Count; i++ )
            {
                MySheet.Cells[row, 2] = OrderItems[i].description;
                MySheet.Cells[row, 4] = OrderItems[i].quantity;
                MySheet.Cells[row, 5] = OrderItems[i].unit;
                MySheet.Cells[row, 6] = OrderItems[i].unit_price;
                MySheet.Cells[row, 7] = OrderItems[i].total;

                MySheet.Cells[row, 10] = OrderItems[i].designation;
                MySheet.Cells[row, 11] = OrderItems[i].category;
                MySheet.Cells[row, 12] = OrderItems[i].status;
                MySheet.Cells[row, 13] = OrderItems[i].gauge;
                MySheet.Cells[row, 14] = OrderItems[i].material;
                MySheet.Cells[row, 15] = OrderItems[i].color;
                MySheet.Cells[row, 16] = OrderItems[i].width;
                MySheet.Cells[row, 17] = OrderItems[i].height;
                MySheet.Cells[row, 18] = OrderItems[i].size_unit;

                row++;
            }

            MySheet.Cells[37, 2] = notetxt.Text;

            MyBook.Save();
            MyBook.Close();

            DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.Copy(databasefilename, saveFileDialog1.FileName);
                }
            }

            return true;
        }

        private class Purchaser : IComparable<Purchaser>
        {
            public string name;
            public string initials;

            public int CompareTo(Purchaser other)
            {
                return this.name.CompareTo(other.name);
            }

            public override string ToString()
            {
                return this.name;
            }
        }
        #endregion

        #region public Methods
        public void ReturnItem(InventoryOrderItem ioi, int index)
        {
            if(index < 0)
            {
                // item is new
                OrderItems.Add(ioi);
            }
            else
            {
                // item is existing
                OrderItems[index] = ioi;
            }

            orderitemlist.Items.Clear();
            for(int i = 0; i < OrderItems.Count; i++)
            {
                orderitemlist.Items.Add(OrderItems[i].description);
            }

            calctotal();
        }
        #endregion

        private void savebtn_Click(object sender, EventArgs e)
        {
            SaveDataChanges(currentDataType);
        }

        private void SaveDataChanges(DataViewType current)
        {
            /*
            switch(current)
            {
                case(DataViewType.Inventory):
                    dataAdapter.Update((System.Data.DataTable)inventoryBindingSource.DataSource);
                    break;
                case (DataViewType.Vendor):
                    dataAdapter.Update((System.Data.DataTable)vendorsBindingSource.DataSource);
                    break;
                case (DataViewType.Color):
                    dataAdapter.Update((System.Data.DataTable)colorBindingSource.DataSource);
                    break;
                case (DataViewType.Material):
                    dataAdapter.Update((System.Data.DataTable)materialBindingSource.DataSource);
                    break;
                case (DataViewType.Thickness):
                    dataAdapter.Update((System.Data.DataTable)thicknessBindingSource.DataSource);
                    break;
                case (DataViewType.Purchaser):
                    dataAdapter.Update((System.Data.DataTable)purchasersBindingSource.DataSource);
                    break;
            }
            */
        }

        
    }
}

//Provider=Microsoft.Jet.OLEDB.4.0;Data Source="N:\Receiving and current inventory\NssmInventory.mdb;"
//Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\Receiving and current inventory\NssmInventory.mdb; Persist Security Info=False;