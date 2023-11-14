using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrabalhoCRUD_MVC.Models;
using TrabalhoCRUD_MVC.Services;

namespace TrabalhoCRUD_MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServices _services;

        public ClienteController(IServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var result = _services.Read();
            return View(result);
        }

        public IActionResult Clientes()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var result = _services.Create(cliente);
                if (result)
                {
                    TempData["Result"] = "Usuario Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }
                TempData["Result"] = "Usuario Não resgistrado error";

            }
            return View("Create");
        }

        public IActionResult Update(int id)
        {
            var cliente = _services.GetById(id);
            return View(cliente);
        }

        [HttpPost]
        public IActionResult UpdateCliente(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                var result = _services.Update(cliente);
                if (result)
                {
                    TempData["Result"] = "Usuario Modificado Com Sucesso";
                    return RedirectToAction("Index");
                }
                TempData["Result"] = "Impossivel Atualizar Usuario";

            }
            return View("Update");
        }

        public IActionResult Delete(int id)
        {
            var cliente = _services.GetById(id);
            return View(cliente);
        }

        public IActionResult DeleteCliente(int id)
        {
            var result = _services.Delete(id);
            if (result)
            {
                TempData["Result"] = "Usuario Deletado Com Sucesso";
                return RedirectToAction("Index");
            }
            TempData["Result"] = "Impossivel Deletar Usuario";
            return RedirectToAction("Index");
        }

    }
}
