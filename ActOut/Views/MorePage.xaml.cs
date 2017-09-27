using ActOut.Services;
using System;
using ActOut.Models;
using Xamarin.Forms.Xaml;

namespace ActOut.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MorePage
    {

        private readonly Historia _historiaActual;
        readonly DataBase _dataBase = new DataBase();

        public MorePage(HistoriaColor param)
        {
            InitializeComponent();

            _historiaActual = param.GetHistoria();

            LabelVisitas.Text = param.Visitas.ToString();
            LabelTitle.Text = param.Title.ToUpper();

            //Ajusta el texto en pantalla
            if (LabelTitle.Text.Length >= 20)
                HeightBox.HeightRequest = 400;

            Panel.BackgroundColor = param.Color;
            LabelText.Text = param.Text;

            LabelText.Text = param.Text + "\n\n\n\n\n\n\n\n\n\n";

        }

        //Borrar Elemento
        private async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var confirmacion = await DisplayAlert("Eliminar Nota", "¿Desea eliminar la siguiente nota?", "Aceptar", "Cancelar");

            if (!confirmacion) return;

            try
            {
                await _dataBase.DeleteHistoria(_historiaActual);
            }
            catch (Exception)
            {
                await DisplayAlert("Error de Conexion", "No se puede conectar al servidor", "Aceptar");
            }
            await Navigation.PopAsync();
        }
    }

}
