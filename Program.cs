using System;

namespace BlackJackV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start of the BlackJack Game
            // Made by Vitaliy Vuychych

            Deck playDeck = new Deck();
            Rules gameRules = new Rules();
            int playerNum = 2;
            Dealer dealer = new Dealer();
            double bet = 10;
            string choice;
            bool play = true;
            string playChoice = "";
            string[] choiceList = { "No", "N", "n", "no", "NO", "Stop", "stop", "STOP", "S", "s" };

            Console.WriteLine("### Hello and Welcome to the BlackJackGame!!! ###");
            Console.WriteLine();
            Console.Write("How many players do you have?: ");
            playerNum = Convert.ToInt32(Console.ReadLine());
            Player[] player = new Player[playerNum];

            // Declaring players based on the choice
            for (int i = 0; i < player.Length; i++)
            {
                player[i] = new Player();
            }

            // Getting balance for players
            for (int i = 0; i < player.Length; i++)
            {
                Console.WriteLine("Player " + (i + 1) + "| " + player[i].GetBalance());
            }

            // Main loop
            while (play)
            {
                // Clearing the hands
                for (int i = 0; i < playerNum; i++)
                {
                    player[i].ClearHand();
                }
                dealer.ClearHand();

                Console.WriteLine();
                Console.WriteLine("_________________________________________________________");

                for (int i = 0; i < playerNum; i++)
                {
                    do
                    {
                        if (bet > player[i].GetMoney())
                        {
                            player[i].SetMoney(player[i].GetMoney() + bet);
                            Console.WriteLine("You do not have enough money!");
                        }
                        Console.Write("Player " + (i + 1) + " please place your bet: ");
                        bet = Convert.ToDouble(Console.ReadLine());
                        player[i].PlaceBet(bet);
                        Console.WriteLine(player[i].GetBalance());
                        Console.WriteLine();
                    } while (bet > (player[i].GetMoney() + bet));
                }


                // Shuffle the deck
                playDeck.Shuffle();

                dealer.GetCard(playDeck.DealCard());
                Console.WriteLine("Dealer's first card: " + dealer.DisplayHand());
                Console.WriteLine();

                for (int i = 0; i < playerNum; i++)
                {
                    if (player[i].GetMoney() >= 0)
                    {
                        player[i].GetCard(playDeck.DealCard());

                        // Player move
                        choice = "H";
                        while ((choice == "H" || choice == "h"))
                        {
                            choice = "";
                            player[i].GetCard(playDeck.DealCard());
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            if (i == 0 || i == 0 + 4 || i == 0 + 8)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                            }
                            else if (i == 1 || i == 1 + 4 || i == 1 + 8)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else if (i == 2 || i == 2 + 4 || i == 2 + 8)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            else if (i == 3 || i == 3 + 4 || i == 3 + 8)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                            }

                            Console.Write("Player " + (i + 1) + ": ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Your cards: " + player[i].DisplayHand());

                            // Hitting
                            if (player[i].InHand < 5 && player[i].GetScore() <= 21)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Your score: " + player[i].GetScore());

                                Console.Write("Press 'H' to hit or 'S' to stay: ");
                                choice = Console.ReadLine();
                            }

                            // Bust
                            else if (player[i].GetScore() > 21)
                            {
                                player[i].Bust();
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Player " + (i + 1) + " is out of money.");
                    }



                }

                // Dealer move
                while (dealer.GetScore() < 17)
                {
                    dealer.GetCard(playDeck.DealCard());
                }

                for (int i = 0; i < playerNum; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player " + (i + 1) + " score is: " + player[i].GetScore());
                }


                // Display player's final hand score

                // Display dealer's final hand score
                Console.WriteLine();
                Console.WriteLine("Dealer's first card: " + dealer.DisplayHand());
                Console.WriteLine("Dealer's score: " + dealer.GetScore());
                // Dealer bust
                if (dealer.GetScore() > 21)
                {
                    dealer.Bust();
                }

                Console.WriteLine();

                for (int i = 0; i < playerNum; i++)
                {
                    // Comparing the scores
                    if (player[i].GetScore() == 21 || player[i].InHand == 5)
                    {
                        Console.Write("Player " + (i + 1) + " ");
                        player[i].Win();
                    }
                    else if (player[i].GetScore() > dealer.GetScore() && player[i].GetScore() <= 21 && dealer.GetScore() <= 21)
                    {
                        Console.Write("Player " + (i + 1) + " ");
                        player[i].Win();
                    }
                    else if (player[i].GetScore() <= 21 && dealer.GetScore() > 21)
                    {
                        Console.Write("Player " + (i + 1) + " ");
                        player[i].Win();
                    }
                    else if (player[i].GetScore() == dealer.GetScore() && player[i].GetScore() <= 21)
                    {
                        Console.Write("Player " + (i + 1) + " ");
                        player[i].Draw();
                    }
                    else
                    {
                        Console.Write("Player " + (i + 1) + " ");
                        player[i].Lose();
                    }
                }

                Console.WriteLine();

                // Balance at the end of the round
                for (int i = 0; i < playerNum; i++)
                {
                    player[i].GetBalance();
                }


                Console.ReadKey();
                Console.Clear();
                // Asking if the game should continue
                Console.Write("Continue playing? (Press 'N' to Stop playing): ");
                playChoice = Console.ReadLine();
                for (int i = 0; i < choiceList.Length; i++)
                {
                    if (playChoice == choiceList[i])
                    {
                        play = false;
                    }
                }

            }

            // Final balance
            for (int i = 0; i < playerNum; i++)
            {
                Console.WriteLine("Final balance of player " + (i + 1) + ": $" + player[i].GetMoney());
            }

            // Exiting
            Console.WriteLine("Press any key to close the program...");
            Console.ReadKey();
        }

        //Notes to self
        //1150 - intro to web dev (summer)
        //2351 - into to data base (summer)
        //2650 - Java (16 week is best) !!! take during autumn
        //1090 - DO NOT TAKE
        //2320 - AFTER 1150 more interactive web development
        //2660 - data structures after 2650


        //public void NotesOfWorkflow()
        //{
        //    // dealer takes a card and shows it (possibly takes two cards but shows only one)
        //    // player takes 2 card, combine the amount the cars are worth
        //    // player places a bet
        //    // player hits/stays // in the future double and split
        //    // dealer makes a choice to hit or stay depending on the cards, hits up to 17 points
        //    // score is calculated, player either wins or looses
        //    // calculate player's balance based on the outcome of the round
        //    // loop and repeat until player looses all their money or quits the game

        //// prints out the whole deck 
        //for (int i = 0; i < 52; i++)
        //{
        //    newCard = playDeck.DealCard();
        //    Console.WriteLine(newCard.getCard());
        //    Console.WriteLine(gameRules.Score(newCard.CardValue));

        //}

        //}
    }
}
