using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackV2
{
    class Deck
    {
        Card[] deck;
        int currentCard;
        string[] cardValue = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        string[] suit = { "♥", "♦", "♣", "♠" };

        public Deck()
        {
            deck = new Card[52];
            currentCard = 0;
            int count = 0;

            for (int i = 0; i < suit.Length; i++)
            {
                for (int x = 0; x < cardValue.Length; x++)
                {
                    deck[count] = new Card(cardValue[x], suit[i]);
                    count++;
                }
            }
        }

        public Card DealCard()
        {
            Card temp = deck[currentCard];
            currentCard++;

            // automatically shuffles the deck when more than 52 cards are drawn
            if (currentCard > 51)
            {
                currentCard = 0;
                Shuffle();
            }

            return temp;
        }
        
        public void Shuffle()
        {
            Random rng = new Random();
            Card temp;

            int rng1;
            int i = 0;
            currentCard = 0;
            
            do
            {
                rng1 = rng.Next(i, 52);
                temp = deck[rng1];
                deck[rng1] = deck[i];
                deck[i] = temp;
                i++;

            } while (i < 52);
        }

        //public int Score(string cardValue)
        //{
        //    int score;

        //    if (cardValue == "Two")
        //    {
        //        score = 2;
        //    }
        //    else if (cardValue == "Three")
        //    {
        //        score = 3;
        //    }
        //    else if(cardValue == "Four")
        //    {
        //        score = 4;
        //    }
        //    else if(cardValue == "Five")
        //    {
        //        score = 5;
        //    }
        //    else if(cardValue == "Six")
        //    {
        //        score = 6;
        //    }
        //    else if(cardValue == "Seven")
        //    {
        //        score = 7;
        //    }
        //    else if(cardValue == "Eight")
        //    {
        //        score = 8;
        //    }
        //    else if(cardValue == "Nine")
        //    {
        //        score = 9;
        //    }
        //    else if(cardValue == "Ten" || cardValue == "Jack" || cardValue == "Queen" || cardValue == "King")
        //    {
        //        score = 10;
        //    }
        //    else if(cardValue == "Ace")
        //    {
        //        score = 11;
        //    }
        //    else
        //    {
        //        score = 0;
        //    }

        //    return score;

        //}

    }
}
