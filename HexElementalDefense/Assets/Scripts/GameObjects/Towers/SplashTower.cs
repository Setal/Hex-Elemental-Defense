namespace Assets.Scripts.GameObjects.Towers
{
    /// <summary>
    /// Vez zpusobujici zraneni trem nepratelum
    /// </summary>
    public class SplashTower : TowerBase
    {
        public SplashTower(int damage, int range, int attackSpeed, int level) : base(damage, range, attackSpeed, level)
        {
        }

        /// <summary>
        /// Provede vystrel
        /// </summary>
        public override void Fire()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Pocita cenu potrebnou k vylepseni veze na dalsi uroven
        /// </summary>
        /// <returns>Vrati cenu potrebnou pro upgrade do dalsi urovne</returns>
        public override int GetUpgradeCost()
        {
            throw new System.NotImplementedException();
        }
    }
}