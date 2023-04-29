using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_DatosI
{
    internal class NodoArbol
    {
            public Client Value;
            public NodoArbol Left;
            public NodoArbol Right;

            public NodoArbol(Client value)
            {
                Value = value;
                Left = null;
                Right = null;
            }

    }
}
