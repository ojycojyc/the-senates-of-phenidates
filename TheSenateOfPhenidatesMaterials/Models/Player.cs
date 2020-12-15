using System;
using System.Collections.Generic;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class Player
    {
        private IGame _gameService { get; set; }
        private Guid _id { get; set; }
        private List<Card> Hand { get; set; }


        public String Name { get; set; }
        public Factions Faction { get; set; }

        public Guid ID
        {
            get => _id;
            set { _id = value; }
        }

        public IGame GameSession
        {
            get => _gameService;
            set { _gameService = value; }
        }

        public Player(IGame gameService)
        {
            _gameService = gameService;
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

    }
}
