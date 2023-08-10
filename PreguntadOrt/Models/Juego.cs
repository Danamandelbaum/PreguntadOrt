public static class Juego
{
    private static string _username{get;  set;}
    private static int _puntajeActual{get;  set;}
    private static int _cantidadPreguntasCorrectas{get;  set;}
    private static list <Pregunta> _preguntas{get;  set;}
    private static list <Respuestas> _respuestas{get;  set;}

    private static void InicializarJuego()
    {
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }


    private static void CargarPartida(string username, int dificultad, int categoria)
    {
        foreach (string pregunta in ObtenerPreguntas)
        {
            list <Pregunta>.Add(pregunta);
        }
         foreach (string rta in ObtenerRtas)
        {
            list <Respuestas>.Add(rta);
        }
    }

    private static void ObtenerProximaPregunta()
    {
       
    }

}