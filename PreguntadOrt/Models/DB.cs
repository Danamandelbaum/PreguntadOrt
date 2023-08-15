using Dapper;
using System.Data.SqlClient;

public static class BD
{
    private static string _connectionString = @"Server = localhost; Database=PreguntOrt; Trusted_Connection = True;";

    private static List<Categorias> listarCategorias = new list <Categorias>();
    public static List<Categorias> ObtenerCategorias()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Categorias";
            listarCategorias =  DB.Query<Categorias>(SQL).ToList();
        }
    } 

    private static List<Dificultades> listarDificultades = new list<Dificultades>();
    public static List<Dificultades> ObtenerDificultades()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Dificultades";
            listarDificultades =  DB.Query<Dificultades>(SQL).ToList();
        }
    } 

    private static List<Pregunta> listarPreguntas = new list<Pregunta>();
    public static List<Pregunta>  ObtenerPreguntas(int dificultad, int categoria)
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Pregunta  WHERE IdCategoria = @categoria and IdDificultad = @dificultad";
            if (dificultad = -1)
            {
                SQL = "SELECT * FROM Pregunta  WHERE IdCategoria = @categoria";
            }
            else if (categoria = -1)
            {
                SQL = "SELECT * FROM Pregunta  WHERE IdDificultad = @dificultad";
            }
            
            listarPreguntas =  DB.Query<Pregunta>(SQL, new {dificultad = IdDificultad, categoria = IdCategoria}).ToList();
        }
    } 

    private static List<Respuestas> listarRtas = new List<Respuestas>();
    public static List<Respuestas> ObtenerRtas (List<Pregunta> listarPreguntas)
    {
        foreach (Pregunta pregunta in listarPreguntas)
        {
            using (SqlConnection DB = new SqlConnection(_connectionString))
            {
                string SQL = "SELECT * FROM Respuestas WHERE Enunciado = @pregunta";
                listarRtas =  DB.Query<Respuestas>(SQL, new {pregunta = Enunciado}).ToList();
            }
        }
    } 
}