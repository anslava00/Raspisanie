using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectKlientApplication.Models
{
    public class Students
    {
        public Students() { }
        public Students(string Status)
        {
            this.Status = Status;
        }
        public Students(string Login, string Pass, string FirstName, string SecondName, string Lastname,
                        string Email, string Telephone, string DateBorn, string Sex, string Group)
        {
            this.Status = "0";
            this.Login = Login;
            this.Pass = Pass;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = Lastname;
            this.Email = Email;
            this.Telephone = Telephone;
            this.DateBorn = DateBorn;
            this.Sex = Sex;
            this.Group = Group;
        }
        public bool CheckPass(string Pass)
        {
            if (Pass == this.Pass)
            {
                return true;
            }
            return false;
        }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Login")]
        public string Login { get; set; }
        [JsonProperty("Pass")]
        public string Pass { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("SecondName")]
        public string SecondName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("Telephone")]
        public string Telephone { get; set; }
        [JsonProperty("DateBorn")]
        public string DateBorn { get; set; }
        [JsonProperty("Sex")]
        public string Sex { get; set; }
        [JsonProperty("Group")]
        public string Group { get; set; }
    }
}
