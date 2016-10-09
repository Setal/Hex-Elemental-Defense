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
            /// Porizovaci cena Common veze
            /// </summary>
            public const int CommonTowerPurchasePrice = 10;

            /// <summary>
            /// Vylepsovaci cena Common veze
            /// </summary>
            public const int CommonTowerUpgradePrice = 1;
        }
    }
}