using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Deals with the variables and functionality of a poker session.
    /// </summary>
    public static class PokerSession
    {
        /// <summary>
        /// Defines the player's balance.
        /// </summary>
        private static int Balance { get; set; }

        /// <summary>
        /// Defines the hand size of the player and the computer.
        /// </summary>
        private static int HandSize { get; set; }

        /// <summary>
        /// Contains the player's total number of wins.
        /// </summary>
        private static int PlayerWinCounter { get; set; }

        /// <summary>
        /// Contains the computer's total number of wins.
        /// </summary>
        private static int ComputerWinCounter { get; set; }

        /// <summary>
        /// Contains the total number of rounds elapsed. 
        /// </summary>
        private static int RoundCounter { get; set; }

        /// <summary>
        /// Runs the poker session.
        /// </summary>
        public static void RunPokerSession()
        {
            
            NewPokerSession();

            DisplayTitleScreen();

            Console.Clear();

            CardSet myDeck = new CardSet();

            while (Balance != 0)
            {
                myDeck.Reset();

                Card[] computerHand = myDeck.GetCards(HandSize);
                Card[] playerHand = myDeck.GetCards(HandSize);
                DisplayHands(computerHand, playerHand);

                PlayerDrawsOne(playerHand, myDeck);
                ComputerDrawsOne(computerHand, myDeck);
                Console.WriteLine();
                DisplayHands(computerHand, playerHand);
                ResetConsoleColor();

                bool playerWon = CompareHands(computerHand, playerHand);

                if (playerWon)
                {

                    Console.WriteLine
                    (
                        $"\nYou won. \nYou have {++Balance:C} left. " +
                        $"\nHit Enter for another hand."
                    );

                    PlayerWinCounter++;
                    RoundCounter++;
                }

                if (!playerWon)
                {

                    Console.WriteLine
                    (
                        $"\nYou lost. \nYou have {--Balance:C} left. " +
                        $"\nHit Enter for another hand."
                    );

                    ComputerWinCounter++;
                    RoundCounter++;
                }

                TerminatePokerSession();

                Console.ReadKey();
                Console.Clear();

            } // end of while (PokerSession.Balance != 0)
        }

        /// <summary>
        /// Handles the termination of the session.
        /// </summary>
        private static void TerminatePokerSession()
        {
            while (Balance == 0)
            {
                Console.Clear();

                Console.WriteLine("You've run out of money.\nPress B to rebuy in at $10, S to see your score or Q to exit.");

                do
                {
                    switch (Console.ReadKey().KeyChar)
                    {
                        case 'b': // Rebuy In
                            Console.Clear();

                            NewPokerSession();

                            Console.WriteLine
                            (
                                $"You have replenished your stack and now have {Balance:c}." +
                                    "\nPress Enter for a new hand."
                            );
                            break;

                        case 'q': // Exit
                            Console.Clear();
                            Console.WriteLine("Thank you for playing.");
                            System.Threading.Thread.Sleep(2000);
                            Environment.Exit(0);
                            break;

                        case 's': // Check Score
                            Console.Clear();

                            Console.WriteLine
                            (
                                $"You won {PlayerWinCounter} rounds " +
                                $"and the computer won {ComputerWinCounter} rounds " +
                                $"out of {RoundCounter}" +
                                "\nPress B to rebuy in at $10, S to see your score or Q to exit."
                            );
                            break;

                        default: // Invalid
                            Console.Clear();
                            Console.WriteLine("Not a valid input.\nPress B to rebuy in at $10, S to see your score or Q to exit.");
                            break;
                    }

                } while (Balance == 0);


            } // end of while(PokerSession.Balance == 0)
        }

        /// <summary>
        /// Initializes the poker session. 
        /// </summary>
        private static void NewPokerSession()
        {
            Balance = 10;
            HandSize = 5;
            PlayerWinCounter = 0;
            ComputerWinCounter = 0;
            RoundCounter = 0;

        }

        /// <summary>
        /// Allows the computer to replace a card in their hand if conditions are met.
        /// </summary>
        /// <param name="pComputerHand">The computer's current hand</param>
        /// <param name="pDeck">The deck of 52 cards</param>
        private static void ComputerDrawsOne(Card[] pComputerHand, CardSet pDeck)
        {
            int lowestCardValue = (int)pComputerHand[0].CardRank;
            int lowestCardIndex = 0;
            PokerHand pokerHand = PokerHandEvaluator.EvaluatePokerHand(pComputerHand);
            
            for (int i = 0; i < pComputerHand.Length; i++)
            {
                int currentCardValue = (int)pComputerHand[i].CardRank;

                if (lowestCardValue > currentCardValue)
                {
                    lowestCardValue = currentCardValue;
                    lowestCardIndex = i;
                }
            }

            if (lowestCardValue <= 7 && pokerHand == PokerHand.NotPokerHand)
            {
                pComputerHand[lowestCardIndex] = pDeck.GetOneCard();
            }

            Array.Sort(pComputerHand);

        }

        /// <summary>
        /// Allows the player to replace a card in their hand.
        /// </summary>
        /// <param name="pPlayerHand">The player's current hand</param>
        /// <param name="pDeck">The deck of 52 cards</param>
        /// <exception cref="IndexOutOfRangeException">When a player attempts to switch out a position that is higher than their hand size.</exception>
        /// <exception cref="FormatException">When a player attempts to enter a value that can't be parsed into an int32 (such as "Enter").</exception>
        private static void PlayerDrawsOne(Card[] pPlayerHand, CardSet pDeck)
        {
            bool cardReplaced = false;

            while (!cardReplaced)
            {
                try
                {
                    Console.WriteLine
                    (
                    "\nEnter 1, 2, 3, 4 or 5 to replace a card in your hand." +
                    "\nEnter 0 if you don't want to replace a card in your hand."
                    );

                    switch (Int32.Parse(Console.ReadLine()))
                    {
                        case 0:
                            cardReplaced = true;
                            break;
                        case 1:
                            pPlayerHand[0] = pDeck.GetOneCard();
                            cardReplaced = true;
                            break;
                        case 2:
                            pPlayerHand[1] = pDeck.GetOneCard();
                            cardReplaced = true;
                            break;
                        case 3:
                            pPlayerHand[2] = pDeck.GetOneCard();
                            cardReplaced = true;
                            break;
                        case 4:
                            pPlayerHand[3] = pDeck.GetOneCard();
                            cardReplaced = true;
                            break;
                        case 5:
                            pPlayerHand[4] = pDeck.GetOneCard();
                            cardReplaced = true;
                            break;
                        default:
                            cardReplaced = true;
                            break;
                    }

                }
                catch (ArgumentNullException)
                {
                    break;
                }
                catch (OverflowException)
                {
                    break;
                }
                catch (FormatException)
                {
                    break;
                }
                catch (IndexOutOfRangeException)
                { 
                    break;
                }
                catch (Exception)
                {
                    break;
                }

            } // end of while(!cardReplaced)

            Array.Sort(pPlayerHand);

        } // end of PlayerDrawsOne()

        /// <summary>
        /// Loops throughs the collections in pComputerHand[] and pPlayerHand[], calling the Display() of each card object.
        /// </summary>
        /// <param name="pComputerHand">Stores the computerHand[] of type SuperCard</param>
        /// <param name="pPlayerHand">Stores the playerHand[] of type SuperCard</param>
        private static void DisplayHands(Card[] pComputerHand, Card[] pPlayerHand)
        {
            Console.WriteLine("DEALER HAND");

            foreach (Card card in pComputerHand)
            {
                if (card != null)
                {
                    card.Display();
                }
            }

            ResetConsoleColor();

            Console.WriteLine("\nPLAYER HAND");
            
            foreach (Card card in pPlayerHand)
            {
                if (card != null)
                {
                    card.Display();
                }

            }

            ResetConsoleColor();

        } // end of DisplayHands()

        /// <summary>
        /// Compares the value and the rarity of the poker hand and decides who wins. 
        /// </summary>
        /// <param name="pComputerHand">The computer's current hand.</param>
        /// <param name="pPlayerHand">The player's current hand.</param>
        /// <returns>Returns true if the player won and false if the player lost. This value is stored in the the bool won variable.</returns>
        private static bool CompareHands(Card[] pComputerHand, Card[] pPlayerHand)
        {
            int playerHandValue = PokerHandEvaluator.EvaluateHandValue(pPlayerHand);
            int computerHandValue = PokerHandEvaluator.EvaluateHandValue(pComputerHand);

            PokerHand playerHand = PokerHandEvaluator.EvaluatePokerHand(pPlayerHand);
            PokerHand computerHand = PokerHandEvaluator.EvaluatePokerHand(pComputerHand);

            if (playerHand == computerHand)
            {
                Console.WriteLine
                (
                    $"\nBoth players have {playerHand.ExtendToString()}!" +
                    $"\nYour hand was worth {playerHandValue} points " +
                    $"and the computer's hand was worth {computerHandValue} points."
                );
                
                if (playerHandValue > computerHandValue)
                    return true;

                if (playerHandValue <= computerHandValue)                
                    return false;
                
            }

            // If the player's poker hand rarity is greater than that of the computer's, the player wins. 
            if (playerHand > computerHand)
            {
                Console.WriteLine($"\nYou have {playerHand.ExtendToString()}!");
                return true;
            }

            // If the player's poker hand rarity is less than that of the computer's, the computer wins.
            if (playerHand < computerHand)
            {
                Console.WriteLine($"\nThe computer has {computerHand.ExtendToString()}!");
                return false;
            }

            
            return false;
            


        } // end of CompareHands()     

        /// <summary>
        /// Resets the console color to the game's base scheme.
        /// </summary>
        private static void ResetConsoleColor()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        /// <summary>
        /// Displays the title screen with a welcome message and the rules of the game.
        /// </summary>
        private static void DisplayTitleScreen()
        {
            ResetConsoleColor();

            Console.WriteLine
            (
                 "Welcome to C# Poker." +
                 "\n\nRules:" +
                $"\n\nYou start with {HandSize} cards in your hand and a balance of {Balance:C}. Each round will be a $1.00 bet." +
                 "\n\nBoth players are given the chance to replace one card in their hand if they choose to." +
                 "\n\nBy default, the player with the highest hand value wins. \nBut, a player with a higher valued poker hand wins automatically." +
                 "\n\nIf both players tie, the tie-breaker will be the hand with highest value." +
                 "\n\nIf you lose, you have the option to rebuy in at $10.00 for the next round, check your score or quit the game." +
                 "\n\nPress any key when you are ready to start..."
            );

            Console.ReadKey();
        }
    }
}
