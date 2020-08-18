using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using FunctionalDatabase.Client.ViewModels;

namespace FunctionalDatabase.Client.Views
{
    public partial class ProductsView
    {
        public ProductsView()
        {
            ViewModel = new ProductsListViewModel();
        }

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.ProductLoader.Execute().ToTask();
        }
    }
}
