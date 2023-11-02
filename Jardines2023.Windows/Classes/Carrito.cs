using System;
using System.Collections.Generic;
using System.Linq;

namespace Jardines2023.Windows.Classes
{
    public class Carrito
    {
        public static Carrito instancia = null;
        public static Carrito GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new Carrito();  
            }
            return instancia;
        }
        private List<ItemCarrito> items;
        private Carrito()
        {
            items= new List<ItemCarrito>();
        }
        public void AgregarAlCarrito(ItemCarrito itemCarrito)
        {
            foreach (var itemEnCarrito in items)
            {
                if (itemEnCarrito.Equals(itemCarrito))
                {
                    itemEnCarrito.Cantidad += itemCarrito.Cantidad;
                    return;
                }
            }
            items.Add(itemCarrito);
        }
        public void QuitarAlCarrito(ItemCarrito itemCarrito)
        {
            items.Remove(itemCarrito);
        }
        public List<ItemCarrito> GetItems() {  return items; }  
        public int GetCantidad()=>items.Count;
        public int GetCantidadProductos() => items.Sum(i => i.Cantidad);
        public decimal GetTotal() => items.Sum(i => i.Total);

        public void VaciarCarrito()
        {
            items.Clear();
        }
    }
}
