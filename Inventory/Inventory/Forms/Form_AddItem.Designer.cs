namespace Inventory
{
    partial class Form_AddItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddItem));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.itemsavebtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.statuscmb = new System.Windows.Forms.ComboBox();
            this.categorycmb = new System.Windows.Forms.ComboBox();
            this.descriptiontxt = new System.Windows.Forms.TextBox();
            this.designationcmb = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.quantitytxt = new System.Windows.Forms.TextBox();
            this.itemtotaltxt = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.unitpricetxt = new System.Windows.Forms.TextBox();
            this.DesButton = new System.Windows.Forms.Button();
            this.unittxt = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(15, 258);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(90, 23);
            this.cancelbtn.TabIndex = 8;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // itemsavebtn
            // 
            this.itemsavebtn.Location = new System.Drawing.Point(234, 258);
            this.itemsavebtn.Name = "itemsavebtn";
            this.itemsavebtn.Size = new System.Drawing.Size(90, 23);
            this.itemsavebtn.TabIndex = 7;
            this.itemsavebtn.Text = "Save";
            this.itemsavebtn.UseVisualStyleBackColor = true;
            this.itemsavebtn.Click += new System.EventHandler(this.itemsavebtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(111, 258);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(90, 23);
            this.clearbtn.TabIndex = 9;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // statuscmb
            // 
            this.statuscmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statuscmb.FormattingEnabled = true;
            this.statuscmb.Location = new System.Drawing.Point(97, 208);
            this.statuscmb.Name = "statuscmb";
            this.statuscmb.Size = new System.Drawing.Size(227, 21);
            this.statuscmb.TabIndex = 6;
            // 
            // categorycmb
            // 
            this.categorycmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categorycmb.FormattingEnabled = true;
            this.categorycmb.Location = new System.Drawing.Point(97, 181);
            this.categorycmb.Name = "categorycmb";
            this.categorycmb.Size = new System.Drawing.Size(227, 21);
            this.categorycmb.TabIndex = 5;
            // 
            // descriptiontxt
            // 
            this.descriptiontxt.Location = new System.Drawing.Point(97, 6);
            this.descriptiontxt.Name = "descriptiontxt";
            this.descriptiontxt.Size = new System.Drawing.Size(201, 20);
            this.descriptiontxt.TabIndex = 0;
            // 
            // designationcmb
            // 
            this.designationcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.designationcmb.FormattingEnabled = true;
            this.designationcmb.Location = new System.Drawing.Point(97, 154);
            this.designationcmb.Name = "designationcmb";
            this.designationcmb.Size = new System.Drawing.Size(227, 21);
            this.designationcmb.TabIndex = 4;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 209);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 88;
            this.label28.Text = "Status";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(60, 13);
            this.label29.TabIndex = 75;
            this.label29.Text = "Description";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 183);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 13);
            this.label30.TabIndex = 87;
            this.label30.Text = "Category";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(12, 157);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 13);
            this.label31.TabIndex = 86;
            this.label31.Text = "Designation";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(12, 67);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(46, 13);
            this.label32.TabIndex = 80;
            this.label32.Text = "Quantity";
            // 
            // quantitytxt
            // 
            this.quantitytxt.Location = new System.Drawing.Point(97, 64);
            this.quantitytxt.Name = "quantitytxt";
            this.quantitytxt.Size = new System.Drawing.Size(127, 20);
            this.quantitytxt.TabIndex = 1;
            this.quantitytxt.TextChanged += new System.EventHandler(this.quantitytxt_TextChanged);
            // 
            // itemtotaltxt
            // 
            this.itemtotaltxt.Location = new System.Drawing.Point(97, 116);
            this.itemtotaltxt.Name = "itemtotaltxt";
            this.itemtotaltxt.Size = new System.Drawing.Size(227, 20);
            this.itemtotaltxt.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(12, 93);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 13);
            this.label33.TabIndex = 82;
            this.label33.Text = "Unit Price";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(12, 119);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(70, 13);
            this.label34.TabIndex = 84;
            this.label34.Text = "Total Amount";
            // 
            // unitpricetxt
            // 
            this.unitpricetxt.Location = new System.Drawing.Point(97, 90);
            this.unitpricetxt.Name = "unitpricetxt";
            this.unitpricetxt.Size = new System.Drawing.Size(227, 20);
            this.unitpricetxt.TabIndex = 2;
            this.unitpricetxt.TextChanged += new System.EventHandler(this.unitpricetxt_TextChanged);
            // 
            // DesButton
            // 
            this.DesButton.Location = new System.Drawing.Point(304, 4);
            this.DesButton.Name = "DesButton";
            this.DesButton.Size = new System.Drawing.Size(20, 23);
            this.DesButton.TabIndex = 89;
            this.DesButton.Text = "+";
            this.DesButton.UseVisualStyleBackColor = true;
            this.DesButton.Click += new System.EventHandler(this.DesButton_Click);
            // 
            // unittxt
            // 
            this.unittxt.FormattingEnabled = true;
            this.unittxt.Items.AddRange(new object[] {
            "CRATES",
            "EA",
            "LF",
            "PCS",
            "RLS",
            "SF",
            "SHTS"});
            this.unittxt.Location = new System.Drawing.Point(230, 63);
            this.unittxt.Name = "unittxt";
            this.unittxt.Size = new System.Drawing.Size(94, 21);
            this.unittxt.Sorted = true;
            this.unittxt.TabIndex = 111;
            // 
            // Form_AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 294);
            this.Controls.Add(this.unittxt);
            this.Controls.Add(this.DesButton);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.itemsavebtn);
            this.Controls.Add(this.descriptiontxt);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.unitpricetxt);
            this.Controls.Add(this.statuscmb);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.categorycmb);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.itemtotaltxt);
            this.Controls.Add(this.designationcmb);
            this.Controls.Add(this.quantitytxt);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_AddItem";
            this.Text = "Add Other Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_AddItem_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button itemsavebtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.ComboBox statuscmb;
        private System.Windows.Forms.ComboBox categorycmb;
        private System.Windows.Forms.TextBox descriptiontxt;
        private System.Windows.Forms.ComboBox designationcmb;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox quantitytxt;
        private System.Windows.Forms.TextBox itemtotaltxt;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox unitpricetxt;
        private System.Windows.Forms.Button DesButton;
        private System.Windows.Forms.ComboBox unittxt;
    }
}