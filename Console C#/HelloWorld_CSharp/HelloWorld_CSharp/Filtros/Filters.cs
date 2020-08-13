using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld_CSharp
{
    class Filters
    {


        public static IEnumerable<Usuario> RuleFilterClienteMayorEdad(List<Usuario> clientes) {


            /*Se filtran clientes y excluyen todos los clientes < 18 años*/
            IEnumerable<Usuario> client = from c in clientes
                         where c.Edad < 18
                         select c;

            return client;
        }
    
    }
}
