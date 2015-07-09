using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory2
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            for(int i = 0; i < 16; i++)
            {
                items[i] = new InventoryItem();
            }
        }

        public string ponumber;             //PO_NUMBER
        public string pruchaserName;        //PURCHASER
        public string pruchaserInitials;    
        public string projectName;          
        public string projectNumber;        //PROJECT_NUMBER
        public string vendorName;           //VENDOR
        public string attn;                 
        public string addressName;          
        public string addressStreet;
        public string addressCity;
        public string addressState;
        public string addressZip;
        public float total;
        public DateTime date;               //PO_DATE
        public DateTime deliveryETA;
        public InventoryItem[] items;
        public string note;                 //NOTE
    }
}
