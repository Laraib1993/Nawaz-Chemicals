using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Configuration;

namespace reportgeneration
{
    class querying
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        public static string up;


        private void Connecting()
        {

            conn = new SQLiteConnection(@"Data Source=C:\sqlite\record.db;Version=3;New=True;Compress=True;");
            cmd = conn.CreateCommand();
        }

        public querying()
        {
            Connecting();
        }

        public void insertuser(datavalues p)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO user (username,password,contactno) VALUES('" + p.Name + "','" + p.Address + "','" + p.Contactno + "')";
                cmd.CommandType = CommandType.Text;
                

                cmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (conn != null)
                {
                    
                    conn.Close();
                }
            }
        }


        public void insertproduct(datavalues p)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO product(productname, productquantity, productprice, producttotal) VALUES('" + p.Productname + "','" + p.Productquantity + "','" + p.Productprice + "','" + p.Producttotal + "')";
                cmd.CommandType = CommandType.Text;
                

                cmd.ExecuteNonQuery();


            }

            catch (Exception)
            {
                throw ;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public void insertcompany(datavalues p)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO company (companyname,companyaddress,companycontactno) VALUES('" + p.Companyname + "','" + p.Companyaddress + "','" + p.Companycontactno + "')";
                cmd.CommandType = CommandType.Text;

                

                cmd.ExecuteNonQuery();
               
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (conn != null)
                {
                    
                    conn.Close();
                }
            }
        }


        public datavalues invoicehistorydetail(datavalues p)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT invoiceno,invoicedatetime,billprice,companyname FROM invoice;";
                cmd.CommandType = CommandType.Text;
                
                cmd.Connection = conn;
                SQLiteDataReader sdr = null;
                using (sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        p.Billnumber = sdr[0].ToString();
                        p.Invoivedatetime = sdr[1].ToString();
                        p.Billprice = Convert.ToDecimal(sdr[2]);
                        p.Companynameforinvoice = sdr[3].ToString();
                    }
                }
                return p;
                //cmd.Dispose();
            }


            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void insertvoice(datavalues p)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO invoice(invoiceno,invoicedatetime,billprice,companyname) VALUES('" + p.Billnumber + "','" + p.Invoicedatetime + "','" + p.Billprice + "','" + p.Companynameforinvoice + "')";
                cmd.CommandType = CommandType.Text;
                

                cmd.ExecuteNonQuery();
                
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (conn != null)
                {
                    
                    conn.Close();
                }
            }
        }



        public void insertowncompany(datavalues p)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "UPDATE owncompany SET owncompanyname='" + p.Owncompany + "' , owncompanyaddress='" + p.Owncompaddress + "', owncompanyno='" + p.Owncompcontactno + "'  WHERE owncompanyID = 1";
                cmd.CommandType = CommandType.Text;

                

                cmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (conn != null)
                {
                    
                    conn.Close();
                }
            }
        }


        //public datavalues selectowncompanydetail(datavalues p)
        //{
        //    cmd.CommandText = "SELECT owncompanyname,owncompanyaddress,owncompanyno FROM owncompany WHERE owncompanyID = 1";
        //    cmd.CommandType = CommandType.Text;
        //    conn.Open();
        //    using (cmd.Connection = conn)
        //    {
        //        SQLiteDataReader sdr = null;
        //        sdr = cmd.ExecuteReader();
        //        while (sdr.Read())
        //        {
        //            //   p.Owncompany = sdr[0].ToString();
        //        }

        //    }

        //    return p;

        //}



    }
}

