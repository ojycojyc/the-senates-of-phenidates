using System;
using System.Collections.Generic;
using System.Linq;

namespace TheSenateMaterials
{
    public class BaseDeck : IDeck
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

        /// <summary>
        /// Completely sort the deck by faction with the greatest number of cards, in decending order of value.
        /// </summary>
        public void Sort()
        {
            this.Cards.GroupBy(card => card.Faction)
                      .OrderByDescending(card => card.Count())
                      .SelectMany(card => card.OrderByDescending(c => c.Value));
        }

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
            
    }
}