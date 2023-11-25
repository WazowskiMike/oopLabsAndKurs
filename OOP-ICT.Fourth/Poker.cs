using OOP_ICT.Models;
using OOP_ICT.Second;
using OOP_ICT.Third;
namespace OOP_ICT.Fourth;

public class Game {
    private List<Player> playerList = new List<Player>();
    public static int chipPrice { get; private set; }
    private CardDeck cardDeck;
    private DealerAdapter dealer;

    public Game() {
        cardDeck = new CardDeck();
        dealer = DealerAdapter.getDealer(cardDeck);
        dealer.Shuffle();
    }

    public void Start() {
        Console.WriteLine("Please, enter one chip price:");
        chipPrice = int.Parse(Console.ReadLine());

    }

    public void AddPlayers() {
        Console.WriteLine("| For end of registration press ENTER |");
        while (true) {
            try { 
                Console.WriteLine("Please, enter player's name:");
                string name = Console.ReadLine();
                if (String.IsNullOrEmpty(name)) {
                    break;
                }
                Console.WriteLine("Please, enter player's bank balance:");
                double deposit = Double.Parse(Console.ReadLine());
                playerList.Add(new Player(name, deposit));
            }
            catch (Exception) {
                throw new WrongFormatException("Wrong player format.");
            }
        }
    }

    public void BuyChips() {
        foreach (var plr in playerList) {
            Console.WriteLine($"Player {plr.name}, enter quantity of chips you want to buy.");
            Console.WriteLine($"The maximum quantity you can buy is {Math.Floor(plr.bankAccount.Balance / chipPrice)}");
            plr.BuyChips();
        }
    }

    public void FirstDistribution() {
        foreach (var player in playerList) {
            player.GetCard(dealer.GiveCard());
            player.GetCard(dealer.GiveCard());
            player.ShowCardsInfo();
        }
    }

    
}