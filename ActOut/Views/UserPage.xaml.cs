using System;
using System.Collections.ObjectModel;
using ActOut.Models;
using ActOut.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage
    {
        private ObservableCollection<HistoriaColor> _userList = new ObservableCollection<HistoriaColor>();

        private enum SearchType { All = 1, User, Title, Text, Date }

        readonly DataBase _dataBase = new DataBase();

        private int _searchTypeSelected = 1;
        private readonly SearchService _searchService = new SearchService();

        private readonly User _user;

        public UserPage(User user)
        {
            InitializeComponent();

            _user = user;
            Title = _user.Username;

            EntryEstado.Text = _user.EstadoActual;

            Lista.ItemsSource = _userList;
            Update();
        }

        //Obtiene la base de datos y lo guarda en _userList
        private async void Update()
        {
            _userList.Clear();
            _userList = await _searchService.Update(_user);
            LabelEmptyList.IsVisible = _userList.Count == 0;

            Lista.ItemsSource = _userList;
        }

        //Accede a la historia seleccionada
        private async void Lista_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new MorePage(
                (HistoriaColor)e.SelectedItem));
        }

        //Botón actualizar
        private void Update_OnClicked(object sender, EventArgs e)
        {
            Update();
        }


        //Cambiar modo de busqueda

        #region ChangeSearchMode

        private void ChangeSearchAll(object sender, EventArgs e)
        {
            _searchTypeSelected = (int)SearchType.All;

            BtnAll.TextColor = Color.FromHex("#FAFAFA");
            BtnTitle.TextColor = Color.FromHex("#C0C0C0");
            BtnText.TextColor = Color.FromHex("#C0C0C0");
            BtnDate.TextColor = Color.FromHex("#C0C0C0");

            SearchBar.IsVisible = true;
            DatePicker.IsVisible = false;

            Search(null, null);
        }

        private void ChangeSearchTitle(object sender, EventArgs e)
        {
            _searchTypeSelected = (int)SearchType.Title;

            BtnAll.TextColor = Color.FromHex("#C0C0C0");
            BtnTitle.TextColor = Color.FromHex("FAFAFA");
            BtnText.TextColor = Color.FromHex("#C0C0C0");
            BtnDate.TextColor = Color.FromHex("#C0C0C0");

            SearchBar.IsVisible = true;
            DatePicker.IsVisible = false;

            Search(null, null);
        }

        private void ChangeSearchText(object sender, EventArgs e)
        {
            _searchTypeSelected = (int)SearchType.Text;

            BtnAll.TextColor = Color.FromHex("#C0C0C0");
            BtnTitle.TextColor = Color.FromHex("#C0C0C0");
            BtnText.TextColor = Color.FromHex("FAFAFA");
            BtnDate.TextColor = Color.FromHex("#C0C0C0");

            SearchBar.IsVisible = true;
            DatePicker.IsVisible = false;

            Search(null, null);
        }

        private void ChangeSearchDate(object sender, EventArgs e)
        {
            _searchTypeSelected = (int)SearchType.Date;

            BtnAll.TextColor = Color.FromHex("#C0C0C0");
            BtnTitle.TextColor = Color.FromHex("#C0C0C0");
            BtnText.TextColor = Color.FromHex("#C0C0C0");
            BtnDate.TextColor = Color.FromHex("FAFAFA");

            SearchBar.Text = string.Empty;

            SearchBar.IsVisible = false;
            DatePicker.IsVisible = true;
        }

        #endregion


        private void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            Search(null, null);
        }

        //Añade una nueva historia
        private async void AddItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage(_user));
        }

        //Filtra cada vez que se modifique el parametro de busqueda
        private void Search(object sender, TextChangedEventArgs e)
        {
            _userList = _searchService.Filtrar(_user, _searchTypeSelected, SearchBar.Text, DatePicker);

            Lista.ItemsSource = _userList;
        }

        //Muestra o oculta la barra de busqueda
        private async void Search_OnClicked(object sender, EventArgs e)
        {
            if (!SearchPanel.IsVisible)
            {
                SearchPanel.IsVisible = true;
                MisHistorias.IsVisible = false;
                Panel.TranslationY = 0;

                //Solo hay un await para que se hagan las tres animaciones a la vez
                SearchPanel.TranslateTo(0, 20, 300, Easing.Linear);
                Panel.TranslateTo(0, 10, 300, Easing.Linear);
                await SearchPanel.FadeTo(100, 300, Easing.Linear);
            }

            else
            {
                SearchBar.Text = string.Empty;

                SearchPanel.Opacity = 0;
                SearchPanel.IsVisible = false;
                MisHistorias.IsVisible = true;
            }
        }

        //Cambia el estado del usuario al pulsar Enter
        private async void EstadoCompleted(object sender, EventArgs e)
        {
            _user.EstadoActual = EntryEstado.Text;

            await _dataBase.UpdateUser(_user);
        }
    }

}
