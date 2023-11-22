public class Card {
    public int IdCard {set; get;}
    public int Likes {set; get;}
    public int DisLikes {set; get;}
    public string Portada {set; get;}
    public string Titulo { set;  get;}
    public string Descripcion { set;  get;}
   
   // constructor
    public Card() {
        IdCard = 0;
        Likes = 0;
        DisLikes = 0;
        Portada = "";
        Titulo = "";
        Descripcion = "";
    }
    public Card(int idCard, string portada, string titulo, string descripcion, int likes, int dislikes) {
        IdCard = idCard;
        Portada = portada;
        Titulo = titulo;
        Descripcion = descripcion;
        Likes = likes;
        DisLikes = dislikes;
    }
}