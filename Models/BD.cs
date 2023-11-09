using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Dapper;
public static class BD {
    private static string _connectionString = @"Server=localhost;DataBase=TPFinalBD;Trusted_Connection=True;";
    
    public static List<Card> MisCards(string condition) {
        List<Card> misCards = new List<Card>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = condition;
            misCards = db.Query<Card>(sql).ToList();
        }
        return misCards;
    }
    
    public static List<Reseña> Reseñas(string condition) {
        List<Reseña> misReseñas = new List<Reseña>();
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            string sql = condition;
            misReseñas = db.Query<Reseña>(sql).ToList();
        }
        return misReseñas;
    }
     public static void AgregarReseña(Reseña reseña) {
        string sql = "INSERT INTO Reseña(IdUsuario,IdPelicula,ReseñaTxt,NombreUsuario,NombrePelicula) VALUES (@pIdUsuario,@pIdPelicula,@pReseñaTxt,@pNombreUsuario,@pNombrePelicula)";
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            db.Execute(sql, new {pIdUsuario = reseña.IdUsuario, pIdPelicula = reseña.IdPelicula, pReseñaTxt = reseña.ReseñaTxt, pNombreUsuario = reseña.NombreUsuario, pNombrePelicula = reseña.NombrePelicula});
        }
    }
}