using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProjectKlientApplication.Models;

namespace ProjectKlientApplication.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage(Students Student)
        {
            InitializeComponent();
            LabelLogin.Text = Student.Login;
            LabelFirstName.Text = Student.FirstName;
            LabelLastName.Text = Student.LastName;
            LabelSecondName.Text = Student.SecondName;
            LabelEmail.Text = Student.Email;
            LabelBorn.Text = Student.DateBorn;
            LabelTelephone.Text = Student.Telephone;
            LabelSex.Text = Student.Sex;
            LabelGroup.Text = Student.Group;
        }
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void Graphik(object sender, EventArgs e)
        {

            Graphik graphik = new Graphik(LabelLogin.Text);
            NavigationPage.SetHasNavigationBar(graphik, false);
            await Navigation.PushAsync(graphik);
        }
    }
}