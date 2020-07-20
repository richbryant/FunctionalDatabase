using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FunctionalDatabase.Client.Data.Local;
using DnetIndexedDb;
using FunctionalDatabase.Client.Data.Remote;
using Refit;

namespace FunctionalDatabase.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddIndexedDbDatabase<ProductsDb>(o => o.UseDatabase(DataModel.GetDataModel()));

            builder.Services.AddRefitClient<IProductsApi>(new RefitSettings{ContentSerializer = new Utility.JsonContentSerializer()})
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:44352/api"));
            
            builder.Services.AddTransient<IProductsDataService, ProductsDataService>();

            await builder.Build().RunAsync();
        }
    }
}
