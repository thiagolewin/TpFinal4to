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
            return View("login");
        }
        ViewBag.Cards = BD.MisCards("Select * from Card");
        return View();
    }
    public IActionResult Pelicula(string pelicula)
    {
        ViewBag.Card = BD.MisCards("Select * from Card where IdCard = " + pelicula)[0];
        ViewBag.Usuario = UsuarioActivo.DevolverUser();
        int total_likes = ViewBag.Card.Likes + ViewBag.Card.DisLikes;
        ViewBag.Estrellas = (ViewBag.Card.Likes/total_likes) * 5;
        ViewBag.Reseñas = BD.Reseñas("Select * from Reseña where IdPelicula = " + pelicula);
        return View("Pelicula");
    }
    public IActionResult Perfil() {
        return View("Perfil");
    }
    public IActionResult EnviarReseña(int idUsuario,int idPelicula,string texto,string nombreUsuario,string nombrePelicula) {
        BD.AgregarReseña(idUsuario,idPelicula,texto,nombreUsuario,nombrePelicula);
        return RedirectToAction("Pelicula", new { pelicula = idPelicula });
    }
    public IActionResult Login(string usuario, string Contrasena) {
    
        User userActivo = BD.Login(usuario, Contrasena);
       
        //if(userActivo != null || userActivo.PeliculaFav == null ) {
        if (userActivo != null){
            UsuarioActivo.AgregarUser(userActivo.IdUsuario,userActivo.UserName,userActivo.Nombre,userActivo.Apellido,userActivo.Contrasena,userActivo.PaisOrigen,userActivo.PeliculaFavorita);
            ViewBag.Cards = BD.MisCards("Select * from Card");
            return View("Index");
        } else {
            return View("Login");
        }


    }
      public IActionResult Register(string username, string Contrasena) {
        User userActivo = BD.Login(username, Contrasena);
        if(userActivo != null || userActivo.PeliculaFavorita == null ) {
           return View("Index");
        } else {
            
            UsuarioActivo.AgregarUser(userActivo.IdUsuario,userActivo.UserName,userActivo.Nombre,userActivo.Apellido,userActivo.Contrasena,userActivo.PaisOrigen,userActivo.PeliculaFavorita);
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
