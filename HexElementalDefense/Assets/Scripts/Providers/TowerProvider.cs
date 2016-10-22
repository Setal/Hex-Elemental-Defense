using Assets.Scripts.GameObjects.Towers;

namespace Assets.Scripts.Providers
{
    /// <summary>
    /// Poskytuje defaultni instance vezi
    /// <remarks>Pomocna trida, zapouzdruje konstruktory kvuli Unity.</remarks>
    /// </summary>
    public static class TowerProvider
    {
        /// <summary>
        /// Vraci novou CommonTower
        /// </summary>
        public static CommonTower GetCommonTower()
        {
            return new CommonTower(GameConstants.TowerConstants.Damage, GameConstants.TowerConstants.Range, GameConstants.TowerConstants.AttackSpeed, 1);
        }

        /// <summary>
        /// Vraci novou SplashTower
        /// </summary>
        public static SplashTower GetSplashTower()
        {
            return new SplashTower(GameConstants.TowerConstants.Damage, GameConstants.TowerConstants.Range, GameConstants.TowerConstants.AttackSpeed, 1);
        }

        /// <summary>
        /// Vraci novou ChainTower
        /// </summary>
        public static ChainTower GetChainTower()
        {
            return new ChainTower(GameConstants.TowerConstants.Damage, GameConstants.TowerConstants.Range, GameConstants.TowerConstants.AttackSpeed, 1);
        }

    }
}