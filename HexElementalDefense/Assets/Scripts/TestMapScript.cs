using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.MapCreation;
using Assets.Scripts.MapObjects;
using UnityEngine;

namespace Assets.Scripts
{
    class TestMapScript : MonoBehaviour
    {
        private GameObject _hex;
        private GameObject _hexPath;
        private Map _map;

        // Use this for initialization
        void Start()
        {
            _hex = (GameObject)Resources.Load("Hex");
            _hexPath = (GameObject)Resources.Load("HexPath");

            _map = new Map(new TestMapBuilder());

            for (int i0 = 0; i0 < _map.GetLength(0); i0++)
                for (int i1 = 0; i1 < _map.GetLength(1); i1++)
                {
                    GameObject localHex = _hex;
                    var zDiff = 1.5f;
                    var xDiff = 0.866025f / 2f;
                    var tile = _map[i0, i1];

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
