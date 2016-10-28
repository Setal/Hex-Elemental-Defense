using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.MapObjects
{
    public class Path
    {
        public List<Vector2> Points { get; set; }

        public Vector2 this[int i]
        {
            get { return Points[i]; }
        }
    }
}
