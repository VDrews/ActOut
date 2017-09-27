using Windows.UI.Xaml.Controls;
using ActOut.Views;
using ActOut.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ActOut
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new LoginPage();
        }
    }
}
