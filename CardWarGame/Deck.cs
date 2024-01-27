using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace Deck
{
    internal class UsingDeck
    {
        public static List<Card> CreateDeck()
        {
            List<Card> deck = new List<Card>();
            string[] name = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "As" };
            string[] suit = { " of Hearts", " of Diamonds", " of Clubs", " of Spades" };
            int[] value = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            int thisValue;
            string thisName;
            string thisSuit;


            for (int i = 0; i < 13; i++)
            {
                thisName = name[i];
                for (int j = 0; j < 4; j++)
                {
                    thisSuit = suit[j];
                    thisValue = i;
                    deck.Add(new Card(thisName, thisSuit, thisValue));
                }
            }
            return deck;
        }

        public static bool ReadyCheck(List<Card> deck, List<Card> graveyard)
        {
            if ((deck.Count() + graveyard.Count()) < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Card> AddFromPull(List<Card> Graveyard, List<Card> pull)
        {
            foreach (Card card in pull)
            {
                Graveyard.Add(card);
            }
            return Graveyard;
        }

        public static List<Card> ShufflingCards(List<Card> graveyard)
        {
            Random random = new Random();
            List<Card> newDedck = new List<Card>();
            int rand;
            Card drawCard;

            do
            {
                rand = random.Next(0, graveyard.Count());
                drawCard = graveyard[rand];
                newDedck.Add(drawCard);
                graveyard.Remove(drawCard);
            } while (graveyard.Count > 0);
            Console.WriteLine("Wtasowano karty");
            return newDedck;
        }






    }
}

