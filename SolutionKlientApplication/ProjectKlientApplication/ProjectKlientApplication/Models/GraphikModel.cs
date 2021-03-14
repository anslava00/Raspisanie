using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectKlientApplication.Models
{
    public class GraphikModel
    {
        public GraphikModel() { }
        public GraphikModel(string Status)
        {
            this.Status = Status;
        }
        public GraphikModel(string Time, string NameSubject, string Teacher, string ClassRoom)
        {
            this.Status = "0";
            this.Time = Time;
            this.NameSubject = NameSubject;
            this.Teacher = Teacher;
            this.ClassRoom = ClassRoom;
        }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("NameSubject")]
        public string NameSubject { get; set; }
        [JsonProperty("Teacher")]
        public string Teacher { get; set; }
        [JsonProperty("ClassRoom")]
        public string ClassRoom { get; set; }
    }
}
