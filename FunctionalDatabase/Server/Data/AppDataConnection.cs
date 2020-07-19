using FunctionalDatabase.Server.Data.Models;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace FunctionalDatabase.Server.Data
{
    public class AppDataConnection : DataConnection
    {
        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options) : base(options)
        { }

        public ITable<Category>                   Categories => GetTable<Category>();
        public ITable<Customer>                   Customers => GetTable<Customer>();
        public ITable<Employee>                   Employees => GetTable<Employee>();
        public ITable<Order>                      Orders => GetTable<Order>();
        public ITable<OrderDetail>                OrderDetails => GetTable<OrderDetail>();
        public ITable<Product>                    Products => GetTable<Product>();
        public ITable<Region>                     Regions => GetTable<Region>();
        public ITable<Shipper>                    Shippers => GetTable<Shipper>();
        public ITable<Supplier>                   Suppliers => GetTable<Supplier>();
        public ITable<Territory>                  Territories => GetTable<Territory>();
    }
}