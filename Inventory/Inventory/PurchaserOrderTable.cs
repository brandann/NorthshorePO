using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class PurchaserOrderTable : DatabaseTable
    {
        public string po_number;
        public string purchaser;
        public string vendor;
        public string project_number;
        public string po_date;
        public string total;
        public string file;
        public string notes;
    }
}
