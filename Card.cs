using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackV2
{
    class Card
    {
        string suit;
        string cardValue;

        public Card(string cardValue , string suit)
        {
            this.suit = suit;
            this.cardValue = cardValue;
        }

        // Suit getter/setter
        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        // Value getter/setter
        public string CardValue
        {
            get { return cardValue; }
            set { cardValue = value; }
        }

        //public string getSuit()
        //{
        //    return suit;
        //}

        //public void setSuit(string newSuit)
        //{
        //    suit = newSuit;
        //}

        //public string getValue()
        //{
        //    return value;
        //}

        //public void setValue(string newValue)
        //{
        //    value = newValue;
        //}

        public string getCard()
        {
            return cardValue + " of " + suit;
        }
    }
}
