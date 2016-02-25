using Dominio;
using Dominio.Repositorio;
using System.Collections.Generic;

namespace CadeMeuMedicoMVC.Models.DTO
{
    public class MedicoDTO
    {
        public static void InserirMedico(Medico medico)
        {
            var medicoRepository = new MedicoRepositorio(Contexto.GetContexto());
            medicoRepository.Inserir(medico);
        }

        public static ICollection<Cidade> BuscaCidades()
        {
            var cidadesRepository = new CidadeRepositorio(Contexto.GetContexto());
            return cidadesRepository.BuscaCidades();
        }

        public static ICollection<Especialidade> BuscaEspecialidades()
        {
            var especialidadesRepository = new EspecialidadeRepositorio(Contexto.GetContexto());
            return especialidadesRepository.BuscaEspecialidades();
        }

        public static ICollection<Medico> BuscaMedicos()
        {
            var medicosRepository = new MedicoRepositorio(Contexto.GetContexto());
            return medicosRepository.BuscaMedicos();
        }

        public static Medico BuscaMedicoPorId(long id)
        {
            var medicosRepository = new MedicoRepositorio(Contexto.GetContexto());
            return medicosRepository.BuscaMedicosPorId(id);
        }

        public static void AtualizaMedico(Medico medico)
        {
            var medicosRepository = new MedicoRepositorio(Contexto.GetContexto());
            medicosRepository.Atualizar(medico);
        }

        public static void DeletaMedico(int id)
        {
            var medicosRepository = new MedicoRepositorio(Contexto.GetContexto());
            medicosRepository.Deletar(id);
        }
    }
}