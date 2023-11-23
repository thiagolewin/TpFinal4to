using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_Final_4IC.Models;

namespace TP_Final_4IC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if(UsuarioActivo.DevolverUser().IdUsuario == 0) {
            return View("Login");
        }
        ViewBag.Usuario = UsuarioActivo.DevolverUser();
        ViewBag.Cards = BD.MisCards("Select * from Card");
        return View();
    }
    public IActionResult Filtrado() {
                ViewBag.Usuario = UsuarioActivo.DevolverUser();
        ViewBag.Cards = BD.MisCards("Select * from Card");
        return View("Filtrado");
    }
    public IActionResult ReseñasFilt(string cond) {
        ViewBag.Usuario = UsuarioActivo.DevolverUser();
        ViewBag.Reseñas = BD.Reseñas(cond);
        return View("Reseñas");
    }
    public IActionResult Reseñas() {
        ViewBag.Usuario = UsuarioActivo.DevolverUser();
        ViewBag.Reseñas = BD.Reseñas("Select * from Reseña");
        return View("Reseñas");
    }
    public IActionResult Filtrar(string cond) {
        ViewBag.Usuario = UsuarioActivo.DevolverUser();
        ViewBag.Cards = BD.MisCards(cond);
        return View("Filtrado");
    }
    public IActionResult ViewRegister() {
        return View("Registro");
    }
    public IActionResult ViewLogin() {
        return View("Login");
    }
    public IActionResult Pelicula(string pelicula)
    {
        ViewBag.Card = BD.MisCards("Select * from Card where IdCard = " + pelicula)[0];
        ViewBag.Usuario = UsuarioActivo.DevolverUser();


        ViewBag.Reseñas = BD.Reseñas("Select * from Reseña where IdPelicula = " + pelicula);
        return View("Pelicula");
    }
    public IActionResult DisLikeReseña() {

        return View();
    }
    public IActionResult Perfil() {
        ViewBag.Usuario = UsuarioActivo.DevolverUser();
        ViewBag.Reseñas = BD.Reseñas("Select * from Reseña where IdUsuario = " + ViewBag.Usuario.IdUsuario);
        return View("Perfil");
    }
    public IActionResult EnviarReseña(int idUsuario,int idPelicula,string texto,string nombreUsuario,string nombrePelicula) {
        if(texto == null) {
            return RedirectToAction("Pelicula", new { pelicula = idPelicula });
        }
        BD.AgregarReseña(idUsuario,idPelicula,texto,nombreUsuario,nombrePelicula);
        return RedirectToAction("Pelicula", new { pelicula = idPelicula });
    }
    public IActionResult Cerrar() {
        UsuarioActivo.AgregarUser(0,"","","","","","","");
        return View("Login");
    }
    public User EditarInfo(string username, string campo, string data)
    {
         BD.ActualizarInfo(username,campo,data);
         User userActivo = BD.ExisteUser(username);
         UsuarioActivo.AgregarUser(userActivo.IdUsuario,userActivo.UserName,userActivo.Nombre,userActivo.Apellido,userActivo.Contrasena,userActivo.PaisOrigen,userActivo.PeliculaFavorita,userActivo.Idioma);
        ViewBag.Usuario = UsuarioActivo.DevolverUser();
        return UsuarioActivo.DevolverUser();
    }    
    public IActionResult Login(string usuario, string Contrasena) {
    
        User userActivo = BD.Login(usuario, Contrasena);
       
        //if(userActivo != null || userActivo.PeliculaFav == null ) {
        if (userActivo != null){
            UsuarioActivo.AgregarUser(userActivo.IdUsuario,userActivo.UserName,userActivo.Nombre,userActivo.Apellido,userActivo.Contrasena,userActivo.PaisOrigen,userActivo.PeliculaFavorita,userActivo.Idioma);
            ViewBag.Usuario = UsuarioActivo.DevolverUser();
            ViewBag.Cards = BD.MisCards("Select * from Card");
            return View("Index");
        } else {
            return View("Login");
        }


    }
      public IActionResult Register(string Nombre,string Apellido, string UserName, string Contraseña,string Mail,string Telefono) {
        if (BD.ExisteUser(UserName) == null) {
            BD.AgregarUser(Nombre,Apellido,UserName,Contraseña,Mail,Telefono);
            User userActivo = BD.Login(UserName, Contraseña);
            UsuarioActivo.AgregarUser(userActivo.IdUsuario,userActivo.UserName,userActivo.Nombre,userActivo.Apellido,userActivo.Contrasena,userActivo.PaisOrigen,userActivo.PeliculaFavorita,userActivo.Idioma);
             ViewBag.Usuario = UsuarioActivo.DevolverUser();
            ViewBag.Cards = BD.MisCards("Select * from Card");
            return View("Index");
        } else {
            @ViewBag.Incorrecto = "Ya existe un user creado con ese username";                     
            return View("Registro");
        }

        return View("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
