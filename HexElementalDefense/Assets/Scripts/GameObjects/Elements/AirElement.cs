namespace Assets.Scripts.GameObjects.Elements
{
    public class AirElement : ElementBase
    {
        /// <summary>
        /// Definice elementu
        /// </summary>
        /// <param name="level">Uroven elementu</param>
        /// <param name="effectPower"></param>
        public AirElement(int level, double effectPower) : base(level, effectPower)
        {
        }

        /// <summary>
        /// Definuje druh efektu elementu
        /// </summary>
        public override ElementEffect Effect
        {
            get { return ElementEffect.Blow;}
        }
    }
}