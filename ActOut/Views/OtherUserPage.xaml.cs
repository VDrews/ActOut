using ActOut.Services;
using System;
using System.Collections.ObjectModel;
using ActOut.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtherUserPage
    {
        private ObservableCollection<HistoriaColor> _userList = new ObservableCollection<HistoriaColor>();

        enum SearchType { All = 1, User, Title, Text, Date }

        private int _searchTypeSelected = 1;

        private readonly User _user;
        readonly SearchService _searchService = new SearchService();


        public OtherUserPage(User user)
        {
            InitializeComponent();

            _user = user;
            Title = "Perfil de " + _user.Username;

            Update();
            Lista.ItemsSource = _userList;

        }

        //Actualiza la base de datos
        private async void Update()
        {
            _userList.Clear();
            _userList = await _searchService.Update(_user);
            LabelEmptyList.IsVisible = _userList.Count == 0;

            Lista.ItemsSource = _userList;
        }

        //Elemento Seleccionado
        private async void Lista_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ItemVisualizerPage((HistoriaColor)e.SelectedItem));
        }

        //Botón Actualizar
        private void Update_OnClicked(object sender, EventArgs e)
        {
            Update();
        }

        //Cambia el modo de Busqueda

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

        //Llama el método buscar cada vez que se escriba
        private void Search(object sender, TextChangedEventArgs e)
        {
            _userList = _searchService.Filtrar(_user, _searchTypeSelected, SearchBar.Text, DatePicker);

            Lista.ItemsSource = _userList;
        }

        //Muestra o Oculta la barra de busqueda
        private async void Search_OnClicked(object sender, EventArgs e)
        {
            if (!SearchPanel.IsVisible)
            {
                SearchPanel.IsVisible = true;
                MisHistorias.IsVisible = false;
                Panel.TranslationY = 0;

                //Solo hay await al final para que hagan las tres animaciones simultaneamente
                SearchPanel.TranslateTo(0, 10, 300, Easing.Linear);
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
    }

}
