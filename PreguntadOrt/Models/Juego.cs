public static class Juego
{
    private static string _username{get;  set;}
    private static int _puntajeActual{get;  set;}
    private static int _cantidadPreguntasCorrectas{get;  set;}
    private static List<Pregunta> _preguntas{get;  set;}
    private static List<Respuestas> _respuestas{get;  set;}

    private static void InicializarJuego()
    {
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
        _preguntas = new List<Pregunta>();
        _respuestas = new List<Respuestas>();
    }

    public static List <Categorias> ObtenerCategorias()
    {
        return DB.ObtenerCategorias();
    }

    public static List <Dificultades> ObtenerDificultades()
    {
        return DB.ObtenerDificultades();
    }


    private static void CargarPartida(string username, int dificultad, int categoria)
    {
        username = username;
        _preguntas = DB.ObtenerPreguntas(dificultad, categoria);
        _respuestas = DB.ObtenerRtas(_preguntas);
    }

    public static Pregunta ObtenerProximaPregunta()
    {
       if (_preguntas.Count == 0)
        {
            return null;
        }

        Random random = new Random();
        int num = random.Next(_preguntas.Count);
        PreguntaActual = _preguntas[num];
        _preguntas.RemoveAt(num);

        NumeroPregunta++;
        return PreguntaActual;
    }

    public static List<Respuestas> ObtenerProximaRespuesta()
    {
       _preguntas.Remove(PreguntaActual);
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        bool respuestaCorrecta = false;
        if (idPregunta == idRespuesta)
        {
            _puntajeActual = _puntajeActual + 5;
            _cantidadPreguntasCorrectas++;
            listarPreguntas.RemoveAt(idPregunta);
            return respuestaCorrecta = true;
        }
        else
        {
            return respuestaCorrecta;
        }
    }

}