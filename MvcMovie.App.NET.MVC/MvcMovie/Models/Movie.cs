using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMovie.Models
{
    /*Se hace uso de Entity Framework ORM para C#*/

    /**/
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
    }

    /*esta clase deberia estar separada*/
    public class MovieDBContext : DbContext
    {
        /*para base de datos SQL SERVER es requerido que este presente un constructor refiriendo
         String de conexion a la BD configurado en el WEB.config*/

        /*SQLLoca: quitar constructor si se quiere trabajar con BD local que implementa el Entity Framework*/
        public MovieDBContext()
        : base("name=MovieBDContext")
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}