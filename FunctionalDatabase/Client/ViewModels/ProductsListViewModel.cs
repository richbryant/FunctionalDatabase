using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionalDatabase.Client.Data.Remote;
using FunctionalDatabase.Shared.Models;
using ReactiveUI;
using RxUnit = System.Reactive.Unit;

namespace FunctionalDatabase.Client.ViewModels
{
    public class ProductsListViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<List<Product>> _products;
        public List<Product> Products => _products.Value;

        public ReactiveCommand<RxUnit, List<Product>> ProductLoader { get; }

        public ProductsListViewModel(Func<Task<List<Product>>> productsFetcher = null)
        {
            productsFetcher ??= ApiFunctions.GetProductsAsync;

            ProductLoader = ReactiveCommand.CreateFromTask(productsFetcher);
            _products = ProductLoader.ToProperty(this, x => x.Products, scheduler: RxApp.MainThreadScheduler);
        }
    }
}