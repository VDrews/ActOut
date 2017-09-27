using ActOutWebService.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ActOutWebService.Controllers
{
    public class HistoriasController : ApiController
    {
        private HistoriasContext db = new HistoriasContext();

        // GET: api/Historias
        public IQueryable<Historia> GetHistorias()
        {
            return db.Historias;
        }

        // GET: api/Historias/5
        [ResponseType(typeof(Historia))]
        public IHttpActionResult GetHistoria(int id)
        {
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return NotFound();
            }

            return Ok(historia);
        }

        // PUT: api/Historias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHistoria(int id, Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != historia.Id)
            {
                return BadRequest();
            }

            db.Entry(historia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Historias
        [ResponseType(typeof(Historia))]
        public IHttpActionResult PostHistoria(Historia historia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Historias.Add(historia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = historia.Id }, historia);
        }

        // DELETE: api/Historias/5
        [ResponseType(typeof(Historia))]
        public IHttpActionResult DeleteHistoria(int id)
        {
            Historia historia = db.Historias.Find(id);
            if (historia == null)
            {
                return NotFound();
            }

            db.Historias.Remove(historia);
            db.SaveChanges();

            return Ok(historia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HistoriaExists(int id)
        {
            return db.Historias.Count(e => e.Id == id) > 0;
        }
    }
}