using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryOrtizAccionDeInventario
{
    public class ClsNodo
    {
        private Int32 cod;
        private string nom;
        private string desc;
        private Int32 pre;
        private Int32 sto;
        private string cat;

        public Int32 codigo
        {
            get { return cod; }
            set { cod = value; }
        }
        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Descripcion
        {
            get { return desc; }
            set { desc = value; }
        }
        public Int32 precio
        {
            get { return pre; }
            set { pre = value; }
        }
        public Int32 stock
        {
            get { return sto; }
            set { sto = value; }
        }
        public string categoria
        {
            get { return cat; }
            set { cat = value; }
        }


    }
}
