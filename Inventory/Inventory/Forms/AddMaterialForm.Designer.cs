namespace Inventory
{
    partial class AddMaterialForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMaterialForm));
			this.addbtn = new System.Windows.Forms.Button();
			this.TextWidth = new System.Windows.Forms.TextBox();
			this.TextHeight = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.removebutton = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// addbtn
			// 
			this.addbtn.Location = new System.Drawing.Point(197, 107);
			this.addbtn.Name = "addbtn";
			this.addbtn.Size = new System.Drawing.Size(75, 23);
			this.addbtn.TabIndex = 2;
			this.addbtn.Text = "Add";
			this.addbtn.UseVisualStyleBackColor = true;
			this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
			// 
			// TextWidth
			// 
			this.TextWidth.Location = new System.Drawing.Point(94, 55);
			this.TextWidth.Name = "TextWidth";
			this.TextWidth.Size = new System.Drawing.Size(144, 20);
			this.TextWidth.TabIndex = 3;
			// 
			// TextHeight
			// 
			this.TextHeight.Location = new System.Drawing.Point(94, 81);
			this.TextHeight.Name = "TextHeight";
			this.TextHeight.Size = new System.Drawing.Size(144, 20);
			this.TextHeight.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Material:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Defualt Width:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Defualt Height:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(244, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(18, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "in.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(244, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(18, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "in.";
			// 
			// removebutton
			// 
			this.removebutton.Enabled = false;
			this.removebutton.Location = new System.Drawing.Point(116, 107);
			this.removebutton.Name = "removebutton";
			this.removebutton.Size = new System.Drawing.Size(75, 23);
			this.removebutton.TabIndex = 11;
			this.removebutton.Text = "Remove";
			this.removebutton.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(94, 28);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(144, 21);
			this.comboBox1.TabIndex = 10;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// AddMaterialForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 144);
			this.Controls.Add(this.removebutton);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TextHeight);
			this.Controls.Add(this.TextWidth);
			this.Controls.Add(this.addbtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddMaterialForm";
			this.Text = "Add Material";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox TextWidth;
        private System.Windows.Forms.TextBox TextHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button removebutton;
		private System.Windows.Forms.ComboBox comboBox1;
	}
}