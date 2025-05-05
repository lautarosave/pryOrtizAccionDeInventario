using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryOrtizAccionDeInventario
{
    public class ClsEliminar
    {
        public bool Eliminar(ref ClsNodo primero, int codigo)
        {
            if (primero == null)
                return false;

            if (primero.codigo == codigo)
            {
                primero = primero.siguiente;
                return true;
            }

            ClsNodo aux = primero;
            while (aux.siguiente != null)
            {
                if (aux.siguiente.codigo == codigo)
                {
                    aux.siguiente = aux.siguiente.siguiente;
                    return true;
                }
                aux = aux.siguiente;
            }

            return false;
        }
    }
}
