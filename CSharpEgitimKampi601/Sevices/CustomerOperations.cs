using CSharpEgitimKampi601.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi601.Sevices
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            var connectionn = new MongoDbConnection();
            var customerCollection = connectionn.GetCustomersCollection();

            var document = new BsonDocument
            {
                {"CustomerName", customer.CustomerName},
                {"CustomerSurname",customer.CustomerSurname},
                {"CustomerCity",customer.CustomerCity},
                {"CustomerBalance",customer.CustomerBalance},
                {"CustomerShoppingCount",customer.CustomerShoppingCount},
            };

            customerCollection.InsertOne(document);
        }

        public List<Customer> GetAllCustomer()
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var customers = customerCollection.Find(new BsonDocument()).ToList();
            List<Customer> customerList = new List<Customer>();
            foreach (var c in customers) 
            {
                customerList.Add(new Customer
                {
                    CustomerID =c["_id"].ToString(),
                    CustomerBalance = decimal.Parse(c["CustomerBalance"].ToString()),
                    CustomerCity = c["CustomerCity"].ToString(),
                    CustomerName = c["CustomerName"].ToString(),
                    CustomerSurname = c["CustomerSurname"].ToString(),
                    CustomerShoppingCount =int.Parse(c["CustomerShoppingCount"].ToString())
                });
            }
            return customerList;
        }

        public void DeleteCustomer(string id)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            customerCollection.DeleteOne(filter);
        }

        public void UpdateCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.CustomerID));
            var updatedValue = Builders<BsonDocument>.Update
                .Set("CustomerName", customer.CustomerName)
                .Set("CustomerSurname", customer.CustomerSurname)
                .Set("CustomerCity", customer.CustomerCity)
                .Set("CustomerShoppingCount", customer.CustomerShoppingCount)
                .Set("CustomerBalance", customer.CustomerBalance);
            customerCollection.UpdateOne(filter, updatedValue);
        }

        public Customer GetCustomerById(string id)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = customerCollection.Find(filter).FirstOrDefault();
            return new Customer
            {
                CustomerBalance = decimal.Parse(result["CustomerBalance"].ToString()),
                CustomerShoppingCount = int.Parse(result["CustomerShoppingCount"].ToString()),
                CustomerCity = result["CustomerCity"].ToString(),
               CustomerName  = result["CustomerName"].ToString(),
                CustomerSurname = result["CustomerSurname"].ToString(),
                CustomerID = id,
            };
        }
    }
}
