using Repaso2.Dato;
using Repaso2.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Repaso2.Controllers
{
    public class VehiculoController : Controller
    {
        VehiculoAdmi admi = new VehiculoAdmi();
        // GET: Vehiculo
        [AutorizacionVehiculoFilter]
        public ActionResult Index()
        {
            IEnumerable<Vehiculo> lista = admi.Consultar();
            ViewBag.mensaje = "";
            return View(lista);
        }

        [AutorizacionVehiculoFilter]
        public ActionResult Guardar() {
            ViewBag.mensaje = "";
            return View();
        }
        [AutorizacionVehiculoFilter]
        public ActionResult Nuevo(Vehiculo modelo) {
            admi.Guardar(modelo);
            ViewBag.mensaje = "vehiculo guardado";
            return View("Guardar", modelo);
        }
        [AutorizacionVehiculoFilter]
        public ActionResult Detalle(int id=0) {
            Vehiculo modelo = admi.consultar(id);
            return View(modelo);
        }
        [AutorizacionVehiculoFilter]
        public ActionResult Modificar(int id=0) {
            Vehiculo modelo = admi.consultar(id);
            ViewBag.mensaje = "";
            return View(modelo);
        }
        [AutorizacionVehiculoFilter]
        public ActionResult Actualizar(Vehiculo modelo) {
            admi.Modificar(modelo);
            ViewBag.mensaje = "vehiculo Modificado";
            return View("Modificar", modelo);
        }

        [AutorizacionVehiculoFilter]
        public ActionResult Eliminar(int id = 0) {
            Vehiculo modelo = new Vehiculo() {
                Id=id
            };
            admi.Eliminar(modelo);
            IEnumerable<Vehiculo> lista = admi.Consultar();
            ViewBag.mensaje = "vehiculo Eliminado";
            return View("Index", lista);
        }
    }
}
