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

namespace ProjectKlientApplication.AdminView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsList : ContentPage
    {
        public ObservableCollection<Students> StudList { get; set; }
        public StudentsList()
        {
            InitializeComponent();
            StudList = new ObservableCollection<Students> { };
            this.BindingContext = this;
            InitStudList();
        }

        private async void InitStudList()
        {
            string Url = "https://localhost:44381/Authorization/GetAllStudents";
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var StudListInst = JsonConvert.DeserializeObject<List<Students>>(await client.GetStringAsync(Url));
            StudList.Clear();
            foreach (Students String in StudListInst)
            {
                if (String.Status == "0")
                {
                    StudList.Add(new Students()
                    {
                        Login = String.Login,
                        Pass = String.Pass,
                        FirstName = String.FirstName,
                        SecondName = String.SecondName,
                        LastName = String.LastName,
                        Email = String.Email,
                        Telephone = String.Telephone,
                        DateBorn = String.DateBorn,
                        Sex = String.Sex,
                        Group = String.Group

                    });
                }
            }
        }
    }
}