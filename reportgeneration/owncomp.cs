using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Collections;

namespace reportgeneration
{
   public class owncomp
    {

        SQLiteConnection con;
        SQLiteCommand cmd;
        ArrayList comboboxValue = new ArrayList();

        public static string up;
        public static string up1;
        public static string up2;
        private int billno;

        private void Connected()
        {

            con = new SQLiteConnection(@"Data Source=C:\sqlite\record.db;Version=3;New=True;Compress=True;");
            cmd = con.CreateCommand();
        }
        public owncomp()
        {
            Connected();
        }

        private List<owncomp> g = new List<owncomp>();



        public string selectowncompanydetail()
        {
            try
            {
                cmd.CommandText = "SELECT owncompanyname FROM owncompany WHERE owncompanyID = 1";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        up = sdr[0].ToString();

                    }
                }
                return up;
                cmd.Dispose();
                con.Close();

            }


            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public string selectownadddetail()
        {
            try
            {
                cmd.CommandText = "SELECT owncompanyaddress FROM owncompany WHERE owncompanyID = 1";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        up = sdr[0].ToString();

                    }
                }
                return up;
                cmd.Dispose();
                con.Close();

            }


            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public string selectowncntctdetail()
        {
            try
            {
                cmd.CommandText = "SELECT owncompanyno FROM owncompany WHERE owncompanyID = 1";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        up = sdr[0].ToString();

                    }
                }
                return up;
                cmd.Dispose();
                con.Close();

            }


            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }



        public ArrayList companycombobox()
        {
            try
            {
                cmd.CommandText = "SELECT companyname FROM company;";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    comboboxValue.Add("Company Name");
                    while (sdr.Read())
                    {
                        comboboxValue.Add(sdr[0].ToString());

                    }
                }
                return comboboxValue;
                cmd.Dispose();
                con.Close();

            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        ArrayList productcombo = new ArrayList();
        public ArrayList productcombobox()
        {

            try
            {
                cmd.CommandText = "SELECT productID,productname FROM product";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    productcombo.Add("Product Name");
                    while (sdr.Read())
                    {
                        productcombo.Add(sdr[1].ToString());

                    }
                }
                return productcombo;
                cmd.Dispose();
                con.Close();

            }





            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        ArrayList quantitycombo = new ArrayList();
        public ArrayList quantitycombobox()
        {

            try
            {
                cmd.CommandText = "SELECT productquantity FROM product WHERE productID=44";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    quantitycombo.Add("Quantity");
                    while (sdr.Read())
                    {
                        quantitycombo.Add(sdr[0].ToString());

                    }
                }
                return quantitycombo;
                cmd.Dispose();
                con.Close();

            }





            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        ArrayList pricecombo = new ArrayList();
        public ArrayList pricecombobox()
        {

            try
            {
                cmd.CommandText = "SELECT productprice FROM product WHERE productID=44";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    pricecombo.Add("Price");
                    while (sdr.Read())
                    {
                        pricecombo.Add(sdr[0].ToString());

                    }
                }
                return pricecombo;
                cmd.Dispose();
                con.Close();

            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public string cmbproduct()
        {
            try
            {
                cmd.CommandText = "SELECT owncompanyno FROM owncompany WHERE owncompanyID = 1";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;

                using (sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        up = sdr[0].ToString();

                    }
                }
                return up;
                cmd.Dispose();
                con.Close();

            }


            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        public long billdetail()
        {
            try
            {
                cmd.CommandText = " SELECT invoiceID FROM invoice";
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.Connection = con;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        billno = Convert.ToInt32((sdr[0]));

                    }
                }
                return billno + 1;
                cmd.Dispose();
                con.Close();

            }


            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


    }
}
