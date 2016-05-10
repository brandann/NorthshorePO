using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class ThicknessTable : DatabaseTable, IComparable
    {
        public string thickness;
        public string type;

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            ThicknessTable other = obj as ThicknessTable;

            if (this.type != other.type)
            {
                return (this.type.CompareTo(other.type));
            }
            else
            {
                float mythick = float.Parse(this.thickness);
                float otherthick = float.Parse(other.thickness);
                return (mythick.CompareTo(otherthick));
            }
        }
    }
}
