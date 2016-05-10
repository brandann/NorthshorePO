using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class InventoryOrderItem
    {
        /*
         * Build a description from the material info if the object
         * is a material item, otherwise return the objects description field
         */
        public string GetMaterialDescription()
        {
            if (isMaterial)
            {
                return gauge + " " + material + " " + color + " " + width + size_unit + "*" + height + size_unit;
            }
            return description;
        }

        public bool isMaterial;
        public string description;
        public string quantity;
        public string unit;
        public float unit_price;
        public float total;
        public string designation;
        public string category;
        public string status;
        public string material;
        public string gauge;
        public string color;
        public float width;
        public float height;
        public string size_unit;
        public string deliveryDate;
        public string sheetsize;
    }
}
