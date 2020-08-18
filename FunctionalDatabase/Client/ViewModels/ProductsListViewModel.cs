using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ProductsListViewModel(TryAsync<List<Product>> productsFetcher = null)
        {
            productsFetcher ??= ApiFunctions.TryGetProducts();
            ProductsFunction = productsFetcher;

            ProductLoader = ReactiveCommand.CreateFromTask(LoadProductsAsync);
            _products = ProductLoader.ToProperty(this, x => x.Products, scheduler: RxApp.MainThreadScheduler);
        }

        private readonly TryAsync<List<Product>> ProductsFunction;

        private static async Task<List<Product>> LoadProductsAsync()
            => (await ApiFunctions.GetProductsAsync()).ToList();
    }
}