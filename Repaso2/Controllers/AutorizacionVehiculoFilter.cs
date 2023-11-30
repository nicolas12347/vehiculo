using System;
using System.Web.Mvc;

public class AutorizacionVehiculoFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        // Verificar si el usuario está autenticado
        if (filterContext.HttpContext.Session["username"] == null)
        {
            // Redireccionar a una página de acceso denegado o inicio de sesión
            filterContext.Result = new RedirectResult("~/Account/Login");
        }
        else
        {
            // El usuario está autenticado, permitir el acceso a la acción
            base.OnActionExecuting(filterContext);
        }
    }
}
