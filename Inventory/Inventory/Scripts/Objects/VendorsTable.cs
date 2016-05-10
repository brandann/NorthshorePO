using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class VendorsTable : DatabaseTable, IComparable
    {
        public string vendor;
        public string address1;
        public string address2;
        public string state;
        public string city;
        public string zip;
        public string web;
        public string phone;
        public string fax;
        public string country;

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;   
            }

            VendorsTable other = obj as VendorsTable;
            return this.vendor.CompareTo(other.vendor);
        }
    }
}
