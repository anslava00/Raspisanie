using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectServerForGraphik.Models
{
    public class Graphik
    {
        public Graphik(string Status)
        {
            this.Status = Status;
        }
        public Graphik(string Time, string NameSubject, string Teacher, string ClassRoom)
        {
            this.Status = "0";
            this.Time = Time;
            this.NameSubject = NameSubject;
            this.Teacher = Teacher;
            this.ClassRoom = ClassRoom;
        }
        public string Status { get; set; }
        public string Time { get; set; }
        public string NameSubject { get; set; }
        public string Teacher { get; set; }
        public string ClassRoom { get; set; }
    }
}