using System;
using Assets.Scripts.MapCreation;
using Assets.Scripts.Support;
using UnityEngine;

namespace Assets.Scripts.MapObjects
{
    /// <summary>
    /// Reprezentuje herni mapu
    /// </summary>
    [Serializable]
    public class Map : MonoBehaviour
    {
        private TileBase[,] _mapArray;
        private GameObject _hex;
        private GameObject _hexPath;

        /// <summary>
        /// Index do seznamu mapBuilderu <see cref="Constants.AviableMapBuilders"/>
        /// </summary>
        [SerializeField]
        private int _mapBuilderIndex;

        private IMapBuilder MapBuilder
        {
            get { return Constants.AviableMapBuilders[_mapBuilderIndex]; }
        }

        /// <summary>
        /// Vraci pole na zadanych souradnicich
        /// </summary>
        /// <param name="x">Souradnice X</param>
        /// <param name="y">Souradnice Y</param>
        /// <returns>Pole na zadanych souradnicich</returns>
        public TileBase this[int x, int y]
        {
            get { return _mapArray[x, y]; }
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

        /// <summary>
        /// Nastavi odkaz na map builder <see cref="Constants.AviableMapBuilders"/>
        /// </summary>
        /// <param name="mapBuilderIndex">Index do </param>
        public void SetMapBuilderIndex(int mapBuilderIndex)
        {
            _mapBuilderIndex = mapBuilderIndex;
        }

        /// <summary>
        /// Vraci odkaz na map builder <see cref="Constants.AviableMapBuilders"/>
        /// </summary>
        /// <returns></returns>
        public int GetMapBuilderIndex()
        {
            return _mapBuilderIndex;
        }

        // Use this for initialization
        void Start()
        {
            _hex = (GameObject)Resources.Load("Hex");
            _hexPath = (GameObject)Resources.Load("HexPath");

            _mapArray = MapBuilder.CreateMap();

            for (int i0 = 0; i0 < GetLength(0); i0++)
                for (int i1 = 0; i1 < GetLength(1); i1++)
                {
                    GameObject localHex = _hex;
                    var zDiff = 1.5f;
                    var xDiff = 0.866025f / 2f;
                    var tile = this[i0, i1];

                    if (tile is PathTile)
                    {
                        localHex = _hexPath;
                    }

                    Instantiate(localHex, new Vector3(i0 * xDiff, 0, i1 * zDiff + ((i0 % 2 == 0) ? 0f : zDiff * 0.5f)), Quaternion.identity);
                }
        }

        // Update is called once per frame
        void Update()
        {
            //TODO vykreslovani mapy
        }
    }
}
