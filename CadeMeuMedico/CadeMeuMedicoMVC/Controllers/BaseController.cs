using CadeMeuMedicoMVC.Filtros;
using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Controllers
{
    [AutorizacaoDeAcesso]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
