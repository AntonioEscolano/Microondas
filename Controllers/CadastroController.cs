using Microondas.Data;
using Microondas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Microondas.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult VerificarSimbolo(string _simbolo)
        {
            try
            {
                int _qtd = _context.Programacao.Where(p => p.stringDeAquecimento.Trim() == _simbolo.Trim()).ToList().Count();
                bool _existe = false;

                if (_qtd > 0)
                {
                    _existe = true;
                }

                return Json(_existe);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
        public ActionResult CadastroProgramacao(ProgramacaoModel _model)
        {
            try
            {
                bool _sucesso = false;
                object _resultado = new object();

                if (!String.IsNullOrEmpty(_model.nomeDaProgramacao))
                {
                    _resultado = _context.Add(_model).State;
                }

                if (_resultado.ToString() == "Added")
                {
                    _sucesso = true;
                }
                return RedirectToAction("Index", _model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
