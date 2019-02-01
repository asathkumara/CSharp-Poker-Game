/************************
 Author: Asel Sathkumara
 Version: 1.0
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
    class Program
    {
        /// <summary>
        /// Contains the code for the user interface.
        /// </summary>
        static void Main(string[] args)
        {
            CardSet myDeck = new CardSet(); 

            // Defines the hand size of the player and the computer.
            // Going below five cards disables some of the poker hand validations.
            int howManyCards = 5;
            
            // Defines the initial balance the player starts out with.
            int balance = 10;

            // Statistic counters
            int playerWinCounter = 0;
            int computerWinCounter = 0;
            int roundCounter = 0;
            

            // Base Color Scheme
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.Title = "C# Poker Game v1.0";

            Console.WriteLine
            (
                 "Welcome to the Poker Game." +
                 "\n\nRules:" +
                $"\n\nYou start with {howManyCards} cards in your hand and a balance of {balance:C}. Each round will be a $1.00 bet." +
                 "\n\nBoth players are given the chance to replace one card in their hand if they choose to." +
                 "\n\nBy default, the player with the highest hand value wins. \nBut, a player with a higher valued poker hand wins automatically." +
                 "\n\nThe house wins on all ties including poker hands." +
                 "\n\nIf you lose, you have the option to rebuy in at $10.00 for the next round, check your score or quit the game." +
                 "\n\nPress any key when you are ready to start..."
            );   

            Console.ReadKey();
            Console.Clear();

            // Round Loop
            while (balance != 0)
            {
                
                myDeck.ResetUsage();

                // Retrieves the computer and player hands.
                SuperCard[] computerHand = myDeck.GetCards(howManyCards); 
                SuperCard[] playerHand = myDeck.GetCards(howManyCards); 

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
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkBlue;

                // Determines whether the player won or lost by calling the CompareHands()
                bool won = CompareHands(computerHand, playerHand);

                // Player won the hand, Computer lost the hand.
                if (won == true) 
                {

                    Console.WriteLine($"\nYou won. \nYou have {++balance:C} left. \nHit Enter for another hand.");
                    playerWinCounter++;
                    roundCounter++;
                }

                // Player lost the hand, Computer won the hand.
                if (won == false) 
                {
                  
                    Console.WriteLine($"\nYou lost. \nYou have {--balance:C} left. \nHit Enter for another hand.");
                    computerWinCounter++;
                    roundCounter++;
                }

                // Game Over Loop
                // Lets the player restart, check their score or quit the application.
                while(balance == 0)
                {
                    Console.Clear();

                    Console.WriteLine("You've run out of money.\nPress B to rebuy in at $10, S to see your score or Q to exit.");

                        Decide:
                        switch (Console.ReadKey().KeyChar)
                        {
                            case 'b':
                                Console.Clear();
                                balance = 10;
                                playerWinCounter = 0;
                                computerWinCounter = 0;
                                roundCounter = 0;
                                Console.WriteLine
                                (
                                    $"You have replenished your stack and now have {balance:c}." + 
                                        "\nPress Enter for a new hand."
                                );
                                break;
                            case 'q':
                                Console.Clear();
                                Console.WriteLine("Thank you for playing.");
                                System.Threading.Thread.Sleep(2000);
                                Environment.Exit(0);
                                break;
                            case 's':
                                Console.Clear();
                                
                                Console.WriteLine
                                (
                                    $"You won {playerWinCounter} rounds and the computer won {computerWinCounter} rounds out of {roundCounter} rounds." +
                                    "\nPress B to rebuy in at $10, S to see your score or Q to exit."
                                );
                                goto Decide;
                            default:
                                Console.Clear();
                                //Console.Beep();
                                Console.WriteLine("Not a valid input.\nPress B to rebuy in at $10, S to see your score or Q to exit.");
                                goto Decide;          
                        }      
                   
                } // end of Game Over Loop

                Console.ReadLine();
                Console.Clear();

            } // end of Round Loop 

            
            Console.ReadLine();

        } // end of Main

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

            // Checks for each poker hand.
            bool notPokerHand = !PokerHands.RoyalFlush(pComputerHand) &&
                                !PokerHands.StraightFlush(pComputerHand) &&
                                !PokerHands.FourOfAKind(pComputerHand) &&
                                !PokerHands.FullHouse(pComputerHand) &&
                                !PokerHands.Flush(pComputerHand) &&
                                !PokerHands.Straight(pComputerHand) &&
                                !PokerHands.ThreeOfAKind(pComputerHand) &&
                                !PokerHands.TwoPair(pComputerHand) &&
                                !PokerHands.OnePair(pComputerHand);
                                
                                


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
            if (lowestValuedCard <= 7 && notPokerHand == true)
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
            foreach (SuperCard item in pComputerHand)
            {
                if (item != null)
                {
                    item.Display();
           
                }
            }

            // Resets console color back to Base
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.WriteLine("\nPLAYER HAND");

            // Loops through cards (and their card classes) stored in pPlayerHand[] and displays them. 
            foreach (SuperCard item in pPlayerHand)
            {
                if (item != null)
                {
                    item.Display();
                    
                }
 
            }

            // Resets console color back to base
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

        } // end of DisplayHands()


        /// <summary>
        /// Evaluates the value of the player hand and computer hand. 
        /// </summary>
        /// <param name="pComputerHand">The computer's current hand.</param>
        /// <param name="pPlayerHand">The player's current hand.</param>
        /// <returns>Returns true if the player won and false if the player lost. This value is stored in the the bool won variable.</returns>
        private static bool CompareHands(SuperCard[] pComputerHand, SuperCard[] pPlayerHand)
        {
            // Stores the value of the player and computer hands.
            int playerHandValue = 0; 
            int computerHandValue = 0;

            // Evaluates the value of computer hand
            for (int i = 0; i < pComputerHand.Length; i++)
            {
                computerHandValue += (int) pComputerHand[i].CardRank; 
            }

            // Evaluates the value of player hand
            for (int i = 0; i < pPlayerHand.Length; i++)
            {
                playerHandValue += (int) pPlayerHand[i].CardRank; 
            }

            #region Poker Hand Evaluations

            #region Royal Flush
            // If there is a royal flush in the computer's hand and the player's hand, the player lost.
            if (PokerHands.RoyalFlush(pPlayerHand) & PokerHands.RoyalFlush(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a royal flush!");
                return false;
            }

            // If there is a royal flush in the player's hand, the player won.
            if (PokerHands.RoyalFlush(pPlayerHand))
            {
                Console.WriteLine("\nYou have a royal flush!");
                return true;
            }

            // If there is a royal flush in the computer's hand, the player lost.
            if (PokerHands.RoyalFlush(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a royal flush!");
                return false;
            }
            #endregion


            #region Straight Flush
            // If there is a straight flush in the computer's hand and the player's hand, the player lost.
            if (PokerHands.StraightFlush(pPlayerHand) & PokerHands.StraightFlush(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a straight flush!");
                return false;
            }

            // If there is a straight flush in the player's hand, the player won.
            if (PokerHands.StraightFlush(pPlayerHand))
            {
                Console.WriteLine("\nYou have a straight flush!");
                return true;
            }

            // If there is a straight flush in the computer's hand, the player lost.
            if (PokerHands.StraightFlush(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a straight flush!");
                return false;
            }
            #endregion


            #region Four Of A Kind 
            // If there is a four of a kind in the computer's hand and the player's hand, the player lost.
            if (PokerHands.FourOfAKind(pPlayerHand) & PokerHands.FourOfAKind(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a four of a kind!");
                return false;
            }

            // If there is a four of a kind in the player's hand, the player won.
            if (PokerHands.FourOfAKind(pPlayerHand))
            {
                Console.WriteLine("\nYou have a four of a kind!");
                return true;
            }

            // If there is a four of a kind in the computer's hand, the player lost.
            if (PokerHands.FourOfAKind(pComputerHand))
            {
                Console.WriteLine("\nThe computer has four of a kind!");
                return false;
            }
            #endregion


            #region Full House
            // If there is a full house in the computer's hand and the player's hand, the player lost.
            if (PokerHands.FullHouse(pPlayerHand) & PokerHands.FullHouse(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a full house!");
                return false;
            }

            // If there is a full house in the player's hand, the player won.
            if (PokerHands.FullHouse(pPlayerHand))
            {
                Console.WriteLine("\nYou have a full house!");
                return true;
            }

            // If there is a four of a kind in the computer's hand, the player lost.
            if (PokerHands.FullHouse(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a full house!");
                return false;
            }
            #endregion


            #region Flush
            // If there is a flush in the player hand and the computer hand, the player lost.
            if (PokerHands.Flush(pPlayerHand) && PokerHands.Flush(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a flush!");
                return false;
            }

            // If there is a flush in the player hand, the player won.
            if (PokerHands.Flush(pPlayerHand))
            {
                Console.WriteLine("\nYou have a flush!");
                return true;
            }

            // If there is a flush in the computer hand, the player lost.
            if (PokerHands.Flush(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a flush!");
                return false;
            }
            #endregion


            #region Straight
            // If there is a straight in the computer's hand and the player's hand, the player lost.
            if (PokerHands.Straight(pPlayerHand) & PokerHands.Straight(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a straight!");
                return false;
            }

            // If there is a straight  in the player's hand, the player won.
            if (PokerHands.Straight(pPlayerHand))
            {
                Console.WriteLine("\nYou have a straight!");
                return true;
            }

            // If there is a straight in the computer's hand, the player lost.
            if (PokerHands.Straight(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a straight!");
                return false;
            }
            #endregion


            #region Three Of A Kind
            // If there is a three of a kind in the computer's hand and the player's hand, the player lost.
            if (PokerHands.ThreeOfAKind(pPlayerHand) & PokerHands.ThreeOfAKind(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a three of a kind!");
                return false;
            }

            // If there is a three of a kind  in the player's hand, the player won.
            if (PokerHands.ThreeOfAKind(pPlayerHand))
            {
                Console.WriteLine("\nYou have a three of a kind!");
                return true;
            }

            // If there is a three of a kind in the computer's hand, the player lost.
            if (PokerHands.ThreeOfAKind(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a three of a kind!");
                return false;
            }
            #endregion


            #region Two Pair
            // If there is a two pair in the computer's hand and the player's hand, the player lost.
            if (PokerHands.TwoPair(pPlayerHand) & PokerHands.TwoPair(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a two pair!");
                return false;
            }

            // If there is a two pair  in the player's hand, the player won.
            if (PokerHands.TwoPair(pPlayerHand))
            {
                Console.WriteLine("\nYou have a two pair!");
                return true;
            }

            // If there is a two pair in the computer's hand, the player lost.
            if (PokerHands.TwoPair(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a two pair!");
                return false;
            }
            #endregion


            #region One Pair
            // If there is a one pair in the computer's hand and the player's hand, the player lost.
            if (PokerHands.OnePair(pPlayerHand) & PokerHands.OnePair(pComputerHand))
            {
                Console.WriteLine("\nBoth players have a one pair!");
                return false;
            }

            // If there is a one pair  in the player's hand, the player won.
            if (PokerHands.OnePair(pPlayerHand))
            {
                Console.WriteLine("\nYou have a one pair!");
                return true;
            }

            // If there is a one pair in the computer's hand, the player lost.
            if (PokerHands.OnePair(pComputerHand))
            {
                Console.WriteLine("\nThe computer has a one pair!");
                return false;
            }
            #endregion

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

            // Satisfies all code paths must return a value error.
            else
            {
                return false;
            }
            #endregion

        } // end of CompareHands()     


       

    } // end of class Program

} // end of namespace CardGameConsole
