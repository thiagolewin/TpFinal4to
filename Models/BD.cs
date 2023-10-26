using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
public static class BD {
    private static string _connectionString = @"Server=localhost;DataBase=TPFinalBD;Trusted_Connection=True;";
    
    public static List<Card> MisCards() {
        List<Card> misCards = new List<Card>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Cards";
            misCards = db.Query<Card>(sql).ToList();
        }
        return misCards;
    }
    
    public static List<Actor> ListarActores(int idSerie) {
        List<Actor> MisActores = new List<Actor>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Actores WHERE IdSerie = " + idSerie;
            MisActores = db.Query<Actor>(sql).ToList();
        }
        return MisActores;
    }

     public static Serie Descripcion(int idSerie) {
        Serie descripcion = new Serie();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT Sinopsis FROM Series WHERE IdSerie = " + idSerie;
            descripcion = db.QueryFirstOrDefault<Serie>(sql);
        }
        return descripcion;
    }

     public static List<Temporada> Temporada(int idSerie) {
        List<Temporada> temporada = new List<Temporada>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Temporadas WHERE IdSerie = " + idSerie;
            temporada = db.Query<Temporada>(sql).ToList();
        }
        return temporada;
    }

     public static Info Informacion() {
        Info informacion = new Info();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = "SELECT * FROM Info";
            informacion = db.QueryFirstOrDefault<Info>(sql);
        }
        return informacion;
    }
}