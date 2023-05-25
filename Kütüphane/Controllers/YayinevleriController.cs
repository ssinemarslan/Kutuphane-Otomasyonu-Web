using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kütüphane.Models;
using Dapper;

namespace Kütüphane.Controllers
{
    public class YayinevleriController : Controller
    {
        // GET: Yayinevleri
        public ActionResult Index()
        {
            return View(DP.ReturnList<YayinevleriModel>("YayineviListele"));
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {//ekelem create çalışacak
                return View();
            }
            else
            {//update çalışacak
                DynamicParameters param = new DynamicParameters();
                param.Add("@YayineviNo", id);
                return View(DP.ReturnList<YayinevleriModel>("YayineviSirala", param).FirstOrDefault<YayinevleriModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(YayinevleriModel yayinevleri)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YayineviNo", yayinevleri.YayineviNo);
            param.Add("@YayineviAdi", yayinevleri.YayineviAdi);
            param.Add("@Adres", yayinevleri.Adres);
            param.Add("@Telefon",yayinevleri.Telefon);
            DP.ExReturn("YayineviEY", param);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YayineviNo", id);
            DP.ExReturn("YayineviSil", param);
            return RedirectToAction("Index");
        }
    }
}
