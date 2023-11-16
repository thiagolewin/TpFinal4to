public class UsuarioActivo {
    public static int IdUsuario {get; private set;} = 0;
    public static string UserName {get; private set;} = "";
    public static string Nombre {get; private set;} = "";
    public static string Apellido {get; private set;} = "";
    public static string Contrasena {get; private set;} = "";
    public static string PaisOrigen {get; private set;} = "";
    public static string PeliculaFavorita {get; private set;} = "";
    public static string Idioma {get; private set;} = "";
    public static void AgregarUser(int idUsuario, string userName, string nombre, string apellido, string Contrasena, string paisOrigen, string peliculaFav, string idioma) {
        IdUsuario = idUsuario;
        UserName = userName;
        Nombre = nombre;
        Apellido = apellido;
        Contrasena = Contrasena;
        PaisOrigen = paisOrigen;
        PeliculaFavorita = peliculaFav;
        Idioma = idioma;
    }
    public static User DevolverUser() {
        User UsuarioActivo = new User(IdUsuario,UserName,Nombre,Apellido,Contrasena,PaisOrigen,PeliculaFavorita,Idioma);
        return UsuarioActivo;
    }
}