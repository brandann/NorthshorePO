using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class Purchaser : IComparable<Purchaser>
    {
        public string name;
        public string initials;

        public int CompareTo(Purchaser other)
        {
            return this.name.CompareTo(other.name);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}

