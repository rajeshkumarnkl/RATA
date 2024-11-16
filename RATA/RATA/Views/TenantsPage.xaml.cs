using RATA.ViewModel;

namespace RATA.Views;

public partial class TenantsPage : ContentPage
{
	public TenantsPage(TenantsViewModel tenantsViewModel)
	{
		InitializeComponent();
		BindingContext = tenantsViewModel;
	}
}