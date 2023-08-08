public static class Juego
{
    private static string _username{get; private set;}
    private static int _puntajeActual{get; private set;}
    private static int _cantidadPreguntasCorrectas{get; private set;}
    private static List<Pregunta> _preguntas{get; private set;}
    private static List<Respuesta> _respuestas{get; private set;}

    private static InicializarJuego()
    {
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }

    private static ObtenerCategorias()
    {
        return listarCategorias;
    }

    private static ObtenerDificultades()
    {
        return listarDificultades;
    }

    private static CargarPartida(string username, int dificultad, int categoria)
    {
        foreach (string pregunta in ObtenerPreguntas)
        {
            List<ObtenerPreguntas>.Add(pregunta);
        }
         foreach (string rta in ObtenerRtas)
        {
            List<ObtenerRtas>.Add(rta);
        }
    }

}