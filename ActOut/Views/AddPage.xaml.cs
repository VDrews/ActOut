using System;
using ActOut.Interfaces;
using ActOut.Models;
using ActOut.Services;
using ComputerVisionApplication.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage
    {
        private readonly User _user;

        //Enumeracion de los colores para el modelo Historias
        private enum Colors { Red = 1, Green, Blue, Yellow, Purple, Gray }

        readonly DataBase _dataBase = new DataBase();

        private int _colorSelected = (int)Colors.Blue;

        public AddPage(User user)
        {
            InitializeComponent();

            _user = user;

            #region GestureRecognizers

            PickerRed.GestureRecognizers.Add(new TapGestureRecognizer(PickRed));
            PickerGreen.GestureRecognizers.Add(new TapGestureRecognizer(PickGreen));
            PickerBlue.GestureRecognizers.Add(new TapGestureRecognizer(PickBlue));
            PickerYellow.GestureRecognizers.Add(new TapGestureRecognizer(PickYellow));
            PickerPurple.GestureRecognizers.Add(new TapGestureRecognizer(PickPurple));
            PickerGray.GestureRecognizers.Add(new TapGestureRecognizer(PickGray));
            SpeechBtn.GestureRecognizers.Add(new TapGestureRecognizer(Speech));

            #endregion

        }

        private async void Speech(View view)
        {
            //Metodo para Reconocer el texto por voz mediante un servicio de UWP
            var texto = await DependencyService.Get<ISpeechRecognizer>().RecordSpeechFromMicrophoneAsync();
            if (!string.IsNullOrEmpty(texto))
                texto = texto.Substring(0, 1).ToUpper() + texto.Substring(1) + ".";
            EntryTexto.Text = texto;
        }

        #region ColorPicker

        private void PickGray(View arg1, object arg2)
        {
            EntryTitulo.BackgroundColor = Color.FromHex("#717171");
            AddButton.BackgroundColor = Color.FromHex("#717171");
            _colorSelected = (int)Colors.Gray;
        }

        private void PickPurple(View arg1, object arg2)
        {
            EntryTitulo.BackgroundColor = Color.FromHex("#7615D8");
            AddButton.BackgroundColor = Color.FromHex("#7615D8");
            _colorSelected = (int)Colors.Purple;

        }

        private void PickYellow(View arg1, object arg2)
        {
            EntryTitulo.BackgroundColor = Color.FromHex("#D6CB2E");
            AddButton.BackgroundColor = Color.FromHex("#D6CB2E");
            _colorSelected = (int)Colors.Yellow;

        }

        private void PickBlue(View arg1, object arg2)
        {
            EntryTitulo.BackgroundColor = Color.FromHex("#2196F3");
            AddButton.BackgroundColor = Color.FromHex("#2196F3");
            _colorSelected = (int)Colors.Blue;

        }

        private void PickGreen(View arg1, object arg2)
        {
            EntryTitulo.BackgroundColor = Color.FromHex("#0ABE22");
            AddButton.BackgroundColor = Color.FromHex("#0ABE22");
            _colorSelected = (int)Colors.Green;
        }

        private void PickRed(View arg1, object arg2)
        {
            EntryTitulo.BackgroundColor = Color.FromHex("#C1272D");
            AddButton.BackgroundColor = Color.FromHex("#C1272D");
            _colorSelected = (int)Colors.Red;
        }

        #endregion

        //Boton para publicar
        private async void Button_OnClicked(object sender, EventArgs e)
        {
            //Creamos un indicador de actividad y bloqueamos el botón para evitar que vuelva a pulsarse mientras se manda a Azure
            ActivityIndicator.IsRunning = ActivityIndicator.IsVisible = true;
            AddButton.IsEnabled = false;

            //Si uno de los campos esta vacio...
            if (string.IsNullOrEmpty(EntryTitulo.Text) || string.IsNullOrEmpty(EntryTexto.Text))
            {
                await DisplayAlert("Error de publicación", "Ni el título ni el texto pueden estar vacíos", "Aceptar");
            }

            else
            {
                //Analizamos el texto con los Cognitive Service
                var textAnalized = new TextAnalyticsService("8aa012ee91104dd985c520783b00be1d");
                var sentimentResult = new SentimentResult();

                try
                {
                    //Si no conecta al API, no hay conexión a la red
                    sentimentResult = await textAnalized.DetectSentimentFromTextAsync(EntryTexto.Text);
                }
                catch (Exception)
                {
                    await DisplayAlert("Error de publicación", "No hay conexión a la red", "Aceptar");
                    await Navigation.PopAsync();
                }

                var newHistoria = new Historia()
                {
                    Title = EntryTitulo.Text,
                    Text = EntryTexto.Text,
                    User = _user.Username,
                    Type = _user.Type,
                    Estado = _user.EstadoActual,
                    Sentimiento = sentimentResult.Documents[0].Score,
                    Visitas = 0,
                    Color = _colorSelected,
                    Date = DateTime.Now
                };


                try
                {
                    await _dataBase.AddHistoria(newHistoria);
                }
                catch (Exception)
                {
                    await DisplayAlert("Error de Conexion", "No se puede conectar al servidor", "Aceptar");
                }

                await Navigation.PopAsync();
            }

        }

    }

}
