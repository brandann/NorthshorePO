using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    
    public class PurchaseOrderItem
    {
        public PurchaseOrderItem()
        {
            for(int i = 0; i < 16; i++)
            {
                orderItem[i] = new InventoryOrderItem();
            }
        }

        public string ponumber;

        public string pruchaserName;
        public string pruchaserInitials;

        public string projectName;
        public string projectNumber;

        public string vendorName;
        public string attn;

        public string addressName;
        public string addressStreet;
        public string addressCity;
        public string addressState;
        public string addressZip;

        public DateTime date;
        public DateTime deliveryETA;

        public InventoryOrderItem[] orderItem;

        public string note;
    }
}
