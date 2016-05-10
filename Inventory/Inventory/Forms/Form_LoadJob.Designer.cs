namespace Inventory
{
    partial class LoadJobInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadJobInformation));
            this.Filterlbl = new System.Windows.Forms.Label();
            this.companycmb = new System.Windows.Forms.ComboBox();
            this.resultlistbox = new System.Windows.Forms.ListBox();
            this.okbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statuscmb = new System.Windows.Forms.ComboBox();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.countlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Filterlbl
            // 
            this.Filterlbl.AutoSize = true;
            this.Filterlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filterlbl.Location = new System.Drawing.Point(12, 9);
            this.Filterlbl.Name = "Filterlbl";
            this.Filterlbl.Size = new System.Drawing.Size(45, 17);
            this.Filterlbl.TabIndex = 0;
            this.Filterlbl.Text = "Filter";
            // 
            // companycmb
            // 
            this.companycmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companycmb.FormattingEnabled = true;
            this.companycmb.Items.AddRange(new object[] {
            "Northshore",
            "Northclad",
            "Facade Supply"});
            this.companycmb.Location = new System.Drawing.Point(112, 32);
            this.companycmb.Name = "companycmb";
            this.companycmb.Size = new System.Drawing.Size(214, 21);
            this.companycmb.TabIndex = 1;
            this.companycmb.SelectedIndexChanged += new System.EventHandler(this.companycmb_SelectedIndexChanged);
            // 
            // resultlistbox
            // 
            this.resultlistbox.FormattingEnabled = true;
            this.resultlistbox.Location = new System.Drawing.Point(112, 113);
            this.resultlistbox.Name = "resultlistbox";
            this.resultlistbox.Size = new System.Drawing.Size(455, 381);
            this.resultlistbox.TabIndex = 2;
            // 
            // okbtn
            // 
            this.okbtn.Location = new System.Drawing.Point(492, 500);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(75, 23);
            this.okbtn.TabIndex = 3;
            this.okbtn.Text = "OK";
            this.okbtn.UseVisualStyleBackColor = true;
            this.okbtn.Click += new System.EventHandler(this.okbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Company";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(55, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Status";
            // 
            // statuscmb
            // 
            this.statuscmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statuscmb.FormattingEnabled = true;
            this.statuscmb.Items.AddRange(new object[] {
            "Open",
            "Closed"});
            this.statuscmb.Location = new System.Drawing.Point(112, 59);
            this.statuscmb.Name = "statuscmb";
            this.statuscmb.Size = new System.Drawing.Size(214, 21);
            this.statuscmb.TabIndex = 6;
            this.statuscmb.SelectedIndexChanged += new System.EventHandler(this.statuscmb_SelectedIndexChanged);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(12, 500);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 7;
            this.cancelbtn.Text = "Cancel";
            this.cancelbtn.UseVisualStyleBackColor = true;
            // 
            // countlbl
            // 
            this.countlbl.AutoSize = true;
            this.countlbl.Location = new System.Drawing.Point(112, 500);
            this.countlbl.Name = "countlbl";
            this.countlbl.Size = new System.Drawing.Size(47, 13);
            this.countlbl.TabIndex = 8;
            this.countlbl.Text = "Count: 0";
            // 
            // LoadJobInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 532);
            this.Controls.Add(this.countlbl);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.statuscmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okbtn);
            this.Controls.Add(this.resultlistbox);
            this.Controls.Add(this.companycmb);
            this.Controls.Add(this.Filterlbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoadJobInformation";
            this.Text = "Load Job Information";
            this.Load += new System.EventHandler(this.LoadJobInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Filterlbl;
        private System.Windows.Forms.ComboBox companycmb;
        private System.Windows.Forms.ListBox resultlistbox;
        private System.Windows.Forms.Button okbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox statuscmb;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Label countlbl;
    }
}