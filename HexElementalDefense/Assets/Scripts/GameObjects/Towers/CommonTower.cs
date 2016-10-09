namespace Assets.Scripts.GameObjects.Towers
{
    /// <summary>
    /// Zakladni vez utocici na prave jednoho nepritele
    /// </summary>
    public class CommonTower : TowerBase
    {
        public CommonTower(int damage, int range, int attackSpeed, int level) : base(damage, range, attackSpeed, level)
        {
        }

        /// <summary>
        /// Provede vystrel
        /// </summary>
        public override void Fire()
        {
            throw new System.NotImplementedException();
            //Friendly remider
            StartCoolDown();
        }

        /// <summary>
        /// Pocita cenu potrebnou k vylepseni veze na dalsi uroven
        /// </summary>
        /// <returns>Vrati cenu potrebnou pro upgrade do dalsi urovne</returns>
        public override int GetUpgradeCost()
        {
            return GameConstants.TowerConstants.CommonTowerUpgradePrice;
        }
    }
}