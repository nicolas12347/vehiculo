using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repaso2.Controllers
{
    using System.Security.Principal;
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string contraseña)
        {
            if (IsValidUser(usuario, contraseña))            
            {
                Session["username"] = usuario; // Guardar el nombre de usuario en la sesión (esto es solo un ejemplo básico)
                return RedirectToAction("Index", "Vehiculo"); // Redirigir a la página principal
            }
            else
            {
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear(); // Limpiar la sesión al cerrar sesión
            return RedirectToAction("Index", "Home"); // Redirigir a la página principal
        }

        private bool IsValidUser(string usuario, string contraseña)
        {
            // Verificar las credenciales (solo para fines demostrativos, no es seguro)
            return (usuario == "usuario" && contraseña == "nico123");
        }
    }
}


