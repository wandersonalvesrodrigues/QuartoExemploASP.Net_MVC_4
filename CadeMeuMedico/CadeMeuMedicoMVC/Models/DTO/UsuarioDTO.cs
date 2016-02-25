using Dominio;
using Dominio.Repositorio;

namespace CadeMeuMedicoMVC.Models.DTO
{
    public class UsuarioDTO
    {
        public static Usuario AutenticarUsuario(string Login, string SenhaCriptografada)
        {
            var usuariosRepository = new UsuarioRepositorio(Contexto.GetContexto());
            return usuariosRepository.AutenticarUsuario(Login, SenhaCriptografada);
        }

        public static Usuario RecuperaUsuarioPorID(int id)
        {
            var usuariosRepository = new UsuarioRepositorio(Contexto.GetContexto());
            return usuariosRepository.RecuperaUsuarioPorID(id);
        }
    }
}