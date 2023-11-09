public class UsuarioActivo {
    public static int IdUsuario {get; private set;} = 0;
    public static string Nombre {get; private set;} = "";
    public static string Apellido {get; private set;} = "";
    public static string Contraseña {get; private set;} = "";
    public static string PaisOrigen {get; private set;} = "";
    public static int PeliculaFav {get; private set;} = 0;
    public UsuarioActivo(int idUsuario, string nombre, string apellido, string contraseña, string paisOrigen, int peliculaFav) {
        IdUsuario = idUsuario;
        Nombre = nombre;
        Apellido = apellido;
        Contraseña = contraseña;
        PaisOrigen = paisOrigen;
        PeliculaFav = peliculaFav;
    }
    public static User DevolverUser() {
        User UsuarioActivo = new User(IdUsuario,Nombre,Apellido,Contraseña,PaisOrigen,PeliculaFav);
        return UsuarioActivo;
    }
}