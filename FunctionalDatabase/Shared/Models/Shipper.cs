using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Shared.Models
{
    [Table(Schema="dbo", Name="Shippers")]
    public partial class Shipper
    {
        [PrimaryKey, Identity   ] public int    ShipperId   { get; set; } // int
        [Column,     NotNull    ] public string CompanyName { get; set; } // nvarchar(40)
        [Column,        Nullable] public string Phone       { get; set; } // nvarchar(24)

        #region Associations

        /// <summary>
        /// FK_Orders_Shippers_BackReference
        /// </summary>
        [Association(ThisKey="ShipperID", OtherKey="ShipVia", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
        public IEnumerable<Order> Orders { get; set; }

        #endregion
    }
}