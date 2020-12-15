using System;
using System.Collections.Generic;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class Game: IGame
    {
        public Dictionary<string, Player> Players { get; set; }
        
        public Dictionary<string, Deck> Decks { get; set; }

        public void Act(Player player)
        {
            throw new NotImplementedException();
        }

        public void Initiate()
        {
            throw new NotImplementedException();
        }

        public void Register(Player player)
        {
            if (!Players.ContainsValue(player))
            {
                Players[player.ID.ToString()] = player;
            }

            player.GameSession = this;
        }

        public void Register(Deck deck)
        {
            if (!Decks.ContainsValue(deck))
            {
                Decks[deck.Name] = deck;
            }

            deck.GameSession = this;
        }


        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
