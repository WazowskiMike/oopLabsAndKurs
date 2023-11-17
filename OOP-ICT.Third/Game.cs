using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class Game {
    public static DealerAdapter dealerForThisGame;
    public Game() {
        dealerForThisGame = new DealerAdapter(new CardDeck());
        dealerForThisGame.Shuffle();
    }

    public void AddPlayers(string name, double deposit) {
        
    }
}