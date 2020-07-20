using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Shared.Models
{
    [Table(Schema="dbo", Name="Customers")]
    public partial class Customer
    {
        [PrimaryKey, NotNull    ] public string CustomerId   { get; set; } // nchar(5)
        [Column,     NotNull    ] public string CompanyName  { get; set; } // nvarchar(40)
        [Column,        Nullable] public string ContactName  { get; set; } // nvarchar(30)
        [Column,        Nullable] public string ContactTitle { get; set; } // nvarchar(30)
        [Column,        Nullable] public string Address      { get; set; } // nvarchar(60)
        [Column,        Nullable] public string City         { get; set; } // nvarchar(15)
        [Column,        Nullable] public string Region       { get; set; } // nvarchar(15)
        [Column,        Nullable] public string PostalCode   { get; set; } // nvarchar(10)
        [Column,        Nullable] public string Country      { get; set; } // nvarchar(15)
        [Column,        Nullable] public string Phone        { get; set; } // nvarchar(24)
        [Column,        Nullable] public string Fax          { get; set; } // nvarchar(24)

        #region Associations

        /// <summary>
        /// FK_Orders_Customers_BackReference
        /// </summary>
        [Association(ThisKey="CustomerID", OtherKey="CustomerID", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
        public IEnumerable<Order> Orders { get; set; }

        #endregion
    }
}