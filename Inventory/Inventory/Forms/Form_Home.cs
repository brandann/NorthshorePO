using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form_Home : Form
    {
        public Form_Home()
        {
            InitializeComponent();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            Form_Main f = new Form_Main();
            f.Show();
            f.SetParent(this);
            this.Hide();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update Excel Inventory by pressing Data>Connections>Refresh All to see the current Inventory data");
            System.Diagnostics.Process.Start(@"N:\Receiving and current inventory\InventoryData\InventoryView.xlsm");
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, Viewing a PO is not yet ready.");
            return; 

            /*Form_POView f = new Form_POView();
            f.Show();
            f.SetParent(this);
            this.Hide();*/
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"N:\Receiving and current inventory\InventoryData\help.docx");
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, editing PO's is not yet ready.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Lookup f = new Form_Lookup();
            f.Show();
            f.SetParent(this);
            this.Hide();
        }
    }
}
