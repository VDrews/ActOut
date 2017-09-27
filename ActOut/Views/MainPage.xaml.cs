using ActOut.Services;
using System;
using System.Collections.ObjectModel;
using ActOut.Interfaces;
using ActOut.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        private enum SearchType { All = 1, User, Title, Text, Date }

        private int _searchTypeSelected = 1;

        private ObservableCollection<HistoriaColor> _listaHistorias = new ObservableCollection<HistoriaColor>();
        private readonly SearchService _searchService = new SearchService();

        private readonly User _user;

        public MainPage(User user)
        {
            InitializeComponent();


            _user = user;
            ToolbarItem.Text = _user.Username;

            Update();
        }

        private async void Update()
        {
            //Actualizamos la lista
            _listaHistorias.Clear();
            _listaHistorias = await _searchService.Filtrar_por_Tipo(_user.Type);

            Lista.ItemsSource = _listaHistorias;
        }

        //Perfil del Usuario
        private async void OnGoUser_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPage(_user));
        }

        //Boton Actualizar
        private void Update_OnClicked(object sender, EventArgs e)
        {
            Update();
        }

        //Lleva al elemento seleccionado
        private async void Lista_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ItemVisualizerPage(
                (HistoriaColor)e.SelectedItem));
        }

        //Añadir Pagina
        private async void AddItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage(_user));
        }

        //Buscar según el modo de busqueda indicado
        private void Search(object sender, TextChangedEventArgs e)
        {

            _listaHistorias = _searchService.Filtrar(_user.Type, _searchTypeSelected, SearchBar.Text, DatePicker);

            Lista.ItemsSource = _listaHistorias;
        }

        //Cambia el modo de busqueda

        #region ChangeSearchMode

        private void ChangeSearchAll(object sender, EventArgs e)
        {
            _searchTypeSelected = (int)SearchType.All;

            BtnAll.TextColor = Color.FromHex("#FAFAFA");
            BtnUser.TextColor = Color.FromHex("#C0C0C0");
            BtnTitle.TextColor = Color.FromHex("#C0C0C0");
            BtnText.TextColor = Color.FromHex("#C0C0C0");
            BtnDate.TextColor = Color.FromHex("#C0C0C0");

            SearchBar.IsVisible = true;
            DatePicker.IsVisible = false;

            Search(null, null);
        }

        private void ChangeSearchUser(object sender, EventArgs e)
        {
            _searchTypeSelected = (int)SearchType.User;

            BtnAll.TextColor = Color.FromHex("#C0C0C0");
            BtnUser.TextColor = Color.FromHex("FAFAFA");
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
            BtnUser.TextColor = Color.FromHex("#C0C0C0");
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
            BtnUser.TextColor = Color.FromHex("#C0C0C0");
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
            BtnUser.TextColor = Color.FromHex("#C0C0C0");
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

        //Muestra o oculta la barra de busqueda
        private async void Search_OnClicked(object sender, EventArgs e)
        {

            if (!SearchPanel.IsVisible)
            {
                SearchPanel.IsVisible = true;
                Panel.TranslationY = 0;

                // Solo hay await al final para hacer simultaneamente las tres animaciones
                SearchPanel.TranslateTo(0, 20, 300, Easing.Linear);
                Panel.TranslateTo(0, 10, 300, Easing.Linear);
                await SearchPanel.FadeTo(100, 300, Easing.Linear);
            }

            else
            {
                SearchBar.Text = string.Empty;
                SearchPanel.Opacity = 0;
                SearchPanel.IsVisible = false;
            }
        }

        private void Sketch_OnClicked(object sender, EventArgs e)
        {
            DependencyService.Get<IWindowsInk>().OpenSketchWindow();
        }
    }

}
