namespace PreguntadOrt.Models;
public static class Juego
{
    private static string _username{get;  set;}
    private static int _puntajeActual{get;  set;}
    private static int _cantidadPreguntasCorrectas{get;  set;}
    private static List<Pregunta> _preguntas{get;  set;}
    private static List<Respuestas> _respuestas{get;  set;}
    public static int NumeroPregunta{get; set;}

    public static void InicializarJuego()
    {
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
        _preguntas = new List<Pregunta>();
        _respuestas = new List<Respuestas>();
    }

    public static List<Categorias> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        return BD.ObtenerDificultades();
    }


    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        _username = username;
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRtas(_preguntas);
    }

    public static Pregunta ObtenerProximaPregunta()
    {
       if (_preguntas.Count == 0)
        {
            return null;
        }

        Random random = new Random();
        int num = random.Next(_preguntas.Count);
        Pregunta PreguntaActual = _preguntas[num];
        _preguntas.Remove(PreguntaActual);
        NumeroPregunta++;
        return PreguntaActual;
    }

    private static List<Respuestas> ListarProximasRespuestas = new List<Respuestas>();
    public static List<Respuestas> ObtenerProximaRespuesta(int IdPregunta)
    {
       for (int i = 0; i < _respuestas.Count; i++)
        {
           if (_respuestas[i].IdPregunta == IdPregunta) 
           {
                ListarProximasRespuestas.Add(_respuestas[i]);
           }
        }
        return ListarProximasRespuestas;
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool respuestaCorrecta = false;
        if (idPregunta == idRespuesta)
        {
            _puntajeActual = _puntajeActual + 5;
            _cantidadPreguntasCorrectas++;
            return respuestaCorrecta = true;
        }
        else
        {
            return respuestaCorrecta;
        }
    }

}











