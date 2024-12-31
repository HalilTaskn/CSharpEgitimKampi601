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

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource = customers;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId =txtCustomerID.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Muşteri Silme İşlemi Başarılı", "Uyarı", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id =txtCustomerID.Text;
            var updateCustomer = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerLastName.Text,
                CustomerBalance = decimal.Parse(txtCustomerBalance.Text),
                CustomerCity = txtCustomerCountry.Text,
                CustomerShoppingCount = int.Parse(txtCustomerAmount.Text),
                CustomerID=id,
                
            };
            customerOperations.UpdateCustomer(updateCustomer);
            MessageBox.Show("Muşteri Güncelleme İşlemi Başarılı", "Uyarı", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnIDAdd_Click(object sender, EventArgs e)
        {
            string id = txtCustomerID.Text;
            Customer customers=customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customers };
        }
    }
}
