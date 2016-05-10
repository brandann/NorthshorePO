namespace Inventory
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseOrdersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.materialsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thicknessToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openReadOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMaterialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGaugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.getponumbtn = new System.Windows.Forms.Button();
            this.POPanel = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.AddMaterialButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.submitbtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.totaltxt = new System.Windows.Forms.TextBox();
            this.initialtxt = new System.Windows.Forms.TextBox();
            this.removeitem = new System.Windows.Forms.Button();
            this.loadprojectbtn = new System.Windows.Forms.Button();
            this.edititem = new System.Windows.Forms.Button();
            this.notetxt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.deliverydate = new System.Windows.Forms.DateTimePicker();
            this.orderdate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.orderitemlist = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.address2txt = new System.Windows.Forms.TextBox();
            this.shippingcmb = new System.Windows.Forms.ComboBox();
            this.address1txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.vendorcmb = new System.Windows.Forms.ComboBox();
            this.attntxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.jobnumbertxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.projecttxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.purchasercmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PoNumbertxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.POPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.purchaseOrderToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // purchaseOrderToolStripMenuItem
            // 
            this.purchaseOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.lookupToolStripMenuItem});
            this.purchaseOrderToolStripMenuItem.Name = "purchaseOrderToolStripMenuItem";
            this.purchaseOrderToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.purchaseOrderToolStripMenuItem.Text = "Purchase Order";
            this.purchaseOrderToolStripMenuItem.Visible = false;
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // lookupToolStripMenuItem
            // 
            this.lookupToolStripMenuItem.Name = "lookupToolStripMenuItem";
            this.lookupToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.lookupToolStripMenuItem.Text = "Lookup";
            this.lookupToolStripMenuItem.Click += new System.EventHandler(this.lookupToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.openReadOnlyToolStripMenuItem});
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Visible = false;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem1,
            this.purchaseOrdersToolStripMenuItem1,
            this.colorsToolStripMenuItem1,
            this.vendorsToolStripMenuItem1,
            this.materialsToolStripMenuItem1,
            this.thicknessToolStripMenuItem1,
            this.purchasersToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Visible = false;
            // 
            // inventoryToolStripMenuItem1
            // 
            this.inventoryToolStripMenuItem1.Name = "inventoryToolStripMenuItem1";
            this.inventoryToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.inventoryToolStripMenuItem1.Text = "Inventory";
            // 
            // purchaseOrdersToolStripMenuItem1
            // 
            this.purchaseOrdersToolStripMenuItem1.Name = "purchaseOrdersToolStripMenuItem1";
            this.purchaseOrdersToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.purchaseOrdersToolStripMenuItem1.Text = "Purchase Orders";
            // 
            // colorsToolStripMenuItem1
            // 
            this.colorsToolStripMenuItem1.Name = "colorsToolStripMenuItem1";
            this.colorsToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.colorsToolStripMenuItem1.Text = "Colors";
            // 
            // vendorsToolStripMenuItem1
            // 
            this.vendorsToolStripMenuItem1.Name = "vendorsToolStripMenuItem1";
            this.vendorsToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.vendorsToolStripMenuItem1.Text = "Vendors";
            // 
            // materialsToolStripMenuItem1
            // 
            this.materialsToolStripMenuItem1.Name = "materialsToolStripMenuItem1";
            this.materialsToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.materialsToolStripMenuItem1.Text = "Materials";
            // 
            // thicknessToolStripMenuItem1
            // 
            this.thicknessToolStripMenuItem1.Name = "thicknessToolStripMenuItem1";
            this.thicknessToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.thicknessToolStripMenuItem1.Text = "Thickness";
            // 
            // purchasersToolStripMenuItem1
            // 
            this.purchasersToolStripMenuItem1.Name = "purchasersToolStripMenuItem1";
            this.purchasersToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.purchasersToolStripMenuItem1.Text = "Purchasers";
            // 
            // openReadOnlyToolStripMenuItem
            // 
            this.openReadOnlyToolStripMenuItem.Name = "openReadOnlyToolStripMenuItem";
            this.openReadOnlyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openReadOnlyToolStripMenuItem.Text = "Open Read Only";
            this.openReadOnlyToolStripMenuItem.Click += new System.EventHandler(this.openReadOnlyToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategoryToolStripMenuItem,
            this.addMaterialToolStripMenuItem,
            this.addGaugeToolStripMenuItem,
            this.addColorToolStripMenuItem,
            this.addVendorToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addCategoryToolStripMenuItem.Text = "Add Category";
            this.addCategoryToolStripMenuItem.Click += new System.EventHandler(this.addCategoryToolStripMenuItem_Click);
            // 
            // addMaterialToolStripMenuItem
            // 
            this.addMaterialToolStripMenuItem.Name = "addMaterialToolStripMenuItem";
            this.addMaterialToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addMaterialToolStripMenuItem.Text = "Add Material";
            this.addMaterialToolStripMenuItem.Click += new System.EventHandler(this.addMaterialToolStripMenuItem_Click);
            // 
            // addGaugeToolStripMenuItem
            // 
            this.addGaugeToolStripMenuItem.Name = "addGaugeToolStripMenuItem";
            this.addGaugeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addGaugeToolStripMenuItem.Text = "Add Thickness";
            this.addGaugeToolStripMenuItem.Click += new System.EventHandler(this.addGaugeToolStripMenuItem_Click);
            // 
            // addColorToolStripMenuItem
            // 
            this.addColorToolStripMenuItem.Name = "addColorToolStripMenuItem";
            this.addColorToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addColorToolStripMenuItem.Text = "Add Color";
            this.addColorToolStripMenuItem.Click += new System.EventHandler(this.addColorToolStripMenuItem_Click);
            // 
            // addVendorToolStripMenuItem
            // 
            this.addVendorToolStripMenuItem.Name = "addVendorToolStripMenuItem";
            this.addVendorToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addVendorToolStripMenuItem.Text = "Add Vendor";
            this.addVendorToolStripMenuItem.Click += new System.EventHandler(this.addVendorToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PO Number*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // getponumbtn
            // 
            this.getponumbtn.Location = new System.Drawing.Point(226, 8);
            this.getponumbtn.Name = "getponumbtn";
            this.getponumbtn.Size = new System.Drawing.Size(93, 23);
            this.getponumbtn.TabIndex = 2;
            this.getponumbtn.Text = "Get PO Number";
            this.getponumbtn.UseVisualStyleBackColor = true;
            this.getponumbtn.Click += new System.EventHandler(this.getponumbtn_Click);
            // 
            // POPanel
            // 
            this.POPanel.Controls.Add(this.button1);
            this.POPanel.Controls.Add(this.label16);
            this.POPanel.Controls.Add(this.label15);
            this.POPanel.Controls.Add(this.label14);
            this.POPanel.Controls.Add(this.label11);
            this.POPanel.Controls.Add(this.AddItemButton);
            this.POPanel.Controls.Add(this.AddMaterialButton);
            this.POPanel.Controls.Add(this.button3);
            this.POPanel.Controls.Add(this.submitbtn);
            this.POPanel.Controls.Add(this.label10);
            this.POPanel.Controls.Add(this.totaltxt);
            this.POPanel.Controls.Add(this.initialtxt);
            this.POPanel.Controls.Add(this.removeitem);
            this.POPanel.Controls.Add(this.loadprojectbtn);
            this.POPanel.Controls.Add(this.edititem);
            this.POPanel.Controls.Add(this.notetxt);
            this.POPanel.Controls.Add(this.label13);
            this.POPanel.Controls.Add(this.deliverydate);
            this.POPanel.Controls.Add(this.orderdate);
            this.POPanel.Controls.Add(this.label12);
            this.POPanel.Controls.Add(this.label9);
            this.POPanel.Controls.Add(this.orderitemlist);
            this.POPanel.Controls.Add(this.label7);
            this.POPanel.Controls.Add(this.address2txt);
            this.POPanel.Controls.Add(this.shippingcmb);
            this.POPanel.Controls.Add(this.address1txt);
            this.POPanel.Controls.Add(this.label8);
            this.POPanel.Controls.Add(this.vendorcmb);
            this.POPanel.Controls.Add(this.attntxt);
            this.POPanel.Controls.Add(this.label5);
            this.POPanel.Controls.Add(this.label6);
            this.POPanel.Controls.Add(this.jobnumbertxt);
            this.POPanel.Controls.Add(this.label4);
            this.POPanel.Controls.Add(this.projecttxt);
            this.POPanel.Controls.Add(this.label3);
            this.POPanel.Controls.Add(this.purchasercmb);
            this.POPanel.Controls.Add(this.label2);
            this.POPanel.Controls.Add(this.PoNumbertxt);
            this.POPanel.Controls.Add(this.label1);
            this.POPanel.Controls.Add(this.getponumbtn);
            this.POPanel.Location = new System.Drawing.Point(12, 27);
            this.POPanel.Name = "POPanel";
            this.POPanel.Size = new System.Drawing.Size(709, 682);
            this.POPanel.TabIndex = 3;
            this.POPanel.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(279, 208);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 54;
            this.label16.Text = "Description";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(206, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "Quantity";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(101, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 52;
            this.label14.Text = "Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(339, 648);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "(Notes are not saved into the database)";
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(539, 256);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(161, 23);
            this.AddItemButton.TabIndex = 50;
            this.AddItemButton.Text = "Add New Item";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // AddMaterialButton
            // 
            this.AddMaterialButton.Location = new System.Drawing.Point(539, 227);
            this.AddMaterialButton.Name = "AddMaterialButton";
            this.AddMaterialButton.Size = new System.Drawing.Size(161, 23);
            this.AddMaterialButton.TabIndex = 49;
            this.AddMaterialButton.Text = "Add New Material";
            this.AddMaterialButton.UseVisualStyleBackColor = true;
            this.AddMaterialButton.Click += new System.EventHandler(this.AddMaterialButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 656);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 45;
            this.button3.Text = "Clear Purchase Order";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // submitbtn
            // 
            this.submitbtn.Location = new System.Drawing.Point(575, 656);
            this.submitbtn.Name = "submitbtn";
            this.submitbtn.Size = new System.Drawing.Size(125, 23);
            this.submitbtn.TabIndex = 44;
            this.submitbtn.Text = "Save Purchase Order";
            this.submitbtn.UseVisualStyleBackColor = true;
            this.submitbtn.Click += new System.EventHandler(this.submitbtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 520);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Total";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // totaltxt
            // 
            this.totaltxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaltxt.Location = new System.Drawing.Point(101, 517);
            this.totaltxt.Name = "totaltxt";
            this.totaltxt.Size = new System.Drawing.Size(125, 20);
            this.totaltxt.TabIndex = 42;
            // 
            // initialtxt
            // 
            this.initialtxt.Location = new System.Drawing.Point(259, 36);
            this.initialtxt.Name = "initialtxt";
            this.initialtxt.Size = new System.Drawing.Size(60, 20);
            this.initialtxt.TabIndex = 41;
            // 
            // removeitem
            // 
            this.removeitem.Location = new System.Drawing.Point(539, 488);
            this.removeitem.Name = "removeitem";
            this.removeitem.Size = new System.Drawing.Size(161, 23);
            this.removeitem.TabIndex = 40;
            this.removeitem.Text = "Remove Item";
            this.removeitem.UseVisualStyleBackColor = true;
            this.removeitem.Click += new System.EventHandler(this.removeitem_Click);
            // 
            // loadprojectbtn
            // 
            this.loadprojectbtn.Location = new System.Drawing.Point(482, 10);
            this.loadprojectbtn.Name = "loadprojectbtn";
            this.loadprojectbtn.Size = new System.Drawing.Size(218, 23);
            this.loadprojectbtn.TabIndex = 9;
            this.loadprojectbtn.Text = "Load Project";
            this.loadprojectbtn.UseVisualStyleBackColor = true;
            this.loadprojectbtn.Click += new System.EventHandler(this.loadprojectbtn_Click);
            // 
            // edititem
            // 
            this.edititem.Location = new System.Drawing.Point(539, 459);
            this.edititem.Name = "edititem";
            this.edititem.Size = new System.Drawing.Size(161, 23);
            this.edititem.TabIndex = 37;
            this.edititem.Text = "Edit Item";
            this.edititem.UseVisualStyleBackColor = true;
            this.edititem.Click += new System.EventHandler(this.edititem_Click);
            // 
            // notetxt
            // 
            this.notetxt.Location = new System.Drawing.Point(101, 543);
            this.notetxt.MaxLength = 255;
            this.notetxt.Multiline = true;
            this.notetxt.Name = "notetxt";
            this.notetxt.Size = new System.Drawing.Size(432, 102);
            this.notetxt.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 539);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Notes";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // deliverydate
            // 
            this.deliverydate.Location = new System.Drawing.Point(101, 165);
            this.deliverydate.Name = "deliverydate";
            this.deliverydate.Size = new System.Drawing.Size(218, 20);
            this.deliverydate.TabIndex = 30;
            // 
            // orderdate
            // 
            this.orderdate.Location = new System.Drawing.Point(101, 139);
            this.orderdate.Name = "orderdate";
            this.orderdate.Size = new System.Drawing.Size(218, 20);
            this.orderdate.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Order Items*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Delivery ETA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // orderitemlist
            // 
            this.orderitemlist.Font = new System.Drawing.Font("Monospac821 BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderitemlist.FormattingEnabled = true;
            this.orderitemlist.ItemHeight = 14;
            this.orderitemlist.Location = new System.Drawing.Point(101, 227);
            this.orderitemlist.Name = "orderitemlist";
            this.orderitemlist.Size = new System.Drawing.Size(432, 284);
            this.orderitemlist.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // address2txt
            // 
            this.address2txt.Location = new System.Drawing.Point(482, 164);
            this.address2txt.Name = "address2txt";
            this.address2txt.Size = new System.Drawing.Size(218, 20);
            this.address2txt.TabIndex = 24;
            this.address2txt.Text = "Everett, WA 98204";
            // 
            // shippingcmb
            // 
            this.shippingcmb.FormattingEnabled = true;
            this.shippingcmb.Location = new System.Drawing.Point(482, 111);
            this.shippingcmb.Name = "shippingcmb";
            this.shippingcmb.Size = new System.Drawing.Size(218, 21);
            this.shippingcmb.TabIndex = 23;
            this.shippingcmb.SelectedIndexChanged += new System.EventHandler(this.shippingcmb_SelectedIndexChanged);
            // 
            // address1txt
            // 
            this.address1txt.Location = new System.Drawing.Point(482, 138);
            this.address1txt.Name = "address1txt";
            this.address1txt.Size = new System.Drawing.Size(218, 20);
            this.address1txt.TabIndex = 22;
            this.address1txt.Text = "18603 Beverly Park RD. Bldg C.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(384, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Shipping Address";
            // 
            // vendorcmb
            // 
            this.vendorcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vendorcmb.FormattingEnabled = true;
            this.vendorcmb.Location = new System.Drawing.Point(101, 73);
            this.vendorcmb.Name = "vendorcmb";
            this.vendorcmb.Size = new System.Drawing.Size(218, 21);
            this.vendorcmb.TabIndex = 18;
            // 
            // attntxt
            // 
            this.attntxt.Location = new System.Drawing.Point(101, 100);
            this.attntxt.Name = "attntxt";
            this.attntxt.Size = new System.Drawing.Size(218, 20);
            this.attntxt.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Attn.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Vendor*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // jobnumbertxt
            // 
            this.jobnumbertxt.Location = new System.Drawing.Point(482, 63);
            this.jobnumbertxt.Name = "jobnumbertxt";
            this.jobnumbertxt.Size = new System.Drawing.Size(218, 20);
            this.jobnumbertxt.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Project Number*";
            // 
            // projecttxt
            // 
            this.projecttxt.Location = new System.Drawing.Point(482, 37);
            this.projecttxt.Name = "projecttxt";
            this.projecttxt.Size = new System.Drawing.Size(218, 20);
            this.projecttxt.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Project*";
            // 
            // purchasercmb
            // 
            this.purchasercmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.purchasercmb.FormattingEnabled = true;
            this.purchasercmb.Location = new System.Drawing.Point(101, 36);
            this.purchasercmb.Name = "purchasercmb";
            this.purchasercmb.Size = new System.Drawing.Size(152, 21);
            this.purchasercmb.TabIndex = 7;
            this.purchasercmb.SelectedIndexChanged += new System.EventHandler(this.purchasercmb_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Purchaser*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PoNumbertxt
            // 
            this.PoNumbertxt.BackColor = System.Drawing.SystemColors.Window;
            this.PoNumbertxt.Location = new System.Drawing.Point(101, 10);
            this.PoNumbertxt.Name = "PoNumbertxt";
            this.PoNumbertxt.Size = new System.Drawing.Size(119, 20);
            this.PoNumbertxt.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 73);
            this.button1.TabIndex = 55;
            this.button1.Text = "HideTestBtn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 720);
            this.Controls.Add(this.POPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Submission";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.POPanel.ResumeLayout(false);
            this.POPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button getponumbtn;
        private System.Windows.Forms.Panel POPanel;
        private System.Windows.Forms.TextBox notetxt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox orderitemlist;
        private System.Windows.Forms.DateTimePicker deliverydate;
        private System.Windows.Forms.DateTimePicker orderdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox address2txt;
        private System.Windows.Forms.ComboBox shippingcmb;
        private System.Windows.Forms.TextBox address1txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox vendorcmb;
        private System.Windows.Forms.TextBox attntxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox jobnumbertxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox projecttxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadprojectbtn;
        private System.Windows.Forms.ComboBox purchasercmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PoNumbertxt;
        private System.Windows.Forms.Button edititem;
        private System.Windows.Forms.Button removeitem;
        private System.Windows.Forms.TextBox initialtxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox totaltxt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button submitbtn;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem purchaseOrdersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vendorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem materialsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thicknessToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem purchasersToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openReadOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMaterialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGaugeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVendorToolStripMenuItem;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.Button AddMaterialButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
    }
}

