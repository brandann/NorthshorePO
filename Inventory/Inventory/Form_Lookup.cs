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
    public partial class Form_Lookup : Form
    {
        private Form_Home mParentForm;
        string[] mExcelFiles;

        public Form_Lookup()
        {
            InitializeComponent();

            FList.Items.Clear();

            //string[] folders = System.IO.Directory.GetDirectories(@"N:\Receiving and current inventory\InventoryData\PurchaseOrders\", "*", System.IO.SearchOption.AllDirectories);
            mExcelFiles = System.IO.Directory.GetFiles(@"N:\Receiving and current inventory\InventoryData\PurchaseOrders\","*");
            for (int i = 0; i < mExcelFiles.Length; i++)
            {
                string[] f = mExcelFiles[i].Split('\\');
                FList.Items.Add(f[f.Length - 1]);
            }
        }

        public void SetParent(Form_Home p)
        {
            this.mParentForm = p;
            this.mParentForm.Hide();
        }

        private void Form_Lookup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.mParentForm.Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //string[] f = files[FList.SelectedIndex].Split('\\');
            //System.IO.File.Copy(files[FList.SelectedIndex], f[FList.SelectedIndex]);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(mExcelFiles[FList.SelectedIndex], saveFileDialog1.FileName);
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
