using System;
using System.Collections.Generic;
using System.Text;

namespace TheSenateMaterials.Interfaces
{
    public interface IGameService
    {
        Game game { get; set; }
        public void Initiate() { }

        public void Terminate() { }
    }
}
