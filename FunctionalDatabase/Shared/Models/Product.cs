using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Shared.Models
{
    [Table(Schema="dbo", Name="Products")]
    public partial class Product
    {
        [PrimaryKey, Identity   ][Column(Name ="ProductID")] public int      ProductId       { get; set; } // int
        [Column,     NotNull    ] public string   ProductName     { get; set; } // nvarchar(40)
        [Column(Name ="SupplierId"),        Nullable] public int?     SupplierId      { get; set; } // int
        [Column(Name ="CategoryId"),        Nullable] public int?     CategoryId      { get; set; } // int
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
        [Association(ThisKey="CategoryId", OtherKey="CategoryId", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Products_Categories", BackReferenceName="Products")]
        public Category Category { get; set; }

        /// <summary>
        /// FK_Order_Details_Products_BackReference
        /// </summary>
        [Association(ThisKey="ProductId", OtherKey="ProductId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        /// <summary>
        /// FK_Products_Suppliers
        /// </summary>
        [Association(ThisKey="SupplierId", OtherKey="SupplierId", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Products_Suppliers", BackReferenceName="Products")]
        public Supplier Supplier { get; set; }

        #endregion
    }
}