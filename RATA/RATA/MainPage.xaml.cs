using RATA.ViewModel;

namespace RATA
{
    public partial class MainPage : ContentPage
    { 
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }
         
    }

}
