using Dapper;
using System.Data.SqlClient;
namespace PreguntadOrt.Models;
public static class BD
{
    private static string _connectionString = @"Server = localhost; Database=PreguntOrt; Trusted_Connection = True;";

    private static List<Categorias> listarCategorias = new List<Categorias>();
    public static List<Categorias> ObtenerCategorias()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Categorias";
            listarCategorias =  DB.Query<Categorias>(SQL).ToList();
        }
        return listarCategorias;
    } 

    private static List<Dificultades> listarDificultades = new List<Dificultades>();
    public static List<Dificultades> ObtenerDificultades()
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Dificultades";
            listarDificultades =  DB.Query<Dificultades>(SQL).ToList();
        }
        return listarDificultades;
    } 

    private static List<Pregunta> listarPreguntas = new List<Pregunta>();
    public static List<Pregunta>  ObtenerPreguntas(int IdDificultad, int IdCategoria)
    {
        using (SqlConnection DB = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Pregunta  WHERE IdCategoria = @categoria and IdDificultad = @dificultad";
            if (IdDificultad== -1)
            {
                SQL = "SELECT * FROM Pregunta  WHERE categoria = @IdCategoria";
            }
            else if (IdCategoria == -1)
            {
                SQL = "SELECT * FROM Pregunta  WHERE dificultad = @IdDificultad";
            }
            
            listarPreguntas =  DB.Query<Pregunta>(SQL, new {dificultad = IdDificultad, categoria = IdCategoria}).ToList();
        }
        return listarPreguntas;
    } 

    private static List<Respuestas> listarRtas = new List<Respuestas>();
    public static List<Respuestas> ObtenerRtas (List<Pregunta> listarPreguntas)
    {
        foreach (Pregunta pregunta in listarPreguntas)
        {
            using (SqlConnection DB = new SqlConnection(_connectionString))
            {
                string SQL = "SELECT * FROM Respuestas where IdPregunta = @IdPregunta ";
                listarRtas.Add( DB.QueryFirstOrDefault<Respuestas>(SQL, new { IdPregunta = pregunta.IdPregunta})) ;
            }
        }
        return listarRtas;
    } 
}