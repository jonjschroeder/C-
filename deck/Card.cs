using System.Collections.Generic;


namespace deck{
    public class Card{  
        public string StringVal{get;set;}
        public string Suit{get;set;}
        public int Val{get;set;}

        public Card(string strVal, string suit, int val){
            StringVal = strVal;
            Suit = suit;
            Val = val;
        }       
    }
}