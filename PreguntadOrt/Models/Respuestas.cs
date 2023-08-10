namespace PreguntadOrt.Models;

public class Respuestas
{
    public int IdRespuesta {get;private set;}
    public int IdPregunta {get;private set;}
    public int Opcion {get;private set;}
    public string Contenido {get;private set;}
    public bool Correcta {get;private set;}
}