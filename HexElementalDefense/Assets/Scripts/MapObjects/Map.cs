using UnityEngine;
using System.Collections;
using Assets.MapCreation;

namespace Assets.MapObjects
{

    public class Map : MonoBehaviour {

        public Map(IMapBuilder mapBuilder)
        {
            _mapArray = mapBuilder.CreateMap();
        }

        private TileBase[,] _mapArray;

        // Use this for initialization
        void Start() {

    }

        // Update is called once per frame
        void Update() {
            //TODO vykreslovani mapy
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">Souradnice X</param>
        /// <param name="y">Souradnice Y</param>
        /// <returns>Vraci pole na zadanych souradnicich</returns>
        public TileBase this[int x, int y]
        {
            get
            {
                return _mapArray[x, y];
            }
        }
    }
}
