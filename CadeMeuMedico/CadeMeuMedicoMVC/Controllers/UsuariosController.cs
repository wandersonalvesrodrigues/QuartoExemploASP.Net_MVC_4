using CadeMeuMedicoMVC.Models.Business;
using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Controllers
{
    public class UsuariosController : Controller
    {
        [HttpGet]
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (UsuarioBL.AutenticarUsuario(Login, Senha))
            {
                return Json(new
                {
                    OK = true,
                    Mensagem = "Usuário autenticado. Redirecionando..."
                },
                JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    OK = false,
                    Mensagem = "Usuário não encontrando. Tente novamente."
                },
                JsonRequestBehavior.AllowGet);
            }
        }
    }
}
