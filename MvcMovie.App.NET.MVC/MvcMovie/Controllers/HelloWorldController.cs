using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        
        /* GET: /HelloWorld*/ 

        /*Nota: Index es un Metodo que se llama por defecto en un controlador si no se especifica un path siguiente*/
        public ActionResult Index()
        {
            return View();
        }

        
        /*Este metodo recibe o espera dos variables de URL*/
        /* GET: /HelloWorld/Welcome*/ 

        public ActionResult Welcome(string name, int numTimes=1)
        {
            /*HttpUtility.HtmlEncode para evitar inyecciones de script JS*/

            //  ViewBag.Message = HttpUtility.HtmlEncode(name + " programador Java y .NET - " + numTimes);

            /*Variable que acepta todas las variables deseadas a imprimir en una vista, los atributos se crean dinamicamente*/
           
            ViewBag.Message = "Welcome " + name;
            ViewBag.NumTimes = numTimes;

            return View() ;
        }
    }
}