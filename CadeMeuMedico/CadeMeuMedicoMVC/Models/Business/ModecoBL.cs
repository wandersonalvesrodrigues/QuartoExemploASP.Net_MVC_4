using AutoMapper;
using CadeMeuMedicoMVC.Models.DTO;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuMedicoMVC.Models.Business
{
    public class ModecoBL
    {
        public static void InserirMedico(MedicoViewModel medicoViewModel)
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MedicoViewModel, Medico>();
                });
            var mapper = config.CreateMapper();
            var medico = mapper.Map<MedicoViewModel, Medico>(medicoViewModel);
            medico.Especialidade = new Especialidade { IDEspecialidade = medicoViewModel.IDEspecialidade };
            medico.Cidade = new Cidade { IDCidade = medicoViewModel.IDCidade };

            MedicoDTO.InserirMedico(medico);
        }

        public static ICollection<Cidade> BuscaCidades()
        {
            return MedicoDTO.BuscaCidades();
        }

        public static ICollection<Especialidade> BuscaEspecialidades()
        {
            return MedicoDTO.BuscaEspecialidades();
        }

        public static ICollection<Medico> BuscaMedicos()
        {
            return MedicoDTO.BuscaMedicos();
        }

        public static Medico BuscaMedicoPorId(long id)
        {
            return MedicoDTO.BuscaMedicoPorId(id);
        }

        public static MedicoViewModel BuscaMedicoViewModelPorId(long id)
        {
            var medico = MedicoDTO.BuscaMedicoPorId(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Medico,MedicoViewModel>();
            });
            var mapper = config.CreateMapper();
            var medicoViewModel = mapper.Map<Medico, MedicoViewModel>(medico);
            medicoViewModel.IDEspecialidade = medico.Especialidade.IDEspecialidade;
            medicoViewModel.IDCidade = medico.Cidade.IDCidade;

            return medicoViewModel;
        }

        public static void AtualizaMedico(MedicoViewModel medicoViewModel)
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MedicoViewModel, Medico>();
                });
            var mapper = config.CreateMapper();
            var medico = mapper.Map<MedicoViewModel, Medico>(medicoViewModel);
            medico.Especialidade = new Especialidade { IDEspecialidade = medicoViewModel.IDEspecialidade };
            medico.Cidade = new Cidade { IDCidade = medicoViewModel.IDCidade };

            MedicoDTO.AtualizaMedico(medico);
        }

        public static void DeletaMedico(int id)
        {

            MedicoDTO.DeletaMedico(id);
        }
    }
}