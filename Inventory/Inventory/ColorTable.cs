using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class ColorTable : DatabaseTable, IComparable
    {
        public string color;
        public string vendor;
        public string type;

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            ColorTable other = obj as ColorTable;
            return (this.color.CompareTo(other.color));
        }
    }
}
