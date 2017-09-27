using ActOut.Services;
using System;
using ActOut.Interfaces;
using ActOut.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TypePage
    {
        private enum Types { Bullying = 1, Genero, Homofobia, Racismo, Agresion, Sexual, Perdidas, Alcoholismo, Drogadiccion, Otros }

        private readonly DataBase _dataBase = new DataBase();
        private int _select;

        private readonly string _username;
        private readonly string _password;

        public TypePage(string username, string password)
        {
            InitializeComponent();

            _username = username;
            _password = password;
        }

        //Selecciona un determinado botón
        #region Switch
        private void BtnBullying_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Accent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Bullying;
        }

        private void BtnGenero_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Accent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Genero;
        }

        private void BtnHomofobia_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Accent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Homofobia;
        }

        private void BtnRacismo_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Accent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Racismo;
        }

        private void BtnAgresion_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Accent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Agresion;
        }

        private void BtnSexual_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Accent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Sexual;
        }

        private void BtnPerdidas_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Accent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Perdidas;
        }

        private void BtnAlcoholismo_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Accent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Alcoholismo;
        }

        private void BtnDrogadicion_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Accent;
            BtnOtros.BackgroundColor = Color.Transparent;

            _select = (int)Types.Drogadiccion;
        }

        private void BtnOtros_OnClicked(object sender, EventArgs e)
        {
            BtnBullying.BackgroundColor = Color.Transparent;
            BtnGenero.BackgroundColor = Color.Transparent;
            BtnHomofobia.BackgroundColor = Color.Transparent;
            BtnRacismo.BackgroundColor = Color.Transparent;
            BtnAgresion.BackgroundColor = Color.Transparent;
            BtnSexual.BackgroundColor = Color.Transparent;
            BtnPerdidas.BackgroundColor = Color.Transparent;
            BtnAlcoholismo.BackgroundColor = Color.Transparent;
            BtnDrogadicion.BackgroundColor = Color.Transparent;
            BtnOtros.BackgroundColor = Color.Accent;

            _select = (int)Types.Otros;
        }


        #endregion

        //Boton continuar
        private async void Btn_Next(object sender, EventArgs e)
        {
            if (_select == 0)
            {
                await DisplayAlert("Error de Selección", "No se ha escogido ninguna opción", "Aceptar");
            }

            else
            {
                var confirm = await DisplayAlert("Crear Cuenta", "¿Esta seguro de su elección?", "Aceptar", "Cancelar");

                if (!confirm) return;

                //Crea el nuevo usuario
                var usuarioNuevo = new User
                {
                    Username = _username,
                    Password = _password,
                    EstadoActual = "Empezando en ActOut!",
                    Type = _select
                };

                try
                {
                    await _dataBase.AddUser(usuarioNuevo);
                }
                catch (Exception)
                {
                    await DisplayAlert("Error de Conexion", "No se puede conectar al servidor", "Aceptar");
                }

                //Guarda el usuario para acceder rapidamente con Windows Hello
                _dataBase.UpdateUserCache(usuarioNuevo);

                await Navigation.PushModalAsync(new TabbedPage
                {
                    BackgroundColor = Color.FromHex("#2370B8"),

                    Children =
                    {
                        new NavigationPage(new MainPage(usuarioNuevo))
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

        }
    }

}
