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
            var medicos = MedicoBL.BuscaMedicos();
            return View(medicos);
        }

        public ActionResult Adicionar()
        {
            //Cidades
            var allCidades = MedicoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = MedicoBL.BuscaEspecialidades();

            //No formulário de cadastro do Médicos,essas informações serão apresentadas em um ComboBox (ou Dropdownlist).No caso de HTML, 
            //o ComboBox é representado pelo elemento select.
            //Nas propriedades dinâmicas da ViewBag retornarmos já o elemento que será apresentado na View. Para isso utilizamos o helper SelectList
            //Esta ViewBag recebe uma estrutura DropDownList que é criada através da classe SelectList e os parâmetros utilizados são: 
            //Source, Value, Name (Origem do dado [Método ListarClientes], valor do elemento e nome a ser exibido). 
            //Estes parâmetros precisam coincidir com as propriedades da estrutura do seu dado (classe Cliente).
            //Para o Razor HtmlHelper criar corretamente seu DropDownList basta informar (no formato String) o 
            //nome da ViewBag que contém a estrutura de dados, foi adicionado um segundo parâmetro para criar um elemento em 
            //branco na primeira posição, assim evitando que o primeiro item seja selecionado por engano.

            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
                MedicoBL.InserirMedico(medicoViewModel);
                return RedirectToAction("Index");
            }

            //Cidades
            var allCidades = MedicoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = MedicoBL.BuscaEspecialidades();

            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome", medicoViewModel.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome", medicoViewModel.IDEspecialidade);

            return View(medicoViewModel);
        }

        public ActionResult Editar(int id)
        {
            var medicoViewModel = MedicoBL.BuscaMedicoViewModelPorId(id);

            //Cidades
            var allCidades = MedicoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = MedicoBL.BuscaEspecialidades();

            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome", medicoViewModel.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome", medicoViewModel.IDEspecialidade);

            return View(medicoViewModel);
        }

        [HttpPost]
        public ActionResult Editar(MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
                MedicoBL.AtualizaMedico(medicoViewModel);
                return RedirectToAction("Index");
            }

            //Cidades
            var allCidades = MedicoBL.BuscaCidades();
            //Especialidades
            var allEspecialidades = MedicoBL.BuscaEspecialidades();

            ViewBag.IDCidade = new SelectList(allCidades, "IDCidade", "Nome", medicoViewModel.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(allEspecialidades, "IDEspecialidade", "Nome", medicoViewModel.IDEspecialidade);

            return View(medicoViewModel);
        }

        public ActionResult Excluir(int id)
        {
            var medico = MedicoBL.BuscaMedicoPorId(id);
            MedicoBL.DeletaMedico(id);
            return RedirectToAction("Index");
        }
    }
}
