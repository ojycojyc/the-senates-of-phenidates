using System;

namespace TheSenateMaterials
{
    public class Card : IDisposable
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
        public Suits Suit { get; set; } = Suits.Blank;

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

        #region Action Methods

        /// <summary>
        /// Returns information about the card.
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            return $@"Name: {this.Name} 
                      Suit: {this.Suit}
                      Value: {this.Value}";
        }

        /// <summary>
        /// Changes the display of the card: if it is face up, it will be flipped face down and vice-versa.
        /// </summary>
        public void Flip() {
            this.IsFaceUp = !this.IsFaceUp;
        }

        /// <summary>
        /// Executes the assigned method for a card.
        /// </summary>
        /// <param name="player"></param>
        public void Activate(Player player) { }
        #endregion Action Methods

        #region Helper Functions
        /// <summary>
        /// Helper function to provide hard copy of a "Card".
        /// </summary>
        /// <returns></returns>
        public Card Copy()
        {
            return new Card() 
            { 
                Name = this.Name, 
                Suit = this.Suit, 
                IsFaceUp = this.IsFaceUp, 
                Value = this.Value
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
            Card other = obj as Card;

            return (other.Name == this.Name) &&
                   (other.Suit == this.Suit) &&
                   (other.Value == this.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion Helper Functions

        #region Disposable
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion Disposable

    }
}
