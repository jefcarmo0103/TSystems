using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Mappers;
using WebApplication2.Services;
using WebApplication2.Utils;
using WebApplication2.Utils.Response;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private LutadorMapper _mapper;
        private LutadorService _service;

        public HomeController()
        {
            _mapper = new LutadorMapper();
            _service = new LutadorService();
            
        }

        public ActionResult Index()
        {
            StaticFighters.setAllFighters(_service.listarLutadores());
            var _lutadores = StaticFighters.getAllFighters().Select(x => _mapper.entityToResponse(x)).ToList();

            return View(_lutadores);
        }

        [HttpPost]
        public ActionResult Campeonato(string[] parameters)
        {
            var lutadores = StaticFighters.getAllFighters().Select(x => _mapper.entityToResponse(x)).ToList();

            var result = _service.comecarLutas(lutadores.FindAll(x => parameters.Contains(x.Id.ToString()))
                .Select(k => _mapper.responseToEntity(k)).ToList());

            var vencedor = _mapper.entityToResponse(result);

            return Json(new { result = "Redirect", url = Url.Action("CampeonatoResultado", "Home", new { id = vencedor.Id }) });
        }

        public ActionResult CampeonatoResultado(int id)
        {
            var vencedor = StaticFighters.getAllFighters().Select(x => _mapper.entityToResponse(x)).FirstOrDefault(y => y.Id == id);

            return View(vencedor);
        }
    }
}