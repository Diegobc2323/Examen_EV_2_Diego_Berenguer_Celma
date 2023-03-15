using Examen_EV_2_Diego_Berenguer_Celma.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen_EV_2_Diego_Berenguer_Celma.Controllers
{
    public class ProveedoresController : Controller
    {

        private readonly Contexto contexto;

        public ProveedoresController(Contexto contexto)
        {
            this.contexto = contexto;
        }


        // GET: ProveedoresController
        public ActionResult Index()
        {
            ViewBag.pedidos = contexto.Pedidos.ToList();
            var lista = contexto.Proveedores.Include(p => p.pedidos).ToList();

            return View(lista);
        }

        // GET: ProveedoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProveedoresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProveedoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProveedoresModel proveedor)
        {
            try
            {
                contexto.Proveedores.Add(proveedor);
                contexto.Database.EnsureCreated();
                contexto.SaveChanges();
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProveedoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProveedoresController/Edit/5
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

        // GET: ProveedoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProveedoresController/Delete/5
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
