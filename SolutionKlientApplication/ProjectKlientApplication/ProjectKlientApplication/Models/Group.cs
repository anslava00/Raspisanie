using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectKlientApplication.Models
{
    public class Group
    {
        public Group() { }
        public Group(string Status)
        {
            this.Status = Status;
        }
        public Group(string NameGroup, string Cours, string YearStart, string YearEnd)
        {
            this.Status = "0";
            this.NameGroup = NameGroup;
            this.Cours = Cours;
            this.YearStart = YearStart;
            this.YearEnd = YearEnd;
        }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("NameGroup")]
        public string NameGroup { get; set; }
        [JsonProperty("Cours")]
        public string Cours { get; set; }
        [JsonProperty("YearStart")]
        public string YearStart { get; set; }
        [JsonProperty("YearEnd")]
        public string YearEnd { get; set; }
    }
}
