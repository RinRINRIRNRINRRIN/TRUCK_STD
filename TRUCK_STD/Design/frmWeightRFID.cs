using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;
using TRUCK_STD.DbBase;

namespace TRUCK_STD.Design
{
    public partial class frmWeightRFID : Form
    {
        public frmWeightRFID()
        {
            InitializeComponent();
        }

        private void SelectItems(object sender, EventArgs e)
        {
            Guna2ComboBox cbb = sender as Guna2ComboBox;

            string cbbType = cbb.Tag.ToString();

            switch (cbbType)
            {
                case "product":

                    if (product.Select())
                    {
                        cbb.Items.Clear();
                        foreach (DataRow rw in product.tb.Rows)
                        {
                            string id = rw["productId"].ToString();
                            string productName = rw["productName"].ToString();

                            string value = $"{id} | {productName}";
                            cbb.Items.Add(value);
                        }
                    }

                    break;
                case "customer":
                    if (customer.Select())
                    {
                        cbb.Items.Clear();
                        foreach (DataRow rw in customer.tb.Rows)
                        {
                            string id = rw["customerId"].ToString();
                            string customerName = rw["customerName"].ToString();

                            string value = $"{id} | {customerName}";
                            cbb.Items.Add(value);
                        }
                    }
                    break;
            }
        }

        private void frmWeightRFID_Load(object sender, EventArgs e)
        {

        }
    }
}
