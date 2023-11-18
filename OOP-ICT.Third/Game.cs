using System.Runtime.ConstrainedExecution;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;

public class Game {
    private List<Player> playerList = new List<Player>();
    public static int chipPrice { get; private set; }
    private CardDeck cardDeck;
    private DealerAdapter dealer;

    public Game() {
        cardDeck = new CardDeck();
        dealer = new DealerAdapter(cardDeck);
        dealer.Shuffle();
    }



    public void Start() {
        Console.WriteLine("Please, enter one chip price:");
        chipPrice = int.Parse(Console.ReadLine());
        AddPlayers();
        BuyChips();
        MakeBids();
        FirstDistribution();
        FinalDistribution();
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
            Console.WriteLine($"Player {plr.name}, enter quantity of chips you want to buy.");
            Console.WriteLine($"The maximum quantity you can buy is {Math.Floor(plr.bankAccount.Balance / chipPrice)}");
            plr.BuyChips();
        }
    }

    public void MakeBids() {
        foreach (var player in playerList) {
            Console.WriteLine($"Player {player.name}, enter quantity of chips you want to bid.");
            Console.WriteLine($"Available chips : {player.playerAccount.Balance}");
            player.makeBid();
        }
    }

    public void FirstDistribution() {
        foreach (var player in playerList) {
            player.GetCard(dealer.GiveCard());
            player.GetCard(dealer.GiveCard());
            player.ShowCardsInfo();
        }
        dealer.GetCard();
        dealer.ShowInfo();
    }

    public void FinalDistribution() {
        foreach (var player in playerList) {
            while (player.CorrectSum() < 21) {
                Console.WriteLine($"{player.name}, do you want to take one more card? Print yes/no");
                string answer = Console.ReadLine();
                if (answer.ToLower().Trim().Equals("yes")) {
                    player.GetCard(dealer.GiveCard());
                    player.ShowCardsInfo();
                } else {
                    break;
                }
            }
            if (player.CorrectSum() > 21) {
                Console.WriteLine($"You lost {player.Bid} chips");
                player.LoseChips();
            }
        }
        while (dealer.CorrectSum() < 17) {
            dealer.GetCard();
            dealer.ShowInfo(); 
        }
        /* ебаный в рот этого казино
        ты кто такой сука чтобы это делать
        один стоит палит, другой колоду тасует
        у вас дилер есть блять
        */
    }
}