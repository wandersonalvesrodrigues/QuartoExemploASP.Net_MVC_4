using CadeMeuMedicoMVC.Models.DTO;
using CadeMeuMedicoMVC.Util;
using Dominio;
using System;
using System.Web;
using System.Web.Security;

namespace CadeMeuMedicoMVC.Models.Business
{
    public class UsuarioBL
    {
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            var autenticado = false;
            var usuario = UsuarioDTO.AutenticarUsuario(Login, SenhaCriptografada);

            if (usuario != null)
            {
                autenticado = true;
                var IDUsuario = usuario.IDUsuario;
                Cookies.RegistraCookieAutenticacao(IDUsuario);
            }
            return autenticado;
        }

        public static Usuario VerificaSeOUsuarioEstaLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];

            if (Usuario == null)
            {
                return null;
            }
            else
            {
                int IDUsuario = Convert.ToInt32(Criptografia.
                Descriptografar(Usuario.Values["IDUsuario"]));
                var UsuarioRetornado = UsuarioDTO.RecuperaUsuarioPorID(IDUsuario);
                return UsuarioRetornado;
            }
        }
    }
}