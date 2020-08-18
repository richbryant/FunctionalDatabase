using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FunctionalDatabase.Client.Data.Local;
using DnetIndexedDb;
using Flurl.Http;

namespace FunctionalDatabase.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddIndexedDbDatabase<ProductsDb>(o => o.UseDatabase(DataModel.GetDataModel()));

            FlurlHttp.Configure(settings => settings.HttpClientFactory = new BlazorHttpClientFactory());

            await builder.Build().RunAsync();
        }
    }
}
