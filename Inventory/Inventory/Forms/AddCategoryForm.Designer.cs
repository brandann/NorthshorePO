namespace Inventory
{
    partial class AddCategoryForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCategoryForm));
			this.Addbtn = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.removebutton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Addbtn
			// 
			this.Addbtn.Location = new System.Drawing.Point(198, 65);
			this.Addbtn.Name = "Addbtn";
			this.Addbtn.Size = new System.Drawing.Size(75, 23);
			this.Addbtn.TabIndex = 0;
			this.Addbtn.Text = "Add";
			this.Addbtn.UseVisualStyleBackColor = true;
			this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(12, 23);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(261, 21);
			this.comboBox1.TabIndex = 2;
			// 
			// removebutton
			// 
			this.removebutton.Enabled = false;
			this.removebutton.Location = new System.Drawing.Point(117, 65);
			this.removebutton.Name = "removebutton";
			this.removebutton.Size = new System.Drawing.Size(75, 23);
			this.removebutton.TabIndex = 3;
			this.removebutton.Text = "Remove";
			this.removebutton.UseVisualStyleBackColor = true;
			// 
			// AddCategoryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 98);
			this.Controls.Add(this.removebutton);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.Addbtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddCategoryForm";
			this.Text = "Add Category";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Addbtn;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button removebutton;
	}
}