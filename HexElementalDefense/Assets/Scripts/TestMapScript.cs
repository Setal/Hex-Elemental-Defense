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
        public GameObject hex;
        public Map map;

        // Use this for initialization
        void Start()
        {
            map = new Map(new TestMapBuilder());

            for (int i0 = 0; i0 < map.GetLength(0); i0++)
                for (int i1 = 0; i1 < map.GetLength(1); i1++)
                {
                    var zDiff = 1.5f;
                    var xDiff = 0.866025f / 2f;
                    var tile = map[i0, i1];
                    if (i0 % 2 == 0)
                    {
                        Instantiate(hex, new Vector3(i0 * xDiff, 0, i1 * zDiff), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(hex, new Vector3(i0 * xDiff, 0, i1 * zDiff + zDiff * 0.5f), Quaternion.identity);
                    }
                }
        }

        // Update is called once per frame
        void Update()
        {
            //TODO vykreslovani mapy
        }
    }
}
