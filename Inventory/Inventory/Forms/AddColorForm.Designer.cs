namespace Inventory
{
    partial class AddColorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddColorForm));
			this.submitbtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.vendorcmb = new System.Windows.Forms.ComboBox();
			this.typecmb = new System.Windows.Forms.ComboBox();
			this.colorcmb = new System.Windows.Forms.ComboBox();
			this.removebutton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// submitbtn
			// 
			this.submitbtn.Location = new System.Drawing.Point(197, 110);
			this.submitbtn.Name = "submitbtn";
			this.submitbtn.Size = new System.Drawing.Size(75, 23);
			this.submitbtn.TabIndex = 0;
			this.submitbtn.Text = "Add";
			this.submitbtn.UseVisualStyleBackColor = true;
			this.submitbtn.Click += new System.EventHandler(this.submitbtn_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Color:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Vendor:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 86);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Type:";
			// 
			// vendorcmb
			// 
			this.vendorcmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.vendorcmb.FormattingEnabled = true;
			this.vendorcmb.Location = new System.Drawing.Point(88, 56);
			this.vendorcmb.Name = "vendorcmb";
			this.vendorcmb.Size = new System.Drawing.Size(184, 21);
			this.vendorcmb.TabIndex = 7;
			// 
			// typecmb
			// 
			this.typecmb.FormattingEnabled = true;
			this.typecmb.Location = new System.Drawing.Point(88, 83);
			this.typecmb.Name = "typecmb";
			this.typecmb.Size = new System.Drawing.Size(184, 21);
			this.typecmb.TabIndex = 8;
			// 
			// colorcmb
			// 
			this.colorcmb.FormattingEnabled = true;
			this.colorcmb.Location = new System.Drawing.Point(88, 31);
			this.colorcmb.Name = "colorcmb";
			this.colorcmb.Size = new System.Drawing.Size(184, 21);
			this.colorcmb.TabIndex = 9;
			// 
			// removebutton
			// 
			this.removebutton.Enabled = false;
			this.removebutton.Location = new System.Drawing.Point(116, 110);
			this.removebutton.Name = "removebutton";
			this.removebutton.Size = new System.Drawing.Size(75, 23);
			this.removebutton.TabIndex = 12;
			this.removebutton.Text = "Remove";
			this.removebutton.UseVisualStyleBackColor = true;
			// 
			// AddColorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 147);
			this.Controls.Add(this.removebutton);
			this.Controls.Add(this.colorcmb);
			this.Controls.Add(this.typecmb);
			this.Controls.Add(this.vendorcmb);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.submitbtn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "AddColorForm";
			this.Text = "Add Color";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox vendorcmb;
        private System.Windows.Forms.ComboBox typecmb;
        private System.Windows.Forms.ComboBox colorcmb;
		private System.Windows.Forms.Button removebutton;
	}
}