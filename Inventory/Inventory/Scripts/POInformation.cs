using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public class POInformation
    {
        public string OrderNumber;

        public string Purchaser;

        public string Vendor;

        public string JobNumber;

        public string OrderDate;

        public string DeliveryDate;

        public float Total;

        public string Note;

        public string ProjectName;

        public Shipping ShippingInfo;

        public string Attention;

        public class Shipping
        {
            public string ShippingName;
            public string ShippingStreet;
            public string ShippingLocation;
        }

    }
}
