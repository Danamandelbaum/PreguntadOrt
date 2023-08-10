using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadOrt.Models;

namespace PreguntadOrt.Controllers;

public class HomeController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
     
        Juego.InicializarJuego();
        ViewBag.dificultad = Dificultades;
        ViewBag.categoria=Categorias; 
        return View();

    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        return View();
    }

    public IActionResult Jugar()
    {
        return View();
    }

    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        return View();
    }

    
}
