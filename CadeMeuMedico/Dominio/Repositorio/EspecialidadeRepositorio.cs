using DataAcessADO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class EspecialidadeRepositorio : Repository<Especialidade>
    {
        public EspecialidadeRepositorio(AdoNetContext context)
            : base(context)
        {
        }

        public ICollection<Especialidade> BuscaEspecialidades()
        {
            var especialidadeCollection = new Collection<Especialidade>();

            using (var command = _context.CreateCommand())
            {
                var strSelect = new StringBuilder();
                strSelect.Append("SELECT [IDEspecialidade],[Nome] FROM [Especialidades]").Append(" ");
                command.CommandText = strSelect.ToString();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var especialidade = new Especialidade();
                        especialidade.IDEspecialidade = Convert.ToInt32(reader["IDEspecialidade"]);
                        especialidade.Nome = reader["Nome"].ToString();

                        especialidadeCollection.Add(especialidade);
                    }
                }
                return especialidadeCollection;
            }
        }
    }
}
