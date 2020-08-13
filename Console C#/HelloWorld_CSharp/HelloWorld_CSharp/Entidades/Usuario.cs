using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld_CSharp
{
    interface Usuario
    {

        public string Nombre { get; set; }
        int Edad { get; set; }

        string Documento { get; set; }

        string TDocumento { get; set; }

        public String canalComunicacion();

    }
}
