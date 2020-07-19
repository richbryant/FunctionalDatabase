using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Server.Data.Models
{
    [Table(Schema="dbo", Name="Suppliers")]
    public partial class Supplier
    {
        [PrimaryKey, Identity   ] public int    SupplierID   { get; set; } // int
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
        [Column,        Nullable] public string HomePage     { get; set; } // ntext

        #region Associations

        /// <summary>
        /// FK_Products_Suppliers_BackReference
        /// </summary>
        [Association(ThisKey="SupplierID", OtherKey="SupplierID", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
        public IEnumerable<Product> Products { get; set; }

        #endregion
    }
}