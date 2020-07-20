using LinqToDB.Mapping;

namespace FunctionalDatabase.Shared.Models
{
    [Table(Schema="dbo", Name="Order Details")]
    public partial class OrderDetail
    {
        [PrimaryKey(1), NotNull] public int     OrderId   { get; set; } // int
        [PrimaryKey(2), NotNull] public int     ProductId { get; set; } // int
        [Column,        NotNull] public decimal UnitPrice { get; set; } // money
        [Column,        NotNull] public short   Quantity  { get; set; } // smallint
        [Column,        NotNull] public float   Discount  { get; set; } // real

        #region Associations

        /// <summary>
        /// FK_Order_Details_Orders
        /// </summary>
        [Association(ThisKey="OrderID", OtherKey="OrderID", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Order_Details_Orders", BackReferenceName="OrderDetails")]
        public Order Order { get; set; }

        /// <summary>
        /// FK_Order_Details_Products
        /// </summary>
        [Association(ThisKey="ProductId", OtherKey="ProductId", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="FK_Order_Details_Products", BackReferenceName="OrderDetails")]
        public Product Product { get; set; }

        #endregion
    }
}