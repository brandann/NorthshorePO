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
    public partial class Form1 : Form
    {
        #region Members
        private string PurchaseOrderTemplateFileName = "PurchaseOrderTemplate.xlsx";
        private string PurchaseOrderTemplateLocation = @"N:\Receiving and current inventory\InventoryData\";
        private string PurchaseOrderDatabaseCopySave = @"N:\Receiving and current inventory\InventoryData\PurchaseOrders\";
        private List<Purchaser> purchasers;
        private List<InventoryOrderItem> OrderItems;
        private List<PurchaseOrderItem> PurchaseOrderResults;
        private string ponum;
        private string initials;
        
        public enum SearchByTerms { PONumber, ProjectNumber, MaterialType, MaterialColor}
        public enum DataViewType { Inventory, Vendor, Color, Material, Thickness, Purchaser, PurchseOrder }
        private DataViewType currentDataType;
        private DatabaseController databaseController;

        private InventoryOrderItem item;
        private bool newItem;
        private int item_index;
        List<MaterialTable> materials;
        #endregion

        #region constructor
        public Form1()
        {
            InitializeComponent();
            databaseController = new DatabaseController();
            
            this.Size = new Size(760, 830);
            POPanel.Location = new System.Drawing.Point(12, 35);
            lookupPanel.Location = new System.Drawing.Point(12, 35);
            InventoryViewPanel.Location = new System.Drawing.Point(12, 35);
            ItemPanel.Location = new System.Drawing.Point(12, 35);

            reset();

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

        #region init
        private void reset()
        {
            POPanel.Visible = false;
            lookupPanel.Visible = false;
            LookupResultPanel.Visible = false;
            InventoryViewPanel.Visible = false;
            ItemPanel.Visible = false;
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
            List<VendorsTable> vendors = databaseController.GetVendors();
            for(int i = 0; i < vendors.Count; i++)
            {
                vendorcmb.Items.Add(vendors[i].vendor);
            }
        }

        private void fillPurchaserComboBox()
        {
            purchasers = new List<Purchaser>();
            List<PurchasersTable> p = databaseController.GetPurchasers();
            for (int i = 0; i < p.Count; i++)
            {
                if(p[i].isActive)
                {
                    Purchaser purchaser = new Purchaser();
                    purchaser.name = p[i].name_last + ", " + p[i].name_first;
                    purchaser.initials = p[i].initials;
                    purchasers.Add(purchaser);
                    purchasercmb.Items.Add(p[i].name_last + ", " + p[i].name_first);
                }
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

        }

        private void edititem_Click(object sender, EventArgs e)
        {
            if(orderitemlist.SelectedIndex != -1)
            {
                EditItem(OrderItems[orderitemlist.SelectedIndex], this, orderitemlist.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }
            
        }

        private void addmaterial_Click(object sender, EventArgs e)
        {
            NewItem(true, this);
        }

        private void addother_Click(object sender, EventArgs e)
        {
            NewItem(false, this);
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
                    //dataviewlist.DataSource = colorBindingSource;
                    currentDataType = DataViewType.Color;
                    break;
                case (DataViewType.Purchaser):
                    //dataviewlist.DataSource = purchasersBindingSource;
                    currentDataType = DataViewType.Purchaser;
                    break;
                case (DataViewType.Thickness):
                    //dataviewlist.DataSource = thicknessBindingSource;
                    currentDataType = DataViewType.Thickness;
                    break;
                case (DataViewType.Material):
                    //dataviewlist.DataSource = materialBindingSource;
                    currentDataType = DataViewType.Material;
                    break;
                case (DataViewType.Vendor):
                    //dataviewlist.DataSource = vendorsBindingSource;
                    currentDataType = DataViewType.Vendor;
                    break;
                case (DataViewType.PurchseOrder):
                    //dataviewlist.DataSource = purchaseOrderBindingSource;
                    currentDataType = DataViewType.PurchseOrder;
                    break;
                case (DataViewType.Inventory):
                    //dataviewlist.DataSource = materialInventoryBindingSource;
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
        {/*
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
            }*/
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
        {/*
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
            }*/
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
        {/*
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
            }*/

            return false;
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

        //----------------------------------------------------------------------------
        //
        // ITEM PANEL
        //
        //----------------------------------------------------------------------------

        #region init
        public void NewItem(bool isMaterial, Form1 parent)
        {
            reset();
            ItemPanel.Visible = true;
            item = new InventoryOrderItem();
            item.isMaterial = isMaterial;
            //init(item, parent);

            if (item != null && item.isMaterial)
            {
                categorycmb.SelectedItem = "Material";
            }
            statuscmb.SelectedItem = "Shipping/Receiving";

            newItem = true;
            item_index = -1;

            materialpanel.Enabled = item.isMaterial;

            sizeunitcmb.SelectedItem = "IN";

            hidecmb.SelectedItem = "NO";
        }

        public void EditItem(InventoryOrderItem ioi, Form1 parent, int index)
        {
            reset();
            ItemPanel.Visible = true;
            item = ioi;
            init(item);

            newItem = false;
            item_index = index;
        }

        private void init(InventoryOrderItem ioi)
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
        }

        private void fillMaterialComboBox()
        {
            DatabaseController dc = new DatabaseController();
            materials = dc.GetMaterial();

            for (int i = 0; i < materials.Count; i++)
            {
                materialcmb.Items.Add(materials[i].material_type);
            }
        }

        private void fillGaugeComboBox()
        {
            DatabaseController dc = new DatabaseController();
            List<ThicknessTable> gauges = dc.GetThickness();

            for (int i = 0; i < gauges.Count; i++)
            {
                gaugecmb.Items.Add(gauges[i].thickness + " " + gauges[i].type.ToLower());
            }
        }

        private void fillColorComboBox()
        {
            DatabaseController dc = new DatabaseController();
            List<ColorTable> colors = dc.GetColor();

            for (int i = 0; i < colors.Count; i++)
            {
                colorcmb.Items.Add(colors[i].color);
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
            DatabaseController dc = new DatabaseController();
            List<CategoryTable> categories = dc.GetCategory();

            for (int i = 0; i < categories.Count; i++)
            {
                categorycmb.Items.Add(categories[i].type);
            }
        }

        private void fillStatusComboBox()
        {
            statuscmb.Items.Add("Inventory");
            statuscmb.Items.Add("Shipping/Receiving");
            statuscmb.Items.Add("Jobsite Delivery");
            statuscmb.Sorted = true;
        }
        #endregion

        #region Events
        private void descriptionbtn_Click_1(object sender, EventArgs e)
        {
            if (item.isMaterial)
            {
                descriptiontxt.Text = buildItem().GetMaterialDescription();
            }
        }

        private void materialcmb_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            widthtxt.Text = materials[materialcmb.SelectedIndex].width;
            heighttxt.Text = materials[materialcmb.SelectedIndex].height;

            findHistory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (descriptiontxt.Text == "")
            {
                descriptiontxt.Text = buildItem().GetMaterialDescription();
            }

            ReturnItem(buildItem(), item_index);
            this.Close();
        }

        private void quantitytxt_TextChanged(object sender, EventArgs e)
        {
            genTotal();
        }

        private void unitpricetxt_TextChanged_1(object sender, EventArgs e)
        {
            genTotal();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {

        }

        private void gaugecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            findHistory();
        }

        private void colorcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            findHistory();
        }

        private void sizeunitcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            findHistory();
        }
        #endregion

        #region Private
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

        private void genTotal()
        {
            try
            {
                float quantity = (quantitytxt.Text == "") ? 0f : float.Parse(quantitytxt.Text);
                float price = (unitpricetxt.Text == "") ? 0f : float.Parse(unitpricetxt.Text);
                totaltxt.Text = (quantity * price).ToString();
            }
            catch (Exception e) { }
        }

        private void findHistory()
        {
            string _material = materialcmb.SelectedText;
            string _color = colorcmb.SelectedText;
            string _gauge = gaugecmb.SelectedText;
            double _width = double.Parse(widthtxt.Text);
            double _height = double.Parse(heighttxt.Text);

            if(ValidateHistory(_material, _color, _gauge, _width, _height))
            {

            }
            else
            {
                MessageBox.Show("History Bad");
            }
        }

        private bool ValidateHistory(string _material, string _color, string _gauge, double _width, double _height)
        {
            if (null == _width || 0 == _width)
            {
                return false;
            }

            if (null == _height || 0 == _height)
            {
                return false;
            }

            if (null == _material || "" == _material)
            {
                return false;
            }

            if (null == _color || "" == _color)
            {
                return false;
            }

            if (null == _gauge || "" == _gauge)
            {
                return false;
            }

            return true;
        }

        #endregion

        private void widthtxt_TextChanged(object sender, EventArgs e)
        {
            findHistory();
        }

        private void heighttxt_TextChanged(object sender, EventArgs e)
        {
            findHistory();
        }
    }
}

//Provider=Microsoft.Jet.OLEDB.4.0;Data Source="N:\Receiving and current inventory\NssmInventory.mdb;"
//Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\Receiving and current inventory\NssmInventory.mdb; Persist Security Info=False;