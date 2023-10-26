public class ReseñaCard {
    public Card Pelicula { set;  get;}
    public User User { set;  get;}
    public Reseña Reseña { set;  get;}
   
   // constructor
       public ReseñaCard() {
        Pelicula = new Card();
        User = new User();
        Reseña = new Reseña();
    }
    public ReseñaCard(Card pelicula, User user, Reseña reseña) {
        Pelicula = pelicula;
        User = user;
        Reseña = reseña;
    }
}