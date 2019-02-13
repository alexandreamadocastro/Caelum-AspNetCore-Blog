﻿using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDAO _dao;

        public UsuarioController(UsuarioDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _dao.Busca(model.Login, model.Senha);

                if (usuario != null)
                {
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                }
            }

            return View("Login", model);
        }
    }
}