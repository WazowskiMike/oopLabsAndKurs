using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using OOP_ICT.Models;
using OOP_ICT.Second;
using OOP_ICT.Third;
namespace OOP_ICT.Fourth;
/*
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢀⠄⡀⠄⡀⢀⠄⡀⡀⠠⢀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⡀⠠⢀⠄⡅⢔⠰⡨⢢⢡⢑⠔⠅⠕⠄⠅⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⡀⠅⢔⠨⢐⠅⡌⢆⢣⠪⡪⡘⡌⡮⡱⡡⣊⢌⢀⢀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠠⡐⢄⠕⡡⡘⢔⢱⢨⢪⢪⢪⢪⡺⣪⢞⢮⢫⢮⢺⢔⢆⡢⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⢀⠐⠈⠄⡠⡊⢌⠢⡑⡌⡆⡇⡇⡇⡇⣇⢗⣝⢮⡺⣪⡳⣹⡪⣞⢵⢝⡵⡝⣕⠡⢀⢂⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⢠⢊⢂⠁⡔⡌⡢⢑⠌⡢⡱⡸⡸⡸⡪⡺⡸⣕⢵⡳⣝⢮⡺⣪⢞⣵⣫⡳⣕⢯⡺⡬⠄⠕⡕⡄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⡇⡇⡂⢢⢣⢣⠨⡂⡊⢔⢕⢱⡱⡝⣜⢝⡺⣜⡵⣝⢮⡳⡽⣵⣻⡺⣼⡺⡵⣳⢝⡮⡃⡕⡺⢄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⢸⡱⡱⡨⢪⢪⢢⠡⢂⢊⠢⡱⡱⡱⡝⡮⡳⣝⢞⢮⢗⡯⣯⢯⣗⡯⣟⣮⢯⣟⢮⡳⣝⢇⢇⢎⢵⡀⠄⠄⠄⠄⠄
⠄⠄⠄⣕⢵⢣⢣⢑⢅⢆⢃⠢⠡⡡⡱⡱⡹⡪⡯⣺⢕⡯⣫⢯⢾⢽⢽⣺⢯⣗⡯⣗⣗⢗⣝⢮⡫⣏⢮⢒⢅⠄⠄⠄⠄⠄
⠄⠄⢀⠮⡪⢪⠪⠢⡃⡪⡂⠅⢕⠰⢱⢸⢸⡱⣝⢮⡳⡽⣪⢏⡯⡯⣟⡾⣽⣺⢽⣳⡳⣝⢮⡳⣫⣳⢳⡱⡱⠄⠄⠄⠄⠄
⠄⠄⢀⡃⡫⢔⢨⢕⢕⢔⢌⢌⠢⡑⡱⡘⢜⢜⢮⡳⣝⣞⢵⣫⢿⢽⣺⡽⡾⣾⢽⣳⢯⢮⡳⣝⣕⢗⢵⡑⡕⡀⠄⠄⠄⠄
⠄⠄⠐⠢⡱⡐⢕⢵⣑⡑⢕⢐⠕⠸⠰⡑⠕⢕⢕⠽⡕⣏⢗⢽⢝⢽⠺⠽⠽⢽⢻⢽⢽⢵⢽⡸⣪⢳⢱⢱⡱⡽⡡⡀⠄⠄
⠄⠄⠨⠈⢆⢊⢎⢖⢂⠃⠡⠐⠈⠈⠄⠄⠄⠄⠄⢑⢹⢘⣜⢕⠑⡈⠄⡈⣈⣐⠨⠘⡜⢕⡳⣝⢮⡳⡱⡱⡵⡯⡪⠂⠄⠄
⠄⠄⠄⠅⢂⠑⡕⡕⠄⡢⢀⠄⠠⠄⠁⠁⡌⠠⢠⠄⠸⣸⣺⡪⣐⠅⢢⢈⠄⢬⢍⣆⢧⣳⡽⡮⣺⡪⡺⣘⢼⣝⠆⠄⠄⠄
⠄⠄⠄⠨⡢⡢⡣⡳⢑⢰⢐⠠⡊⡪⣢⡣⡪⡰⠑⡀⠨⣪⢷⣝⡮⡫⡪⣪⢾⢝⣯⢾⣝⣗⡯⣟⢮⡪⡯⡷⣗⡯⠄⠄⠄⠄
⠄⠄⠄⠄⢕⠄⡇⡣⡑⠔⢅⠇⡇⡏⡖⡕⡕⣌⢂⠂⠌⢮⢷⡳⡯⡯⡾⡵⣫⢯⢞⣗⡷⡯⣯⡳⣱⢱⢝⡽⣺⠁⠄⠄⠄⠄
⠄⠄⠄⠄⠡⡡⢱⢐⠨⠨⠐⡡⢃⢇⢇⡏⡞⡔⡐⠠⢑⢽⢽⢽⢽⢽⢽⣝⢗⡯⣟⢾⢽⢝⡞⣜⢜⢜⣽⣺⠎⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠊⠃⠂⡐⠄⠅⡐⡈⡢⡃⢇⠕⡢⠄⠨⢘⢮⢯⢯⣳⡫⡗⣗⢽⢝⡮⡯⡮⡣⡏⣎⢎⠞⠺⠊⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠂⡁⢂⠐⡈⡢⢑⠅⡕⡐⠈⠨⡨⢯⣻⢽⣺⢺⡺⡪⣏⢷⢽⢕⣯⡫⣞⢜⢜⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⡁⠄⠄⠂⡂⠌⠄⢕⢐⠌⢄⠄⠨⠨⢘⢥⢅⡵⣝⣝⢮⡳⡽⣝⡮⣺⢪⢎⣗⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⢂⢀⠡⠄⠌⠌⢂⢂⠪⠐⡌⢰⢰⢘⢼⢝⣞⢞⣞⡵⡯⣞⢵⣫⢮⡳⡣⡳⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠈⡀⠐⠄⠊⠄⠨⠐⠠⠈⠌⠘⠜⠵⡢⢳⢹⢜⢕⠕⠱⡹⡪⡳⣕⣳⢹⡸⠅⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⢄⠡⠁⠠⠄⠄⡀⠄⠐⠔⠔⠔⡢⠦⣒⢎⣎⢦⢢⢩⡫⣎⢮⢣⠃⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⢰⣇⠄⠐⠠⠄⠁⠄⠡⢀⢂⢅⢔⢄⣆⣆⢕⢵⡹⣪⡳⣕⢵⢱⢕⢇⡇⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠱⡿⣵⣀⠄⠄⠄⠈⠨⠨⡂⢇⢎⢕⢎⢞⡽⡵⣝⢮⢺⢸⠸⡘⣜⢼⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⢹⣺⣳⣧⣄⡀⠄⠄⡀⠂⠌⡂⠕⢌⠊⢎⠪⠪⠪⡊⡆⣕⣕⢧⣓⣧⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⢪⢞⣾⡽⣷⣮⡄⠐⠄⡂⠌⢌⠢⢑⢐⢄⢅⢇⢇⣗⣕⢗⡵⣽⣿⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠙⡾⣽⣯⣷⣿⡿⣮⣰⢱⡱⣜⢔⡑⡜⣜⢮⣣⡳⣪⢷⣽⣿⣿⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠘⡷⣿⣽⣿⣿⣿⣿⣿⣾⣮⣗⣽⢵⢕⣕⢮⡺⢝⣵⣿⣿⣿⣷⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠘⣯⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣵⣏⣾⣿⣿⣿⣿⣿⣿⣇⠄⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠻⣟⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠉⠄⠄⠄⠉⠻⢿⣿⣿⣿⣿⡀⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⢻⣿⣿⣿⣿⣿⣿⣿⡟⠁⠄⠄⠁⠠⠄⠄⠄⠈⠽⣿⣿⣿⣷⠄⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⢿⣿⣿⣿⣿⣿⡵⣄⠄⠄⠄⠄⠁⠈⠄⠄⢸⣹⡪⣿⣿⣿⡂⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠈⢿⣿⣿⣻⣿⣿⣯⣿⣢⣄⠄⠄⠄⠑⠠⢸⣿⣿⣮⢞⣿⣧⠄⠄⠄⠄⠄⠄⠄
*/
public class Poker {
    private List<Player> playerList;
    public static int chipPrice { get; private set; }
    private CardDeck cardDeck;
    private DealerAdapter dealer;
    private int bigBlind;
    private int smallBlind;
    public int pot { get; set; }
    private Card[] communityCards;
    private int[] allPlayerBets;
    private Player playerDealer;
    private Player playerSmallBlind;
    private Player playerBigBlind;
    private bool keepPlaying;
    public Poker() {
        playerList = new List<Player>();
        Console.WriteLine("Please, enter one chip price:");
        chipPrice = int.Parse(Console.ReadLine());
        Console.WriteLine("Please, enter big blind price for this game:");
        bigBlind = int.Parse(Console.ReadLine());
        smallBlind = bigBlind / 2;
        keepPlaying = true;
        AddPlayers();
        BuyChips();
        giveRoles();
        
        while (keepPlaying) {
            communityCards  = new Card[5];
            cardDeck = new CardDeck();
            dealer = DealerAdapter.getDealer(cardDeck);
            dealer.Shuffle();

            payOutBlinds();
            FirstDistribution();

            Console.WriteLine("Preflop");
            BettingRound(true);

            Console.WriteLine("Flop");
            dealNextCommunityCard();
            BettingRound(false);

            Console.WriteLine("Turn");
            dealNextCommunityCard();
            BettingRound(false);

            Console.WriteLine("River");
            dealNextCommunityCard();
            BettingRound(false);

            FindWinner();

            Console.WriteLine("Do you want to play another round? Yes/No");
            string answer = Console.ReadLine();
            if (answer.ToLower().Contains("no")) {
                keepPlaying = false;
                break;
            }
            rotatePlayersPositions();
            foreach (var player in playerList) {
                player.ClearHand();
            }
        }

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
        if (playerList.Count() < 2) {
            Console.WriteLine("There's no way to play with one person. Plese, add at least one more player.");
            AddPlayers();
        }
        allPlayerBets = new int[playerList.Count()];
    }

    public void BuyChips() {
        foreach (var plr in playerList) {
            Console.WriteLine($"Player {plr.name}, enter quantity of chips you want to buy.");
            Console.WriteLine($"The maximum quantity you can buy is {Math.Floor(plr.bankAccount.Balance / chipPrice)}");
            plr.BuyChips();
        }
    }

    public void payOutBlinds () {
        playerSmallBlind.playerAccount.WithDraw(smallBlind);
        playerSmallBlind.Bid = smallBlind;
        pot += smallBlind;
        playerBigBlind.playerAccount.WithDraw(bigBlind);
        playerBigBlind.Bid = bigBlind;
        pot += bigBlind;

        allPlayerBets[playerList.IndexOf(playerSmallBlind)] = smallBlind;
        allPlayerBets[playerList.IndexOf(playerBigBlind)] = bigBlind;

        Console.WriteLine($"Player {playerDealer.name}, you are dealer.\n" +
        $"Player {playerSmallBlind.name}, you are small blind. Your bid is {smallBlind}.\n" +
        $"Player {playerBigBlind.name}, you are bid blind. Your bid is {bigBlind}.");   
    }

    public void giveRoles() {
        playerDealer = playerList[0];
        if (playerList.Count == 2) {
            playerSmallBlind = playerList[0];
            playerBigBlind = playerList[1];
        } else {
            playerSmallBlind = playerList[1];
            playerBigBlind = playerList[2];
        }
    }
    public void FirstDistribution() {
        foreach (var player in playerList) {
            player.GetCard(dealer.GiveCard());
            player.GetCard(dealer.GiveCard());
            player.ShowCardsInfo();
        }
    }

    public int getHighestBet() {
        int highestBet = 0;
        for (int i = 0; i < allPlayerBets.Length; i++) {
            if (playerList[i].GetIsInGame()) {
                highestBet = Math.Max(highestBet, allPlayerBets[i]);
            }
        }
        return highestBet;
    }

    public bool allBetsAreEqual () {
        int highestBet = getHighestBet();
        for (int j = 0; j < allPlayerBets.Length; j++) {
            if (playerList[j].GetIsInGame() && allPlayerBets[j] < highestBet) {
                return false;
            }
        }
        return true;
    }

    public int individualBet (int currentPlayerIndex) {
        string checkOrCall = allBetsAreEqual() ? "check" : "call";
        printCommunityCards();
        Console.WriteLine("The pot is " + pot);
        Console.WriteLine(playerList[currentPlayerIndex].name + ", do you want to fold, " + checkOrCall + " or raise?");
        string answer = Console.ReadLine();
        if (answer.ToLower().Contains("fold")) {
            fold(playerList[currentPlayerIndex]);
        } else if (answer.ToLower().Contains("call")) {
            call(playerList[currentPlayerIndex]);
        } else if (answer.ToLower().Contains("raise")) {
            raise(playerList[currentPlayerIndex]);
        }
        currentPlayerIndex++;
        if (currentPlayerIndex == playerList.Count) {
            currentPlayerIndex = 0;
        }
        return currentPlayerIndex;
    }

    public void fold (Player player) {
        player.SetIsInGame(false);
    }

    public void call(Player player) {
        int highestBet = getHighestBet();
        int playersBetDifference = highestBet - allPlayerBets[playerList.IndexOf(player)];
        player.playerAccount.WithDraw(playersBetDifference);
        allPlayerBets[playerList.IndexOf(player)] += playersBetDifference;
        updateWinningPot();
    }
    
    public void raise(Player player) {
        Console.WriteLine($"{player.name}, how much you want to raise?");
        int raiseAmount = int.Parse(Console.ReadLine());
        call(player);
        player.playerAccount.WithDraw(raiseAmount);
        allPlayerBets[playerList.IndexOf(player)] += raiseAmount;
        updateWinningPot();
    }

    public void updateWinningPot() {
        pot = 0;
        for (int i = 0; i < allPlayerBets.Length; i++) {
            pot += allPlayerBets[i];
        }
    }

    public void printCommunityCards() {
        Console.WriteLine("-----------------------------------------------------");
        if (communityCards[0] != null && communityCards[3] == null && communityCards[4] == null) {
            Console.WriteLine("The Flop :");
        } else if (communityCards[3] != null && communityCards[4] == null) {
            Console.WriteLine("The Turn :");
        } else if (communityCards[4] != null) {
            Console.WriteLine("The river");
        }
        for (int i = 0; i < 5; i++) {
            if (communityCards[i] != null) {
                Console.WriteLine(communityCards[i].CardValue + " of " + communityCards[i].Suit);
            }
        }
        Console.WriteLine("-----------------------------------------------------");
    }
    
    public void BettingRound (bool isPreFlop) {
        int currentPlayerIndex;
        if (isPreFlop) {
            currentPlayerIndex = (playerList.IndexOf(playerSmallBlind) + 2) % playerList.Count;
        } else {
            currentPlayerIndex = playerList.IndexOf(playerSmallBlind);
        }
        foreach (var plr in playerList) {
            if (plr.GetIsInGame()) {
                currentPlayerIndex = individualBet(currentPlayerIndex);
            }
        }
        while (!allBetsAreEqual()) {
            if (playerList[currentPlayerIndex].GetIsInGame()) {
                currentPlayerIndex = individualBet(currentPlayerIndex);
            }
        }
    }

    public void dealNextCommunityCard() {
        if (communityCards[0] == null) {
            communityCards[0] = dealer.GiveCard();
            communityCards[1] = dealer.GiveCard();
            communityCards[2] = dealer.GiveCard();
        } else if (communityCards[3] == null) {
            communityCards[3] = dealer.GiveCard();
        } else if (communityCards[4] == null) {
            communityCards[4] = dealer.GiveCard();
        }
    }
    
    public List<Card> OnePlayerCards(Player player) {
        List<Card> result = new();
        foreach (var card in communityCards) {
            result.Add(card);
        }
        result.Add(player.playerHand[0]);
        result.Add(player.playerHand[1]);
        return result;
    }

    public List<int> getValueOfAllPlayerCards(List<Card > onePlayerCards) {
        List<int> result = new();
        foreach (var card in onePlayerCards) {
            result.Add(card.Value);
        }    
        return result;
    }

    public List<int> getValueofSuits (List<Card> allPlayerCards, Suits suit) {
        List<int> result = new();
        foreach(var card in allPlayerCards) {
            if (card.Suit == suit) {
                result.Add(card.Value);
            }
        }
        return result;
    }

    public List<Player> highCard () {
        List<Player> winningPlayers = new();
        int playerListSize = playerList.Count;
        int highestCardValue = 0;
        for (int i = 0; i < playerListSize; i++) {
            Player player = playerList[i];
            if (player.GetIsInGame()) {
                int highestPlayerCardValue = player.playerHand[0].Value > player.playerHand[1].Value ? player.playerHand[0].Value : player.playerHand[1].Value;
                if (highestPlayerCardValue > highestCardValue) {
                    highestCardValue = highestPlayerCardValue;
                    winningPlayers.Clear();
                    winningPlayers.Add(player);
                } else if (highestPlayerCardValue == highestCardValue) {
                    winningPlayers.Add(player);
                }
            }
        }
        return winningPlayers;
    }
    
    public List<Player> Pair() {
        List<Player> winningPlayers = new();
        foreach (var plr in playerList) {
            if (plr.GetIsInGame()) {
                int[] quantityEachCard = new int[13];
                List<Card> playerCards = OnePlayerCards(plr);
                foreach (var card in playerCards) {
                    quantityEachCard[card.Value - 2]++;
                }
                foreach (var quantity in quantityEachCard) {
                    if (quantity >= 2 && !winningPlayers.Contains(plr)) {
                        winningPlayers.Add(plr);
                    }
                }
            }
        }
        return winningPlayers;
    }

    public List<Player> TwoPair() {
        List<Player> winningPlayers = new();
        foreach (var plr in playerList) {
            if (plr.GetIsInGame()) {
                int[] quantityEachCard = new int[13];
                int pairCount = 0;
                List<Card> playerCards = OnePlayerCards(plr);
                foreach (var card in playerCards) {
                    quantityEachCard[card.Value - 2]++;
                }
                foreach (var quantity in quantityEachCard) {
                    if (quantity >= 2) {
                        pairCount++;
                        if (pairCount == 2) {
                            winningPlayers.Add(plr);
                        }
                    }
                }
            }
        }
        return winningPlayers;
    }

    public List<Player> Straight () {
        List<Player> winningPlayers = new();
        foreach (var player in playerList) {
            if (player.GetIsInGame()) {
                List<Card> playerCards = OnePlayerCards(player);
                List<int> playerCardsValues = getValueOfAllPlayerCards(playerCards);
                playerCardsValues.Sort();
                int lowestValue = playerCardsValues[0];
                int secondHighestValue = playerCardsValues[1];
                int thirdHighestValue = playerCardsValues[2];
                if (playerCardsValues.Contains(lowestValue + 1) &&
                    playerCardsValues.Contains(lowestValue + 2) &&
                    playerCardsValues.Contains(lowestValue + 3) &&
                    playerCardsValues.Contains(lowestValue + 4)) {
                    winningPlayers.Add(player);
                    continue;
                    }
                if (playerCardsValues.Contains(secondHighestValue + 1) &&
                    playerCardsValues.Contains(secondHighestValue + 2) &&
                    playerCardsValues.Contains(secondHighestValue + 3) &&
                    playerCardsValues.Contains(secondHighestValue + 4)) {
                    winningPlayers.Add(player);
                    continue;
                }
                if (playerCardsValues.Contains(thirdHighestValue + 1) &&
                    playerCardsValues.Contains(thirdHighestValue + 2) &&
                    playerCardsValues.Contains(thirdHighestValue + 3) &&
                    playerCardsValues.Contains(thirdHighestValue + 4)) {
                    winningPlayers.Add(player);
                    continue;
                }
            }
        }
        return winningPlayers;
    } 
        
        
     
    public List<Player> Set() {
        List<Player> winningPlayers = new();
        foreach (var plr in playerList) {
            if (plr.GetIsInGame()) {
                int[] quantityEachCard = new int[13];
                List<Card> playerCards = OnePlayerCards(plr);
                foreach (var card in playerCards) {
                    quantityEachCard[card.Value - 2]++;
                }
                foreach (var quantity in quantityEachCard) {
                    if (quantity >= 3 && !winningPlayers.Contains(plr)) {
                        winningPlayers.Add(plr);
                    }
                }
            }
        }
        return winningPlayers;
    }

    public List<Player> Flush() {
        List<Player> winningPlayers = new();
        foreach (var plr in playerList) {
            int hearts = 0;
            int diamonds = 0;
            int spades = 0;
            int clubs = 0;

            if (plr.GetIsInGame()) {
                List<Card>  plrCards = OnePlayerCards(plr);

                foreach (var card in plrCards) {
                    if (card.Suit == Suits.Hearts) {
                        hearts++;
                    } else if (card.Suit == Suits.Diamond) {
                        diamonds++;
                    } else if (card.Suit == Suits.Spades) {
                        spades++;
                    } else if (card.Suit == Suits.Clubs) {
                        clubs++;
                    }
                }
                
                if (hearts >= 5 || diamonds >= 5 || spades >= 5 || clubs >= 5) {
                    winningPlayers.Add(plr);
                }
            }
        }
        return winningPlayers;
    }

    public List<Player> FullHouse() {
        List<Player> winningPlayers = new();
        foreach (var plr in playerList) {
            if (plr.GetIsInGame()) {
                int[] quantityEachCard = new int[13];
                bool pair = false;
                bool set = false;
                List<Card> playerCards = OnePlayerCards(plr);
                foreach (var card in playerCards) {
                    quantityEachCard[card.Value - 2]++;
                }
                foreach (var quantity in quantityEachCard) {
                    if (quantity >= 3 && !winningPlayers.Contains(plr)) {
                        set = true;
                    } else if (quantity >= 2 && !winningPlayers.Contains(plr)) {
                        pair = true;
                    }
                }
                if (pair && set) {
                    winningPlayers.Add(plr);
                }
            }
        }
        return winningPlayers;
    }

    public List<Player> Care() {
        List<Player> winningPlayers = new();
        foreach (var plr in playerList) {
            if (plr.GetIsInGame()) {
                int[] quantityEachCard = new int[13];
                List<Card> playerCards = OnePlayerCards(plr);
                foreach (var card in playerCards) {
                    quantityEachCard[card.Value - 2]++;
                }
                foreach (var quantity in quantityEachCard) {
                    if (quantity >= 4 && !winningPlayers.Contains(plr)) {
                        winningPlayers.Add(plr);
                    }
                }
            }
        }
        return winningPlayers;
    }

    public List<Player> StraightFlush () {
        List<Player> winningPlayers = new();
        foreach (var player in playerList) {
            int hearts = 0;
            int diamonds = 0;
            int spades = 0;
            int clubs = 0;
            if (player.GetIsInGame()) {
                List<Card> playerCards = OnePlayerCards(player);
                List<int> playerCardsValues = new();
                foreach (var card in playerCards) {
                    if (card.Suit == Suits.Hearts) {
                        hearts++;
                    } else if (card.Suit == Suits.Diamond) {
                        diamonds++;
                    } else if (card.Suit == Suits.Spades) {
                        spades++;
                    } else if (card.Suit == Suits.Clubs) {
                        clubs++;
                    }
                }
                Suits suit = Suits.Diamond;
                bool flag = false;
                if (hearts >= 5) {
                    suit = Suits.Hearts;
                    flag = true;
                } else if (diamonds >= 5) {
                    suit = Suits.Diamond;
                    flag = true;
                } else if (spades >= 5) {
                    suit = Suits.Spades;
                    flag = true;
                }  else if (clubs >=  5) {
                    suit = Suits.Clubs;
                    flag = true;
                }
                if (flag) {
                    playerCardsValues = getValueofSuits(playerCards, suit);
                } else {
                    continue;
                }
                playerCardsValues.Sort();
                int lowestValue = playerCardsValues[0];
                int secondHighestValue = playerCardsValues[1];
                int thirdHighestValue = playerCardsValues[2];
                if (playerCardsValues.Contains(lowestValue + 1) &&
                    playerCardsValues.Contains(lowestValue + 2) &&
                    playerCardsValues.Contains(lowestValue + 3) &&
                    playerCardsValues.Contains(lowestValue + 4)) {
                    winningPlayers.Add(player);
                    continue;
                    }
                if (playerCardsValues.Contains(secondHighestValue + 1) &&
                    playerCardsValues.Contains(secondHighestValue + 2) &&
                    playerCardsValues.Contains(secondHighestValue + 3) &&
                    playerCardsValues.Contains(secondHighestValue + 4)) {
                    winningPlayers.Add(player);
                    continue;
                }
                if (playerCardsValues.Contains(thirdHighestValue + 1) &&
                    playerCardsValues.Contains(thirdHighestValue + 2) &&
                    playerCardsValues.Contains(thirdHighestValue + 3) &&
                    playerCardsValues.Contains(thirdHighestValue + 4)) {
                    winningPlayers.Add(player);
                    continue;
                }
            }
        }
        return winningPlayers;
    }

    public List<Player> FlushRoyal() {
        List<Player> winningPlayers = new();
        foreach (var plr in playerList) {
            int hearts = 0;
            int diamonds = 0;
            int spades = 0;
            int clubs = 0;

            if (plr.GetIsInGame()) {
                List<int> valuesOfFlush = new();
                List<Card>  plrCards = OnePlayerCards(plr);

                foreach (var card in plrCards) {
                    if (card.Suit == Suits.Hearts) {
                        hearts++;
                    } else if (card.Suit == Suits.Diamond) {
                        diamonds++;
                    } else if (card.Suit == Suits.Spades) {
                        spades++;
                    } else if (card.Suit == Suits.Clubs) {
                        clubs++;
                    }
                }
                
                if (hearts >= 5) {
                    valuesOfFlush = getValueofSuits(plrCards, Suits.Hearts);
                } else if(diamonds >= 5) {
                    valuesOfFlush = getValueofSuits(plrCards, Suits.Diamond);
                } else if(spades >= 5) {
                    valuesOfFlush = getValueofSuits(plrCards, Suits.Spades);
                } else if(clubs >= 5) {
                    valuesOfFlush = getValueofSuits(plrCards, Suits.Clubs);
                }

                if (valuesOfFlush.Contains(10) &&
                valuesOfFlush.Contains(11) &&
                valuesOfFlush.Contains(12) &&
                valuesOfFlush.Contains(13) &&
                valuesOfFlush.Contains(14)) {
                    winningPlayers.Add(plr);
                }
            }
        }
        return winningPlayers;
    }
    public void HandleWinners(List<Player> winningPlayers) {
        int award = pot / winningPlayers.Count;
        foreach (var player in winningPlayers) {
            player.playerAccount.Deposit(award);
            Console.WriteLine($"Player {player.name} gained {award} chips. Congratulations!");
        }
        pot = 0;
    }

    public void rotatePlayersPositions () {
        int dealerIndex = playerList.IndexOf(playerDealer);
        int smallBlindIndex = playerList.IndexOf(playerSmallBlind);
        int bigBlindIndex = playerList.IndexOf(playerBigBlind);
        int playerListSize = playerList.Count;
        playerDealer = playerList[(dealerIndex + 1) % playerListSize];
        playerSmallBlind = playerList[(smallBlindIndex + 1) % playerListSize];
        playerBigBlind = playerList[(bigBlindIndex + 1) % playerListSize];
    }

    public void FindWinner() {
        List<Player> winningPlayers = new();
        
        winningPlayers = FlushRoyal();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("FlushRoyal");
            HandleWinners(winningPlayers);
            return;
        }

        winningPlayers = StraightFlush();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("StraightFlush");
            HandleWinners(winningPlayers);
            return;
        }
        
        winningPlayers = Care();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("Care");
            HandleWinners(winningPlayers);
            return;
        }
        
        winningPlayers = FullHouse();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("FullHouse");
            HandleWinners(winningPlayers);
            return;
        }

        winningPlayers = Flush();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("Flush");
            HandleWinners(winningPlayers);
            return;
        }
        
        winningPlayers = Straight();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("Straight");
            HandleWinners(winningPlayers);
            return;
        }

        winningPlayers = Set();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("Set");
            HandleWinners(winningPlayers);
            return;
        }

        winningPlayers = TwoPair();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("TwoPair");
            HandleWinners(winningPlayers);
            return;
        }
        
        winningPlayers = Pair();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("Pair");
            HandleWinners(winningPlayers);
            return;
        }

        winningPlayers = highCard();
        if (winningPlayers.Count() > 0) {
            Console.WriteLine("HighCard");
            HandleWinners(winningPlayers);
            return;
        }
    }
}