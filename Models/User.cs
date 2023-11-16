public class User {
    public int IdUsuario {set; get;}
    public string UserName {set; get;}
    public string Nombre {set; get;}
    public string Apellido { set;  get;}
    public string Contrasena { set;  get;}
    public string PaisOrigen { set;  get;}
    public string PeliculaFavorita { set;  get;}
    public string Idioma { set;  get;}
   
   // constructor
    public User() {
        IdUsuario = 0;
        UserName = "";
        Nombre = "";
        Apellido = "";
        Contrasena = "";
        PaisOrigen = "";
        PeliculaFavorita = "";
        Idioma = "";
    }
    public User(int idUsuario, string userName, string nombre, string apellido, string Contrasena, string paisOrigen, string peliculaFav, string idioma) {
        IdUsuario = idUsuario;
        UserName = userName;
        Nombre = nombre;
        Apellido = apellido;
        Contrasena = Contrasena;
        PaisOrigen = paisOrigen;
        PeliculaFavorita = peliculaFav;
        Idioma = idioma;
    }
}