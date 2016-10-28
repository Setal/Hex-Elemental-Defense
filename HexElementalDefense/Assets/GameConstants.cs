using Assets.Scripts.GameObjects.Elements;

namespace Assets
{
    /// <summary>
    /// Zdruzuje vsechny herni konstanty a vychozi hodnoty
    /// </summary>
    public static class GameConstants
    {
        /// <summary>
        /// Zdruzuje vsechny herni konstanty a vychozi hodnoty vezi
        /// </summary>
        public static class TowerConstants
        {
            /// <summary>
            /// Vychozi poskozeni veze
            /// </summary>
            public const int Damage = 10;

            /// <summary>
            /// Vychozi dostrel veze v ????
            ///  TODO Define Range
            /// </summary>
            public const int Range = 1;

            /// <summary>
            /// Rychlost strelby veze v ms 
            /// </summary>
            public const int AttackSpeed = 1500;

            /// <summary>
            /// Poskozeni, ktere vez ziska z kazdou dalsi urovni
            /// </summary>
            public const int DamagePerLevelGain = 2;

            /// <summary>
            /// Dostrel, ktery vez ziska z kazdou dalsi urovni
            /// TODO Define Range
            /// </summary>
            public const int RangePerLevelGain = 1;

            /// <summary>
            /// Porizovaci cena CommonTower
            /// </summary>
            public const int CommonTowerPurchasePrice = 10;

            /// <summary>
            /// Vylepsovaci cena CommonTower
            /// </summary>
            public const int CommonTowerUpgradePrice = 1;

            /// <summary>
            /// Porizovaci cena ChainTower
            /// </summary>
            public const int ChainTowerPurchasePrice = 22;

            /// <summary>
            /// Vylepsovaci cena ChainTower
            /// </summary>
            public const int ChainTowerUpgradePrice = 2;

            /// <summary>
            /// Porizovaci cena SplashTower
            /// </summary>
            public const int SplashTowerPurchasePrice = 33;

            /// <summary>
            /// Vylepsovaci cena SplashTower
            /// </summary>
            public const int SplashTowerUpgradePrice = 3;
        }

        /// <summary>
        /// Zdruzuje vsechny herni konstanty a vychozi hodnoty elementu
        /// </summary>
        public static class ElementConstants
        {
            /// <summary>
            /// Vychozi multiplikator efektu elementu
            /// </summary>
            public const double PowerEffect = 1;

            /// <summary>
            /// Prirustek sili schopnosti za kazdou uroven
            /// </summary>
            public const double PerLevelPowerEffectGain = 1;
        }
    }
}