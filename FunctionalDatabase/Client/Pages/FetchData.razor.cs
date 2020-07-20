using FunctionalDatabase.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FunctionalDatabase.Client.Pages
{
    public partial class FetchData
    {
        public bool NoData => !Products.Any();

        public List<Product> Products { get; set; } = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            Products = await Http.GetFromJsonAsync<List<Product>>("api/Product");
        }
    }
}
