using Mod02_01.DAL;
using Mod02_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace Mod02_01.Controllers
{
    public class OperaController : Controller
    {
        // GET: Opera
        // GET: Opera/Index?operaId=111&title=xx&year=1923&composer=John
        //public ActionResult Index(Opera opera)
        //{
        //    //var test = ModelState.IsValid;
        //    //Opera o = new Opera()
        //    //{
        //    //    OperaID = opera.OperaID,
        //    //    Title = opera.Title,
        //    //    Year = opera.Year,
        //    //    Composer = opera.Composer
        //    //};

        //    return View(opera);
        //}

        // Lab2_4
        // GET: Opera/Index
        public ActionResult Index()
        {
            OperaContext context = new OperaContext();

            return View(context.Operas.ToList());
        }

        //lab3-3
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OperaContext context = new OperaContext();
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }

        public ActionResult Create()
        {
            return View();
        }

       [HttpPost]
       public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                OperaContext contex = new OperaContext();
                contex.Operas.Add(opera);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }

        //GET: opera/edit/1
        //GET:opera/edit?id=1
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OperaContext context = new OperaContext();
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }

        [HttpPost]
        public ActionResult Edit(Opera opera)
        {
            if (ModelState.IsValid)
            {
                OperaContext contex = new OperaContext();
                contex.Entry(opera).State=EntityState.Modified;
                //Opera o = contex.Operas.Find(opera.OperaID);
                //o.Title = opera.Title;
                //o.Year = opera.Year;
                //o.Composer = opera.Composer;
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }


    }
}