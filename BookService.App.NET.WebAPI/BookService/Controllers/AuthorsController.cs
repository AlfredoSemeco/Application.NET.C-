using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookService.Data;
using BookService.Models;

namespace BookService.Controllers
{
    public class AuthorsController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        /*Consulta Personalizada de un Author: FindByName,[PARAMETRO URL]*/
        public IQueryable<Author> GetAuthors(String name)
        {

            /*[FORMA DE OBTENER VALOR POR HEADER EN .NET]. 
            /*Obtener valores del HEADER de una peticion
            var re = Request;
            var headers = re.Headers;

            /*validar si el valor header existe en la peticion 
            if (headers.Contains("nameAuthor"))
            {
                /*Si exite, se obtiene valor
                var nameAuthor = headers.GetValues("nameAuthor").First();
            }
            */

           

            var author = from m in db.Authors
                         select m;

            author = author.Where(s => s.Name.Contains(name));


            return db.Authors.Include(b => b.Books);

        }


            // GET: api/Authors
            public IQueryable<Author> GetAuthors()
        {
            //return db.Authors;

           


            return db.Authors.Include(b => b.Books);
        }

        // GET: api/Authors/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> GetAuthor(int id)
        {
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.Id)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(author);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public async Task<IHttpActionResult> DeleteAuthor(int id)
        {
            Author author = await db.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            db.Authors.Remove(author);
            await db.SaveChangesAsync();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorExists(int id)
        {
            return db.Authors.Count(e => e.Id == id) > 0;
        }
    }
}