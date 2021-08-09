using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackV2
{
    class Rules
    {
        public int Score(string cardValue)
        {
            int score;

            switch (cardValue)
            {
                case "Two": score = 2; break;
                case "Three": score = 3; break;
                case "Four": score = 4; break;
                case "Five": score = 5; break;
                case "Six": score = 6; break;
                case "Seven": score = 7; break;
                case "Eight": score = 8; break;
                case "Nine": score = 9; break;                
                case "Ace": score = 11; break;
                default: score = 10; break;
            }

            return score;

        }

        //public int IsAce(int score, bool ace)
        //{
        //    while(ace)
        //    {
        //        if (score > 21)
        //        {
        //            score = score - 10;
        //        }
        //        else
        //        {
        //            score = score + 0;
        //        }
        //    } 

        //    return score;
        //}

        //public void EndGame()
        //{

        //}
    }
}
