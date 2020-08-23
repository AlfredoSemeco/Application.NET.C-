using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    /*Entidad MOVIE: Entity Framework Controller*/
    public class MoviesController : Controller
    {
        /*Objeto DAO del aplicativo*/
        private MovieDBContext db = new MovieDBContext();

        /*Al crear este controlador(Controller as Entity framework), el IDE VS Automaticamente genera todas las operaciones CRUD por Entidad*/


        // GET: Movies : Metodo si se quiere, se ajusta con nombramiento {id} para utilizar patron de routes (RouteConfig) definido: Controller/action/id
        public ActionResult Index(string movieGenre, string searchString)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());

            /*Se pasa todas las categorias posibles existentes en registros de Movies*/
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Movies
                         select m;

            /*Se aplica filtros a busqueda de Movies*/
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View(movies);
        }


        // GET: Movies/Details/5
        /*En este punto tambien es posible pasar el ID como un parametro de URL: http://localhost:1234/movies/details?id=1 */
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            /*Obtiene el objeto(Modelo)  y lo pasa a la vista*/
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            /*Fomar clasica de pasar equivalente es utilizanod el Objeto [ViewBAG]*/
            ViewBag.ObjetoMovie = movie;


            /*Otra forma de relacionar a un vista un Objeto de tipo (Pasar)*/
            return View(movie);
        }

        // GET: Movies/Create [Vista formualario]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create [Crear entidad Movie]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] /*Propiedad de seguridad para evitar falsificacion de solicitudes cruzadas  XSRF o CSRF
                                    mecanismo para evitar peticiones de terceros no autorizados. 
                                    Peticion tipo Form o parametros POST o impacte modificacion*/
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {

            Console.WriteLine("Pelicula con rating: "+ movie.Rating);

            /*Se envia datos y serializa desde la vista a un tipo Objeto: Movie*/
            /* Se define como un metodo POST*/
            /*El atributo Bind se indica que variables se van a vincular al objeto*/

            if (ModelState.IsValid) /*Condicional NECESARIA para validaciones del lado del BACKEND. Validaciones de entidad declaradas en la Entidad Movie*/
            {
                db.Movies.Add(movie); /*Se adiciona objeto en DAO*/
                db.SaveChanges(); /*Se aplica camio*/
                return RedirectToAction("Index"); /*Redirecciona a index view [Lista de peliculas]*/
            }

            /*Si validaciones no se cumple entonces, el controlador recarga (Este recarga no se preciben) la pagina con lo datos y validaicones de campos a corregir */
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Movie movie = db.Movies.Find(id); /*Obtiene el objeto(Modelo)  y lo pasa a la vista*/
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {/*La interfaz conoce objeto a persistir sin necesidad de hacer un find Entity*/
                db.Entry(movie).State = EntityState.Modified; /*Entidad existente, modificada y persistida en BD*/
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")] /*Se esta indicando explicitamente el nombre del metodo accion*/
        [ValidateAntiForgeryToken]
        /*Otra forma de mantener el nombramiento (accion) es sobrecargando el metodo y pasando un valor de parametro aux (No se utiliza)*/
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
