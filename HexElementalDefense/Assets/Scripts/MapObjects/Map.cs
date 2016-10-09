using System;
using System.Collections.Generic;
using Assets.Scripts.MapCreation;
using Assets.Scripts.Math;
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
        public GameObject MapAsParent;

        private TileBase[,] _mapArray;
        private GameObject _hex;
        private GameObject _hexPath;

        public List<Path> Paths { get; set; }

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
        /// Vraci pole na zadanych souradnicich
        /// </summary>
        /// <param name="v">Vektor souradnic</param>
        /// <returns>Pole na zadanych souradnicich</returns>
        public TileBase this[Vector2 v]
        {
            get { return _mapArray[(int)v.x, (int)v.y]; }
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

            List<Path> paths;
            _mapArray = MapBuilder.CreateMap(out paths);

            for (int i0 = 0; i0 < GetLength(0); i0++)
                for (int i1 = 0; i1 < GetLength(1); i1++)
                {
                    GameObject localHex = _hex;
                    const float zDiff = 1.5f;
                    const float xDiff = 0.866025f / 2f;

                    var x = i0 * xDiff;
                    var z = i1 * zDiff + ((i0 % 2 == 0) ? 0f : zDiff * 0.5f);

                    var tile = this[i0, i1];
                    tile.Position = new Vector2(x, z);

                    if (tile is PathTile)
                    {
                        localHex = _hexPath;
                    }

                    GameObject instance = (GameObject)Instantiate(localHex, new Vector3(x, 0, z), Quaternion.identity);
                    instance.transform.parent = MapAsParent.transform;
                }

            //TODO vykresli cestu

            for (int i = 0; i < paths[0].Points.Count - 1; i++)
            {
                Vector2 point = paths[0].Points[i];
                Vector2 nextpoint = paths[0].Points[i + 1];
                Vector2 vector = (paths[0].Points[i + 1] - paths[0].Points[i]) / 2f;
                TileBase tile = this[point];
                TileBase nexttile = this[nextpoint];
                GameObject instance = (GameObject)Instantiate(new GameObject(), new Vector3(tile.Position.x, 0, tile.Position.y), Quaternion.identity);
                BezierSpline spline = instance.AddComponent(typeof(BezierSpline)) as BezierSpline;
                spline.Reset();
                spline.SetControlPoint(0, new Vector3(0, 1, 0));
                spline.SetControlPoint(1, new Vector3(vector.x, 1, vector.y));
                spline.SetControlPoint(2, new Vector3(nexttile.Position.x - tile.Position.x, 1, nexttile.Position.y - tile.Position.y));
                spline.SetControlPoint(3, new Vector3(nexttile.Position.x - tile.Position.x, 1, nexttile.Position.y - tile.Position.y));


            }
        }

        // Update is called once per frame
        void Update()
        {
            //TODO vykreslovani mapy
        }
    }
}
