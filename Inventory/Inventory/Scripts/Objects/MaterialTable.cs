using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class MaterialTable : DatabaseTable, IComparable
    {
        public string material_type;
        public string width;
        public string height;

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            MaterialTable other = obj as MaterialTable;
            return this.material_type.CompareTo(other.material_type);
        }
    }
}
