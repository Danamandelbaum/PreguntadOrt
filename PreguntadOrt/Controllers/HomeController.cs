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
        ViewBag.dificultad = Juego.ObtenerDificultades();
        ViewBag.categoria = Juego.ObtenerCategorias(); 
        return View("ConfigurarJuego");

    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        if (Juego.ObtenerProximaPregunta() != null )
        {
            return RedirectToAction("Jugar");
        }
        else
        {
            return RedirectToAction("ConfigurarJuego");
        }
        return View("Comenzar");
    }

    public IActionResult Jugar()
    {
        ViewBag.PreguntaAResponder = Juego.ObtenerProximaPregunta();
        if (ViewBag.PreguntaAResponder == null)
        {
            return View ("Fin");
        }
        else
        {
            ViewBag.Respuestas = Juego.ObtenerProximaRespuesta(ViewBag.PreguntaAResponder.IdPregunta);
            return View ("Juego");
        }
        return View();
    }

    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool rtaCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        ViewBag.rtaCorrecta = rtaCorrecta;
        return View("VerificarRespuesta");
    }

    
}
