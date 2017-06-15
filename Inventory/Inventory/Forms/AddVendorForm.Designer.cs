namespace Inventory
{
    partial class AddVendorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVendorForm));
			this.okbtn = new System.Windows.Forms.Button();
			this.removebutton = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// okbtn
			// 
			this.okbtn.Location = new System.Drawing.Point(197, 68);
			this.okbtn.Name = "okbtn";
			this.okbtn.Size = new System.Drawing.Size(75, 23);
			this.okbtn.TabIndex = 0;
			this.okbtn.Text = "Submit";
			this.okbtn.UseVisualStyleBackColor = true;
			this.okbtn.Click += new System.EventHandler(this.okbtn_Click);
			// 
			// removebutton
			// 
			this.removebutton.Enabled = false;
			this.removebutton.Location = new System.Drawing.Point(116, 68);
			this.removebutton.Name = "removebutton";
			this.removebutton.Size = new System.Drawing.Size(75, 23);
			this.removebutton.TabIndex = 5;
			this.removebutton.Text = "Remove";
			this.removebutton.UseVisualStyleBackColor = true;
			this.removebutton.Click += new System.EventHandler(this.removebutton_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(11, 26);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(261, 21);
			this.comboBox1.TabIndex = 4;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// AddVendorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 108);
			this.Controls.Add(this.removebutton);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.okbtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddVendorForm";
			this.Text = "Add Vendor";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okbtn;
		private System.Windows.Forms.Button removebutton;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}