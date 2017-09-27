using ActOut.RestClient;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ActOut.Interfaces;
using ActOut.Models;
using Xamarin.Forms;

namespace ActOut.Services
{
    // La aplicación siempre usara base de datos local, pero 
    class DataBase
    {
        private readonly SQLiteConnection _sqLiteConnection;

        RestClientUsers<User> restClientUsers = new RestClientUsers<User>();
        RestClientHistorias<Historia> restClientHistorias = new RestClientHistorias<Historia>();
        Examples _examples = new Examples();

        public DataBase()
        {
            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
            _sqLiteConnection.CreateTable<Historia>();
            _sqLiteConnection.CreateTable<User>();
            _sqLiteConnection.CreateTable<LastUser>();

            //BORRAR BASE DE DATOS
            //_sqLiteConnection.DeleteAll<User>();
            //_sqLiteConnection.DeleteAll<Historia>();
            //_sqLiteConnection.DeleteAll<LastUser>();
        }

        public async Task ResubirAzure()
        {
            var userList = await restClientUsers.GetAsync();
            var storyList = await restClientHistorias.GetAsync();

            foreach (var item in userList)
            {
                await DeleteUser(item);
            }

            foreach (var item in storyList)
            {
                await DeleteHistoria(item);
            }

            _sqLiteConnection.DeleteAll<User>();
            _sqLiteConnection.DeleteAll<Historia>();
            _sqLiteConnection.DeleteAll<LastUser>();
            _examples.CrearUsuarios();
            _examples.CrearHistorias();

            foreach (var item in _sqLiteConnection.Table<User>())
            {
                await restClientUsers.PostAsync(item);
            }

            foreach (var item in _sqLiteConnection.Table<Historia>())
            {
                await restClientHistorias.PostAsync(item);
            }
        }

        private static ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll) c.Add(e);
            return c;
        }

        private void SaveLocalDb<T>(IEnumerable<T> coll)
        {
            _sqLiteConnection.DeleteAll<T>();

            foreach (var item in coll)
            {
                _sqLiteConnection.Insert(item);
            }
        }

        public bool LastUserExist()
        {
            List<LastUser> listAux = _sqLiteConnection.Table<LastUser>().ToList();

            return listAux.Any();
        }

        public void UpdateUserCache(User user)
        {
            if (LastUserExist())
            {
                _sqLiteConnection.DeleteAll<LastUser>();
                _sqLiteConnection.Insert(new LastUser()
                {
                    Username = user.Username,
                    Password = user.Password
                });
            }
            else
            {
                _sqLiteConnection.Insert(new LastUser()
                {
                    Username = user.Username,
                    Password = user.Password
                });
            }
        }

        public LastUser GetUserCache()
        {
            return _sqLiteConnection.Table<LastUser>().First();
        }

        public async Task<ObservableCollection<User>> GetUsers()
        {
            List<User> auxList;

            try
            {
                auxList = await restClientUsers.GetAsync();
                SaveLocalDb(auxList);
            }
            catch (Exception)
            {
                if (!_sqLiteConnection.Table<User>().Any())
                {
                    _examples.CrearUsuarios();
                }
                auxList = _sqLiteConnection.Table<User>().ToList();
            }


            ObservableCollection<User> userList;


            userList = ToObservableCollection<User>(auxList);
            return userList;
        }

        public async Task<ObservableCollection<Historia>> GetHistorias()
        {
            List<Historia> auxList;

            try
            {
                auxList = await restClientHistorias.GetAsync();
                SaveLocalDb(auxList);
            }
            catch (Exception)
            {
                if (!_sqLiteConnection.Table<Historia>().Any())
                {
                    _examples.CrearHistorias();
                }
                auxList = _sqLiteConnection.Table<Historia>().ToList();
            }


            ObservableCollection<Historia> storyList;


            storyList = ToObservableCollection<Historia>(auxList);
            return storyList;
        }

        public async Task AddUser(User param)
        {
            await restClientUsers.PostAsync(param);
        }

        public async Task AddHistoria(Historia param)
        {
            await restClientHistorias.PostAsync(param);
        }

        public async Task UpdateUser(User param)
        {
            await restClientUsers.PutAsync(param.Id, param);
        }

        public async Task UpdateHistoria(Historia param)
        {
            await restClientHistorias.PutAsync(param.Id, param);
        }

        public async Task DeleteHistoria(Historia param)
        {
            await restClientHistorias.DeleteAsync(param.Id, param);
        }

        public async Task DeleteUser(User param)
        {
            await restClientUsers.DeleteAsync(param.Id, param);
        }
    }
}
