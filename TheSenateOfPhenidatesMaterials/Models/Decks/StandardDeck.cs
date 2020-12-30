using System;
using System.Collections.Generic;
using System.Linq;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class StandardDeck : Deck
    {

        public StandardDeck(IGame game, string name, List<Card> cards = null, bool extended = false) : base(game, name, cards) {

            this.cardLimit = 52;

            if (cards != null)
            {
                // Validate the cards and make sure that all of the standard cards are in there
            }
            else 
            { 
                // Populate the deck with the cards of a standard deck
            }

            if (extended)
            { 
                // If the deck is extended, add the Jokers
            }

        }

        #region Helper Functions

        public void PopulateDeck()
        { }

        public void ValidateDeck()
        { }

        public void AddJokers()
        { }

        #endregion Helper Functions

    }
}