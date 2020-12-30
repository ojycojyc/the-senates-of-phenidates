using System;
using System.Collections.Generic;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class Game: IGame, IDisposable
    {
        #region Properties
        private bool disposedValue;

        private Guid id;

        public Guid ID { get => id; set { id = Guid.NewGuid(); } }
        public Dictionary<string, Player> Players { get; set; }
        
        public Dictionary<string, Deck> Decks { get; set; }

        #endregion Properties

        public void Act(IAction action)
        {
            throw new NotImplementedException();
        }

        public void Initiate()
        {
            Deck mainDeck = new Deck(this, "Main");


            Deck discardDeck = new Deck(this, "Discard");

            Player defaultPlayer = new Player("Player 1", Factions.Factionless);

            this.Register(mainDeck);
            this.Register(discardDeck);
            this.Register(defaultPlayer);
            //this.ID = new Guid();
        }

        #region Register
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
        #endregion Register

        public void Terminate()
        {
            throw new NotImplementedException();
        }

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
        // ~Game()
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
