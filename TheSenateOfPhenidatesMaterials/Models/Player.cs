using System;
using System.Collections.Generic;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class Player
    {
        private IGameService _gameService { get; set; }
        private Guid _id { get; set; }
        private List<Card> Hand { get; set; }


        public String Name { get; set; }
        public Factions Faction { get; set; }

        public Player(IGameService gameService)
        {
            _gameService = gameService;
        }

        public Player(String name, Factions faction)
        {
            this._id = Guid.NewGuid();
            this.Name = name;
            this.Faction = faction;
        }

        public void draw()
        {
            //_gameService.game
            Card newCard = new Card();
            Hand.Add(newCard);
        }

    }
}
