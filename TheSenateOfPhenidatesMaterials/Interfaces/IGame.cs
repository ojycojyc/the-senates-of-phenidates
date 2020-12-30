using System;
using System.Collections.Generic;
using System.Text;

namespace TheSenateMaterials.Interfaces
{
    public interface IGame
    {
        public abstract void Register(Player player);

        public abstract void Register(Deck deck);

        public abstract void Act(IAction action);

        public abstract void Initiate();

        public abstract void Terminate();
    }
}
