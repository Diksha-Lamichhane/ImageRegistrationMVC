using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageRegistration.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ImageRegistration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel model, HttpPostedFileBase file)
        {
            string MyCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            SqlConnection con = new SqlConnection(MyCon);
            string sqlquery = "Insert into [dbo].[ImgUser] (Name, Email, Password, Image) VALUES (@Name, @Email, @Password, @Image)";
            SqlCommand com = new SqlCommand(sqlquery, con);
            con.Open();
            com.Parameters.AddWithValue("@Name", model.Name);
            com.Parameters.AddWithValue("@Email", model.Email);
            com.Parameters.AddWithValue("@Password", model.Password);
            if(file!=null && file.ContentLength>0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/UserImages/"), filename);
                file.SaveAs(imgpath);
            }
            com.Parameters.AddWithValue("@Image", "~/UserImages/"+file.FileName);
            com.ExecuteNonQuery();
            con.Close();
            ViewData["Message"] = "User Record " + model.Name + " is saved successfully..!!";
            return View();
        }
    }
}