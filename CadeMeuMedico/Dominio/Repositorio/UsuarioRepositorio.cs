using DataAcessADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class UsuarioRepositorio : Repository<Usuario>
    {
        public UsuarioRepositorio(AdoNetContext context)
            : base(context)
        {
        }

        public Usuario AutenticarUsuario(string Login, string Senha)
        {
            Usuario usuario = null;
            using (var command = _context.CreateCommand())
            {
                IDbDataParameter parameter = null;

                var query = new StringBuilder();
                query.Append("SELECT [IDUsuario] FROM [Usuarios]").Append(" ");
                query.Append("WHERE [Login] = @Login").Append(" ").Append("AND").Append(" ").Append("[Senha] = @Senha").Append(" ");

                #region[Login]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Login";
                parameter.Value = Login;
                command.Parameters.Add(parameter);
                #endregion

                #region[Senha]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Senha";
                parameter.Value = Senha;
                command.Parameters.Add(parameter);
                #endregion

                command.CommandText = query.ToString();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.IDUsuario = Convert.ToInt32(reader["IDUsuario"]);
                    }
                }
                return usuario;
            }
        }

        public Usuario RecuperaUsuarioPorID(int IDUsuario)
        {
            Usuario usuario = null;
            using (var command = _context.CreateCommand())
            {
                IDbDataParameter parameter = null;

                var query = new StringBuilder();
                query.Append("SELECT [IDUsuario],[Nome],[Login],[Senha],[Email] FROM [Usuarios]").Append(" ");
                query.Append("WHERE [IDUsuario] = @ID").Append(" ");

                #region[IDUsuario]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = IDUsuario;
                command.Parameters.Add(parameter);
                #endregion

                command.CommandText = query.ToString();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario();

                        usuario.IDUsuario = Convert.ToInt32(reader["IDUsuario"]);
                        usuario.Nome = reader["Nome"].ToString();
                        usuario.Login = reader["Login"].ToString();
                        usuario.Senha = reader["Senha"].ToString();
                        usuario.Email = reader["Email"].ToString();
                    }
                }
            }

            return usuario;
        }
    }
}
