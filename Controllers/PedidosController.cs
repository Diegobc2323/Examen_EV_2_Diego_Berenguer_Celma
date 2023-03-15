using Examen_EV_2_Diego_Berenguer_Celma.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Examen_EV_2_Diego_Berenguer_Celma.Controllers
{
    public class PedidosController : Controller
    {

        private readonly Contexto contexto;

        public PedidosController(Contexto contexto)
        {
            this.contexto = contexto;
        }


        // GET: PedidosController
        public ActionResult Index(int id=1)
        {
            ViewBag.productos = contexto.Productos.ToList();
            var lista = contexto.Pedidos.Where(p => p.ID == id).Include(p => p.pedidosProductos).ToList();
            return View(lista);
        }

        // GET: PedidosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidosController/Create
        public ActionResult Create(int id=1)
        {
            ViewBag.proveedorID = new SelectList(contexto.Proveedores, "ID", "nomProveedor", id);

            var lista = contexto.ProvProd.Where(prov => prov.proveedorID == id).ToList();
            var productos = contexto.Productos.ToList();
            var aEliminar = new List<ProductosModel>();

            foreach (ProductosModel producto in productos)
            {
               
                bool esta = false;
                foreach (ProvProdModel item in lista)
                {
                    if (item.productoID == producto.ID && item.proveedorID==id)
                    {
                        esta = true;
                    }
                }

                if (!esta)
                {
                    aEliminar.Add(producto);
                }
            }

            
            foreach (var item in aEliminar)
            {
                productos.Remove(item);
            }

            

            ViewBag.pedidosProductos = new MultiSelectList(productos, "ID", "nomProducto");
            return View();
        }

        // POST: PedidosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidosModel pedido)
        {
            try
            {
                contexto.Pedidos.Add(pedido);
                contexto.SaveChanges();

                foreach(var item in pedido.listaProductos)
                {
                    var obj = new PedidosProductosModel() { productoID = item, pedidoID = pedido.ID };
                    contexto.PedidosProductos.Add(obj);
                }

                contexto.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
