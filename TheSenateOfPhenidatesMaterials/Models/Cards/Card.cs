using System;

namespace TheSenateMaterials
{
    public class Card: IDisposable
    {
        #region Properties

        /// <summary>
        /// Display name of the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Equivalent to the concept of "suits"
        /// Property describes the faction to which the card belongs to.
        /// </summary>
        public Factions Faction { get; set; } = Factions.Factionless;

        /// <summary>
        /// Property defining the value of a card, if any.
        /// Default value of 0.
        /// </summary>
        public int Value { get; set; } = 0;

        /// <summary>
        /// Property defining whether the card is being displayed face up or face down.
        /// Should maybe be a front-end property instead.
        /// </summary>
        public Boolean IsFaceUp { get; set; } = false;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns information about the card.
        /// </summary>
        /// <returns></returns>
        public string read()
        {
            return $@"Name: {this.Name} 
                      Faction: {this.Faction}
                      Value: {this.Value}";
        }

        /// <summary>
        /// Changes the display of the card: if it is face up, it will be flipped face down and vice-versa.
        /// </summary>
        public void flip() {
            this.IsFaceUp = !this.IsFaceUp;
        }

        /// <summary>
        /// Executes the assigned method for a card.
        /// </summary>
        /// <param name="player"></param>
        public void activate(IPlayer player) { }
        #endregion Methods

        #region Disposable
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion Disposable

    }
}
