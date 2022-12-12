using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Views;
using Firebase.Database;


namespace ProyectoProgramacionMovil_Andrade_Bedon_Moreta.Models
{
    internal class LoginModel : INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyD7ZTFhFn6-2UvEyzIrfI3W55BZWCqKy5M";
        private INavigation _navigation;
        private string userMail;
        private string userPassword;
        public event PropertyChangedEventHandler PropertyChanged;

        public Command RegisterBtn { get; set; }
        public Command LoginBtn { get; set; }

        public string UserMailLogin { get => userMail; set 
            {
                userMail = value;
                RaisePropertyChange("UserMailLogin");

            } 
        }
        public string UserPasswordLogin { get => userPassword;
            set 
            {
                userPassword = value;
                RaisePropertyChange("UserPasswordLogin");
            } 
        }

        public LoginModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnAsync);
            LoginBtn = new Command(LoginBtnAsync);

           
        }


        private void RaisePropertyChange(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }


        private async void LoginBtnAsync(object obj)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserMailLogin, UserPasswordLogin);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                await this._navigation.PushAsync(new MenuUsuario());
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                throw;
            }
        }

        private async void RegisterBtnAsync(object obj)
        {
            await this._navigation.PushAsync(new Register());
        }

      
    }

}

