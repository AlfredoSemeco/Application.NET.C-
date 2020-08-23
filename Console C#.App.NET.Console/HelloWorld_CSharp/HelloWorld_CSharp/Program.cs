using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace HelloWorld_CSharp
{
    class Program
    {
        /*es un valor conestante en el app y solo es accedido como un metodo estatico( No es valor de instancia)*/
        const int varGlobalEstatico = 34;

        /*puede ser accedido por un metodo estatico[explicitamente deb tener static la var] o de clase*/
        readonly static int vaGlobal = 30;

        static void Main(string[] args)
        {
            /*una forma equvalente a stream de Java 8*/


            /*[base]: es equivalente a super para acceder a miembros de clase padre heredado*/


            /*[ref] : hace una varibla primitiva o inmutable(String, Integer, primitivos objetos) de referencia: objeto*/
            /* [out]: permite el paso de un variabla a otro metodo sin inicializarla, pero en el metodo se debe inicializar (Inicio)*/


            //example 1
            Program obj = new Program();
            String d = "hola mundo";
            obj.MakeSomething(ref d);

            //[1]   Console.WriteLine(d);

            //example 2
            /*la palabra params es equivalente a valor... de Java*/
            /*Se comporta igual, se peude pasar valores n veces sin declarar como matriz*/


            //[2] Console.WriteLine( obj.CalParesMatrix(1,2,3,4));

            obj.VerClientes();

        }


        void MakeSomething(ref String c)
        {





            c = "Alfredo Alejandro, Referencia inmutable se modifico a partir de otro Stack [ref]" + vaGlobal;

        }


        int CalParesMatrix(params int[] v)
        {

            int resultado = 0;

            foreach (int a in v)
            {

                if (a % 2 == 0)
                {
                    Console.WriteLine("Valores " + a);

                    resultado += a;
                }/*suma de valores pares*/
            }


            return resultado;

        }


        public void VerClientes()
        {

            ClienteFactory clf = new ClienteFactory();



            /*Imprime clientes > 18 años*/
            foreach (Usuario cl in clf.getClientesMayoresEdad("Alfredo", "Manuel", "Anaher","Angela"))
            {

                Console.WriteLine(cl.Nombre + " con edad: " + cl.Edad +"  "+ cl.canalComunicacion());

            }/*Creacion de clientes nuevos*/


            /* Exception expression*/
            try
            {
             
            }
            catch (Exception e)
            {
                Console.WriteLine("Attempted divide by zero.");
            }

        }




    }
}
