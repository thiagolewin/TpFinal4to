public class Reseña {
    public int IdReseña {set; get;}
    public int IdUsuario { set;  get;}
    public int IdPelicula { set;  get;}
    public string ReseñaTxt { set;  get;}
   
   // constructor
    public Reseña() {
        IdReseña = 0;
        IdUsuario = 0;
        IdPelicula = 0;
        ReseñaTxt = "";
    }
    public Reseña(int idReseña, int idUsuario, int idPelicula, string reseñaTxt) {
        IdReseña = idReseña;
        IdUsuario = idUsuario;
        IdPelicula = idPelicula;
        ReseñaTxt = reseñaTxt;
    }
}