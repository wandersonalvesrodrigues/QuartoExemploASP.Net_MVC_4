using DataAcessADO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorio
{
    public class MedicoRepositorio : Repository<Medico>
    {
        public MedicoRepositorio(AdoNetContext context)
            : base(context)
        {
        }

        public void Inserir(Medico medicos)
        {
            if (medicos != null)
            {
                using (var command = _context.CreateCommand())
                {
                    var query = new StringBuilder();
                    query.Append("INSERT INTO Medicos").Append(" ").Append("([CRM],[Nome],[Endereco],[Bairro],[Email],[AtendePorConvenio],[TemClinica],[WebsiteBlog],[IDCidade],[IDEspecialidade])").Append(" ");
                    query.Append("VALUES(@CRM,@Nome,@Endereco,@Bairro,@Email,@AtendePorConvenio,@TemClinica,@WebsiteBlog,@IDCidade,@IDEspecialidade)").Append(" ");

                    #region[Parametros]
                    IDbDataParameter parameter = null;

                    #region[CRM]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@CRM";
                    if (string.IsNullOrEmpty(medicos.CRM))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.CRM;
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Nome]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@Nome";
                    if (string.IsNullOrEmpty(medicos.Nome))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.Nome;
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Endereço]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@Endereco";
                    if (string.IsNullOrEmpty(medicos.Endereco))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.Endereco;
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Bairro]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@Bairro";
                    if (string.IsNullOrEmpty(medicos.Bairro))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.Bairro;
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[E-mail]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@Email";
                    if (string.IsNullOrEmpty(medicos.Email))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.Email;
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Atende por Convênio]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@AtendePorConvenio";
                    parameter.Value = medicos.AtendePorConvenio;
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Tem Clinica]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@TemClinica";
                    parameter.Value = medicos.TemClinica;
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Blog]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@WebsiteBlog";
                    if (string.IsNullOrEmpty(medicos.WebsiteBlog))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.WebsiteBlog;
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Cidade]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@IDCidade";
                    if (medicos.Cidade == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        if (medicos.Cidade.IDCidade == 0)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        else
                        {
                            parameter.Value = medicos.Cidade.IDCidade;
                        }
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #region[Especialiadde]
                    parameter = command.CreateParameter();
                    parameter.ParameterName = "@IDEspecialidade";
                    if (medicos.Especialidade == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        if (medicos.Especialidade.IDEspecialidade == 0)
                        {
                            parameter.Value = DBNull.Value;
                        }
                        else
                        {
                            parameter.Value = medicos.Especialidade.IDEspecialidade;
                        }
                    }
                    command.Parameters.Add(parameter);
                    #endregion
                    #endregion

                    command.CommandText = query.ToString();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(Medico medicos)
        {
            using (var command = _context.CreateCommand())
            {
                var query = new StringBuilder();
                query.Append("UPDATE [Medicos]").Append(" ");
                query.Append("SET").Append(" ");
                query.Append("[CRM]").Append("=").Append("@CRM").Append(",");
                query.Append("[Nome]").Append("=").Append("@Nome").Append(",");
                query.Append("[Endereco]").Append("=").Append("@Endereco").Append(",");
                query.Append("[Bairro]").Append("=").Append("@Bairro").Append(",");
                query.Append("[Email]").Append("=").Append("@Email").Append(",");
                query.Append("[AtendePorConvenio]").Append("=").Append("@AtendePorConvenio").Append(",");
                query.Append("[TemClinica]").Append("=").Append("@TemClinica").Append(",");
                query.Append("[WebsiteBlog]").Append("=").Append("@WebsiteBlog").Append(",");
                query.Append("[IDCidade]").Append("=").Append("@IDCidade").Append(",");
                query.Append("[IDEspecialidade]").Append("=").Append("@IDEspecialidade").Append(" ");
                query.Append("WHERE [IDMedico]").Append("=").Append("@ID").Append(" ");

                #region[Parametros]
                IDbDataParameter parameter = null;
                #region[IDMedico]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = medicos.IDMedico;
                command.Parameters.Add(parameter);
                #endregion
                #region[CRM]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@CRM";
                if (string.IsNullOrEmpty(medicos.CRM))
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = medicos.CRM;
                }
                command.Parameters.Add(parameter);
                #endregion
                #region[Nome]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Nome";
                if (string.IsNullOrEmpty(medicos.Nome))
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = medicos.Nome;
                }
                command.Parameters.Add(parameter);
                #endregion
                #region[Endereço]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Endereco";
                if (string.IsNullOrEmpty(medicos.Endereco))
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = medicos.Endereco;
                }
                command.Parameters.Add(parameter);
                #endregion
                #region[Bairro]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Bairro";
                if (string.IsNullOrEmpty(medicos.Bairro))
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = medicos.Bairro;
                }
                command.Parameters.Add(parameter);
                #endregion
                #region[E-mail]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@Email";
                if (string.IsNullOrEmpty(medicos.Email))
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = medicos.Email;
                }
                command.Parameters.Add(parameter);
                #endregion
                #region[Atende por Convênio]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@AtendePorConvenio";
                parameter.Value = medicos.AtendePorConvenio;
                command.Parameters.Add(parameter);
                #endregion
                #region[Tem Clinica]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@TemClinica";
                parameter.Value = medicos.TemClinica;
                command.Parameters.Add(parameter);
                #endregion
                #region[Blog]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@WebsiteBlog";
                if (string.IsNullOrEmpty(medicos.WebsiteBlog))
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    parameter.Value = medicos.WebsiteBlog;
                }
                command.Parameters.Add(parameter);
                #endregion
                #region[Cidade]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@IDCidade";
                if (medicos.Cidade == null)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    if (medicos.Cidade.IDCidade == 0)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.Cidade.IDCidade;
                    }
                }
                command.Parameters.Add(parameter);
                #endregion
                #region[Especialiadde]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@IDEspecialidade";
                if (medicos.Especialidade == null)
                {
                    parameter.Value = DBNull.Value;
                }
                else
                {
                    if (medicos.Especialidade.IDEspecialidade == 0)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    else
                    {
                        parameter.Value = medicos.Especialidade.IDEspecialidade;
                    }
                }
                command.Parameters.Add(parameter);
                #endregion
                #endregion

                command.CommandText = query.ToString();
                command.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = @"DELETE FROM [Medicos] WHERE [IDMedico] = @ID";

                #region[IDMedico]
                IDbDataParameter parameter = null;
                parameter = command.CreateParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = id;
                command.Parameters.Add(parameter);
                #endregion

                command.ExecuteNonQuery();
            }
        }

        public ICollection<Medico> BuscaMedicos()
        {
            var medicoCollection = new Collection<Medico>();

            using (var command = _context.CreateCommand())
            {
                var strSelect = new StringBuilder();
                strSelect.Append("SELECT m.[IDMedico],m.[CRM],m.[Nome],m.[Endereco],m.[Bairro],m.[Email],m.[AtendePorConvenio],m.[TemClinica],m.[WebsiteBlog],m.[IDCidade],m.[IDEspecialidade],c.Nome as nomeCidade,e.Nome as nomeEspecialidade").Append(" ");
                strSelect.Append("FROM [CadeMeuMedicoBD].[dbo].[Medicos] as m").Append(" ");
                strSelect.Append("INNER JOIN [CadeMeuMedicoBD].[dbo].[Cidades] as c ON m.IDCidade = c.IDCidade").Append(" ");
                strSelect.Append("INNER JOIN [CadeMeuMedicoBD].[dbo].[Especialidades] as e ON m.IDEspecialidade = e.IDEspecialidade").Append(" ");

                command.CommandText = strSelect.ToString();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var medico = new Medico();
                        var cidade = new Cidade();
                        var especialiade = new Especialidade();

                        medico.IDMedico = Convert.ToInt32(reader["IDMedico"]);
                        medico.CRM = reader["CRM"].ToString();
                        medico.Nome = reader["Nome"].ToString();
                        medico.Endereco = reader["Endereco"].ToString();
                        medico.Bairro = reader["Bairro"].ToString();
                        medico.Email = reader["Email"].ToString();
                        medico.AtendePorConvenio = Convert.ToBoolean(reader["AtendePorConvenio"]);
                        medico.TemClinica = Convert.ToBoolean(reader["TemClinica"]);
                        medico.WebsiteBlog = reader["WebsiteBlog"].ToString();

                        cidade.IDCidade = Convert.ToInt32(reader["IDCidade"]);
                        cidade.Nome = reader["nomeCidade"].ToString();
                        medico.Cidade = cidade;
                        especialiade.IDEspecialidade = Convert.ToInt32(reader["IDEspecialidade"]);
                        especialiade.Nome = reader["nomeEspecialidade"].ToString();
                        medico.Especialidade = especialiade;

                        medicoCollection.Add(medico);
                    }
                }
                return medicoCollection;
            }
        }

        public Medico BuscaMedicosPorId(long id)
        {
            var medico = new Medico();

            using (var command = _context.CreateCommand())
            {
                IDbDataParameter parameter = null;

                var query = new StringBuilder();
                query.Append("SELECT m.[IDMedico],m.[CRM],m.[Nome],m.[Endereco],m.[Bairro],m.[Email],m.[AtendePorConvenio],m.[TemClinica],m.[WebsiteBlog],m.[IDCidade],m.[IDEspecialidade],c.Nome as nomeCidade,e.Nome as nomeEspecialidade").Append(" ");
                query.Append("FROM [CadeMeuMedicoBD].[dbo].[Medicos] as m").Append(" ");
                query.Append("INNER JOIN [CadeMeuMedicoBD].[dbo].[Cidades] as c ON m.IDCidade = c.IDCidade").Append(" ");
                query.Append("INNER JOIN [CadeMeuMedicoBD].[dbo].[Especialidades] as e ON m.IDEspecialidade = e.IDEspecialidade").Append(" ");
                query.Append("WHERE m.[IDMedico] = @ID").Append(" ");

                #region[ID]
                parameter = command.CreateParameter();
                parameter.ParameterName = "@ID";
                parameter.Value = id;
                command.Parameters.Add(parameter);
                #endregion

                command.CommandText = query.ToString();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cidade = new Cidade();
                        var especialiade = new Especialidade();

                        medico.IDMedico = Convert.ToInt32(reader["IDMedico"]);
                        medico.CRM = reader["CRM"].ToString();
                        medico.Nome = reader["Nome"].ToString();
                        medico.Endereco = reader["Endereco"].ToString();
                        medico.Bairro = reader["Bairro"].ToString();
                        medico.Email = reader["Email"].ToString();
                        medico.AtendePorConvenio = Convert.ToBoolean(reader["AtendePorConvenio"]);
                        medico.TemClinica = Convert.ToBoolean(reader["TemClinica"]);
                        medico.WebsiteBlog = reader["WebsiteBlog"].ToString();

                        cidade.IDCidade = Convert.ToInt32(reader["IDCidade"]);
                        cidade.Nome = reader["nomeCidade"].ToString();
                        medico.Cidade = cidade;
                        especialiade.IDEspecialidade = Convert.ToInt32(reader["IDEspecialidade"]);
                        especialiade.Nome = reader["nomeEspecialidade"].ToString();
                        medico.Especialidade = especialiade;
                    }
                }
                return medico;
            }
        }
    }
}
