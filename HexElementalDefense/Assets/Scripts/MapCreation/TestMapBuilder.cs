using Assets.Scripts.MapObjects;

namespace Assets.Scripts.MapCreation
{
    /// <summary>
    /// Builder k vytvoreni testovaci mapy
    /// </summary>
    class TestMapBuilder : IMapBuilder
    {
        private const int mapSizeX = 10;
        private const int mapSizeY = 4;

        /// <summary>
        /// Vytvoreni pole hernich poli
        /// </summary>
        /// <returns>Vraci nainicializovane herni pole</returns>
        public TileBase[,] CreateMap()
        {
            var map = new TileBase[mapSizeX, mapSizeY];

            //TODO vytvoreni smysluplne testovaci mapy
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    map[x, y] = new EmptyTile();
                }
            }

            //Vygeneruj cestu

            map[1, 0] = new PathTile();
            map[3, 0] = new PathTile();
            map[5, 0] = new PathTile();
            map[6, 1] = new PathTile();
            map[5, 1] = new PathTile();
            map[4, 2] = new PathTile();
            map[3, 2] = new PathTile();
            map[4, 3] = new PathTile();
            map[6, 3] = new PathTile();
            map[8, 3] = new PathTile();

            return map;
        }
    }
}
