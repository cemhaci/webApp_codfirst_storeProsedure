using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webApp_codfirst_storeProsedure.Models;

namespace webApp_codfirst_storeProsedure.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            databasecontest dc=new databasecontest();
            dc.kitaplar.ToList();
            //dc.yazarlar.ToList();
            //dc.procedureinsertData();
            List<kitapyayin> liste =dc.precedurekitapdata(2010,2020);
            //kitap kitap=new kitap()
            //{adi="homo saphiens",aciklama="deneme",yayintarihi=DateTime.Now};

            //dc.kitaplar.Add(kitap); 
            //dc.SaveChanges();
            List<kitap> bilgilist=dc.viewkitapgetir();
            List<yazar> yazarlist=dc.yazarlar.ToList();
            hemyayınhembilgi hyh=new hemyayınhembilgi();
            hyh.kitapyayin=liste;
            //hyh.kitapbilgi=bilgilist;
            hyh.kitaps=bilgilist;
            hyh.yazars= yazarlist;
           
           


            return View(hyh);  //viewe bir şey gönderirsek indeksimizin modeli o gönderdiğimiz şey olur artık
        }
    }
}