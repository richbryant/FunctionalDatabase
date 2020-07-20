using System;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FunctionalDatabase.Server
{
    public static class Extensions
    {
        private static IActionResult GetGenericErrorResult(Exception ex) =>
            ex is AggregateException aggregate ? GetInternalServerErrorResult(aggregate.InnerExceptions)
            : GetInternalServerErrorResult(ex);

        private static IActionResult GetGenericErrorResult<T>(T error) =>
            error is Exception ex ? GetGenericErrorResult(ex)
            : GetInternalServerErrorResult(error);

        private static IActionResult GetGenericSuccessResult<T>(T value) =>
            value is Unit ? GetNoContentResult()
            : new OkObjectResult(value);

        private static IActionResult GetInternalServerErrorResult(object value) =>
            new ObjectResult(value) { StatusCode = StatusCodes.Status500InternalServerError };

        private static IActionResult GetNoContentResult() => new NoContentResult();

        private static IActionResult GetNotFoundResult() => new NotFoundResult();

        public static IActionResult ToActionResult<T>(this Try<T> self, Func<T, IActionResult> succ = null, Func<Exception, IActionResult> fail = null) =>
            self.Match(Succ: succ ?? GetGenericSuccessResult, Fail: fail ?? GetGenericErrorResult);

        public static Task<IActionResult> ToActionResult<T>(this TryAsync<T> self, Func<T, IActionResult> succ = null, Func<Exception, IActionResult> fail = null) =>
            self.Match(Succ: succ ?? GetGenericSuccessResult, Fail: fail ?? GetGenericErrorResult);

        public static IActionResult ToActionResult<TL, TR>(this Either<TL, TR> self, Func<TR, IActionResult> right = null, Func<TL, IActionResult> left = null) =>
            self.Match(Right: right ?? GetGenericSuccessResult, Left: left ?? GetGenericErrorResult);

        public static Task<IActionResult> ToActionResult<TL, TR>(this EitherAsync<TL, TR> self, Func<TR, IActionResult> right = null, Func<TL, IActionResult> left = null) =>
            self.Match(Right: right ?? GetGenericSuccessResult, Left: left ?? GetGenericErrorResult);

        public static IActionResult ToActionResult<TA>(this Option<TA> self, Func<TA, IActionResult> some = null, Func<IActionResult> none = null) =>
            self.Match(Some: some ?? GetGenericSuccessResult, None: none ?? GetNotFoundResult);

        public static Task<IActionResult> ToActionResult<TA>(this OptionAsync<TA> self, Func<TA, IActionResult> some = null, Func<IActionResult> none = null) =>
            self.Match(Some: some ?? GetGenericSuccessResult, None: none ?? GetNotFoundResult);

        public static Category Find(this ITable<Category> table, int categoryId) =>
            table.FirstOrDefault(t =>
                t.CategoryId == categoryId);

        public static Task<Category> FindAsync(this ITable<Category> table, int categoryId) =>
            table.FirstOrDefaultAsync(t =>
                t.CategoryId == categoryId);

        public static Customer Find(this ITable<Customer> table, string customerId) =>
            table.FirstOrDefault(t =>
                t.CustomerId == customerId);

        public static Task<Customer> FindAsync(this ITable<Customer> table, string customerId) =>
            table.FirstOrDefaultAsync(t =>
                t.CustomerId == customerId);

        public static Employee Find(this ITable<Employee> table, int employeeId) =>
            table.FirstOrDefault(t =>
                t.EmployeeId == employeeId);

        public static Task<Employee> FindAsync(this ITable<Employee> table, int employeeId) =>
            table.FirstOrDefaultAsync(t =>
                t.EmployeeId == employeeId);

        public static Order Find(this ITable<Order> table, int orderId) =>
            table.FirstOrDefault(t =>
                t.OrderId == orderId);

        public static Task<Order> FindAsync(this ITable<Order> table, int orderId) =>
            table.FirstOrDefaultAsync(t =>
                t.OrderId == orderId);

        public static OrderDetail Find(this ITable<OrderDetail> table, int orderId, int productId) =>
            table.FirstOrDefault(t =>
                t.OrderId   == orderId &&
                t.ProductId == productId);

        public static Task<OrderDetail> FindAsync(this ITable<OrderDetail> table, int orderId, int productId) =>
            table.FirstOrDefaultAsync(t =>
                t.OrderId   == orderId &&
                t.ProductId == productId);

        public static Product Find(this ITable<Product> table, int productId) =>
            table.FirstOrDefault(t =>
                t.ProductId == productId);

        public static Task<Product> FindAsync(this ITable<Product> table, int productId) =>
            table.FirstOrDefaultAsync(t =>
                t.ProductId == productId);

        public static Region Find(this ITable<Region> table, int regionId) =>
            table.FirstOrDefault(t =>
                t.RegionId == regionId);

        public static Shipper Find(this ITable<Shipper> table, int shipperId) =>
            table.FirstOrDefault(t =>
                t.ShipperId == shipperId);

        public static Supplier Find(this ITable<Supplier> table, int supplierId) =>
            table.FirstOrDefault(t =>
                t.SupplierId == supplierId);

        public static Task<Supplier> FindAsync(this ITable<Supplier> table, int supplierId) =>
            table.FirstOrDefaultAsync(t => t.SupplierId == supplierId);

        public static Territory Find(this ITable<Territory> table, string territoryId) =>
            table.FirstOrDefault(t =>
                t.TerritoryId == territoryId);
    }
}