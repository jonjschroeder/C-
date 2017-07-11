using System;
using System.Collections.Generic;

namespace deck
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();
            System.Console.WriteLine(myDeck);
            Player PlayerOne = new Player();
            Player PlayerTwo = new Player();
            PlayerOne.Draw(myDeck);
            PlayerOne.Draw(myDeck);
            PlayerOne.Draw(myDeck);
            PlayerOne.Draw(myDeck);
            PlayerOne.Draw(myDeck);
            PlayerOne.Discard(10);
            System.Console.WriteLine(PlayerOne.Hand);
            // System.Console.WriteLine(myDeck);
            // Card DealtCard = myDeck.Deal();
            // Card DealtCard2 = myDeck.Deal();
            // System.Console.WriteLine(myDeck);
            // myDeck.Reset();
            // System.Console.WriteLine(myDeck);
        }
    }
}
// Give the Card class a property "stringVal" which will hold the value of the card ex. (Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King). This "val" should be a String Give the Card a property "suit" which will hold the suit of the card (Clubs, Spades, Hearts, Diamonds) Give the Card a property "val" which will hold the numerical value of the card 1-13 as integers