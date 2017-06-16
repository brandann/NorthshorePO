namespace Inventory
{
    partial class Form_AddMaterial
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddMaterial));
			this.descriptiontxt = new System.Windows.Forms.TextBox();
			this.unitpricetxt = new System.Windows.Forms.TextBox();
			this.statuscmb = new System.Windows.Forms.ComboBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.itemtotaltxt = new System.Windows.Forms.TextBox();
			this.designationcmb = new System.Windows.Forms.ComboBox();
			this.quantitytxt = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.cancelbtn = new System.Windows.Forms.Button();
			this.itemsavebtn = new System.Windows.Forms.Button();
			this.gaugecmb = new System.Windows.Forms.ComboBox();
			this.label23 = new System.Windows.Forms.Label();
			this.materialcmb = new System.Windows.Forms.ComboBox();
			this.label24 = new System.Windows.Forms.Label();
			this.colorcmb = new System.Windows.Forms.ComboBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.widthtxt = new System.Windows.Forms.TextBox();
			this.sizeunitcmb = new System.Windows.Forms.ComboBox();
			this.label27 = new System.Windows.Forms.Label();
			this.heighttxt = new System.Windows.Forms.TextBox();
			this.clearbtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.DesButton = new System.Windows.Forms.Button();
			this.unittxt = new System.Windows.Forms.ComboBox();
			this.AddNewMaterialButton = new System.Windows.Forms.Button();
			this.AddNewColorButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// descriptiontxt
			// 
			this.descriptiontxt.Location = new System.Drawing.Point(97, 6);
			this.descriptiontxt.Name = "descriptiontxt";
			this.descriptiontxt.Size = new System.Drawing.Size(203, 20);
			this.descriptiontxt.TabIndex = 0;
			// 
			// unitpricetxt
			// 
			this.unitpricetxt.Location = new System.Drawing.Point(97, 90);
			this.unitpricetxt.Name = "unitpricetxt";
			this.unitpricetxt.Size = new System.Drawing.Size(229, 20);
			this.unitpricetxt.TabIndex = 2;
			this.unitpricetxt.TextChanged += new System.EventHandler(this.unitpricetxt_TextChanged);
			// 
			// statuscmb
			// 
			this.statuscmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.statuscmb.FormattingEnabled = true;
			this.statuscmb.Location = new System.Drawing.Point(97, 208);
			this.statuscmb.Name = "statuscmb";
			this.statuscmb.Size = new System.Drawing.Size(203, 21);
			this.statuscmb.TabIndex = 5;
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(12, 119);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(70, 13);
			this.label34.TabIndex = 98;
			this.label34.Text = "Total Amount";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(12, 93);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(53, 13);
			this.label33.TabIndex = 96;
			this.label33.Text = "Unit Price";
			// 
			// itemtotaltxt
			// 
			this.itemtotaltxt.Location = new System.Drawing.Point(97, 116);
			this.itemtotaltxt.Name = "itemtotaltxt";
			this.itemtotaltxt.Size = new System.Drawing.Size(229, 20);
			this.itemtotaltxt.TabIndex = 3;
			// 
			// designationcmb
			// 
			this.designationcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.designationcmb.FormattingEnabled = true;
			this.designationcmb.Location = new System.Drawing.Point(97, 154);
			this.designationcmb.Name = "designationcmb";
			this.designationcmb.Size = new System.Drawing.Size(229, 21);
			this.designationcmb.TabIndex = 4;
			// 
			// quantitytxt
			// 
			this.quantitytxt.Location = new System.Drawing.Point(97, 64);
			this.quantitytxt.Name = "quantitytxt";
			this.quantitytxt.Size = new System.Drawing.Size(129, 20);
			this.quantitytxt.TabIndex = 1;
			this.quantitytxt.TextChanged += new System.EventHandler(this.quantitytxt_TextChanged_1);
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(12, 209);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(37, 13);
			this.label28.TabIndex = 102;
			this.label28.Text = "Status";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(12, 67);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(46, 13);
			this.label32.TabIndex = 94;
			this.label32.Text = "Quantity";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(12, 9);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(60, 13);
			this.label29.TabIndex = 91;
			this.label29.Text = "Description";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(12, 157);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(63, 13);
			this.label31.TabIndex = 100;
			this.label31.Text = "Designation";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(12, 183);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(49, 13);
			this.label30.TabIndex = 101;
			this.label30.Text = "Category";
			// 
			// cancelbtn
			// 
			this.cancelbtn.Location = new System.Drawing.Point(15, 387);
			this.cancelbtn.Name = "cancelbtn";
			this.cancelbtn.Size = new System.Drawing.Size(90, 23);
			this.cancelbtn.TabIndex = 14;
			this.cancelbtn.Text = "Cancel";
			this.cancelbtn.UseVisualStyleBackColor = true;
			this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
			// 
			// itemsavebtn
			// 
			this.itemsavebtn.Location = new System.Drawing.Point(236, 387);
			this.itemsavebtn.Name = "itemsavebtn";
			this.itemsavebtn.Size = new System.Drawing.Size(90, 23);
			this.itemsavebtn.TabIndex = 13;
			this.itemsavebtn.Text = "Save";
			this.itemsavebtn.UseVisualStyleBackColor = true;
			this.itemsavebtn.Click += new System.EventHandler(this.itemsavebtn_Click);
			// 
			// gaugecmb
			// 
			this.gaugecmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gaugecmb.FormattingEnabled = true;
			this.gaugecmb.Location = new System.Drawing.Point(97, 262);
			this.gaugecmb.Name = "gaugecmb";
			this.gaugecmb.Size = new System.Drawing.Size(203, 21);
			this.gaugecmb.TabIndex = 7;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(14, 238);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(44, 13);
			this.label23.TabIndex = 58;
			this.label23.Text = "Material";
			// 
			// materialcmb
			// 
			this.materialcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.materialcmb.FormattingEnabled = true;
			this.materialcmb.Location = new System.Drawing.Point(97, 235);
			this.materialcmb.Name = "materialcmb";
			this.materialcmb.Size = new System.Drawing.Size(203, 21);
			this.materialcmb.TabIndex = 6;
			this.materialcmb.SelectedIndexChanged += new System.EventHandler(this.materialcmb_SelectedIndexChanged);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(14, 265);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(39, 13);
			this.label24.TabIndex = 56;
			this.label24.Text = "Gauge";
			// 
			// colorcmb
			// 
			this.colorcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.colorcmb.FormattingEnabled = true;
			this.colorcmb.Location = new System.Drawing.Point(97, 289);
			this.colorcmb.Name = "colorcmb";
			this.colorcmb.Size = new System.Drawing.Size(203, 21);
			this.colorcmb.TabIndex = 8;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(14, 292);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(31, 13);
			this.label25.TabIndex = 60;
			this.label25.Text = "Color";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(14, 319);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(35, 13);
			this.label26.TabIndex = 62;
			this.label26.Text = "Width";
			// 
			// widthtxt
			// 
			this.widthtxt.Location = new System.Drawing.Point(97, 316);
			this.widthtxt.Name = "widthtxt";
			this.widthtxt.Size = new System.Drawing.Size(129, 20);
			this.widthtxt.TabIndex = 9;
			// 
			// sizeunitcmb
			// 
			this.sizeunitcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sizeunitcmb.FormattingEnabled = true;
			this.sizeunitcmb.Location = new System.Drawing.Point(232, 342);
			this.sizeunitcmb.Name = "sizeunitcmb";
			this.sizeunitcmb.Size = new System.Drawing.Size(94, 21);
			this.sizeunitcmb.TabIndex = 11;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(14, 346);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(38, 13);
			this.label27.TabIndex = 65;
			this.label27.Text = "Height";
			// 
			// heighttxt
			// 
			this.heighttxt.Location = new System.Drawing.Point(97, 343);
			this.heighttxt.Name = "heighttxt";
			this.heighttxt.Size = new System.Drawing.Size(129, 20);
			this.heighttxt.TabIndex = 10;
			// 
			// clearbtn
			// 
			this.clearbtn.Location = new System.Drawing.Point(111, 387);
			this.clearbtn.Name = "clearbtn";
			this.clearbtn.Size = new System.Drawing.Size(90, 23);
			this.clearbtn.TabIndex = 15;
			this.clearbtn.Text = "Clear";
			this.clearbtn.UseVisualStyleBackColor = true;
			this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 186);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 109;
			this.label1.Text = "Flat Sheets";
			// 
			// DesButton
			// 
			this.DesButton.Location = new System.Drawing.Point(306, 4);
			this.DesButton.Name = "DesButton";
			this.DesButton.Size = new System.Drawing.Size(20, 23);
			this.DesButton.TabIndex = 12;
			this.DesButton.Text = "+";
			this.DesButton.UseVisualStyleBackColor = true;
			this.DesButton.Click += new System.EventHandler(this.DesButton_Click);
			// 
			// unittxt
			// 
			this.unittxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.unittxt.FormattingEnabled = true;
			this.unittxt.Items.AddRange(new object[] {
            "CRATES",
            "EA",
            "LF",
            "PCS",
            "RLS",
            "SF",
            "SHTS"});
			this.unittxt.Location = new System.Drawing.Point(232, 64);
			this.unittxt.Name = "unittxt";
			this.unittxt.Size = new System.Drawing.Size(94, 21);
			this.unittxt.Sorted = true;
			this.unittxt.TabIndex = 110;
			// 
			// AddNewMaterialButton
			// 
			this.AddNewMaterialButton.Location = new System.Drawing.Point(306, 235);
			this.AddNewMaterialButton.Name = "AddNewMaterialButton";
			this.AddNewMaterialButton.Size = new System.Drawing.Size(20, 23);
			this.AddNewMaterialButton.TabIndex = 112;
			this.AddNewMaterialButton.Text = "+";
			this.AddNewMaterialButton.UseVisualStyleBackColor = true;
			// 
			// AddNewColorButton
			// 
			this.AddNewColorButton.Location = new System.Drawing.Point(306, 289);
			this.AddNewColorButton.Name = "AddNewColorButton";
			this.AddNewColorButton.Size = new System.Drawing.Size(20, 23);
			this.AddNewColorButton.TabIndex = 114;
			this.AddNewColorButton.Text = "+";
			this.AddNewColorButton.UseVisualStyleBackColor = true;
			// 
			// Form_AddMaterial
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 424);
			this.Controls.Add(this.AddNewColorButton);
			this.Controls.Add(this.AddNewMaterialButton);
			this.Controls.Add(this.unittxt);
			this.Controls.Add(this.DesButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gaugecmb);
			this.Controls.Add(this.cancelbtn);
			this.Controls.Add(this.itemsavebtn);
			this.Controls.Add(this.clearbtn);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.descriptiontxt);
			this.Controls.Add(this.materialcmb);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.unitpricetxt);
			this.Controls.Add(this.colorcmb);
			this.Controls.Add(this.statuscmb);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label34);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.widthtxt);
			this.Controls.Add(this.label33);
			this.Controls.Add(this.sizeunitcmb);
			this.Controls.Add(this.itemtotaltxt);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.designationcmb);
			this.Controls.Add(this.heighttxt);
			this.Controls.Add(this.quantitytxt);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.label32);
			this.Controls.Add(this.label29);
			this.Controls.Add(this.label31);
			this.Controls.Add(this.label30);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form_AddMaterial";
			this.Text = "Add Material Item";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_AddMaterial_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptiontxt;
        private System.Windows.Forms.TextBox unitpricetxt;
        private System.Windows.Forms.ComboBox statuscmb;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox itemtotaltxt;
        private System.Windows.Forms.ComboBox designationcmb;
        private System.Windows.Forms.TextBox quantitytxt;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button itemsavebtn;
        private System.Windows.Forms.ComboBox gaugecmb;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox materialcmb;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox colorcmb;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox widthtxt;
        private System.Windows.Forms.ComboBox sizeunitcmb;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox heighttxt;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DesButton;
        private System.Windows.Forms.ComboBox unittxt;
		private System.Windows.Forms.Button AddNewMaterialButton;
		private System.Windows.Forms.Button AddNewColorButton;
	}
}