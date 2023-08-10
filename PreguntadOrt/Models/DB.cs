using Dapper;
using System.Data.SqlClient;

public static class BD
{
    private static string _connectionString = @"Server = localhost; Database=PreguntOrt; Trusted_Connection = True;";

    public static list <int> listarCategorias = new list <int>();
    private static void ObtenerCategorias()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Categorias";
            listarCategorias =  DB.Query<Categorias>(SQL).ToList();
        }
    } 

    public static list <int> listarDificultades = new list<int>();
    private static void ObtenerDificultades()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Dificultades";
            listarDificultades =  DB.Query<Dificultades>(SQL).ToList();
        }
    } 

    public static list <Pregunta> listarPreguntas = new list<Pregunta>();
    private static void  ObtenerPreguntas(int dificultad, int categoria)
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Categorias WHERE Dificultad = @dificultad and Categoria = @categoria";
            listarPreguntas =  DB.Query<Pregunta>(SQL, new {dificultad = Dificultad}, new {categoria = Categoria}).ToList();
        }
    } 

    public static list <Respuestas> listarRtas = new list <Respuestas>();
    private static void ObtenerRtas (list <Pregunta> preguntas)
    {
        
    } 
}