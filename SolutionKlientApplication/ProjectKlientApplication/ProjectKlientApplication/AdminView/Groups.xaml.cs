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
    public partial class Groups : ContentPage
    {
        public ObservableCollection<Group> GroupList { get; set; }
        public Groups()
        {
            InitializeComponent();
            GroupList = new ObservableCollection<Group> { };
            this.BindingContext = this;
            InitGroupList();
            
        }

        public async void InitGroupList()
        {
            string Url = "https://localhost:44381/Authorization/GetAllGroup";
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            var GroupListInst = JsonConvert.DeserializeObject<List<Group>>(await client.GetStringAsync(Url));
            GroupList.Clear();
            foreach (Group String in GroupListInst)
            {
                if (String.Status == "0")
                {
                    GroupList.Add(new Group()
                    {
                        NameGroup = "ГРУППА : " + String.NameGroup,
                        Cours = "Курс : " + String.Cours,
                        YearStart = "Год начала : " + String.YearStart,
                        YearEnd = "Год окончания : " + String.YearEnd
                    });
                }
            }
        }
    }
}