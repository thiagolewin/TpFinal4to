public class Card {
    public int IdCard {set; get;}
    public string Portada {set; get;}
    public string Titulo { set;  get;}
    public int Likes { set;  get;}
    public int DisLikes { set;  get;}
    public string Descripcion { set;  get;}
   
   // constructor
    public Card() {
        IdCard = 0;
        Portada = "";
        Titulo = "";
        Likes = 0;
        DisLikes = 0;
        Descripcion = "";
    }
    public Card(int idCard, string portada, string titulo, int likes, int disLikes, string descripcion) {
        IdCard = idCard;
        Portada = portada;
        Titulo = titulo;
        Likes = likes;
        DisLikes = disLikes;
        Descripcion = descripcion;
    }
}