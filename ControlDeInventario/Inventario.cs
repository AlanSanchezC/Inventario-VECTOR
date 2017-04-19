/*
 *  Creado por Alan Francisco Sánchez Cazarez
 */

using System;

namespace ControlDeInventario
{
    class Inventario
    {
        private Producto[] productos;
        private int ocupados;

        public Inventario()
        {
            productos = new Producto[15];
            ocupados = 0;
        }

        public bool agregar(Producto p)
        {
            if (ocupados <= productos.Length-1)
            {
                int i = 0;
                while (productos[i] != null)
                {
                    i++;
                }
                productos[i] = p;
                ocupados++;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string reporte()
        {
            string cad = "";
            for (int i = 0; i <= productos.Length - 1; i++)
            {
                if (productos[i] != null)
                    cad += productos[i].ToString() + Environment.NewLine;
            }
            return cad;
        }

        public Producto busqueda(string codigo)
        {
            for (int i = 0; i <= productos.Length - 1; i++)
            {
                try
                {
                    if (productos[i].codigo == codigo)
                    {
                        return productos[i];
                    }
                }
                catch (System.NullReferenceException) { }
            }
            return null;
        }

        public bool insertar(Producto p, int posicion)
        {
            bool insertado = false;
            if (ocupados < productos.Length)
            {
                int pos = posicion;
                Producto aux = productos[pos];

                while (aux != null)
                {
                    pos++;
                    if (pos > productos.Length - 1)
                        aux = null;
                }

                if (pos < productos.Length)
                {
                    for (int i = pos; i > posicion; i--)
                    {
                        productos[i] = productos[i - 1];
                    }
                    productos[posicion] = p;
                    insertado = true;
                    ocupados++;
                }
            }
            return insertado; 
        }

        public void eliminar(string codigo)
        {
            for (int i = 0; i <= productos.Length-1; i++)
            {
                try
                {
                    if (productos[i].codigo == codigo)
                    {
                        productos[i] = null;
                        ocupados--;
                    }
                }
                catch (System.NullReferenceException) { }
            }
        }
    }
}
