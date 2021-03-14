using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace ProjectServerForGraphik.Models
{
    public class Connection
    {
        static public NpgsqlConnection Connect = new NpgsqlConnection("Server=127.0.0.1; Port=5432;" +
                                                                      "User Id=postgres;" +
                                                                      "Password=Ctvtqrf55@;" +
                                                                      "Database=University;");
        static public string SqlRequest;
    }
}