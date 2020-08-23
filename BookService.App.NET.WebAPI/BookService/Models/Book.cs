using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BookService.Models
{
    [DataContract(IsReference = true)]  /* Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
    public class Book
    {
        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        public int Id { get; set; }

        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        [Required]
        public string Title { get; set; }

        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        public int Year { get; set; }

        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        public decimal Price { get; set; }

        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        public string Genre { get; set; }

        // Foreign Key
        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        public int AuthorId { get; set; }

        // Navigation property
        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        public Author Author { get; set; }



        /*Consulta Tipo: [Carga Diferida], Cuando se obtiene un objeto, este no se carga inicialmente todas sus relaciones pero,
         * medida que se accede a un objeto relacion EF (Entity Framework) realiza consulta y lo dispone de forma dinamica*/

        // Virtual navigation property
         //public virtual Author Author { get; set; } 

    }
}

/*Objetos DTO, requeridos para query LINQ. Consultas personalizadas*/
namespace BookService.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }
}


/*Objetos DTO, requeridos para query LINQ. Consultas personalizadas*/
namespace BookService.Models
{
    public class BookDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
    }
}