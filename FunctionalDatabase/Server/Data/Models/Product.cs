using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Server.Data.Models
{
    [Table(Schema="dbo", Name="Products")]
    public partial class Product
    {
        [PrimaryKey, Identity   ] public int      ProductID       { get; set; } // int
        [Column,     NotNull    ] public string   ProductName     { get; set; } // nvarchar(40)
        [Column,        Nullable] public int?     SupplierID      { get; set; } // int
        [Column,        Nullable] public int?     CategoryID      { get; set; } // int
        [Column,        Nullable] public string   QuantityPerUnit { get; set; } // nvarchar(20)
        [Column,        Nullable] public decimal? UnitPrice       { get; set; } // money
        [Column,        Nullable] public short?   UnitsInStock    { get; set; } // smallint
        [Column,        Nullable] public short?   UnitsOnOrder    { get; set; } // smallint
        [Column,        Nullable] public short?   ReorderLevel    { get; set; } // smallint
        [Column,     NotNull    ] public bool     Discontinued    { get; set; } // bit

        #region Associations

        /// <summary>
        /// FK_Products_Categories
        /// </summary>
        [Association(ThisKey="CategoryID", OtherKey="CategoryID", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Products_Categories", BackReferenceName="Products")]
        public Category Category { get; set; }

        /// <summary>
        /// FK_Order_Details_Products_BackReference
        /// </summary>
        [Association(ThisKey="ProductID", OtherKey="ProductID", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// FK_Products_Suppliers
        /// </summary>
        [Association(ThisKey="SupplierID", OtherKey="SupplierID", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Products_Suppliers", BackReferenceName="Products")]
        public Supplier Supplier { get; set; }

        #endregion
    }
}