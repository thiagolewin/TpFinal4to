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
    public static void ActualizarInfo(string username, string campo, string data) {
        using(SqlConnection db = new SqlConnection(_connectionString)) {
        switch (campo) {
            case "PaisOrigen":
                string sql = "UPDATE Usuario SET PaisOrigen = @pData WHERE UserName = @pUserName";
                db.Execute(sql, new {@pCampo = campo, @pData = data, pUserName = username});
                break;
            case "Idioma":
                 sql = "UPDATE Usuario SET Idioma = @pData WHERE UserName = @pUserName";
                db.Execute(sql, new {@pCampo = campo, @pData = data, pUserName = username});
                break;
            case "PeliculaFavorita":
                 sql = "UPDATE Usuario SET PeliculaFavorita = @pData WHERE UserName = @pUserName";
                db.Execute(sql, new {@pCampo = campo, @pData = data, pUserName = username});
                break;
        }
    }
    }
     public static User ExisteUser(string username) {
        User MiUser = new User();
        
        using(SqlConnection db = new SqlConnection(_connectionString)) {
                string sql = "SELECT * FROM Usuario WHERE UserName = @pUserName";
                MiUser = db.QueryFirstOrDefault<User>(sql, new {pUserName = username});
            
        }
        return MiUser;
    }
     public static void AgregarUser(string Nombre, string Apellido, string UserName, string Contraseña, string Mail, string Telefono) {
        string sql = "INSERT INTO Usuario(Nombre,Apellido,Contrasena,PaisOrigen,PeliculaFavorita,UserName,Idioma,admin) VALUES (@pNombre,@pApellido,@pContrasena,'','',@pUserName,'',0)";
        using(SqlConnection db = new SqlConnection(_connectionString)) {
            db.Execute(sql, new {pNombre = Nombre, pApellido = Apellido, pContrasena = Contraseña,pUserName = UserName});
        }
    }
   
}