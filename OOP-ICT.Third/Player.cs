using System.Collections;
using OOP_ICT.Models;
using OOP_ICT.Second;
namespace OOP_ICT.Third;
public class Player 
{

    private PlayerAccount playerAccount;
    private BankAccount bankAccount;
    private ArrayList playerCardList = new();

    private void GetCard() {
        List<Card> dealerCardList = Dealer.CardDeck.CardList;
        playerCardList.Add(dealerCardList[0]);
        dealerCardList.Remove(dealerCardList[0]);
    }
}
