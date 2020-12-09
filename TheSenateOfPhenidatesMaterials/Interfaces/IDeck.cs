using System.Collections.Generic;

namespace TheSenateMaterials
{
    public interface IDeck
    {
        string Name { get; set; }

        List<Card> Cards { get; set; }

        void Sort();

        Card Read(int position);

        Card Draw(int position);

    }
}