using System;
using System.Collections.Generic;
using LinqToDB;
using LinqToDB.Data;

namespace FunctionalDatabase.Server.Data
{
    public static class AppStoredProcedures
    {
		#region CustOrderHist

		public static IEnumerable<CustOrderHistResult> CustOrderHist(this AppDataConnection dataConnection, string customerId)
		{
			return dataConnection.QueryProc<CustOrderHistResult>("[dbo].[CustOrderHist]",
				new DataParameter("@CustomerID", customerId, DataType.NChar));
		}

		public class CustOrderHistResult
		{
			public string ProductName { get; set; }
			public int?   Total       { get; set; }
		}

		#endregion

		#region CustOrdersDetail

		public static IEnumerable<CustOrdersDetailResult> CustOrdersDetail(this AppDataConnection dataConnection, int? orderId)
		{
			return dataConnection.QueryProc<CustOrdersDetailResult>("[dbo].[CustOrdersDetail]",
				new DataParameter("@OrderID", orderId, DataType.Int32));
		}

		public class CustOrdersDetailResult
		{
			public string   ProductName   { get; set; }
			public decimal  UnitPrice     { get; set; }
			public short    Quantity      { get; set; }
			public int?     Discount      { get; set; }
			public decimal? ExtendedPrice { get; set; }
		}

		#endregion

		#region CustOrdersOrders

		public static IEnumerable<CustOrdersOrdersResult> CustOrdersOrders(this AppDataConnection dataConnection, string customerId)
		{
			return dataConnection.QueryProc<CustOrdersOrdersResult>("[dbo].[CustOrdersOrders]",
				new DataParameter("@CustomerID", customerId, DataType.NChar));
		}

		public class CustOrdersOrdersResult
		{
			public int       OrderId      { get; set; }
			public DateTime? OrderDate    { get; set; }
			public DateTime? RequiredDate { get; set; }
			public DateTime? ShippedDate  { get; set; }
		}

		#endregion

		#region EmployeeSalesByCountry

		public static IEnumerable<EmployeeSalesByCountryResult> EmployeeSalesByCountry(this AppDataConnection dataConnection, DateTime? beginningDate, DateTime? endingDate) =>
            dataConnection.QueryProc<EmployeeSalesByCountryResult>("[dbo].[Employee Sales by Country]",
                new DataParameter("@Beginning_Date", beginningDate, DataType.DateTime),
                new DataParameter("@Ending_Date",    endingDate,    DataType.DateTime));

        public class EmployeeSalesByCountryResult
		{
			public string    Country     { get; set; }
			public string    LastName    { get; set; }
			public string    FirstName   { get; set; }
			public DateTime? ShippedDate { get; set; }
			public int       OrderId     { get; set; }
			public decimal?  SaleAmount  { get; set; }
		}

		#endregion

		#region SalesByYear

		public static IEnumerable<SalesByYearResult> SalesByYear(this AppDataConnection dataConnection, DateTime? beginningDate, DateTime? endingDate) =>
            dataConnection.QueryProc<SalesByYearResult>("[dbo].[Sales by Year]",
                new DataParameter("@Beginning_Date", beginningDate, DataType.DateTime),
                new DataParameter("@Ending_Date",    endingDate,    DataType.DateTime));

        public class SalesByYearResult
		{
			public DateTime? ShippedDate { get; set; }
			public int       OrderId     { get; set; }
			public decimal?  Subtotal    { get; set; }
			public string    Year        { get; set; }
		}

		#endregion

		#region SalesByCategory

		public static IEnumerable<SalesByCategoryResult> SalesByCategory(this AppDataConnection dataConnection, string categoryName, string ordYear) =>
            dataConnection.QueryProc<SalesByCategoryResult>("[dbo].[SalesByCategory]",
                new DataParameter("@CategoryName", categoryName, DataType.NVarChar),
                new DataParameter("@OrdYear",      ordYear,      DataType.NVarChar));

        public class SalesByCategoryResult
		{
			public string   ProductName   { get; set; }
			public decimal? TotalPurchase { get; set; }
		}

		#endregion

		#region TenMostExpensiveProducts

		public static IEnumerable<TenMostExpensiveProductsResult> TenMostExpensiveProducts(this AppDataConnection dataConnection) => dataConnection.QueryProc<TenMostExpensiveProductsResult>("[dbo].[Ten Most Expensive Products]");

        public class TenMostExpensiveProductsResult
		{
			public string   TenMostExpensiveProducts { get; set; }
			public decimal? UnitPrice                { get; set; }
		}

		#endregion
	}
}