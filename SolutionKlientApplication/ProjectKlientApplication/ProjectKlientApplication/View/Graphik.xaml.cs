using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjectKlientApplication.Models;

namespace ProjectKlientApplication.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graphik : ContentPage
    {
        string Login;
        public ObservableCollection<GraphikModel> Graphiks { get; set; }
        public Graphik(string Log)
        {
            InitializeComponent();
            Login = Log;
            Label1.Text = "Login : " + Login;
            Graphiks = new ObservableCollection<GraphikModel> { };
            DatePicke.Date = new DateTime(2020, 11, 21); // DateTime.Now.ToString("yyyy-MM-dd");
            this.BindingContext = this;
        }
        private async void ChooseDate(object sende, DateChangedEventArgs e)
        {
            string Url = "https://localhost:44381/Authorization/GetGraphik/?login="
                            + Login + "&Date=" + e.NewDate.ToString("dd/MM/yyyy");
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var GraphikInst = JsonConvert.DeserializeObject<List<GraphikModel>>(await client.GetStringAsync(Url));
            //await DisplayAlert("", GraphikInst[0].Status, "Ok");
            Graphiks.Clear();
            foreach (GraphikModel String in GraphikInst)
            {
                if(String.Status == "0")
                {
                    Graphiks.Add(new GraphikModel()
                    {
                        Time = "Время : " + String.Time,
                        NameSubject = "Дисциплина : " + String.NameSubject,
                        Teacher = "Преподаватель : " + String.Teacher,
                        ClassRoom = "Кабинет : " + String.ClassRoom
                    });
                }
            }
        }

    }
}