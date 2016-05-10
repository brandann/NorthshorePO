using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    public static class BuildQueue
    {
        public static string buildQueuePO(POInformation p)
        {
            string QA, QB;

            QA = "INSERT INTO PurchaseOrder (";
            QB = "VALUES('";

            QA = QA + "PO_NUMBER,";
            QB = QB + p.OrderNumber + "','";

            QA = QA + "PURCHASER,";
            QB = QB + p.Purchaser + "','";

            QA = QA + "VENDOR,";
            QB = QB + p.Vendor + "','";

            QA = QA + "PROJECT_NUMBER,";
            QB = QB + p.JobNumber + "','";

            QA = QA + "PO_DATE,";
            QB = QB + p.OrderDate + "','";

            QA = QA + "TOTAL,";
            QB = QB + p.Total + "','";

            QA = QA + "FILE,";
            QB = QB + " " + "','";

            QA = QA + "NOTES";
            QB = QB + p.Note;

            QA = QA + ")";
            QB = QB + "')";

            QB.Replace("''", "' '");
            return QA + " " + QB;
        }

        public static string buildQueueMaterial(InventoryOrderItem i, POInformation p)
        {
            string QA, QB;

            QA = "INSERT INTO MaterialInventory (";
            QB = "VALUES('";

            QA = QA + "PO_NUMBER,";
            QB = QB + p.OrderNumber + "','";

            QA = QA + "ORDER_BY,";
            QB = QB + p.Purchaser + "','";

            QA = QA + "DATE_ORDERED,";
            QB = QB + p.OrderDate + "','";

            QA = QA + "PROJECT,";
            QB = QB + p.ProjectName + "','";

            QA = QA + "JOB_NUMBER,";
            QB = QB + p.JobNumber + "','";

            QA = QA + "VENDOR,";
            QB = QB + p.Vendor + "','";

            QA = QA + "GAUGE,";
            QB = QB + i.gauge + "','";

            QA = QA + "DESCRIPTION,";
            QB = QB + i.description + "','";

            QA = QA + "SHEET_SIZE,";
            QB = QB + i.width.ToString() + " x " + i.height.ToString() + " " + i.size_unit + "','";

            QA = QA + "MATERIAL,";
            QB = QB + i.material + "','";

            QA = QA + "ETA,";
            QB = QB + p.DeliveryDate + "','";

            QA = QA + "ATA,";
            QB = QB + "1900-01-01" + "','";
            //------------------------------------------------------------
            QA = QA + "QUANTITY,";
            QB = QB + i.quantity + "','";

            QA = QA + "INVENTORY_QUANTITY,";
            QB = QB + "-" + "','";

            QA = QA + "UNIT_COST,";
            QB = QB + i.unit_price + "','";

            QA = QA + "UNIT,";
            QB = QB + "-" + "','"; //ioi.unit + "','";

            QA = QA + "TOTAL,";
            QB = QB + i.total + "','";

            QA = QA + "COLOR,";
            QB = QB + i.color + "','";

            QA = QA + "MATERIAL_ITEM,"; //category;
            QB = QB + i.category + "','";

            QA = QA + "STOCK_ITEM,"; //designation;
            QB = QB + i.designation + "','";

            QA = QA + "STATUS";
            QB = QB + i.status;

            QA = QA + ")";
            QB = QB + "')";

            //QB.Replace("''", "'-'");
            return QA + " " + QB;
        }
    }
}
