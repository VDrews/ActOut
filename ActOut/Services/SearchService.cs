using ActOut.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ActOut.Services
{
    public class SearchService
    {

        private readonly DataBase _dataBase = new DataBase();
        private ObservableCollection<HistoriaColor> _historiaList = new ObservableCollection<HistoriaColor>();

        private enum SearchType
        {
            All = 1,
            User,
            Title,
            Text,
            Date
        }

        //Ordena la lista que entra por parametro segun sus visitas
        private static void OrderByVisits(ref ObservableCollection<HistoriaColor> storyList)
        {
            var sortedList = storyList.ToList();
            sortedList = sortedList.OrderByDescending(o => o.Visitas).ToList();

            storyList.Clear();

            foreach (var item in sortedList)
            {
                storyList.Add(item);
            }
        }

        //Devuelve una lista con los datos actualizados y ordenados 
        public async Task<ObservableCollection<HistoriaColor>> Update(User user)
        {
            _historiaList.Clear();
            var storyList = await _dataBase.GetHistorias();

            foreach (var item in storyList)
            {
                if (item.User == user.Username)
                {
                    _historiaList.Add(new HistoriaColor(item));
                }
            }

            OrderByVisits(ref _historiaList);

            return _historiaList;
        }

        //Obtiene la lista de la base de datos, pero solo las historias con el tema elegido
        public async Task<ObservableCollection<HistoriaColor>> Filtrar_por_Tipo(int tipo)
        {
            _historiaList.Clear();
            var storyList = await _dataBase.GetHistorias();


            foreach (var item in storyList)
            {
                if (item.Type == tipo)
                {
                    _historiaList.Add(new HistoriaColor(item));
                }
            }

            OrderByVisits(ref _historiaList);

            return _historiaList;
        }

        //Devuelve la lista con el tipo de busqueda indicado y con el parametro escogido
        //Hay una sobrecarga, uno para la pagina principal, y otro para la pagina de usuario
        public ObservableCollection<HistoriaColor> Filtrar(User usuario, int tipoSearch, string param, DatePicker datePicker)
        {

            var listaAux = new ObservableCollection<HistoriaColor>();

            switch (tipoSearch)
            {
                case (int)SearchType.All:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != usuario.Type || item.User != usuario.Username) continue;

                        if (item.Title.ToLower().Contains(param.ToLower()) ||
                            item.Text.ToLower().Contains(param.ToLower()) ||
                            item.User.ToLower().Contains(param.ToLower()))
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;
                case (int)SearchType.Title:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != usuario.Type || item.User != usuario.Username) continue;
                        if (item.Title.ToLower().Contains(param.ToLower()))
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;
                case (int)SearchType.Text:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != usuario.Type || item.User != usuario.Username) continue;
                        if (item.Text.ToLower().Contains(param.ToLower()))
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;
                case (int)SearchType.Date:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != usuario.Type || item.User != usuario.Username) continue;
                        if (item.Date.Day != datePicker.Date.Day) continue;
                        if (item.Date.Month != datePicker.Date.Month) continue;
                        if (item.Date.Year ==
                            datePicker.Date.Year)
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;

                default:
                    throw new Exception("El valor entero no es válido...");
            }

            return listaAux;
        }


        public ObservableCollection<HistoriaColor> Filtrar(int tipo, int tipoSearch, string param, DatePicker datePicker)
        {
            var listaAux = new ObservableCollection<HistoriaColor>();

            switch (tipoSearch)
            {
                case (int)SearchType.All:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != tipo) continue;

                        if (item.Title.ToLower().Contains(param.ToLower()) ||
                            item.Text.ToLower().Contains(param.ToLower()) ||
                            item.User.ToLower().Contains(param.ToLower()))
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;
                case (int)SearchType.Title:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != tipo) continue;
                        if (item.Title.ToLower().Contains(param.ToLower()))
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;
                case (int)SearchType.Text:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != tipo) continue;
                        if (item.Text.ToLower().Contains(param.ToLower()))
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;
                case (int)SearchType.User:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != tipo) continue;
                        if (item.User.ToLower().Contains(param.ToLower()))
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;
                case (int)SearchType.Date:
                    foreach (var item in _historiaList)
                    {
                        if (item.Type != tipo) continue;
                        if (item.Date.Day != datePicker.Date.Day) continue;
                        if (item.Date.Month != datePicker.Date.Month) continue;
                        if (item.Date.Year ==
                            datePicker.Date.Year)
                        {
                            listaAux.Add(item);
                        }
                    }
                    break;

                default:
                    throw new Exception("Valor fuera de rango");
            }

            return listaAux;
        }

    }
}

