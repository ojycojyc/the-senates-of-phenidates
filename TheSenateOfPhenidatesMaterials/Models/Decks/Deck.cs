using System;
using System.Collections.Generic;
using System.Linq;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class Deck : IDeck, IDisposable
    {
        private bool disposedValue;
        private IGame _game { get; set; }

        public int cardLimit;
        
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public IGame GameSession
        {
            get => _game;
            set { _game = value; }
        }

        public Deck(){ }

        public Deck(IGame game, string name, List<Card> cards = null)
        {
            this.GameSession = game;
            this.Name = name;
            this.Cards = cards;
        }

        #region Add 
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
        #endregion Add 

        #region Discard 
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
        #endregion Discard 

        #region Draw
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
        /// Draw the card at the top of the deck.
        /// </summary>
        /// <param name="position"> Index of the card to be drawn from the deck</param>
        /// <returns></returns>
        public Card DrawTop()
        {
            return Draw(0);
        }

        /// <summary>
        /// Draw the card at the bottom of the deck.
        /// </summary>
        /// <param name="position"> Index of the card to be drawn from the deck</param>
        /// <returns></returns>
        public Card DrawBottom()
        {
            return Draw(this.Cards.Count -1);
        }
        #endregion

        #region Find
        /// <summary>
        /// Find index of the first card in the deck that is equivalent to the provided Card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public int FindIndex(Card card)
        {
            return this.Cards.FindIndex(card.Equals);
        }

        /// <summary>
        /// Find all indexes of cards equivalent to the provided Card. 
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public List<int> FindIndexes(Card card)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < this.Cards.Count; i++)
            {
                if (this.Cards[i].Equals(card))
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }
        #endregion Find

        #region Read
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
        #endregion Read

        #region Shuffle
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
        #endregion Shuffle

        #region Sort
        /// <summary>
        /// Completely sort the deck by faction with the greatest number of cards, in decending order of value.
        /// </summary>
        public void Sort()
        {
            this.Cards.GroupBy(card => card.Suit)
                      .OrderByDescending(card => card.Count())
                      .SelectMany(card => card.OrderByDescending(c => c.Value));
        }
        #endregion Sort

        #region Helper Functions
        /// <summary>
        /// Helper function to provide hard copy of a "Card".
        /// </summary>
        /// <returns></returns>
        public Deck Copy()
        {
            return new Deck()
            {
                Name = this.Name,
                Cards = this.Cards.Select(card=>card.Copy()).ToList()
            };
        }

        /// <summary>
        /// Two cards are equal if their name, faction and value are the same.
        /// Whether the cards are both face up or face down does not affect the determination of their equivalence.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Deck other = obj as Deck;

            return (other.Name == this.Name) && (other.Cards == this.Cards);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion Helper Functions

        #region Disposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Deck()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion Disposable
    }
}