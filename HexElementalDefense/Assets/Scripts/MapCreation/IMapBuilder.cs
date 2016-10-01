using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MapCreation
{
    /// <summary>
    /// Rozhrani pro vytvareni map
    /// </summary>
    public interface IMapBuilder
    {
        /// <summary>
        /// Vytvoreni pole hernich poli
        /// </summary>
        /// <returns>Vraci nainicializovane herni pole</returns>
        TileBase[,] CreateMap();
    }
}
