public class User {
    public int IdUsuario {set; get;}
    public string Nombre {set; get;}
    public string Apellido { set;  get;}
    public string Contraseña { set;  get;}
    public string PaisOrigen { set;  get;}
    public int PeliculaFav { set;  get;}
   
   // constructor
    public User() {
        IdUsuario = 0;
        Nombre = "";
        Apellido = "";
        Contraseña = "";
        PaisOrigen = "";
        PeliculaFav = 0;
    }
    public User(int idUsuario, string nombre, string apellido, string contraseña, string paisOrigen, int peliculaFav) {
        IdUsuario = idUsuario;
        Nombre = nombre;
        Apellido = apellido;
        Contraseña = contraseña;
        PaisOrigen = paisOrigen;
        PeliculaFav = peliculaFav;
    }
}