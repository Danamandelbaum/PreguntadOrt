using Dapper;
using System.Data.SqlClient;

public static class BD
{
    private static string _connectionString = @"Server = localhost; Database=PreguntOrt; Trusted_Connection = True;";

    private static list<Categorias> listarCategorias = new list<Categorias>();
    public static list<Categorias> ObtenerCategorias()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Categorias"
            listarCategorias =  DB.Query<Categorias>(SQL).ToList();
        }
    } 

    private static list<listarDificultades> listarDificultades = new list<Dificultades>();
    public static list<Dificultades> ObtenerDificultades()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Dificultades"
            listarDificultades =  DB.Query<Dificultades>(SQL).ToList();
        }
    } 

    private static list<Pregunta> listarPreguntas = new list<Pregunta>();
    public static list<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Categorias WHERE Dificultad = @dificultad and Categoria = @categoria"
            listarPreguntas =  DB.Query<Pregunta>(SQL, new {dificultad = Dificultad}, new {categoria = Categoria}).ToList();
        }
    } 

    private static list<Respuestas> listarRtas = new list<Respuestas>();
    public static list<Respuestas> ObtenerRtas(List<Pregunta> preguntas)
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Categorias WHERE Dificultad = @dificultad and Categoria = @categoria"
            listarRtas =  DB.Query<Respuestas>(SQL, new {dificultad = Dificultad}).ToList();
        }
    } 
}