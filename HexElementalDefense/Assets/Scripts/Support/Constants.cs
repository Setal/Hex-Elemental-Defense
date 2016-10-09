using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.MapCreation;

namespace Assets.Scripts.Support
{
    /// <summary>
    /// Trida poskytujici globalni pomocne konstanty
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Seznam dostupnych MapBuilderu
        /// </summary>
        public static IMapBuilder[] AviableMapBuilders = new IMapBuilder[]
        {
            new TestMapBuilder(),
        };
    }
}
