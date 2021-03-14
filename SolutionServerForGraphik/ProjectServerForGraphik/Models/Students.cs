using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectServerForGraphik.Models
{
    public class Students
    {
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
        public string Status { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string DateBorn { get; set; }
        public string Sex { get; set; }
        public string Group { get; set; }
    }
}