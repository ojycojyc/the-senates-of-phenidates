using System;
using System.Collections.Generic;
using System.Linq;

namespace TheSenateMaterials
{
    public class Deck : IDeck
    {
        public string Name 
        {
            get;
            set;
        }
        public List<Card> Cards 
        {
            get;
            set;
        }

        #region Add methods
        /// <summary>
        /// Add a new card to the deck.
        /// </summary>
        /// <param name="card"></param>
        public void Add(Card card)
        {
            this.Cards.Add(card);
        }

        /// <summary>
        /// Add a collection of cards to the deck.
        /// </summary>
        /// <param name="cards"></param>
        public void Add(List<Card> cards)
        {
            this.Cards.AddRange(cards);
        }

        /// <summary>
        ///  Add the cards from one deck to another deck.
        /// </summary>
        /// <param name="deck"></param>
        public void Add(IDeck deck)
        {
            this.Add(deck.Cards);
        }
        #endregion Add Methods

        #region Discard Methods
        public void Discard()
        {
            // Empty the complete deck
            this.Cards = new List<Card>();
        }

        /// <summary>
        /// Renove a specific card from the deck, given its position 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="discardedCard"></param>
        public void Discard(int position, out Card discardedCard)
        {
            discardedCard = this.Cards[position];
            this.Cards.RemoveAt(position);
        }

        /// <summary>
        /// Renove a specific card from the deck.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="discardedCard"></param>
        public void Discard(Card card, out Card discardedCard)
        {
            int position = FindIndex(card);
            Discard(position, out discardedCard);
        }
        #endregion Discard Methods

        /// <summary>
        /// Draw the card at a given position from the deck.
        /// </summary>
        /// <param name="position"> Index of the card to be drawn from the deck</param>
        /// <returns></returns>
        public Card Draw(int position)
        {
            Card cardDrawn = this.Cards[position];

            if (cardDrawn != null)
            {
                this.Cards.RemoveAt(position);
                return cardDrawn;
            }
            else
            {
                throw new ArgumentNullException($"No card was found in the deck at position ${position}.");
            }
        }

        /// <summary>
        /// Find first card in the deck that is equivalent to the provided Card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int FindIndex(Card card)
        {
            return this.Cards.FindIndex(card.Equals);
        }

        #region Read methods
        /// <summary>
        /// Return card information for card in given position.
        /// </summary>
        /// <param name="position"> Index of the card to be read from the deck.</param>
        /// <returns></returns>
        public Card Read(int position)
        {
            return this.Cards[position];
        }

        public Card ReadTop()
        {
            return this.Read(0);
        }

        public Card ReadBottom()
        {
            return this.Read(this.Cards.Count-1);
        }
        #endregion Read methods

        /// <summary>
        /// Implement a modern version of "Fisher-Yates" shuffle
        /// </summary>
        public void Shuffle()
        {
            for (int i = 0; i < this.Cards.Count(); i++)
            {
                // Get index card with which to switch/shuffle
                Random random = new Random();
                int randPosition = random.Next(i, this.Cards.Count());

                // Cannot pass by reference: need a deep copy
                Card temp = this.Cards[i].Copy();

                // Switch the cards with one another
                this.Cards[i] = this.Cards[randPosition];
                this.Cards[randPosition] = temp;
            }
        }

        /// <summary>
        /// Completely sort the deck by faction with the greatest number of cards, in decending order of value.
        /// </summary>
        public void Sort()
        {
            this.Cards.GroupBy(card => card.Faction)
                      .OrderByDescending(card => card.Count())
                      .SelectMany(card => card.OrderByDescending(c => c.Value));
        }
    }
}