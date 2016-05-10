using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public static class InventoryDatabase
    {
        public const string PurchaseOrderTemplateFileName = "PurchaseOrderTemplate2.xlsx";
        public const string PurchaseOrderTemplateLocation = @"N:\Receiving and current inventory\InventoryData\";
        public const string PurchaseOrderDatabaseCopySave = @"N:\Receiving and current inventory\InventoryData\PurchaseOrders\";
        public const string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\Inventory.mdb; Persist Security Info=False;";
        public const string InventoryLocation = @"N:\Receiving and current inventory\InventoryData\";
    }
}
