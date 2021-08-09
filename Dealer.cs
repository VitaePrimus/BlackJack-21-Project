using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackV2
{
    class Dealer
    {
        Card[] hand = new Card[5];
        int inHand;
        Rules rulesScore = new Rules();
        int score;

        public int InHand
        {
            get { return inHand; }
        }

        public void GetCard(Card card)
        {
            hand[inHand] = card;
            inHand++;
        }

        public string DisplayHand()
        {
            string displayHand = "";

            for (int i = 0; i < inHand; i++)
            {
                displayHand = displayHand + "| " + hand[i].getCard() + " |";
            }

            return displayHand;
        }

        public int GetScore()
        {
            score = 0;
            int bigAce = 0;

            for (int i = 0; i < inHand; i++)
            {
                score = score + rulesScore.Score(hand[i].CardValue);
                if (rulesScore.Score(hand[i].CardValue) == 11)
                {
                    bigAce = 1;
                }
            }

            if (bigAce == 1 && score > 21)
            {
                score = score - 10;
                bigAce = 0;
            }

            return score;
        }

        public void ClearHand()
        {
            inHand = 0;
        }

        public string Bust()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string bust = ">>>Dealer busted<<<";
            Console.WriteLine(bust);
            Console.ForegroundColor = ConsoleColor.White;
            return bust;
        }

    }
}
