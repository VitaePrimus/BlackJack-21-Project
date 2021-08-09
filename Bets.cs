using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackV2
{
    class Bets
    {
        double money;
        double bet;

        public Bets()
        {
            money = 100;            
        }

        public double GetMoney()
        {
            return money;
        }

        public void SetMoney(double money)
        {
            this.money = money;
        }

        public void PlaceBet(double bet)
        {
            this.bet = bet;
            money = money - bet;
        }

        public void WinBet()
        {
            money = money + (bet * 2);
        }

        public void WinBigBet()
        {
            money = money + (bet * 2.5);
        }

        public string Balance()
        {
            if (money < 0)
            {
                //Loose();
                return null;
            }
            else
            {
                return "Your current balance is: $" + money;
            }

        }

        public void Loose()
        {
            Console.WriteLine("You lost all your money! Game over...");
            Console.WriteLine("Would you like to play again?: ");
        }

        public void Draw()
        {
            money = money + bet;
        }
    }
}
