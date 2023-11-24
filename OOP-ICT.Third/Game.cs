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
        dealer = DealerAdapter.getDealer(cardDeck);
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
        EndGame();
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

    public void MakeBids() {
        foreach (var player in playerList) {
            Console.WriteLine($"Player {player.name}, enter quantity of chips you want to bid.");
            player.makeBid();
        }
    }

    public void FirstDistribution() {
        List<Player> toRemove = new List<Player>();
        foreach (var player in playerList) {
            player.GetCard(dealer.GiveCard());
            player.GetCard(dealer.GiveCard());
            player.ShowCardsInfo();
            if (player.CorrectSum() == 21) {
                Console.WriteLine($"{player.name}, it's blackjack! You won {player.Bid * 1.5} chips!");
                player.BlackJack();
                toRemove.Add(player);
            }
        }
        playerList.RemoveAll(x => toRemove.Contains(x));
        dealer.GetCard();
        dealer.ShowInfo();
    }

    public void FinalDistribution() {
        List<Player> toRemove = new List<Player>();
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
                toRemove.Add(player);
            }
        }
        playerList.RemoveAll(x => toRemove.Contains(x));
        if (playerList.Count() == 0) {
            return;
        }
        while (dealer.CorrectSum() < 17) {
            dealer.GetCard();
            dealer.ShowInfo(); 
        }
    }

    public void EndGame () {
        if (playerList.Count() > 0) {
            Console.WriteLine("We are ready to compare cards!");
        } else {
            Console.WriteLine("All players lost!");
        }
        if (dealer.CorrectSum() == 21) {
            foreach (var player in playerList) {
                player.ShowCardsInfo();
                if (player.CorrectSum() == 21) {
                    Console.WriteLine($"{player.name}, it's a draw! Your chips will be returned");
                    player.ReturnChips();
                } else {
                    Console.WriteLine($"{player.name}, sorry ! You lost {player.Bid} chips");
                    player.LoseChips();
                }
            }
        } else if (dealer.CorrectSum() > 21) {
            foreach (var player in playerList) {
                player.ShowCardsInfo();
                Console.WriteLine($"{player.name}, you won {player.Bid * 2} chips!");
                player.WinChips();
            }
        } else {
            foreach (var player in playerList) {
                player.ShowCardsInfo();
                if (player.CorrectSum() < dealer.CorrectSum()) {
                    Console.WriteLine($"{player.name}, sorry ! You lost {player.Bid} chips");
                    player.LoseChips();
                } else if (player.CorrectSum() == dealer.CorrectSum()) {
                    Console.WriteLine($"{player.name}, it's a draw! Your chips will be returned");
                    player.ReturnChips();
                } else {
                    Console.WriteLine($"{player.name}, you won {player.Bid * 2} chips!");
                    player.WinChips();
                }
            }
        }
    }
}
