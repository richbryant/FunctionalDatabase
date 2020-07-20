using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace FunctionalDatabase.Shared.Models
{
    [Table(Schema="dbo", Name="Orders")]
	public partial class Order
	{
		[PrimaryKey, Identity] public int       OrderId        { get; set; } // int
		[Column,     Nullable] public string    CustomerId     { get; set; } // nchar(5)
		[Column,     Nullable] public int?      EmployeeId     { get; set; } // int
		[Column,     Nullable] public DateTime? OrderDate      { get; set; } // datetime
		[Column,     Nullable] public DateTime? RequiredDate   { get; set; } // datetime
		[Column,     Nullable] public DateTime? ShippedDate    { get; set; } // datetime
		[Column,     Nullable] public int?      ShipVia        { get; set; } // int
		[Column,     Nullable] public decimal?  Freight        { get; set; } // money
		[Column,     Nullable] public string    ShipName       { get; set; } // nvarchar(40)
		[Column,     Nullable] public string    ShipAddress    { get; set; } // nvarchar(60)
		[Column,     Nullable] public string    ShipCity       { get; set; } // nvarchar(15)
		[Column,     Nullable] public string    ShipRegion     { get; set; } // nvarchar(15)
		[Column,     Nullable] public string    ShipPostalCode { get; set; } // nvarchar(10)
		[Column,     Nullable] public string    ShipCountry    { get; set; } // nvarchar(15)

		#region Associations

		/// <summary>
		/// FK_Orders_Customers
		/// </summary>
		[Association(ThisKey="CustomerID", OtherKey="CustomerID", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Orders_Customers", BackReferenceName="Orders")]
		public Customer Customer { get; set; }

		/// <summary>
		/// FK_Orders_Employees
		/// </summary>
		[Association(ThisKey="EmployeeID", OtherKey="EmployeeID", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Orders_Employees", BackReferenceName="Orders")]
		public Employee Employee { get; set; }

		/// <summary>
		/// FK_Order_Details_Orders_BackReference
		/// </summary>
		[Association(ThisKey="OrderID", OtherKey="OrderID", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<OrderDetail> OrderDetails { get; set; }

		/// <summary>
		/// FK_Orders_Shippers
		/// </summary>
		[Association(ThisKey="ShipVia", OtherKey="ShipperID", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="FK_Orders_Shippers", BackReferenceName="Orders")]
		public Shipper Shipper { get; set; }

		#endregion
	}
}