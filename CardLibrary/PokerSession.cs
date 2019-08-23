using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLibrary
{
    /// <summary>
    /// Represents the poker session.
    /// </summary>
    public static class PokerSession
    {
        /// <summary>
        /// The maximum size for a player's hand.
        /// </summary>
        private const int HandSize = 5;

        /// <summary>
        /// The player's balance.
        /// </summary>
        private static decimal balance;

        /// <summary>
        /// The player's number of wins.
        /// </summary>
        private static int playerWinCounter;

        /// <summary>
        /// The computer's number of wins.
        /// </summary>
        private static int computerWinCounter;

        /// <summary>
        /// The number of rounds in the session.
        /// </summary>
        private static int roundCounter;

        /// <summary>
        /// Runs the poker session.
        /// </summary>
        public static void Run()
        {
            
            Initialize();

            DisplayMainMenu();

            Console.Clear();

            Deck myDeck = new Deck();

            while (balance != 0)
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

                if (CompareHands(computerHand, playerHand))
                {

                    Console.WriteLine
                    (
                        $"\nYou won. \nYou have {++balance:C} left. " +
                        $"\nHit Enter for another hand."
                    );

                    playerWinCounter++;
                    roundCounter++;
                }

                else
                {

                    Console.WriteLine
                    (
                        $"\nYou lost. \nYou have {--balance:C} left. " +
                        $"\nHit Enter for another hand."
                    );

                    computerWinCounter++;
                    roundCounter++;
                }

                Terminate();

                Console.ReadKey();
                Console.Clear();

            } // end of while (PokerSession.Balance != 0)
        }

        /// <summary>
        /// Terminates the session.
        /// </summary>
        private static void Terminate()
        {
            while (balance == 0)
            {
                Console.Clear();

                Console.WriteLine("You've run out of money.\nPress B to rebuy in at $10, S to see your score or Q to exit.");

                do
                {
                    switch (Console.ReadKey().KeyChar)
                    {
                        case 'b': // Rebuy In
                            Console.Clear();

                            Initialize();

                            Console.WriteLine
                            (
                                $"You have replenished your stack and now have {balance:c}." +
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
                                $"You won {playerWinCounter} rounds " +
                                $"and the computer won {computerWinCounter} rounds " +
                                $"out of {roundCounter}" +
                                "\nPress B to rebuy in at $10, S to see your score or Q to exit."
                            );
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Not a valid input.\nPress B to rebuy in at $10, S to see your score or Q to exit.");
                            break;
                    }

                } while (balance == 0);


            } // end of while
        }

        /// <summary>
        /// Initializes the poker session. 
        /// </summary>
        private static void Initialize()
        {
            balance = 10;
            playerWinCounter = 0;
            computerWinCounter = 0;
            roundCounter = 0;

        }

        /// <summary>
        /// Allows the computer to replace a card in their hand.
        /// </summary>
        /// <param name="pComputerHand">The computer's current hand</param>
        /// <param name="pDeck">The deck of cards.</param>
        private static void ComputerDrawsOne(Card[] pComputerHand, Deck pDeck)
        {
            int lowestCardValue = (int)pComputerHand[0].Rank;
            int lowestCardIndex = 0;
            PokerHand pokerHand = PokerHandEvaluator.EvaluatePokerHand(pComputerHand);

            for (int i = 0; i < pComputerHand.Length; i++)
            {
                int currentCardValue = (int)pComputerHand[i].Rank;

                if (lowestCardValue > currentCardValue)
                {
                    lowestCardValue = currentCardValue;
                    lowestCardIndex = i;
                }
            }

            if (lowestCardValue <= 7 && pokerHand == PokerHand.NotPokerHand)
                pComputerHand[lowestCardIndex] = pDeck.GetCard();

            Array.Sort(pComputerHand);

        }

        /// <summary>
        /// Allows the player to replace a card in their hand.
        /// </summary>
        /// <param name="pPlayerHand">The player's current hand</param>
        /// <param name="pDeck">The deck of cards</param>
        /// <exception cref="IndexOutOfRangeException">The player tried to replace a card that wasn't in their hand.</exception>
        /// <exception cref="FormatException">The player didn't specify a valid command.</exception>
        private static void PlayerDrawsOne(Card[] pPlayerHand, Deck pDeck)
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
                            pPlayerHand[0] = pDeck.GetCard();
                            cardReplaced = true;
                            break;
                        case 2:
                            pPlayerHand[1] = pDeck.GetCard();
                            cardReplaced = true;
                            break;
                        case 3:
                            pPlayerHand[2] = pDeck.GetCard();
                            cardReplaced = true;
                            break;
                        case 4:
                            pPlayerHand[3] = pDeck.GetCard();
                            cardReplaced = true;
                            break;
                        case 5:
                            pPlayerHand[4] = pDeck.GetCard();
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
        /// Displays the players hands.
        /// </summary>
        /// <param name="pComputerHand">The computer's hand.</param>
        /// <param name="pPlayerHand">The player's hand.</param>
        private static void DisplayHands(Card[] pComputerHand, Card[] pPlayerHand)
        {
            Console.WriteLine("DEALER HAND");

            foreach (Card card in pComputerHand)
            {
                if (card != null)
                    card.Display();
            }

            ResetConsoleColor();

            Console.WriteLine("\nPLAYER HAND");
            
            foreach (Card card in pPlayerHand)
            {
                if (card != null)
                    card.Display();
            }

            ResetConsoleColor();

        } // end of DisplayHands()

        /// <summary>
        /// Compares the player's hands. 
        /// </summary>
        /// <param name="pComputerHand">The computer's current hand.</param>
        /// <param name="pPlayerHand">The player's current hand.</param>
        /// <returns>Returns true if the player won; and false otherwise.</returns>
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

                return playerHandValue > computerHandValue;
            }

            // If the player's poker hand rarity is greater than that of the computer's, the player wins. 
            else if (playerHand > computerHand)
            {
                Console.WriteLine($"\nYou have {playerHand.ExtendToString()}!");
                return true;
            }

            // If the player's poker hand rarity is less than that of the computer's, the computer wins.
            else
            {
                Console.WriteLine($"\nThe computer has {computerHand.ExtendToString()}!");
                return false;
            }

            
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
        /// Displays the main menu.
        /// </summary>
        private static void DisplayMainMenu()
        {
            ResetConsoleColor();

            Console.WriteLine
            (
                 "Welcome to C# Poker." +
                 "\n\nRules:" +
                $"\n\nYou start with {HandSize} cards in your hand and a balance of {balance:C}. Each round will be a $1.00 bet." +
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
