namespace Inventory
{
    partial class AddGaugeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGaugeForm));
            this.submitbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.thicknesstxt = new System.Windows.Forms.TextBox();
            this.labelcmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitbtn
            // 
            this.submitbtn.Location = new System.Drawing.Point(229, 81);
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
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gauge/Thicknes";
            // 
            // thicknesstxt
            // 
            this.thicknesstxt.Location = new System.Drawing.Point(106, 28);
            this.thicknesstxt.Name = "thicknesstxt";
            this.thicknesstxt.Size = new System.Drawing.Size(198, 20);
            this.thicknesstxt.TabIndex = 2;
            // 
            // labelcmb
            // 
            this.labelcmb.FormattingEnabled = true;
            this.labelcmb.Location = new System.Drawing.Point(106, 54);
            this.labelcmb.Name = "labelcmb";
            this.labelcmb.Size = new System.Drawing.Size(198, 21);
            this.labelcmb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Label";
            // 
            // AddGaugeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 117);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelcmb);
            this.Controls.Add(this.thicknesstxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.submitbtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddGaugeForm";
            this.Text = "Add Gauge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox thicknesstxt;
        private System.Windows.Forms.ComboBox labelcmb;
        private System.Windows.Forms.Label label3;
    }
}