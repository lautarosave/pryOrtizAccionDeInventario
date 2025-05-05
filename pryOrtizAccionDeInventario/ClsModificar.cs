using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryOrtizAccionDeInventario
{
    public class ClsModificar
    {
        public bool Modificar(ClsNodo primero, int codigo, ClsNodo nuevosDatos)
        {
            ClsNodo aux = primero;
            while (aux != null)
            {
                if (aux.codigo == codigo)
                {
                    aux.Nombre = nuevosDatos.Nombre;
                    aux.Descripcion = nuevosDatos.Descripcion;
                    aux.precio = nuevosDatos.precio;
                    aux.stock = nuevosDatos.stock;
                    aux.categoria = nuevosDatos.categoria;
                    return true;
                }
                aux = aux.siguiente;
            }
            return false;
        }
    }
}
