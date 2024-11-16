using RATA.Views;

namespace RATA
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TenantsPage), typeof(TenantsPage));
        }
    }
}
