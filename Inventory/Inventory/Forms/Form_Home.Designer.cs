namespace Inventory
{
    partial class Form_Home
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Home));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.HelpButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.FindButton = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.ViewButton = new System.Windows.Forms.Button();
			this.NewButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(81, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(271, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "Material Inventory";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Crimson;
			this.label2.Location = new System.Drawing.Point(325, 319);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "NEW";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.label3.Location = new System.Drawing.Point(0, 388);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "@2017 (v 2017.06.13)";
			// 
			// HelpButton
			// 
			this.HelpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.HelpButton.Location = new System.Drawing.Point(352, 366);
			this.HelpButton.Name = "HelpButton";
			this.HelpButton.Size = new System.Drawing.Size(75, 23);
			this.HelpButton.TabIndex = 7;
			this.HelpButton.Text = "Help";
			this.HelpButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.HelpButton.UseVisualStyleBackColor = true;
			this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(398, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Beta";
			this.label4.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(145, 319);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Coming Soon";
			// 
			// button1
			// 
			this.button1.BackgroundImage = global::Inventory.Properties.Resources.dark_search;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button1.Location = new System.Drawing.Point(310, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(117, 65);
			this.button1.TabIndex = 8;
			this.button1.Text = "Find Purchase Order";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FindButton
			// 
			this.FindButton.BackgroundImage = global::Inventory.Properties.Resources.dark_doc;
			this.FindButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.FindButton.Location = new System.Drawing.Point(221, 224);
			this.FindButton.Name = "FindButton";
			this.FindButton.Size = new System.Drawing.Size(140, 92);
			this.FindButton.TabIndex = 4;
			this.FindButton.Text = "View Purchase Order";
			this.FindButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.FindButton.UseVisualStyleBackColor = true;
			this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
			// 
			// EditButton
			// 
			this.EditButton.BackgroundImage = global::Inventory.Properties.Resources.dark_pencil;
			this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.EditButton.Enabled = false;
			this.EditButton.Location = new System.Drawing.Point(75, 224);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(140, 92);
			this.EditButton.TabIndex = 3;
			this.EditButton.Text = "Edit Purchase Order";
			this.EditButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.EditButton.UseVisualStyleBackColor = true;
			this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
			// 
			// ViewButton
			// 
			this.ViewButton.BackgroundImage = global::Inventory.Properties.Resources.dark_book_2x;
			this.ViewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ViewButton.Location = new System.Drawing.Point(221, 118);
			this.ViewButton.Name = "ViewButton";
			this.ViewButton.Size = new System.Drawing.Size(140, 92);
			this.ViewButton.TabIndex = 2;
			this.ViewButton.Text = "View Database";
			this.ViewButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.ViewButton.UseVisualStyleBackColor = true;
			this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
			// 
			// NewButton
			// 
			this.NewButton.BackgroundImage = global::Inventory.Properties.Resources.dark_add_2x;
			this.NewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.NewButton.Location = new System.Drawing.Point(75, 118);
			this.NewButton.Name = "NewButton";
			this.NewButton.Size = new System.Drawing.Size(140, 92);
			this.NewButton.TabIndex = 1;
			this.NewButton.Text = "New Purchase Order";
			this.NewButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.NewButton.UseVisualStyleBackColor = true;
			this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
			// 
			// Form_Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 401);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.HelpButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.FindButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.ViewButton);
			this.Controls.Add(this.NewButton);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form_Home";
			this.Text = "Material Inventory";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}