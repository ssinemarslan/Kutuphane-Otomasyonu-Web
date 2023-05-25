using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kütüphane.Models;
using Dapper;

namespace Kütüphane.Controllers
{
    public class KitaplarController : Controller
    {
        // GET: Kitaplar
        public ActionResult Index()
        {
            return View(DP.ReturnList<KitaplarModel>("KitaplarListele"));
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
                param.Add("@KitapNo", id);
                return View(DP.ReturnList<KitaplarModel>("KitaplarSirala", param).FirstOrDefault<KitaplarModel>());
            }
        }
        [HttpPost]
        public ActionResult EY(KitaplarModel kitaplar)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KitapNo", kitaplar.KitapNo);
            param.Add("@KitapAdi", kitaplar.KitapAdi);
            param.Add("@Yayinevi", kitaplar.Yayinevi);
            param.Add("@SayfaSayisi", kitaplar.SayfaSayisi);
            param.Add("@BasimTarihi", kitaplar.BasimTarihi);
            param.Add("@YazarAdi", kitaplar.YazarAdi);
            DP.ExReturn("KitaplarEY", param);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KitapNo", id);
            DP.ExReturn("KitaplarSil", param);
            return RedirectToAction("Index");
        }
    }
}