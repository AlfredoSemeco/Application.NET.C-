using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BookService.Models
{
    [DataContract(IsReference = true)]/*Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
    public class Author
    {
        [DataMember] /*Se tiene que colocar a todos los miembros. Requerido para no tener error de serializacion(XML) y doble referencia (Bucle)*/
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        /*Key Books*/
        public ICollection<Book> Books { get; set; }

    }
}