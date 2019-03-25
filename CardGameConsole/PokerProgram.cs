/************************
 Author: Asel Sathkumara
 Version: 2.0
 ************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

namespace CardGameConsole
{
    /// <summary>
    /// The class Program contains the calls to the various methods that are used to run the Poker Game.
    /// </summary>
    class PokerProgram
    {
        /// <summary>
        /// Contains the code for the user interface.
        /// </summary>
        static void Main(string[] args)
        {
            Console.Title = "C# Poker Game v2.0";

            NewPokerSession();
            
            ResetConsoleColor();
         
            Console.WriteLine
            (
                 "Welcome to the Poker Game." +
                 "\n\nRules:" +
                $"\n\nYou start with {PokerSession.HandSize} cards in your hand and a balance of {PokerSession.Balance:C}. Each round will be a $1.00 bet." +
                 "\n\nBoth players are given the chance to replace one card in their hand if they choose to." +
                 "\n\nBy default, the player with the highest hand value wins. \nBut, a player with a higher valued poker hand wins automatically." +
                 "\n\nIf both players tie, the tie-breaker will be the hand with highest value." +
                 "\n\nIf you lose, you have the option to rebuy in at $10.00 for the next round, check your score or quit the game." +
                 "\n\nPress any key when you are ready to start..."
            );   

            Console.ReadKey();
            Console.Clear();

            RunPokerSession();
                      
            Console.ReadLine();

        } // end of Main()

        /// <summary>
        /// Runs the poker session.
        /// </summary>
        private static void RunPokerSession()
        {
            // Create our deck object
            CardSet myDeck = new CardSet();

            while (PokerSession.Balance != 0)
            {               
                myDeck.ResetUsage();

                // Retrieves the computer and player hands.
                SuperCard[] computerHand = myDeck.GetCards(PokerSession.HandSize);
                SuperCard[] playerHand = myDeck.GetCards(PokerSession.HandSize);

                // Sorts the computer and player hands using the SuperCard's IComparable implementation.
                Array.Sort(computerHand);
                Array.Sort(playerHand);

                // Display the hands and allow the player / computer to replace one of their cards.
                DisplayHands(computerHand, playerHand);
                PlayerDrawsOne(playerHand, myDeck);
                ComputerDrawsOne(computerHand, myDeck);

                // Sort the new hands and display them.
                Array.Sort(computerHand);
                Array.Sort(playerHand);
                Console.WriteLine();
                DisplayHands(computerHand, playerHand);

                // Resets console to base color scheme
                ResetConsoleColor();

                // Determines whether the player won or lost by calling the CompareHands()
                bool playerWon = CompareHands(computerHand, playerHand);

                // Player won the hand, Computer lost the hand.
                if (playerWon == true)
                {

                    Console.WriteLine
                    (
                        $"\nYou won. \nYou have {++PokerSession.Balance:C} left. " +
                        $"\nHit Enter for another hand."
                    );
                    PokerSession.PlayerWinCounter++;
                    PokerSession.RoundCounter++;
                }

                // Player lost the hand, Computer won the hand.
                if (playerWon == false)
                {

                    Console.WriteLine
                    (
                        $"\nYou lost. \nYou have {--PokerSession.Balance:C} left. " +
                        $"\nHit Enter for another hand."
                    );
                    PokerSession.ComputerWinCounter++;
                    PokerSession.RoundCounter++;
                }

                TerminatePokerSession();

                Console.ReadLine();
                Console.Clear();

            } // end of while (PokerSession.Balance != 0)
        }

        /// <summary>
        /// Handles the termination of the session.
        /// </summary>
        private static void TerminatePokerSession()
        {
            while (PokerSession.Balance == 0)
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
                                $"You have replenished your stack and now have {PokerSession.Balance:c}." +
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
                                $"You won {PokerSession.PlayerWinCounter} rounds " +
                                $"and the computer won {PokerSession.ComputerWinCounter} rounds " +
                                $"out of {PokerSession.RoundCounter}" +
                                "\nPress B to rebuy in at $10, S to see your score or Q to exit."
                            );
                            break;

                        default: // Invalid
                            Console.Clear();
                            Console.WriteLine("Not a valid input.\nPress B to rebuy in at $10, S to see your score or Q to exit.");
                            break;
                    }

                } while (PokerSession.Balance == 0);


            } // end of while(PokerSession.Balance == 0)
        }

        /// <summary>
        /// Initializes the poker session. 
        /// </summary>
        private static void NewPokerSession()
        {
            PokerSession.Balance = 10;
            PokerSession.HandSize = 5;
            PokerSession.PlayerWinCounter = 0;
            PokerSession.ComputerWinCounter = 0;
            PokerSession.RoundCounter = 0;
       
        }

        /// <summary>
        /// Allows the computer to replace a card in their hand if conditions are met.
        /// </summary>
        /// <param name="pComputerHand">The computer's current hand</param>
        /// <param name="pDeck">The deck of 52 cards</param>
        private static void ComputerDrawsOne(SuperCard[] pComputerHand, CardSet pDeck)
        {
            // Stores the card object in the first position of the hand.
            int lowestValuedCard = (int)pComputerHand[0].CardRank;

            // Stores the index of the lowest card.
            int lowestCardIndex = 0;

            // Checks for a poker hand. 
            PokerHand pokerHand = PokerHandEvaluator.EvaluatePokerHand(pComputerHand);           


            for (int i = 0; i < pComputerHand.Length; i++)
            {
                // When the initial card object is no longer the lowest valued card, we update it and save the index.
                if (lowestValuedCard > (int)pComputerHand[i].CardRank)
                {
                    lowestValuedCard = (int)pComputerHand[i].CardRank;
                    lowestCardIndex = i;
                }
            }
            
            // When the lowest valued card is less than or equal to 7 and not a poker hand, replace the card.
            if (lowestValuedCard <= 7 && pokerHand == PokerHand.NotPokerHand)
            {
                pComputerHand[lowestCardIndex] = pDeck.GetOneCard();
            }


        }


        /// <summary>
        /// Allows the player to replace a card in their hand.
        /// </summary>
        /// <param name="pPlayerHand">The player's current hand</param>
        /// <param name="pDeck">The deck of 52 cards</param>
        /// <exception cref="IndexOutOfRangeException">When a player attempts to switch out a position that is higher than their hand size.</exception>
        /// <exception cref="FormatException">When a player attempts to enter a value that can't be parsed into an int32 (such as "Enter").</exception>
        private static void PlayerDrawsOne(SuperCard[] pPlayerHand, CardSet pDeck)
        {
            bool cardReplaced = false;

            while (!cardReplaced)
            {
                Console.WriteLine
                (
                    "\nEnter 1, 2, 3, 4 or 5 to replace a card in your hand." +
                    "\nEnter 0 if you don't want to replace a card in your hand."
                );

                try
                {
                    // Switch on the user's response and update the card by position if a valid integer is entered.
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
                            Console.WriteLine("\nInvalid Input.");
                            cardReplaced = false;
                            break;
                    }
                }
            
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input.");

                }

                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\nInvalid Input.");
                }

            } // end of while(!cardReplaced)

        } // end of PlayerDrawsOne()

    

        /// <summary>
        /// Loops throughs the collections in pComputerHand[] and pPlayerHand[], calling the Display() of each card object.
        /// </summary>
        /// <param name="pComputerHand">Stores the computerHand[] of type SuperCard</param>
        /// <param name="pPlayerHand">Stores the playerHand[] of type SuperCard</param>
        private static void DisplayHands(SuperCard[] pComputerHand, SuperCard[] pPlayerHand)
        {
            Console.WriteLine("DEALER HAND");

            // Loops through cards (and their card classes) stored in pComputerHand[] and displays them. 
            foreach (SuperCard card in pComputerHand)
            {
                if (card != null)
                {
                    card.Display();
           
                }
            }

            // Resets console color back to Base
            ResetConsoleColor();
            

            Console.WriteLine("\nPLAYER HAND");

            // Loops through cards (and their card classes) stored in pPlayerHand[] and displays them. 
            foreach (SuperCard card in pPlayerHand)
            {
                if (card != null)
                {
                    card.Display();
                    
                }
 
            }

            // Resets console color back to base
            ResetConsoleColor();
            

        } // end of DisplayHands()


        /// <summary>
        /// Evaluates the value of the player hand and computer hand. 
        /// </summary>
        /// <param name="pComputerHand">The computer's current hand.</param>
        /// <param name="pPlayerHand">The player's current hand.</param>
        /// <returns>Returns true if the player won and false if the player lost. This value is stored in the the bool won variable.</returns>
        private static bool CompareHands(SuperCard[] pComputerHand, SuperCard[] pPlayerHand)
        {     
            int playerHandValue = PokerHandEvaluator.EvaluateHandValue(pPlayerHand); 
            int computerHandValue = PokerHandEvaluator.EvaluateHandValue(pComputerHand);

            PokerHand playerHand = PokerHandEvaluator.EvaluatePokerHand(pPlayerHand);
            PokerHand computerHand = PokerHandEvaluator.EvaluatePokerHand(pComputerHand);

            // If the poker hands of both players are equal, the player loses.
            if (playerHand == computerHand)
            {
                Console.WriteLine
                (
                    $"\nBoth players have {playerHand.ExtendToString()}!" +
                    $"\nYour hand was worth {playerHandValue} points " +
                    $"and the computer's hand was worth {computerHandValue} points."
                );
                

                // If the player's hand value is greater than the computer's hand value, the player won.
                if (playerHandValue > computerHandValue)
                {
                    return true;
                }

                // If the player's hand value is less than or equal to the computer's hand value, the player lost.
                if (playerHandValue <= computerHandValue)
                {
                    return false;
                }
            }

            // If the player's poker hand rarity is greater than that of the computer's, the player wins. 
            if (playerHand > computerHand)
            {
                Console.WriteLine($"\nThe player has {playerHand.ExtendToString()}!");
                return true;
            }

            // If the player's poker hand rarity is less than that of the computer's, the computer wins.
            if (playerHand < computerHand)
            {
                Console.WriteLine($"\nThe computer has {computerHand.ExtendToString()}!");
                return false;
            }

            else
            {
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

    } // end of class Program

} // end of namespace CardGameConsole
