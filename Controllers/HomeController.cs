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
            ViewBag.StartTime = startTime.ToString("O");
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
        else if (EscapeRoom.nivel == 6)
        {
           return RedirectToAction("MostrarResultado");
        }
        @ViewBag.nombre = EscapeRoom.NomUsu;
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
    public IActionResult MostrarResultado()
{
    var startStr = HttpContext.Session.GetString("StartTime");
    string tiempoFinal = "00:00";

    if (DateTime.TryParse(startStr, out DateTime startTime))
    {
        var tiempoTotal = DateTime.Now - startTime;
        int totalSeconds = (int)tiempoTotal.TotalSeconds;

        int horas = totalSeconds / 3600;
        int minutos = (totalSeconds % 3600) / 60;
        int segundos = totalSeconds % 60;

        tiempoFinal = (horas > 0 ? $"{horas:D2}:" : "") +
                      $"{minutos:D2}:{segundos:D2}";
    }

    Escaperoom escape = Objeto.StringToObject<Escaperoom>(HttpContext.Session.GetString("EscapeRoom"));
    ViewBag.TiempoFinal = tiempoFinal;
    ViewBag.Nombre = escape.NomUsu;

    // Limpiar la sesión si querés
    // HttpContext.Session.Clear();

    return View(MostrarResultado);
}
}

