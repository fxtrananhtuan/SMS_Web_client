using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS_Web_client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        ServiceReference1.DesktopEndpointClient _client = new ServiceReference1.DesktopEndpointClient();
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(ServiceReference1.DTO_Account account)
        {
            if (ModelState.IsValid)
            {
                string sql = "select * from Account where password='" + account.Password.Trim() + "' and email='" + account.email.Trim() + "' ";
                try
                {

                    if (_client.CheckSignin(sql))
                    {

                        Cglobal_varible.Account_ID = _client.GetID(sql);
                        Session["AccountID"] = Cglobal_varible.Account_ID;
                        Cglobal_varible.Name = _client.GetName(sql);
                        Session["AccountName"] = Cglobal_varible.Name;
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View();
        }

        public ActionResult SendSMS()
        {
            Cglobal_varible._customer = _client.load_Customer("select * from Customer where AccountID='" + Cglobal_varible.Account_ID + "' and active = 1");
            return View("SendSMS",Cglobal_varible._customer);
        }
        public ActionResult Add(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Add(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}