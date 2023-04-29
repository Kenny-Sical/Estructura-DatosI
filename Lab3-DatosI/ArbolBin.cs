using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3_DatosI
{
    internal class ArbolBin
    {
        public NodoArbol Root;
        //Insertar
        public void Inserta(Client value)
        {
            Root = Insert(Root, value);
        }

        private NodoArbol Insert(NodoArbol node, Client value)
        {
            if (node == null)
            {
                return new NodoArbol(value);
            }

            if (value.DPI < node.Value.DPI)
            {
                node.Left = Insert(node.Left, value);
            }
            else
            {
                node.Right = Insert(node.Right, value);
            }

            return node;
        }
        public Client Encontrar(long dpi)
        {
            return Find(Root, dpi);
        }

        private Client Find(NodoArbol node, long dpi)
        {
            if (node == null)
            {
                return null;
            }

            if (dpi < node.Value.DPI)
            {
                return Find(node.Left, dpi);
            }
            else if (dpi > node.Value.DPI)
            {
                return Find(node.Right, dpi);
            }
            else
            {
                return node.Value;
            }
        }
    }
}
