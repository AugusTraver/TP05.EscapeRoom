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
        HttpContext.Session.SetString("EscapeRoom", Objeto.ObjectToString(EscapeRoom));
        HttpContext.Session.SetString("StartTime", DateTime.Now.ToString("O"));
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
         if (string.IsNullOrWhiteSpace(respuesta))
        return RedirectToAction("MandarNivel");

        Escaperoom EscapeRoom = Objeto.StringToObject<Escaperoom>(HttpContext.Session.GetString("EscapeRoom"));
        EscapeRoom.CompararRespuesta(respuesta.ToUpper().Replace(" ", ""));
        HttpContext.Session.SetString("EscapeRoom", Objeto.ObjectToString(EscapeRoom));
        return RedirectToAction("MandarNivel");
    }
    public IActionResult MandarNivel()
    {
        Escaperoom EscapeRoom = Objeto.StringToObject<Escaperoom>(HttpContext.Session.GetString("EscapeRoom"));
            DateTime startTime;
        if (DateTime.TryParse(HttpContext.Session.GetString("StartTime"), out startTime))
        {
        ViewBag.StartTime = startTime.ToString("O"); // Pasamos el tiempo al ViewBag
        } 
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
        return View(Nivel);
    }
    public IActionResult DevolverPista()
    {
        Escaperoom EscapeRoom = Objeto.StringToObject<Escaperoom>(HttpContext.Session.GetString("EscapeRoom"));
        ViewBag.Pista = EscapeRoom.DevolverPista();
        return View("Pista");
    }
    public IActionResult DPapel()
    {
        return View("Papel");
    }
    public IActionResult DLockers()
    {
        return View("Lockers");
    }
}

