using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using System.Net.Http;
using System.Text.Json;
using ProjectKlientApplication.Models;
using ProjectKlientApplication.View;
using ProjectKlientApplication.AdminView;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Input;

namespace ProjectKlientApplication
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }
        
        private async void EnterButtonClicked(object sende, System.EventArgs e)
        {
            string helloUrl = "https://localhost:44381/Authorization/CheckAuthorization/?login="
                                   + LoginEntry.Text + "&pass=" + PasswordEntry.Text;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var Student = JsonConvert.DeserializeObject<List<Students>>(await client.GetStringAsync(helloUrl));
            //Students Student = new Students("an.va","123", "222", "333", "44", "555", "6666", "777", "888", "123");// For test

            if (Student.First().Status == "1")
            {
                await DisplayAlert("Error BD", "Отсутствует подключение к бд", "Ok");
                return;
            }
            if (Student.First().Status == "2")
            {
                await DisplayAlert("Error Pass", "Неправильный пароль", "Ok");
                return;
            }
            if (Student.First().Status == "3")
            {
                await DisplayAlert("Error BD", "Несуществующий логин", "Ok");
                return;
            }
            StudentPage StudPage = new StudentPage(Student.First());
            NavigationPage.SetHasNavigationBar(StudPage, false);
            await Navigation.PushAsync(StudPage);

        }

        private async void EnterAdminPanelButtonClicked(object sende, System.EventArgs e)
        {
            
            AdminMenu Admin = new AdminMenu();
            NavigationPage.SetHasNavigationBar(Admin, false);
            await Navigation.PushAsync(Admin);
        }

        private async void RegistrationButtonClicked(object sende, System.EventArgs e)
        {

            RegistrationPage Registr = new RegistrationPage();
            NavigationPage.SetHasNavigationBar(Registr, false);
            await Navigation.PushAsync(Registr);
        }
    }
}
