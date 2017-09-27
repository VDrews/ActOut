using ActOutWebService.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ActOutWebService.Controllers
{

    //Controlador Mvc para poder Gestionar las historias desde el navegador
    public class HistoriasMvcController : Controller
    {
        private HistoriasContext db = new HistoriasContext();

        // GET: HistoriasMvc
        public ActionResult Index()
        {
            return View(db.Historias.ToList());
        }

        // GET: HistoriasMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }

        // GET: HistoriasMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistoriasMvc/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Text,User,Estado,Type,Visitas,Sentimiento,Color,Date")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                db.Historias.Add(historia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historia);
        }

        // GET: HistoriasMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }

        // POST: HistoriasMvc/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Text,User,Estado,Type,Visitas,Sentimiento,Color,Date")] Historia historia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historia);
        }

        // GET: HistoriasMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return HttpNotFound();
            }
            return View(historia);
        }

        // POST: HistoriasMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historia historia = db.Historias.Find(id);
            db.Historias.Remove(historia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
