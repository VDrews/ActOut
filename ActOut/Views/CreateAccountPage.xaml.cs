using ActOut.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using ActOut.Models;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage
    {
        private ObservableCollection<User> _userList = new ObservableCollection<User>();
        readonly DataBase _dataBase = new DataBase();

        private bool _exist;

        public CreateAccountPage()
        {
            InitializeComponent();
            Initialize();
        }

        private async void Initialize()
        {
            //Guardamos la lista de usuarios para comprobar que no coincide el nombre de usuario
            _userList = await _dataBase.GetUsers();
        }

        //Boton Continuar
        private async void Button_OnClicked(object sender, EventArgs e)
        {

            foreach (var item in _userList)
            {
                //Si coincide con algun nombre de usuario de la base de datos
                if (item.Username == EntryUser.Text)
                {
                    await DisplayAlert("Error de Confirmacion",
                        EntryUser.Text + " ya existe como nombre de usuario", "Aceptar");

                    EntryUser.Text = string.Empty;
                    EntryPass.Text = string.Empty;
                    EntryPassConfirm.Text = string.Empty;

                    _exist = true;
                    break;
                }

                _exist = false;
            }

            //Si no coincide con ningún nombre de usuario
            if (!_exist)
            {
                //Comprobamos si la contraseña se ha introducido las dos veces correctamente
                if (EntryPass.Text == EntryPassConfirm.Text)
                {
                    //Comprobamos si la contraseña sigue las normas puestas
                    if (EvaluatePassword(EntryPass.Text))
                    {
                        await Navigation.PushModalAsync(new TypePage(EntryUser.Text, EntryPass.Text));
                    }

                    //Si no sigue las normas de la contraseña, muestra una alerta y borra los entry de las contraseñas
                    else
                    {
                        await DisplayAlert("Error de Confirmación",
                            "Las contraseñas deben tener mas de 8 caracteres y con números",
                            "Aceptar");
                        EntryPass.Text = string.Empty;
                        EntryPassConfirm.Text = string.Empty;
                    }
                }

                //Si las contraseñas no coinciden
                else
                {
                    await DisplayAlert("Error de Confirmacion", "Las contraseñas no coinciden", "Aceptar");
                    EntryPass.Text = string.Empty;
                    EntryPassConfirm.Text = string.Empty;
                }
            }

        }

        private static bool EvaluatePassword(string password)
        {
            if (password.Length >= 8)
            {
                if (TieneNumeros(password))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TieneNumeros(string param)
        {
            return param.Cast<char>().Any(letra => letra >= '1' && letra <= '9');
        }

        private async void Cancel_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }

}
