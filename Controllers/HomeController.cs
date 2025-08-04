using System.Diagnostics;
using Microondas.Models;
using Microsoft.AspNetCore.Mvc;
using Microondas.Manager;
using Microondas.Data;
using Microondas.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Microondas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public AcaoManager _acaoManager = new AcaoManager();

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                ProgramacaoViewModel _programacaoViewModel = new ProgramacaoViewModel();
                _programacaoViewModel._programacao = _context.Programacao.ToList();
                return View(_programacaoViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RecebeDados(EntredaVW _dados)
        {
            try
            {
                if (_dados != null)
                {
                    _dados = _acaoManager.VerificaDados(_dados);
                }

                return Json(_dados);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult RecebeDadosProgramacao(int _id)
        {
            try
            {
                ProgramacaoModel _programacao = new ProgramacaoModel();
                ProgramacaoVW _programacaoVW = new ProgramacaoVW();
                if (_id > 0)
                {
                    _programacao = _context.Programacao.Where(p => p.idProgramacao == _id).FirstOrDefault();

                    _programacaoVW.idProgramacao = _programacao.idProgramacao;
                    _programacaoVW.nomeDaProgramacao = _programacao.nomeDaProgramacao;
                    _programacaoVW.alimento = _programacao.alimento;
                    _programacaoVW.tempo = _acaoManager.TrataTempo(_programacao.tempo);
                    _programacaoVW.potencia = _programacao.potencia;
                    _programacaoVW.stringDeAquecimento = _programacao.stringDeAquecimento;
                    _programacaoVW.instrucoesComplementares = _programacao.instrucoesComplementares;
                }

                return Json(_programacaoVW);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
