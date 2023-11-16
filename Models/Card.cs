public class Card {
    public int IdCard {set; get;}
    public string Portada {set; get;}
    public string Titulo { set;  get;}
    public string Descripcion { set;  get;}
   
   // constructor
    public Card() {
        IdCard = 0;
        Portada = "";
        Titulo = "";
        Descripcion = "";
    }
    public Card(int idCard, string portada, string titulo, string descripcion) {
        IdCard = idCard;
        Portada = portada;
        Titulo = titulo;
        Descripcion = descripcion;
    }
}