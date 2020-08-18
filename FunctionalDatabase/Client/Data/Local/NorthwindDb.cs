using DnetIndexedDb;
using Microsoft.JSInterop;

namespace FunctionalDatabase.Client.Data.Local
{
    public class NorthwindDb : IndexedDbInterop
    {
        public NorthwindDb(IJSRuntime jsRuntime, IndexedDbOptions options)
            :base(jsRuntime, options)
        { }
    }
}