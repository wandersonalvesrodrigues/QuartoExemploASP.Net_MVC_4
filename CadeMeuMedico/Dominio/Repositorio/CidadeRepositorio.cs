using DataAcessADO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Dominio.Repositorio
{
    public class CidadeRepositorio : Repository<Cidade>
    {
        public CidadeRepositorio(AdoNetContext context)
            : base(context)
        {
        }

        public ICollection<Cidade> BuscaCidades()
        {
            var cidadeCollection = new Collection<Cidade>();

            using (var command = _context.CreateCommand())
            {
                var strSelect = new StringBuilder();
                strSelect.Append("SELECT [IDCidade],[Nome] FROM [Cidades]").Append(" ");
                command.CommandText = strSelect.ToString();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cidade = new Cidade();
                        cidade.IDCidade = Convert.ToInt32(reader["IDCidade"]);
                        cidade.Nome = reader["Nome"].ToString();

                        cidadeCollection.Add(cidade);
                    }
                }
                return cidadeCollection;
            }
        }
    }
}
