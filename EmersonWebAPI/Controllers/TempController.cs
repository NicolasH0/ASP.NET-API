using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;

namespace EmersonWebAPI.Controllers
{
    public class TempController : Controller
    {
        public int pvHigh;
        public int pvLow;
        public string tempHigh;
        public string tempLow;
        public TempController()
        {
            pvHigh = Int32.Parse(WebConfigurationManager.AppSettings["maxTemp"]);
            pvLow = Int32.Parse(WebConfigurationManager.AppSettings["minTemp"]);

        }
        // GET: Temp
        public ActionResult Index()
        {
            ViewBag.Title = "TempView";
            TempData["pvHigh"] = pvHigh;
            TempData["pvLow"] = pvLow;
            return View();
        }

        // GET: Temp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Temp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Temp/Create
        [System.Web.Http.HttpPost]
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

        // GET: Temp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Temp/Edit/5
        [System.Web.Http.HttpPost]
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

        // GET: Temp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Temp/Delete/5
        [System.Web.Http.HttpPost]
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
        public ActionResult WriteConfig()
        {
            foreach (string name in Request.Form.AllKeys)
            {
                tempLow = Request.Form["min"];
                tempHigh = Request.Form["max"];
            }
            if (tempHigh == "" || tempLow == "" || int.Parse(tempHigh) > 1500 || int.Parse(tempHigh) < -50 || int.Parse(tempLow) > 1500 || int.Parse(tempLow) < -50)
            {
                return RedirectToAction("");
            }
            else
            {
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings["maxTemp"].Value = tempHigh;
                config.AppSettings.Settings["minTemp"].Value = tempLow;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                return RedirectToAction("");
            }
            
        }
    }
}
