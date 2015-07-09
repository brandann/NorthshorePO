using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory2
{
    public class InventoryItem
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
        public string description;  //DESCRIPTION
        public string quantity;     //QUANTITY
        public string unit;         //UNIT
        public float unit_price;    //UNIT_COST
        public float total;         //TOTAL
        public string designation;  
        public string category;     
        public string status;       //STATUS
        public string material;     //MATERIAL
        public string gauge;        //GAUGE
        public string color;        //COLOR
        public float width;         //WIDTH
        public float height;        //HEIGHT
        public string size_unit;    //UNITS
    }
}
