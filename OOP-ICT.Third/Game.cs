using System.Runtime.ConstrainedExecution;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class Game {
    private List<Player> playerList = new List<Player>();
    public int chipPrice { get; private set; }
    private CardDeck cardDeck;
    private DealerAdapter dealer;

    public Game() {
        cardDeck = new CardDeck();
        dealer = new DealerAdapter(cardDeck);
    }



    public void Start() {
        Console.WriteLine("Please, enter one chip price:");
        chipPrice = int.Parse(Console.ReadLine());
        AddPlayers();
    }

    public void AddPlayers() {
        Console.WriteLine("| For end of registration press ENTER |");
        while (true) {
            Console.WriteLine("Please, enter player's name:");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name)) {
                break;
            }
            Console.WriteLine("Please, enter player's bank balance:");
            double deposit = Double.Parse(Console.ReadLine());
            playerList.Add(new Player(name, deposit));
        }
    }

    public void BuyChips() {
        foreach (var plr in playerList) {
            Console.WriteLine($"Player {plr.name}, enter quantity of cihps you want to buy.");
            Console.WriteLine($"The maximum quantity you can buy is {Math.Floor(plr.bankAccount.Balance / chipPrice)}");
            int playerChips = 
        }
    }
}