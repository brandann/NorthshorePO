using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace testCsharp
{
    public partial class Form1 : Form
    {
        private OleDbConnection myCon;
        public Form1()
        {
            InitializeComponent();
            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\brandan\Documents\NorthshorePO\Access\NssmInventory.mdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into PO_Table (PO_NUMBER,ORDER_BY) values ('" + txtPO.Text + "','" + txtNAME.Text + "')";
            cmd.Connection = myCon;
            myCon.Open();
            cmd.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show("User Account Succefully Created", "Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            myCon.Close();
        }
    }
}
