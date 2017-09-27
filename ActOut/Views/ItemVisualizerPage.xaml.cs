using ActOut.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ActOut.Interfaces;
using ActOut.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemVisualizerPage
    {
        ObservableCollection<User> _userList = new ObservableCollection<User>();

        readonly DataBase _dataBase = new DataBase();
        private readonly Historia _param;

        public ItemVisualizerPage(HistoriaColor param)
        {
            InitializeComponent();

            UserBox.GestureRecognizers.Add(new TapGestureRecognizer(OnGoUser));

            _param = param.GetHistoria();

            //Actualiza el numero de visitas
            _param.Visitas++;
            Actualizar();


            Panel.BackgroundColor = param.Color;
            LabelUser.Text = _param.User;
            LabelTitle.Text = _param.Title.ToUpper();

            //Para ajustar el texto en pantalla
            if (LabelTitle.Text.Length >= 20)
                HeightBox.HeightRequest = 400;

            LabelText.Text = _param.Text + "\n\n\n\n\n\n\n\n\n\n";


        }

        private async Task Actualizar()
        {
            await _dataBase.UpdateHistoria(_param);
        }

        private async void OnGoUser(View arg1, object arg2)
        {
            await Navigation.PushAsync(new OtherUserPage(await BuscarUsuario(_param.User)));
        }

        //Devuelve el usuario a partir de su nombre de usuario
        private async Task<User> BuscarUsuario(string username)
        {
            _userList = await _dataBase.GetUsers();
            return _userList.FirstOrDefault(user => user.Username == username);
        }

        //Muestra el texto por voz
        private void TextToSpeechBtn_OnClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ITextToSpeech>().Speak(LabelText.Text);
        }

    }

}