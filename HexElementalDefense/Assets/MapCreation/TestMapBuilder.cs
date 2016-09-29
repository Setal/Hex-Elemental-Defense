using Assets.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.MapCreation
{
    /// <summary>
    /// Builder k vytvoreni testovaci mapy
    /// </summary>
    class TestMapBuilder : IMapBuilder
    {
        private const int mapSize = 10;

        /// <summary>
        /// Vytvoreni pole hernich poli
        /// </summary>
        /// <returns>Vraci nainicializovane herni pole</returns>
        public TileBase[,] CreateMap()
        {
            var map = new TileBase[mapSize, mapSize];

            //TODO vytvoreni smysluplne testovaci mapy
            for (int x = 0; x < mapSize; x++)
            {
                for (int y = 0; y < mapSize; y++)
                {
                    map[x, y] = new EmptyTile();
                }
            }

            return map;
        }
    }
}
