using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RATA.Views;

namespace RATA.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {

        [RelayCommand]
        async Task NavigateToRental()
        {
            await Shell.Current.GoToAsync(nameof(TenantsPage), true);
        }
    }
}
