public class Reseña {
    public int IdReseña {set; get;}
    public int IdUsuario { set;  get;}
    public int IdPelicula { set;  get;}
    public string ReseñaTxt { set;  get;}
    public string NombreUsuario { set;  get;}
    public string NombrePelicula { set;  get;}
   
   // constructor
    public Reseña() {
        IdUsuario = 0;
        IdPelicula = 0;
        ReseñaTxt = "";
        NombreUsuario = "";
        NombrePelicula = "";
    }
    public Reseña(int idUsuario, int idPelicula, string reseñaTxt, string nombreUsuario,string nombrePelicula) {
        IdUsuario = idUsuario;
        IdPelicula = idPelicula;
        ReseñaTxt = reseñaTxt;
        NombreUsuario = nombreUsuario;
        NombrePelicula = nombrePelicula;
    }
}