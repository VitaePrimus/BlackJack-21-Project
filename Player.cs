using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackV2
{
    class Player
    {
        Bets mainBet;
        Card[] hand = new Card[5];
        int inHand;
        Rules rulesScore = new Rules();
        int score;

        public Player()
        {
            mainBet = new Bets();
        }

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

        public void PlaceBet(double bet)
        {
            mainBet.PlaceBet(bet);
        }

        public string GetBalance()
        {
            return mainBet.Balance();
        }

        public double GetMoney()
        {
            return mainBet.GetMoney();
        }

        public void SetMoney(double money)
        {
            mainBet.SetMoney(money);
        }

        public string Bust()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string bust = ">>>You busted<<<";
            Console.WriteLine(bust);
            Console.ForegroundColor = ConsoleColor.White;
            return bust;
        }

        public void Win()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You won!");
            mainBet.WinBet();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Lose()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("You lost");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            mainBet.Draw();
            Console.WriteLine("Draw, you get your bet back.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
