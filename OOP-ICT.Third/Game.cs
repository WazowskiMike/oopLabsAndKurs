using System.Runtime.ConstrainedExecution;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class Game {
    private List<Player> playerList = new List<Player>();
    private int chipPrice;

    public Game() {
        CardDeck cardDeck = new CardDeck();
        DealerAdapter dealer = new DealerAdapter(cardDeck);
        
        
    }

    public void Start() {
        Console.WriteLine("Пожалуйста, введите цену одной фишки ");
        chipPrice = int.Parse(Console.ReadLine());
        AddPlayers();

    }

    public void AddPlayers() {
        while (Console.ReadLine().Trim() != ""){
            Console.WriteLine("Пожалуйста, введите имя игрока ");
            string name = Console.ReadLine();
            Console.WriteLine("Пожалуйста, введите баланс");
            double deposit = Double.Parse(Console.ReadLine());
            playerList.Add(new Player(name, deposit));
        }
    }
}