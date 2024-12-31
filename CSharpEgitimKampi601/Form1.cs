using CSharpEgitimKampi601.Entities;
using CSharpEgitimKampi601.Sevices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi601
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerOperations customerOperations = new CustomerOperations();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerLastName.Text,
                CustomerBalance = decimal.Parse( txtCustomerBalance.Text),
                CustomerCity = txtCustomerCountry.Text,
                CustomerShoppingCount = int.Parse(txtCustomerAmount.Text) 
            };


            customerOperations.AddCustomer(customer);
            MessageBox.Show("Muşteri Ekleme İşlemi Başarılı", "Uyarı", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
