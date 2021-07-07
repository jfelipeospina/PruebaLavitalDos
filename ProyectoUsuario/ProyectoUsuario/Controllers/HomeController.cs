using ProyectoUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoUsuario.DataAccess;

namespace ProyectoUsuario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            PruebaEntities cbe = new PruebaEntities();
            var s = cbe.GetLogin(model.Usuario, model.Contraseña);

            var item = s.FirstOrDefault();
            if (item == "1")
            {

                return RedirectToAction("ShowAllUserDetails");
            }
            else if (item == "2")
			{
                return View("About");

            }
            else if (item == "User Does not Exists")

            {
                ViewBag.NotValidUser = item;

            }
            else
            {
                return View("Contact");
            }

            return View("Index");
        }

        public ActionResult UserView()
        {
            return View();
        }


        //    
        // GET: /Customer/    
        [HttpGet]
        public ActionResult InsertUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertUser(UserDetailsModel objCustomer)
        {

            if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                //ViewData["result"] = result;    
                TempData["result1"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("ShowAllUserDetails");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllUserDetails()
        {
            UserDetailsModel objCustomer = new UserDetailsModel();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            objCustomer.ShowallUser = objDB.Selectalldata();
            return View(objCustomer);
        }
        [HttpGet]
        public ActionResult Details(string Id)
        {
            //Customer objCustomer = new Customer();    
            //DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            //objCustomer.ShowallCustomer = objDB.Selectalldata();    
            //return View(objCustomer);    
            UserDetailsModel objCustomer = new UserDetailsModel();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            return View(objDB.SelectDatabyID(Id));
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            UserDetailsModel objCustomer = new UserDetailsModel();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            return View(objDB.SelectDatabyID(Id));
        }

        [HttpPost]
        public ActionResult Edit(UserDetailsModel objCustomer)
        {
            if (ModelState.IsValid) //checking model is valid or not    
            {
                DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
                string result = objDB.UpdateData(objCustomer);
                //ViewData["result"] = result;    
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    
                                    //return View();    
                return RedirectToAction("ShowAllUserDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String Id)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(Id);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model    
                                //return View();    
            return RedirectToAction("ShowAllUserDetails");
        }
    }
}
