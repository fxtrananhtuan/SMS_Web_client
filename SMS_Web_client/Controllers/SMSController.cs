using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS_Web_client.Controllers
{
    public class SMSController : Controller
    {
        ServiceReference1.DesktopEndpointClient _client = new ServiceReference1.DesktopEndpointClient();
        // GET: SMS
        public ActionResult Index()
        {
            Cglobal_varible._customer = _client.load_Customer("select * from Customer where AccountID='" + Cglobal_varible.Account_ID + "' and active = 1");
            return View("Index", Cglobal_varible._customer);
        }
        public ActionResult Send(string input)
        {
            if(Cglobal_varible._PhoneNumber.Count!=0)
            {
                foreach(ServiceReference1.DTO_Customer _cus in Cglobal_varible._PhoneNumber)
                {
                    ServiceReference1.DTO_SMS _SMS = new ServiceReference1.DTO_SMS();
                    _SMS.Message = input;
                    _SMS.Sender = _cus.Phone;
                    _client.SendSMS(_SMS);
                }
               
            }

            return View("Index", Cglobal_varible._customer);
        }


        // GET: SMS/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SMS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SMS/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SMS/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceReference1.DTO_Customer _cus = new ServiceReference1.DTO_Customer();
            _cus.Phone = "0"+id.ToString();
            Cglobal_varible._PhoneNumber.Add(_cus);
            return View("ListCustomer", Cglobal_varible._PhoneNumber);
        }

        // POST: SMS/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: SMS/Delete/5
        public ActionResult Delete(int id)
        {
           for (int i=0;i<Cglobal_varible._PhoneNumber.Count;i++)
            {
                if(Cglobal_varible._PhoneNumber[i].Phone=="0"+id.ToString())
                {
                    Cglobal_varible._PhoneNumber.RemoveAt(i);
                    break;
                }
            }
            return View("ListCustomer", Cglobal_varible._PhoneNumber);

        }

        // POST: SMS/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
