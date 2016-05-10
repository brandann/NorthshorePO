using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class PurchasersTable : DatabaseTable, IComparable
    {
        public string name_first;
        public string name_last;
        public string initials;
        public string email;
        public bool isActive;

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            PurchasersTable other = obj as PurchasersTable;

            if (this.name_last == other.name_last)
            {
                return (this.name_first.CompareTo(other.name_first));
            }
            else
            {
                return (this.name_last.CompareTo(other.name_last));
            }
        }
    }
}
