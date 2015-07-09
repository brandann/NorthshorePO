using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel; 

namespace Inventory
{
    public class DatabaseController
    {
        #region Members
        private const string InventoryLocation = @"N:\Receiving and current inventory\InventoryData\";

        private  OleDbConnection connection = new OleDbConnection();

        private static Excel.Workbook MyBook = null;
        private static Excel.Application MyApp = null;
        private static Excel.Worksheet MySheet = null;

        public enum SheetNames { MaterialInventory = 1, PruchaseOrderInventory = 2}
        public enum Tables { Category, Color, Material, MaterialInventory, PurchaseOrder, Purchasers, Thickness, Vendors }
        public enum Category_Col { ID, TYPE }
        public enum Color_Col { ID, COLOR, VENDOR, TYPE }
        public enum Material_Col { ID, MATERIAL_TYPE, DEFAULT_WIDTH, DEFAULT_HEIGHT}
        public enum MaterialInventory_Col { ID, PO_NUMBER, DATE_ORDERED, PROJECT, JOB_NUMBER, VENDOR, GAUGE, DESCRIPTION, MATERIAL, ETA, QUANTITY, UNIT, ATA, UNIT_COST, TOTAL, COLOR, MATERIAL_ITEM, ORDER_BY, STOCK_ITEM, WIDTH, HEIGHT, UNITS, STATUS, ATTN }
        public enum PurchaseOrder_Col { ID, PO_NUMBER, PURCHASER, VENDOR, PROJECT_NUMBER, PO_DATE, TOTAL, FILE, NOTES }
        public enum Purchasers_Col { ID, Name_First, Name_Last, Initials, Email, Active }
        public enum Thickness_Col { ID, THICKNESS, TYPE }
        public enum Vendors_Col { ID, VENDOR, CONTACT }
        #endregion

        #region Constructor
        public DatabaseController()
        {
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=N:\Receiving and current inventory\NssmInventory.mdb; Persist Security Info=False;";
        }
        #endregion

        #region Public Methods
        public bool Insert(Tables table, DatabaseTable item)
        {
            string queue = "SELECT * from " + table.ToString();
            try
            {
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = queue;

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception e) 
            {
                connection.Close();
                return false;
            }
            finally { }

            connection.Close();

            return true;
        }

        public DatabaseTable GetTable(Tables table, int id)
        {
            string queue = "SELECT * from " + table.ToString() + " where ID = '" + id + "'";
            return null;
        }

        public bool ReplaceItem(Tables table, int id, string col, string newvalue)
        {
            string queue = "UPDATE " + table.ToString() + " SET " + col + "='" + newvalue + "' WHERE ID='" + id + "'";
            return false;
        }
        #endregion

        #region Private Methods
        private string MaterialInventoryQuery()
        {

            string query = "INSERT INTO MaterialInventory (";
            query += MaterialInventory_Col.PO_NUMBER.ToString();

            return query;
        }

        private string PurchaseOrdersQuery(PurchaseOrderItem po)
        {
            //public enum PurchaseOrder_Col { ID, PO_NUMBER, PURCHASER, VENDOR, PROJECT_NUMBER, PO_DATE, TOTAL, FILE, NOTES }

            string query = "INSERT INTO MaterialInventory (";
            query += PurchaseOrder_Col.PO_NUMBER.ToString() + ",";
            query += PurchaseOrder_Col.PURCHASER.ToString() + ",";
            query += PurchaseOrder_Col.VENDOR.ToString() + ",";
            query += PurchaseOrder_Col.PROJECT_NUMBER.ToString() + ",";
            query += PurchaseOrder_Col.PO_DATE.ToString() + ",";
            query += PurchaseOrder_Col.TOTAL.ToString() + ",";
            query += PurchaseOrder_Col.FILE.ToString() + ",";
            query += PurchaseOrder_Col.NOTES.ToString() + ")";

            query += "VALUES('";

            return query;
        }
        #endregion

        public List<VendorsTable> GetVendors()
        {
            List<VendorsTable> vendors = new List<VendorsTable>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Vendors";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    VendorsTable vendor = new VendorsTable();
                    vendor.vendor = reader.GetString(1);
                    vendors.Add(vendor);
                }

                vendors.Sort();
                reader.Close();
                connection.Close();
                return vendors;
            }
            catch (Exception e) { }
            finally { }

            return vendors;
        }

        public List<PurchasersTable> GetPurchasers()
        {
            List<PurchasersTable> purchasers = new List<PurchasersTable>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Purchasers";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    PurchasersTable p = new PurchasersTable();

                    p.name_first = reader.GetString(1);
                    p.name_last = reader.GetString(2);
                    p.initials = reader.GetString(3);
                    p.email = reader.GetString(4);
                    p.isActive = reader.GetBoolean(5);

                    purchasers.Add(p);
                }

                purchasers.Sort();
                reader.Close();
            }
            catch (Exception e) { }
            finally { }

            connection.Close();
            return purchasers;
        }

        public List<MaterialTable> GetMaterial()
        {
            List<MaterialTable> materials = new List<MaterialTable>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Materials";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MaterialTable material = new MaterialTable();
                    material.material_type = reader.GetString(1);
                    material.width = reader.GetString(2);
                    material.height = reader.GetString(3);
                    materials.Add(material);
                }

                materials.Sort();
                reader.Close();
                connection.Close();
                return materials;
            }
            catch (Exception e) { }
            finally { }

            return materials;
        }

        public List<ThicknessTable> GetThickness()
        {
            List<ThicknessTable> thicknesses = new List<ThicknessTable>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Thickness";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ThicknessTable thickness = new ThicknessTable();
                    thickness.thickness = reader.GetString(1);
                    thickness.type = reader.GetString(2);
                    thicknesses.Add(thickness);
                }

                thicknesses.Sort();
                reader.Close();
                connection.Close();
                return thicknesses;
            }
            catch (Exception e) { }
            finally { }

            return thicknesses;
        }

        public List<ColorTable> GetColor()
        {
            List<ColorTable> colors = new List<ColorTable>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Color";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ColorTable color = new ColorTable();
                    color.color = reader.GetString(1);
                    color.vendor = reader.GetString(2);
                    colors.Add(color);
                }

                colors.Sort();
                reader.Close();
                connection.Close();
                return colors;
            }
            catch (Exception e) { }
            finally { }

            return colors;
        }

        public List<CategoryTable> GetCategory()
        {
            List<CategoryTable> categorys = new List<CategoryTable>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Category";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CategoryTable category = new CategoryTable();
                    category.type = reader.GetString(1);
                    categorys.Add(category);
                }

                categorys.Sort();
                reader.Close();
                connection.Close();
                return categorys;
            }
            catch (Exception e) { }
            finally { }

            return categorys;
        }

        public List<MaterialInventoryTable> QueryMaterialInventory(string q)
        {
            List<MaterialInventoryTable> materials = new List<MaterialInventoryTable>();
            try
            {
                connection.Open();
                var command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from MaterialInventory Where " + q;
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    MaterialInventoryTable material = new MaterialInventoryTable();

                    // ID, PO_NUMBER, DATE_ORDERED, PROJECT, JOB_NUMBER, VENDOR, GAUGE, DESCRIPTION, MATERIAL, ETA, QUANTITY, UNIT, ATA, 
                    // UNIT_COST, TOTAL, COLOR, MATERIAL_ITEM, ORDER_BY, STOCK_ITEM, WIDTH, HEIGHT, UNITS, STATUS, ATTN

                    material.po_number = reader.GetString(1);
                    material.date_ordered = reader.GetString(2);
                    material.project = reader.GetString(3);
                    material.job_number = reader.GetString(4);
                    material.vendor = reader.GetString(5);
                    material.gauge = reader.GetString(6);
                    material.description = reader.GetString(7);
                    material.materail = reader.GetString(8);
                    material.eta = reader.GetString(9);
                    
                    material.quantity = reader.GetDouble(10);
                    
                    material.unit = reader.GetString(11);
                    material.ata = reader.GetString(12);
                    
                    material.unit_cost = reader.GetString(13);
                    material.total = reader.GetString(14);
                    
                    material.color = reader.GetString(15);
                    material.material_item = reader.GetString(16);
                    material.order_by = reader.GetString(17);
                    material.stock_item = reader.GetString(18);
                    
                    material.width = reader.GetString(19);
                    material.height = reader.GetString(20);
                    
                    material.units = reader.GetString(21);
                    material.status = reader.GetString(22);
                    material.attn = reader.GetString(23);

                    materials.Add(material);
                }

                materials.Sort();
                reader.Close();
                connection.Close();
                return materials;
            }
            catch (Exception e) { }
            finally { }

            return materials;
        }
    }
}
