using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryOrtizAccionDeInventario
{
    public class ClsAgregar
    {
        public void Agregar(ref ClsNodo primero, ClsNodo nuevo)
        {
            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                ClsNodo aux = primero;
                while (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                aux.siguiente = nuevo;
            }
        }
    }
}
