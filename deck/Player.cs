using System.Collections.Generic;


namespace deck{
    public class Player{
        public List<Card> Hand {get;set;}
   
    public Player(){
        Hand = new List<Card>();

    }
    public Card Draw(Deck Deck){
        Card DrawnCard = Deck.Deal();
        Hand.Add(DrawnCard);
        return DrawnCard;
    }
    public Card Discard(int index){
        if(index>Hand.Count){
            System.Console.WriteLine("There is no card number " + index);
            return null;
        }
        index--;
        Card DiscardedCard = Hand[index];
        Hand.RemoveAt(index); 
        return DiscardedCard;
    }
  }
}