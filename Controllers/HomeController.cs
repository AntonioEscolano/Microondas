using System.Diagnostics;
using Microondas.Models;
using Microsoft.AspNetCore.Mvc;
using Microondas.Manager;

namespace Microondas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Acao _Acao = new Acao();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public JsonResult RecebeDados(EntredaViewModel _dados)
        {
            if (_dados != null)
            {
                _dados = _Acao.VerificaDados(_dados);
            }
            
            return Json(_dados);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
