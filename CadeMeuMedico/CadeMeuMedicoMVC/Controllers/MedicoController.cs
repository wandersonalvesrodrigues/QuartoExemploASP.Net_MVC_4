using CadeMeuMedicoMVC.Models;
using CadeMeuMedicoMVC.Models.Business;
using System;
using System.Web.Mvc;

namespace CadeMeuMedicoMVC.Controllers
{
    public class MedicoController : BaseController
    {
        public ActionResult Index()
        {
            var medicos = ModecoBL.BuscaMedicos();
            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            //Cidades
            var allCidades = ModecoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = ModecoBL.BuscaEspecialidades();

            //No formulário de cadastro do Médicos,essas informações serão apresentadas em um ComboBox (ou Dropdownlist).No caso de HTML, 
            //o ComboBox é representado pelo elemento select.
            //Nas propriedades dinâmicas da ViewBag retornarmos já o elemento que será apresentado na View. Para isso utilizamos o helper SelectList
            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
                ModecoBL.InserirMedico(medicoViewModel);
                return RedirectToAction("Index");
            }

            //Cidades
            var allCidades = ModecoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = ModecoBL.BuscaEspecialidades();

            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome", medicoViewModel.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome", medicoViewModel.IDEspecialidade);

            return View(medicoViewModel);
        }

        public ActionResult Editar(int id)
        {
            var medicoViewModel = ModecoBL.BuscaMedicoViewModelPorId(id);

            //Cidades
            var allCidades = ModecoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = ModecoBL.BuscaEspecialidades();

            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome", medicoViewModel.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome", medicoViewModel.IDEspecialidade);

            return View(medicoViewModel);
        }

        [HttpPost]
        public ActionResult Editar(MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
                ModecoBL.AtualizaMedico(medicoViewModel);
                return RedirectToAction("Index");
            }

            //Cidades
            var allCidades = ModecoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = ModecoBL.BuscaEspecialidades();

            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome", medicoViewModel.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome", medicoViewModel.IDEspecialidade);

            return View(medicoViewModel);
        }

        public ActionResult Excluir(int id)
        {
            var medico = ModecoBL.BuscaMedicoPorId(id);
            ModecoBL.DeletaMedico(id);
            return RedirectToAction("Index");
        }
    }
}
