using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using ProjectKlientApplication.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectKlientApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            InitGroupPick();
        }
        public async void InitGroupPick()
        {
            Picker CtPicker = this.FindByName<Picker>("GroupPick");
            ObservableCollection<Group> GroupList = new ObservableCollection<Group> { };
            string Url = "https://localhost:44381/Authorization/GetAllGroup";
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var GroupListInst = JsonConvert.DeserializeObject<List<Group>>(await client.GetStringAsync(Url));
            foreach (Group String in GroupListInst)
            {
                if (String.Status == "0")
                {
                    CtPicker.Items.Add(String.NameGroup);
                }
            }

            
            
        }

        private async void RegistrationButtonClicked(object sende, System.EventArgs e)
        {
            if (LoginEntry.Text == "" || PasswordEntry.Text == "")
            {
                await DisplayAlert("Error", "Ошибка логина или пароля", "Ok");
                return;
            }
            if (Sex.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Укажите пол", "Ok");
                return;
            }
            if (GroupPick.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Укажите Группу", "Ok");
                return;
            }
            string Url = "https://localhost:44381/Authorization/CheckAuthorization/?login="
                                   + LoginEntry.Text + "&pass=" + PasswordEntry.Text;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var Student = JsonConvert.DeserializeObject<List<Students>>(await client.GetStringAsync(Url));
            if (Student.First().Status == "0")
            {
                await DisplayAlert("Error", "Такой логин уже существует", "Ok");
                return;
            }

            Url = "https://localhost:44381/Authorization/PostStudents/?login=" + LoginEntry.Text +
                "&p1=" + PasswordEntry.Text +
                "&p2=" + firstname.Text +
                "&p3=" + secondname.Text +
                "&p4=" + lastname.Text +
                "&p5=" + email.Text +
                "&p6=" + telephone.Text +
                "&p7=" + DateBorn.Date.ToString("dd/MM/yyyy") +
                "&p8=" + Sex.Items[Sex.SelectedIndex] +
                "&p9=" + GroupPick.Items[GroupPick.SelectedIndex];
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            client = new HttpClient(clientHandler);
            await client.GetStringAsync(Url);
        }
    }
}