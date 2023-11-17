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
        Console.WriteLine("Пожалуйста, введите цену одной фишки ");
        chipPrice = int.Parse(Console.ReadLine());
        AddPlayers();
    }

    public void AddPlayers() {
        Console.WriteLine("| Для окончания регистрации нажмите ENTER в поле ввода имени |");
        while (true) {
            Console.WriteLine("Пожалуйста, введите имя игрока ");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name)) {
                break;
            }
            Console.WriteLine("Пожалуйста, введите баланс");
            double deposit = Double.Parse(Console.ReadLine());
            playerList.Add(new Player(name, deposit));
        }
    }
}