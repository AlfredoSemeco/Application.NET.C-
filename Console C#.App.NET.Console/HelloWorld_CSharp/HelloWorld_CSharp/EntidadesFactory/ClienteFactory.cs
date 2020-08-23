using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld_CSharp
{
    class ClienteFactory
    {
        private List<Usuario> CreateClientes(params String[] nombresClientes)
        {

            /*Edad aleatoria*/
            Random rnd = new Random();

            String[] nombres = nombresClientes;

            List<Usuario> clientes = new List<Usuario>();

            /*Se crean clientes*/
            foreach (String nombre in nombres)
            {
                ClienteVirtual clientev = new ClienteVirtual(nombre, rnd.Next(1, 40));
                clientes.Add(clientev);
                Cliente cliente = new Cliente(nombre, rnd.Next(1, 40));
                clientes.Add(cliente);

            }/*Creacion de clientes nuevos*/

            return clientes;

        }




        public IEnumerable<Usuario> getClientesMayoresEdad(params String[] nombres)
        {


            var clientesObj = this.CreateClientes(nombres);

            return Filters.RuleFilterClienteMayorEdad(clientesObj);


        }


    }
}
