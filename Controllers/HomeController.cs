using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp05.EscapeRoom.Models;

namespace Tp05.EscapeRoom.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult InicializarJuego(string NomUsu)
    {
        Escaperoom EscapeRoom = new Escaperoom(NomUsu);
        HttpContext.Session.SetString("1", Objeto.ObjectToString(EscapeRoom));
        return RedirectToAction("MandarNivel");
    }
    public IActionResult DTutorial()
    {
        return View("Tutorial");
    }
    public IActionResult DContexto()
    {
        return View("Contexto");
    }
    public IActionResult DCreditos()
    {
        return View("Creditos");
    }

    public IActionResult CompararRespuesta(string respuesta)
    {
        Escaperoom EscapeRoom = Objeto.StringToObject<Escaperoom>((HttpContext.Session.GetString("1")));
        bool Resultado = EscapeRoom.CompararRespuesta(respuesta);
        HttpContext.Session.SetString("2", Objeto.ObjectToString(EscapeRoom));
        return RedirectToAction("MandarNivel");
    }
    public IActionResult MandarNivel()
    {
        Escaperoom EscapeRoom = Objeto.StringToObject<Escaperoom>((HttpContext.Session.GetString("2")));
        string Nivel = "Sala1";
        if (EscapeRoom.nivel == 2)
        {
            Nivel = "Sala2";
        }
        else if (EscapeRoom.nivel == 3)
        {
            Nivel = "Sala3";
        }
        else if (EscapeRoom.nivel == 4)
        {
            Nivel = "Sala4";
        }
        else if (EscapeRoom.nivel == 5)
        {
            Nivel = "Sala5";
        }
        HttpContext.Session.SetString("3", Objeto.ObjectToString(EscapeRoom));
        return View(Nivel);
    }
    public IActionResult DevolverPista()
    {
        Escaperoom EscapeRoom = Objeto.StringToObject<Escaperoom>((HttpContext.Session.GetString("3")));
        ViewBag.Pista = EscapeRoom.DevolverPista();
        return RedirectToAction("Pista");
    }
    public IActionResult DPapel()
    {
        return View("Papel");
    }
}

