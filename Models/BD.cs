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
     public static void AgregarReseña(int idUsuario,int idPelicula,string texto,string nombreUsuario,string nombrePelicula) {
        string sql = "INSERT INTO Reseña(IdUsuario,IdPelicula,ReseñaTxt,NombreUsuario,NombrePelicula,Likes,DisLikes) VALUES (@pIdUsuario,@pIdPelicula,@pReseñaTxt,@pNombreUsuario,@pNombrePelicula,0,0)";
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            db.Execute(sql, new {pIdUsuario = idUsuario, pIdPelicula = idPelicula, pReseñaTxt = texto, pNombreUsuario = nombreUsuario, pNombrePelicula = nombrePelicula});
        }
    }
       public static User Login(string username, string contrasena) {
        User MiUser = new User();
        
        using(SqlConnection db = new SqlConnection(_connectionString)) {
                string sql = "SELECT * FROM Usuario WHERE UserName = @pUserName AND Contrasena = @pContrasena";
                MiUser = db.QueryFirstOrDefault<User>(sql, new {pUserName = username, pContrasena = contrasena});
            
        }
        return MiUser;
    }
   
}