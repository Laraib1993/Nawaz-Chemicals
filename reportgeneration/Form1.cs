using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Xml;
using System.Collections;
using reportgeneration.Properties;
using System.Drawing.Printing;


namespace reportgeneration
{
    public partial class Form1 : Form
    {
        querying b = new querying();
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            try
            {
                owncomp oc = new owncomp();
                dellblTb();
                btnprintview.Visible = false;
                lblowncompname.Visible = true;
                lblowncompadd.Visible = true;
                lblownmob.Visible = true;
                lblowncompname.Text = oc.selectowncompanydetail().ToString();
                lblowncompadd.Text = oc.selectownadddetail().ToString();
                lblownmob.Text = oc.selectowncntctdetail().ToString();
            }
            catch (Exception)
            {

            }
            
        }

        private void dellblTb()
        {
            try
            {
                foreach (var lbl in Controls.OfType<Label>())
                    lbl.Hide();

                foreach (var txt in Controls.OfType<TextBox>())
                    txt.Hide();

                foreach (var btn in Controls.OfType<Button>())
                    btn.Hide();
                foreach (var combo in Controls.OfType<ComboBox>())
                    combo.Hide();
                foreach (var grid in Controls.OfType<DataGridView>())
                    grid.Hide();
            }
            catch (Exception)
            {

            }
        }

        private void shwlblTb()
        {
            try
            {
                foreach (var lbl in Controls.OfType<Label>())
                    lbl.Show();

                foreach (var txt in Controls.OfType<TextBox>())
                    txt.Show();

                foreach (var btn in Controls.OfType<Button>())
                    btn.Show();
            }

            catch (Exception)
            {

            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dellblTb();
                lblUserName.Visible = true;
                lblPassword.Visible = true;
                lblContact.Visible = true;
                txtUserName.Visible = true;
                txtPassword.Visible = true;
                txtContact.Visible = true;
                btnSubmit.Visible = true;
            }

            catch (Exception)
            {

            }
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
           try
            {
                shwlblTb();
                lblUserName.Visible = false;
                lblPassword.Visible = false;
                lblContact.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
                txtContact.Visible = false;
                btnSubmit.Visible = false;
                lblProductNmae.Visible = false;
                lblPrize.Visible = false;
                lblQuantity.Visible = false;
                txtProductName.Visible = false;
                txtQuantity.Visible = false;
                txtPrize.Visible = false;
                btnProductSubmit.Visible = false;
            }
            catch (Exception)
            {

            }
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                shwlblTb();
                lblUserName.Visible = false;
                lblPassword.Visible = false;
                lblContact.Visible = false;
                txtUserName.Visible = false;
                txtPassword.Visible = false;
                txtContact.Visible = false;
                btnSubmit.Visible = false;
                lblCompanyName.Visible = false;
                lblAddress.Visible = false;
                lblCompanyContact.Visible = false;
                txtCompantName.Visible = false;
                txtCompanyAddress.Visible = false;
                txtComanyContact.Visible = false;
                btnCompanySubmit.Visible = false;
            }
             catch (Exception)
            {

            }
        }

        private void btnProductSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Isproduct())
                {
                    datavalues pc = new datavalues();
                    pc.Productname = txtProductName.Text;
                    pc.Productquantity = Convert.ToInt16(txtQuantity.Text);
                    pc.Productprice = Convert.ToInt16(txtPrize.Text);
                    int calculation = (Convert.ToInt16(txtQuantity.Text) * Convert.ToInt16(txtPrize.Text));
                    pc.Producttotal = calculation;
                    b.insertproduct(pc);
                    MessageBox.Show("Product has been addded successfully", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }
            catch (Exception)
            {

            }
        }

        private bool Isproduct()
        {
            if (txtProductName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                
            }

            if (txtQuantity.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Quantity is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                
            }


            if (txtPrize.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Price is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                if (Isuser())
                {
                    datavalues pc = new datavalues();
                    pc.Name = txtUserName.Text;
                    pc.Address = txtPassword.Text;
                    pc.Contactno = txtContact.Text;
                    b.insertuser(pc);
                    MessageBox.Show("User has been added successfully", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool Isuser()
        {
            if (txtUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("User name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Password is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtContact.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Contact is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void btnCompanySubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Iscomp())
                {
                    datavalues pc = new datavalues();
                    pc.Companyname = txtCompantName.Text;
                    pc.Companyaddress = txtCompanyAddress.Text;
                    pc.Companycontactno = txtComanyContact.Text;
                    b.insertcompany(pc);
                    MessageBox.Show("Company has been added successfully", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }
            catch (Exception)
            {
                
            }

        }

        private bool Iscomp()
        {
            if (txtCompantName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Company name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCompanyAddress.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Address is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtComanyContact.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Contact is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void btnnewbill_Click(object sender, EventArgs e)
        {
            try
            {
                cmbcompanyname.Focus();
                gen.Clear();
                dataGridView1.DataSource = null;
                cmbcompanyname.Focus();
                owncomp oc = new owncomp();
                lblowncompname.Text = oc.selectowncompanydetail().ToString();
                lblowncompadd.Text = oc.selectownadddetail().ToString();
                lblownmob.Text = oc.selectowncntctdetail().ToString();
                lblbillno.Text = (oc.billdetail().ToString());
                lbldatenow.Text = DateTime.Now.ToShortDateString();
                lbldays.Text = DateTime.Now.DayOfWeek.ToString();
                //Company Combox 
                cmbcompanyname.DataSource = oc.companycombobox();
                //PrductComboBox
                cmbproductname.DataSource = oc.productcombobox();
                txtownadd.Visible = false;
                txtowncntct.Visible = false;
                txtowncomp.Visible = false;
                btnowncompsubmit.Visible = false;
                lblowncntct.Visible = false;
                lblowncompadd.Visible = false;
                lblowncompany.Visible = false;
                lblowncompanyadd.Visible = false;
                btnSubmit.Visible = false;
                btnCompanySubmit.Visible = false;
                btnProductSubmit.Visible = false;
                txtContact.Visible = false;
                txtPassword.Visible = false;
                txtUserName.Visible = false;
                txtComanyContact.Visible = false;
                txtCompanyAddress.Visible = false;
                txtCompantName.Visible = false;
                lblCompanyContact.Visible = false;
                lblContact.Visible = false;
                lblowncompname.Visible = false;
                lblowncompadd.Visible = false;
                lblownmob.Visible = false;
                lblPassword.Visible = false;
                lblUserName.Visible = false;
                lblCompanyName.Visible = false;
                lblAddress.Visible = false;
                lblPrize.Visible = false;
                lblQuantity.Visible = false;
                lblProductNmae.Visible = false;
                txtPrize.Visible = false;
                txtQuantity.Visible = false;
                txtProductName.Visible = false;
                lblbillname.Visible = true;
                lblbillno.Visible = true;
                lbldatename.Visible = true;
                lbldatenow.Visible = true;
                lbldayname.Visible = true;
                lbldays.Visible = true;
                lblgrossname.Visible = true;
                txttotalamount.Visible = true;
                txttotalamount.Enabled = true;
                btnnewbill.Visible = true;
                cmbproductname.Enabled = true;
                cmbquantityname.Visible = true;
                cmbquantityname.Enabled = true;
                cmbpricename.Enabled = true;
                cmbpricename.Visible = true;
                btncart.Enabled = true;
                cmbcompanyname.Enabled = true;
                btnprinterorder.Visible = true;
                btnprinterorder.Enabled = true;
                btnprintview.Visible = false;//
                btnprintview.Enabled = false;
                lblowncompname.Visible = true;
                lblowncompadd.Visible = true;
                lblownmob.Visible = true;
                cmbcompanyname.Enabled = true;

                btncancleoder.Enabled = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void makeInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                btnprintview.Visible = false;
                dellblTb();
                lblowncompadd.Visible = true;
                cmbcompanyname.Enabled = false;
                cmbproductname.Enabled = false;
                cmbquantityname.Enabled = false;
                cmbquantityname.Enabled = false;
                cmbpricename.Enabled = false;
                btncancleoder.Enabled = false;
                btncart.Enabled = false;
                btnprinterorder.Enabled = false;
                lblownmob.Visible = true;
                lblowncompname.Visible = true;
                cmbcompanyname.Visible = true;
                cmbproductname.Visible = true;
                cmbquantityname.Visible = true;
                cmbpricename.Visible = true;
                lblbillname.Visible = true;
                lblbillno.Visible = true;
                lbldatename.Visible = true;
                lbldatenow.Visible = true;
                lbldayname.Visible = true;
                lbldays.Visible = true;
                lblclientname.Visible = true;
                lblquantityname.Visible = true;
                lblproduct.Visible = true;
                lblprice.Visible = true;
                dataGridView1.Visible = true;
                btncart.Visible = true;
                btnprinterorder.Visible = true;
                btnnewbill.Visible = true;
                btncancleoder.Visible = true;
                lblgrossname.Visible = true;
                txttotalamount.Visible = true;
                owncomp oc = new owncomp();
                lblowncompname.Text = oc.selectowncompanydetail().ToString();
                lblowncompadd.Text = oc.selectownadddetail().ToString();
                lblownmob.Text = oc.selectowncntctdetail().ToString();
                lblbillno.Text = (oc.billdetail().ToString());
                
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
        }
        private void cmbproductname_SelectedIndexChanged(object sender, EventArgs e)
        {  
        }
        
        private List<AddCart> gen = new List<AddCart>();
        private void btncart_Click(object sender, EventArgs e)
        {
            cmbproductname.Focus();
            int k;
            try
            {
                if (IsValidated())
                {
                    k = 0 + 1;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells["Serialno"].Value = k;
                        k++;
                    }
                    AddCart cart = new AddCart()
                    {
                        Serialno = k,
                        ProductName = cmbproductname.Text,
                        Qunatity = Convert.ToDecimal(cmbquantityname.Text.Trim()),
                        Price = Convert.ToDecimal(cmbpricename.Text.Trim()),
                        TotalAmount = ((Convert.ToDecimal(cmbquantityname.Text.Trim())) * (Convert.ToDecimal(cmbpricename.Text.Trim())))
                    };
                    
                    gen.Add(cart);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = gen;

                    cmbproductname.SelectedIndex = -1;
                    cmbquantityname.Text = null;
                    cmbpricename.Text = null;
                    cmbproductname.Text = null;
                    cmbpricename.Text = null;
                    cmbquantityname.Text = null;
                    decimal grossamount = gen.Sum(x => x.TotalAmount);
                    txttotalamount.Text = grossamount.ToString();
                }
        }

                catch (Exception ex)
                {
                MessageBox.Show(ex.Message, "btncart_Click");
                }

}

        private bool IsValidated()
        {
            if (cmbcompanyname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Client Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbproductname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product Name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbquantityname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product Quantity is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            if (cmbpricename.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Product Price is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void companyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                TextBox t = new TextBox();
                t.Width = 1000;
            dellblTb();
            lblowncompadd.Visible = true;
            lblownmob.Visible = true;
            lblowncompname.Visible = true;
            lblCompanyName.Visible = true;
            lblAddress.Visible = true;
            lblCompanyContact.Visible = true;
            txtCompantName.Visible = true;
            txtCompanyAddress.Visible = true;
            txtComanyContact.Visible = true;
            btnCompanySubmit.Visible = true;
            btnprintview.Visible = false;
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void userToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                dellblTb();
                lblowncompadd.Visible = true;
                lblownmob.Visible = true;
                lblowncompname.Visible = true;
                lblUserName.Visible = true;
                lblPassword.Visible = true;
                lblContact.Visible = true;
                txtUserName.Visible = true;
                txtPassword.Visible = true;
                txtContact.Visible = true;
                btnSubmit.Visible = true;
                btnprintview.Visible = false;

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void productsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           try
            {
                dellblTb();
                lblowncompname.Visible = true;
                lblowncompadd.Visible = true;
                lblownmob.Visible = true;
                lblProductNmae.Visible = true;
                lblQuantity.Visible = true;
                lblPrize.Visible = true;
                txtProductName.Visible = true;
                txtQuantity.Visible = true;
                txtPrize.Visible = true;
                btnProductSubmit.Visible = true;
                btnprintview.Visible = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
               

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          
           
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

       

        private void btncancleoder_Click(object sender, EventArgs e)
        {
            try
            {
                txttotalamount.Text = "0";
                gen.Clear();
                dataGridView1.DataSource = null;
                cmbproductname.SelectedIndex = -1;
                cmbcompanyname.SelectedIndex = -1;
                cmbquantityname.Text = null;
                cmbpricename.Text = null;
                cmbproductname.Text = null;
                cmbpricename.Text = null;
                cmbquantityname.Text = null;
                cmbcompanyname.Enabled = false;
                cmbproductname.Enabled = false;
                cmbquantityname.Enabled = false;
                cmbquantityname.Enabled = false;
                cmbpricename.Enabled = false;
                btncancleoder.Enabled = false;
                btncart.Enabled = false;
                btnprinterorder.Enabled = false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    var hiting = dataGridView1.HitTest(e.X, e.Y);
                    dataGridView1.Rows[hiting.RowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int gvindex = dataGridView1.CurrentCell.RowIndex;
                gen.RemoveAt(gvindex);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = gen;
                decimal grossamount = gen.Sum(x => x.TotalAmount);
                txttotalamount.Text = grossamount.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "deleteToolStripMenuItem_Click");
            }
        }

        private void ownCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dellblTb();
                lblowncompname.Visible = true;
                lblowncompadd.Visible = true;
                lblownmob.Visible = true;
                lblowncompany.Visible = true;
                lblowncompanyadd.Visible = true;
                lblowncntct.Visible = true;
                txtowncomp.Visible = true;
                txtownadd.Visible = true;
                txtowncntct.Visible = true;
                btnowncompsubmit.Visible = true;
                btnprintview.Visible = false;
            }

             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnowncompsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Isowncomp())
                {
                    datavalues pc = new datavalues();
                    pc.Owncompany = txtowncomp.Text;
                    pc.Owncompaddress = txtownadd.Text;
                    pc.Owncompcontactno = txtowncntct.Text;
                    b.insertowncompany(pc);
                    MessageBox.Show("Your company information has been replaced successfully", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool Isowncomp()
        {
            if (txtowncomp.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Company name is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtownadd.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Company address is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtowncntct.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Company contact number is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void btnprinterorder_Click(object sender, EventArgs e)
        {
            
                if (dataGridView1.DataSource != null)
                {
                    PrinterSettings ps = new PrinterSettings();
                    var recordDoc = new PrintDocument();
                    recordDoc.PrinterSettings = ps;
                    IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
                    PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
                    recordDoc.DefaultPageSettings.PaperSize = sizeA4;
                    recordDoc = printDocument1;
                    printPreviewDialog1.Document = recordDoc;
                    //recordDoc.DefaultPageSettings.Landscape = true;
                    //printDocument1.Print();
                    recordDoc.Print();

                    datavalues pc = new datavalues();
                    pc.Billnumber = lblbillno.Text;
                    pc.Invoicedatetime = DateTime.Now;
                    pc.Billprice = Convert.ToDecimal(txttotalamount.Text);
                    pc.Companynameforinvoice = cmbcompanyname.SelectedValue.ToString();;
                    b.insertvoice(pc);
                    //database 
                }

                else
                {
                    MessageBox.Show("List is empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
               
        //    }

            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private List<carthistory> historygen = new List<carthistory>();
        private void invoiceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            owncomp oc = new owncomp();
            dellblTb();
            lblowncompname.Visible = true;
            lblowncompadd.Visible = true;
            lblownmob.Visible = true;
            lblowncompname.Visible = true;
            lblowncompadd.Visible = true;
            lblownmob.Visible = true;
            // TODO: This line of code loads data into the 'recordDataSet.invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.recordDataSet.invoice);
            dgvinvoicehist.Visible = true;
        }

        private int pages = 0;
        private int pageprinted = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string orignal = "Orignal Copy";
                string dupicate = "Duplicate Copy";
                string extra = "Company Copy";
                StringFormat rightt = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                e.Graphics.DrawString(lblowncompname.Text, new Font("arial black", 20, FontStyle.Underline), Brushes.Black, new Point(240, 85));
                e.Graphics.DrawString(lblowncompadd.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(255, 145));
                e.Graphics.DrawString("Cell# : " + lblownmob.Text, new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new Point(320, 170));
                e.Graphics.DrawString("Bill No : " + lblbillno.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, 10), rightt);

                for (int i = pageprinted; i <= 3; i++)
                {
                    i++;
                    pages++;
                    if (pages < 2)
                    {
                        pageprinted++;

                        if (pageprinted <= 3)
                        {

                            if (pageprinted == 1)
                            {
                                e.Graphics.DrawString(orignal, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(670, 30),rightt);
                                e.Graphics.DrawString("Date : " + lbldatenow.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, 180),rightt);
                                e.Graphics.DrawString("Day : " + lbldays.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, 215),rightt);
                                e.Graphics.DrawString("Mr/Company : " + cmbcompanyname.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 250));
                                e.Graphics.DrawString("_______________________________________________________",
                                    new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 255));
                                e.Graphics.DrawString("_______________________________________________________",
                                    new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 265));
                                e.Graphics.DrawString("SNo", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(154, 290));
                                e.Graphics.DrawString("Product", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(194, 290));
                                e.Graphics.DrawString("Quantity in kg", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(394, 290));
                                e.Graphics.DrawString("Rate/KG", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(522, 290));
                                e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(604, 290));
                                e.Graphics.DrawString("_______________________________________________________",
                                     new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 300));
                                int ypo = 335;
                                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                                for (int j = 0; j < gen.Count; j++)
                                {
                                    e.Graphics.DrawString(gen[j].Serialno.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(153, ypo));
                                    e.Graphics.DrawString(gen[j].ProductName, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(192, ypo));
                                    e.Graphics.DrawString(gen[j].Qunatity.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(510, ypo), format);
                                   e.Graphics.DrawString(gen[j].Price.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(593, ypo),format);
                                    e.Graphics.DrawString(gen[j].TotalAmount.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(670, ypo),format);

                                    ypo += 20;

                                }
                                e.Graphics.DrawString("_______________________________________________________",
                                new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, ypo));
                                e.Graphics.DrawString("Gross Amount : " + txttotalamount.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Blue, new Point(670, ypo + 24), format);

                                e.Graphics.DrawString("_______________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, ypo + 30));
                                e.Graphics.DrawString("Signture : _____________", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(154, 770));
                                e.Graphics.DrawString("Reciever : _____________", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(470, 770));
                                


                            }

                            else if (pageprinted == 2)
                            {
                                e.Graphics.DrawString(dupicate, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(670, 30), rightt);
                                e.Graphics.DrawString("Date : " + lbldatenow.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, 180), rightt);
                                e.Graphics.DrawString("Day : " + lbldays.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, 215), rightt);
                                e.Graphics.DrawString("Mr/Company : " + cmbcompanyname.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 250));
                                e.Graphics.DrawString("_______________________________________________________",
                                    new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 255));
                                e.Graphics.DrawString("_______________________________________________________",
                                    new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 265));
                                e.Graphics.DrawString("SNo", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(154, 290));
                                e.Graphics.DrawString("Product", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(194, 290));
                                e.Graphics.DrawString("Quantity in kg", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(394, 290));
                                e.Graphics.DrawString("Rate/KG", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(522, 290));
                                e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(604, 290));
                                e.Graphics.DrawString("_______________________________________________________",
                                     new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 300));
                                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                                int yp = 335;
                                for (int j = 0; j < gen.Count; j++)
                                {

                                    e.Graphics.DrawString(gen[j].Serialno.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(153, yp));
                                    e.Graphics.DrawString(gen[j].ProductName, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(192, yp));
                                    e.Graphics.DrawString(gen[j].Qunatity.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(510, yp),format);
                                    e.Graphics.DrawString(gen[j].Price.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(593, yp),format);
                                    e.Graphics.DrawString(gen[j].TotalAmount.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, new Point(670, yp),format);

                                    yp += 20;

                                }
                                e.Graphics.DrawString("_______________________________________________________",
                                new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, yp));
                                e.Graphics.DrawString("Gross Amount : " + txttotalamount.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Blue, new Point(670, yp + 24), format);

                                e.Graphics.DrawString("_______________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, yp + 30));
                                e.Graphics.DrawString("Signture : _____________", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(154, 770));
                                e.Graphics.DrawString("Reciever : _____________", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(470, 770));

                            }


                            else if (pageprinted == 3)
                            {
                                e.Graphics.DrawString(extra, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(670, 30), rightt);
                                e.Graphics.DrawString("Date : " + lbldatenow.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, 180), rightt);
                                e.Graphics.DrawString("Day : " + lbldays.Text, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, 215), rightt);
                                e.Graphics.DrawString("Mr/Company : " + cmbcompanyname.Text, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 250));
                                e.Graphics.DrawString("_______________________________________________________",
                                    new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 255));
                                e.Graphics.DrawString("_______________________________________________________",
                                    new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 265));
                                e.Graphics.DrawString("SNo", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(154, 290));
                                e.Graphics.DrawString("Product", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(194, 290));
                                e.Graphics.DrawString("Quantity in kg", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(394, 290));
                                e.Graphics.DrawString("Rate/KG", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(522, 290));
                                e.Graphics.DrawString("Amount", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(604, 290));
                                e.Graphics.DrawString("_______________________________________________________",
                                     new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, 300));
                                StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                                int ypos = 335;
                                for (int j = 0; j < gen.Count; j++)
                                {

                                    e.Graphics.DrawString(gen[j].Serialno.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(153, ypos));
                                    e.Graphics.DrawString(gen[j].ProductName, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(192, ypos));
                                    e.Graphics.DrawString(gen[j].Qunatity.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(510, ypos),format);
                                    e.Graphics.DrawString(gen[j].Price.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(593, ypos),format);
                                    e.Graphics.DrawString(gen[j].TotalAmount.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(670, ypos),format);

                                    ypos += 20;

                                }

                                e.Graphics.DrawString("_______________________________________________________",
                                new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, ypos));
                                e.Graphics.DrawString("Gross Amount : " + txttotalamount.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Blue, new Point(670, ypos + 24), format);

                                e.Graphics.DrawString("_______________________________________________________", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(154, ypos + 30));
                                e.Graphics.DrawString("Signture : _____________", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(154, 770));
                                e.Graphics.DrawString("Reciever : _____________", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(470, 770));

                                pageprinted = 0;
                                pages = 0;
                            }

                        }

                        else
                        {
                            e.HasMorePages = false;
                        }

                    }


                    else
                    {
                        pages = 0;
                        e.HasMorePages = true;
                    }


                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnprintview_Click(object sender, EventArgs e)
        {
        }

        private void lblownmob_Click(object sender, EventArgs e)
        {

        }

        private void lblowncompadd_Click(object sender, EventArgs e)
        {

        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbquantityname_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Globalization.CultureInfo c = System.Globalization.CultureInfo.CurrentUICulture;
            char dot = (char)c.NumberFormat.NumberDecimalSeparator[0];
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !e.KeyChar.Equals(dot))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
        && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void cmbpricename_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Globalization.CultureInfo c = System.Globalization.CultureInfo.CurrentUICulture;
            char dot = (char)c.NumberFormat.NumberDecimalSeparator[0];
            if (!char.IsControl(e.KeyChar) && !char.IsDigit (e.KeyChar) && !e.KeyChar.Equals(dot))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
        && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }

        private void txtPrize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtComanyContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtowncntct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void dgvinvoicehist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
