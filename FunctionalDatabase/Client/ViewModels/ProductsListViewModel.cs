using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionalDatabase.Client.Data.Local;
using FunctionalDatabase.Client.Data.Remote;
using FunctionalDatabase.Shared.Models;
using LanguageExt;
using ReactiveUI;
using RxUnit = System.Reactive.Unit;

namespace FunctionalDatabase.Client.ViewModels
{
    public class ProductsListViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<List<Product>> _products;
        public List<Product> Products => _products.Value;

        public ReactiveCommand<RxUnit, List<Product>> ProductLoader { get; }

        public ProductsListViewModel(IProductsService productsService, TryAsync<List<Product>> productsFetcher = null)
        {
            _productsService = productsService;
            productsFetcher ??= ApiFunctions.TryGetProducts();
            
            ProductsFunction = productsFetcher;

            ProductLoader = ReactiveCommand.CreateFromTask(LoadProductsToListAsync);
            _products = ProductLoader.ToProperty(this, x => x.Products, scheduler: RxApp.MainThreadScheduler);
        }

        private readonly IProductsService _productsService;
        private readonly TryAsync<List<Product>> ProductsFunction;

        private async Task<List<Product>> CheckLocalAsync()
            => await _productsService.GetProductsAsync();

        private async Task StashLocalAsync(List<Product> products)
            => await _productsService.LoadProductsAsync(products);

        private async Task<List<Product>> LoadProductsToListAsync()
        {
            var local = await CheckLocalAsync();
            if (local.Any()) return local;
            local = await LoadProductsFromApiAsync();
            await StashLocalAsync(local);
            return local;
        }

        private async Task<List<Product>> LoadProductsFromApiAsync()
        {
            var result = new List<Product>();
            await ProductsFunction.Match(
                Succ: x => result = x,
                Fail: x => Console.WriteLine(x.Message));
            return result;
        }
    }
}