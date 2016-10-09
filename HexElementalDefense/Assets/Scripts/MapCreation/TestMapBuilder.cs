using System;
using System.Collections.Generic;
using Assets.Scripts.MapObjects;
using UnityEngine;

namespace Assets.Scripts.MapCreation
{
    /// <summary>
    /// Builder k vytvoreni testovaci mapy
    /// </summary>
    [Serializable]
    class TestMapBuilder : IMapBuilder
    {
        private const int mapSizeX = 10;
        private const int mapSizeY = 4;

        /// <summary>
        /// Vytvoreni pole hernich poli
        /// </summary>
        /// <returns>Vraci nainicializovane herni pole</returns>
        public TileBase[,] CreateMap(out List<Path> paths)
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

            paths = new List<Path>();
            var path = new Path
            {
                Points = new List<Vector2>
                {
                    new Vector2(1, 0),
                    new Vector2(3, 0),
                    new Vector2(5, 0),
                    new Vector2(6, 1),
                    new Vector2(5, 1),
                    new Vector2(4, 2),
                    new Vector2(3, 2),
                    new Vector2(4, 3),
                    new Vector2(6, 3),
                    new Vector2(8, 3)
                }
            };
            paths.Add(path);

            foreach (var path_ in paths)
            {
                foreach (var point in path_.Points)
                {
                    map[(int)point.x, (int)point.y] = new PathTile();
                }
            }

            return map;
        }
    }
}
