using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace FunctionalDatabase.Client.Views
{
    public partial class ProductsView
    {
        protected override async Task OnInitializedAsync()
        {
            await ViewModel.ProductLoader.Execute().ToTask();
        }
    }
}
