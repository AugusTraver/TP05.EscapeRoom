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
}
