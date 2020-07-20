using DnetIndexedDb;
using Microsoft.JSInterop;

namespace FunctionalDatabase.Client.Data.Local
{
    public class ProductsDb : IndexedDbInterop
    {
        public ProductsDb(IJSRuntime jsRuntime, IndexedDbOptions<ProductsDb> options) 
            :base(jsRuntime, options)
        { }
    }
}