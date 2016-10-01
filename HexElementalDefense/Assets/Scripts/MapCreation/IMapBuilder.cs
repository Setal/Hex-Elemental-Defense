using Assets.Scripts.MapObjects;

namespace Assets.Scripts.MapCreation
{
    /// <summary>
    /// Rozhrani pro vytvareni map
    /// </summary>
    public interface IMapBuilder
    {
        /// <summary>
        /// Vytvoreni pole hernich poli
        /// </summary>
        /// <returns>Vraci nainicializovane herni pole</returns>
        TileBase[,] CreateMap();
    }
}
