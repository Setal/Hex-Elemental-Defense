using Assets.Scripts.GameObjects.Towers;

namespace Assets.Scripts.GameObjects.MapParts
{
    /// <summary>
    /// Reprezentuje prazdny prvek pole, na kterem lze zbudovat vez
    /// </summary>
    public class EmptyTile : TileBase
    {
        /// <summary>
        /// Vez na tomto dilku mapy
        /// <remarks> Je null pokud je dilek prazdny. </remarks>
        /// </summary>
        public TowerBase Tower { get; set; }
    }
}