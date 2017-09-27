using ActOut.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ActOut.Interfaces;
using ActOut.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage
    {
        private bool _access;
        private User _accessUser;
        private readonly DataBase _dataBase = new DataBase();
        private ObservableCollection<User> _userList = new ObservableCollection<User>();

        public LoginPage()
        {
            InitializeComponent();
            Inicialize();
        }

        private async Task Inicialize()
        {
            //await _dataBase.ResubirAzure();
            _userList = await _dataBase.GetUsers();

            //Obtiene la base de datos de usuarios e inicia Windows Hello
            ShowCredentials();
        }

        private async void ShowCredentials()
        {
            //Utilizamos Windows Hello para rellenar los datos del ultimo usuario utilizado para iniciar sesión
            //Asi evitamos que nadie pueda ver la contraseña del usuario y acceder mas rapidamente

            if (_dataBase.LastUserExist())
            {
                LastUser UserCache = _dataBase.GetUserCache();
                if (await DependencyService.Get<IWindowsHello>().GetPassportAuthenticationMessageAsync(UserCache))
                {
                    EntryUser.Text = UserCache.Username;
                    EntryPass.Text = UserCache.Password;
                }
            }
        }

        //Boton iniciar sesion
        private async void Login_OnClicked(object sender, EventArgs e)
        {

            //Busca si existe el Usuario y si la contraseña es correcta
            foreach (var item in _userList)
            {
                if (item.Username != EntryUser.Text || item.Password != EntryPass.Text) continue;
                _access = true;
                _accessUser = item;
                break;
            }

            //Si existe el usuario y coincide accede al mainpage
            if (_access)
            {
                _dataBase.UpdateUserCache(_accessUser);
                await Navigation.PushModalAsync(new TabbedPage
                {
                    BackgroundColor = Color.FromHex("#2370B8"),

                    Children =
                    {
                        new NavigationPage(new MainPage(_accessUser))
                        {
                            Title = "Historias",
                        },
                        new NavigationPage(new AboutPage())
                        {
                            Title = "Acerca de",
                        }
                    }
                });
            }

            // Si no coincide Muestra una alerta
            else
            {
                await DisplayAlert("Error de Acceso", "El nombre de usuario o la contraseña no es correcta", "Aceptar");
            }

        }

        private async void CreateAccount_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateAccountPage());
        }
    }

}
