using FunctionalDatabase.Client.Data.Remote;
using FunctionalDatabase.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System;

namespace FunctionalDatabase.Client.Pages
{
    public partial class FetchData
    {
        [Inject]
        private IProductsDataService ProductsDataService { get; set; }
        public bool NoData => !Products.Any();

        public List<Product> Products { get; set; } = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            await ProductsDataService.TryGetAllAsync().Match(
                Succ: x => Products.AddRange(x),
                Fail: x => Console.WriteLine(x.Message));
        }
    }
}
