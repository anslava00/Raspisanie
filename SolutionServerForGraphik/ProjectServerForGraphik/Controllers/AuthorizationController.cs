using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectServerForGraphik.Models;
using Npgsql;

using System.Data.Common;

namespace ProjectServerForGraphik.Controllers
{
    public class AuthorizationController : Controller
    {
        public string Index()
        {
            string s1 = "123";
            string s2 = "234";
            string s3 = "345";
            string s4 = "456";

            return CsharpHashAlgorithm.GetHash(s1) +"_N_"+ CsharpHashAlgorithm.GetHash(s2) + "_N_" + CsharpHashAlgorithm.GetHash(s3)
                + "_N_" + CsharpHashAlgorithm.GetHash(s4);
        }

        public JsonResult CheckAuthorization(string login, string pass)
        {
            Connection.SqlRequest = "SELECT public.students.*,public.studgroup.numbergroup " +
                                    " FROM public.students" +
                                    " inner join public.studentsingroup " +
                                        " ON public.students.id = public.studentsingroup.studentid " +
                                    " inner join public.studgroup " +
                                        " ON public.studentsingroup.groupid = public.studgroup.id " +
                                    " WHERE login = '" + login + "';";
            NpgsqlCommand npgsql = new NpgsqlCommand(Connection.SqlRequest, Connection.Connect);
            try
            {
                Connection.Connect.Open();
            }
            catch (Exception ex)
            {
                Connection.Connect.Close();
                return Json(new List<Students> { new Students("1") }, JsonRequestBehavior.AllowGet);
            }
            DbDataReader Reader = npgsql.ExecuteReader();
            if (!Reader.HasRows)
            {
                Connection.Connect.Close();
                return Json(new List<Students> { new Students("3") }, JsonRequestBehavior.AllowGet); 
            }
            Reader.Read();

            List<Students> UserData = new List<Students> {
            new Students(
                        Reader.GetValue(1).ToString(),
                        Reader.GetValue(2).ToString(),
                        Reader.GetValue(3).ToString(),
                        Reader.GetValue(4).ToString(),
                        Reader.GetValue(5).ToString(),
                        Reader.GetValue(6).ToString(),
                        Reader.GetValue(7).ToString(),
                        Reader.GetValue(8).ToString(),
                        Reader.GetValue(9).ToString(),
                        Reader.GetValue(10).ToString())
                        };
            
            if (UserData[0].CheckPass(CsharpHashAlgorithm.GetHash(pass)))
            {
                Connection.Connect.Close();
                return Json(UserData, JsonRequestBehavior.AllowGet);
            }
            Connection.Connect.Close();
            return Json(new List<Students> { new Students("2") }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllStudents()
        {
            Connection.SqlRequest = "SELECT public.students.*,public.studgroup.numbergroup " +
                                    " FROM public.students" +
                                    " inner join public.studentsingroup " +
                                        " ON public.students.id = public.studentsingroup.studentid " +
                                    " inner join public.studgroup " +
                                        " ON public.studentsingroup.groupid = public.studgroup.id ";
            NpgsqlCommand npgsql = new NpgsqlCommand(Connection.SqlRequest, Connection.Connect);
            try
            {
                Connection.Connect.Open();
            }
            catch (Exception ex)
            {
                Connection.Connect.Close();
                return Json(new List<Students> { new Students("1") }, JsonRequestBehavior.AllowGet);
            }
            DbDataReader Reader = npgsql.ExecuteReader();
            if (!Reader.HasRows)
            {
                Connection.Connect.Close();
                return Json(new List<Students> { new Students("3") }, JsonRequestBehavior.AllowGet);
            }

            List<Students> UserData = new List<Students>();
            while (Reader.Read())
            {
                UserData.Add(
                    new Students(
                                Reader.GetValue(1).ToString(),
                                Reader.GetValue(2).ToString(),
                                Reader.GetValue(3).ToString(),
                                Reader.GetValue(4).ToString(),
                                Reader.GetValue(5).ToString(),
                                Reader.GetValue(6).ToString(),
                                Reader.GetValue(7).ToString(),
                                Reader.GetValue(8).ToString(),
                                Reader.GetValue(9).ToString(),
                                Reader.GetValue(10).ToString()));
            }
            Connection.Connect.Close();
            return Json(UserData, JsonRequestBehavior.AllowGet);
        }

        public string PostStudents(string login, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8,string p9)
        {
            Connection.SqlRequest = "INSERT INTO public.students(login, pass, firstname, secondname, lastname, email, telephone, dateborn, sex)" +
                "VALUES('" + login + "', '" + CsharpHashAlgorithm.GetHash(p1) + "', '" + p2 + "', '" + p3 + "', '" + p4 + 
                            "', '" + p5 + "', '" + p6 + "', '" + p7 + "', '" + p8 + "');" +
                "INSERT INTO public.studentsingroup(studentid, groupid)" +
                "VALUES((SELECT public.students.id FROM public.students WHERE login = '" + login + "')," +
                "(SELECT public.studgroup.id FROM public.studgroup WHERE numbergroup = '" + p9 + "'));";

            NpgsqlCommand npgsql = new NpgsqlCommand(Connection.SqlRequest, Connection.Connect);
            try
            {
                Connection.Connect.Open();
            }
            catch (Exception ex)
            {
                Connection.Connect.Close();
            }
            npgsql.ExecuteNonQuery();

            Connection.Connect.Close();
            return "YES";
        }

        public JsonResult GetAllGroup()
        {
            Connection.SqlRequest = "SELECT * FROM public.studgroup";
            NpgsqlCommand npgsql = new NpgsqlCommand(Connection.SqlRequest, Connection.Connect);
            try
            {
                Connection.Connect.Open();
            }
            catch (Exception ex)
            {
                Connection.Connect.Close();
                return Json(new List<Group> { new Group("1") }, JsonRequestBehavior.AllowGet);
            }
            DbDataReader Reader = npgsql.ExecuteReader();
            if (!Reader.HasRows)
            {
                Connection.Connect.Close();
                return Json(new List<Group> { new Group("3") }, JsonRequestBehavior.AllowGet);
            }

            List<Group> GroupData = new List<Group>();
            while (Reader.Read())
            {
                GroupData.Add(
                    new Group(
                                Reader.GetValue(1).ToString(),
                                Reader.GetValue(2).ToString(),
                                Reader.GetValue(3).ToString(),
                                Reader.GetValue(4).ToString()));
            }
            Connection.Connect.Close();
            return Json(GroupData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGraphik(string login, string Date)
        {
            Connection.SqlRequest = "DELETE FROM tmp_val_for_grafik;" +
                                "INSERT INTO tmp_val_for_grafik(FLT_NAME, FLT_DATE)" +
                                "VALUES('" + login + "' , '" + Date + "');" +
                                "SELECT * FROM graphik_views";
            NpgsqlCommand npgsql = new NpgsqlCommand(Connection.SqlRequest, Connection.Connect);
            try
            {
                Connection.Connect.Open();
            }
            catch (Exception ex)
            {
                Connection.Connect.Close();
                return Json(new List<Graphik> { new Graphik("1") }, JsonRequestBehavior.AllowGet);
            }
            DbDataReader Reader = npgsql.ExecuteReader();
            if (!Reader.HasRows)
            {
                Connection.Connect.Close();
                return Json(new List<Graphik> { new Graphik("3") }, JsonRequestBehavior.AllowGet);
            }
            List<Graphik> GraphikData = new List<Graphik>();
            while (Reader.Read())
            {
                GraphikData.Add( 
                            new Graphik(
                            Reader.GetValue(0).ToString(),
                            Reader.GetValue(1).ToString(),
                            Reader.GetValue(2).ToString(),
                            Reader.GetValue(3).ToString())
                            );
            }
            Connection.Connect.Close();
            return Json(GraphikData, JsonRequestBehavior.AllowGet);
            
        }
    }
}
