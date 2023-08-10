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
        ViewBag.dificultad = DB.ObtenerDificultades();
        ViewBag.categoria = DB.ObtenerCategorias(); 
        return View();

    }

    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida();
        if (Juego.ObtenerProximaPregunta())
        {
            return RedirectToAction("Jugar");
        }
        else
        {
            return RedirectToAction("ConfigurarJuego");
        }
        return View();
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
            viewBag.Respuestas = Juego.ObtenerProximaRespuesta();
            return View ("Juego");
        }
        return View();
    }

    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool rtaCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        viewBag.rtaCorrecta = respuestaCorrecta;
        return View();
    }

    
}
