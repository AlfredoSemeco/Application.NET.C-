﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld_CSharp
{
    class Cliente : Usuario
    {

        public String canalComunicacion() {

            return "Hablamos directamente, estamos presencial!";
        
        
        }

        public Cliente(String nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }

        private String nombre;
        private int edad;
        private String documento;
        private String tDocumento;

        /*Expression-bodied members caracteristica de C# 6 Y 7*/

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Documento { get => documento; set => documento = value; }
        public string TDocumento { get => tDocumento; set => tDocumento = value; }





    }
}