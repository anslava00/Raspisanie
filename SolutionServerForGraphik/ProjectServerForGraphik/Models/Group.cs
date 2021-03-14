using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectServerForGraphik.Models
{
    public class Group
    {
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
        public string Status { get; set; }
        public string NameGroup { get; set; }
        public string Cours { get; set; }
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
    }
}