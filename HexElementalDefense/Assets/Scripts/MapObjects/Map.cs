using Assets.Scripts.MapCreation;
using UnityEngine;

namespace Assets.Scripts.MapObjects
{

    public class Map
    {

        public Map(IMapBuilder mapBuilder)
        {
            _mapArray = mapBuilder.CreateMap();
        }

        private TileBase[,] _mapArray;

        /// <summary>
        /// Vraci pole na zadanych souradnicich
        /// </summary>
        /// <param name="x">Souradnice X</param>
        /// <param name="y">Souradnice Y</param>
        /// <returns>Pole na zadanych souradnicich</returns>
        public TileBase this[int x, int y]
        {
            get
            {
                return _mapArray[x, y];
            }
        }

        /// <summary>
        /// Vraci Vraci pocet prvku mapy daneho rozmeru
        /// </summary>
        /// <param name="dimension">Index rozmeru jehoz velikost zjistujeme</param>
        /// <returns>Pocet prvku mapy daneho rozmeru</returns>
        public int GetLength(int dimension)
        {
            return _mapArray.GetLength(dimension);
        }
    }
}
