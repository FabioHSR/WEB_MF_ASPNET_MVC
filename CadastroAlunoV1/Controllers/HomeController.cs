using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBMF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBMF.DAO;

namespace WEBMF.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
            if (ViewBag.Logado == true)
                return RedirectToAction("Index", "OS");
            else
                return View();
        }

        public IActionResult FazLogin(string usuario, string senha)
        {
            LoginDAO lDao = new LoginDAO();
            if (lDao.VerificaUsuario(usuario,senha))
            {
                HttpContext.Session.SetString("Logado", "true");
                ViewBag.Logado = HelperControllers.VerificaUserLogado(HttpContext.Session);
                return RedirectToAction("Index", "OS");
            }
            else
            {
                ViewBag.Erro = "Usuário ou senha inválidos!";
                return View("Index");
            }
        }

        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}