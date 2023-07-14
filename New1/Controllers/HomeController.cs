using Dapper;
using Microsoft.Extensions.Configuration;
using New1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace New1.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = "server=104.155.208.131; database=OLYMPICENGLISH.VN.2023;User Id=HSSV_Intern;Password=ames@123456;Trusted_Connection=True; Integrated Security=false; TrustServerCertificate=True";

        public ActionResult Index()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var proc = "[dbo].[p_OLYMPICHSSV_Get_Week]";
                var listWeeks = connection.Query<Weeks>(proc, commandType: CommandType.StoredProcedure).ToList();
                return View(listWeeks);
            }
        }
       
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateWeek weeks)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var insertQuery = "p_OLYMPICHSSV_Create_Week";
                int result = connection.QueryFirstOrDefault<int>(insertQuery, weeks, commandType: CommandType.StoredProcedure);
                TempData["CreateSuccess"] = result;

                return RedirectToAction("Index");

            }
        }
        [HttpPost]
        public ActionResult Edit(EditWeek weeks)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var updateQuery = "p_OLYMPICHSSV_Edit_Week";
                int result = connection.QueryFirstOrDefault<int>(updateQuery, weeks, commandType: CommandType.StoredProcedure);
                TempData["EditSuccess"] = result;

                return RedirectToAction("Index");
            }

        }
        public JsonResult GetCities()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var cities = connection.Query<City>("SELECT Id, Name FROM t_OLYMPIC_ENGLISH_Cities ").ToList();
                return Json(cities, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(DeleteWeek weeks)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var deleteQuery = "p_OLYMPICHSSV_Delete_Week";

                int result = connection.QueryFirstOrDefault<int>(deleteQuery, weeks, commandType: CommandType.StoredProcedure);
                TempData["DeleteSuccess"] = result;
            }
            return RedirectToAction("Index");
        }
    }
}