using System;
using System.Collections.Generic;
using System.Text;

namespace TheSenateMaterials.Interfaces
{
    public interface IGame
    {
        public abstract void Register(Player player);

        public abstract void Act(Player player);

        public abstract void Initiate();

        public abstract void Terminate();
    }
}
