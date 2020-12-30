using System;
using System.Collections.Generic;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class Player: IDisposable
    {
        private bool disposedValue;
        private Guid _id;
        private List<Card> Hand;


        public String Name { get; set; }
        public Factions Faction { get; set; }

        public Guid ID
        {
            get => _id;
            set { _id = value; }
        }

        public IGame GameSession { get; set; }

        public Player(IGame game)
        {
            GameSession = game;
        }

        public Player(String name, Factions faction)
        {
            this._id = Guid.NewGuid();
            this.Name = name;
            this.Faction = faction;
        }

        public void Draw()
        {
            //_gameService.game
            Card newCard = new Card();
            Hand.Add(newCard);
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
