using System;
using System.Collections.Generic;
using TheSenateMaterials.Interfaces;

namespace TheSenateMaterials
{
    public class Player
    {
        private IGameService _gameService { get; set; }
        private Guid _id { get; set; }
        private List<Card> hand { get; set; }


        public String name { get; set; }
        public Factions faction { get; set; }

        public Player(IGameService gameService)
        {
            _gameService = gameService;
        }

        public Player(String name, Factions faction)
        {
            this._id = Guid.NewGuid();
            this.name = name;
            this.faction = faction;
        }

        public void draw()
        {
            //_gameService.game
            Card newCard = new Card();
            hand.Add(newCard);
        }

    }
}
