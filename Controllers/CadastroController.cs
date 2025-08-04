using Microsoft.AspNetCore.Mvc;

namespace Microondas.Controllers
{
    public class CadastroController : Controller
    {
        //Route("[Controller]")]
        //[Route("[Controller]/Cadastro")]
        public IActionResult Index()
        {
            return View();
        }



        //[Route("[Controller]/Cadastro")]
    }
}
