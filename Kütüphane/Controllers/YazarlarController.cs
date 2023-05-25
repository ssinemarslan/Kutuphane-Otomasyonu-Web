using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kütüphane.Models;
using Dapper;

namespace Kütüphane.Controllers
{
    public class YazarlarController : Controller
    {
        // GET: Yazarlar
        public ActionResult Index()
        {
            return View(DP.ReturnList<YazarlarModel>("YazarlarListele"));
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
                param.Add("@YazarNo", id);
                return View(DP.ReturnList<YazarlarModel>("YazarlarSirala", param).FirstOrDefault<YazarlarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(YazarlarModel yazarlar)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YazarNo", yazarlar.YazarNo);
            param.Add("@YazarAdi", yazarlar.YazarAdi);
            param.Add("@Adres", yazarlar.Adres);
            param.Add("@Telefon", yazarlar.Telefon);
            DP.ExReturn("YazarlarEY", param);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YazarNo", id);
            DP.ExReturn("YazarlarSil", param);
            return RedirectToAction("Index");
        }
    }
}