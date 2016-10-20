using System;

namespace Assets.Scripts.GameObjects.Elements
{
    /// <summary>
    /// Predek vsech elementu
    /// </summary>
    public abstract class ElementBase
    {
        /// <summary>
        /// Definice elementu
        /// </summary>
        /// <param name="level">Uroven elementu</param>
        /// <param name="effectPower"></param>
        protected ElementBase(int level, double effectPower)
        {
            _level = level;
            EffectPower = effectPower;
        }

        /// <summary>
        /// Uroven elementu
        /// </summary>
        private int _level;

        /// <summary>
        /// Definuje druh efektu elementu
        /// </summary>
        public abstract ElementEffect Effect { get; }

        /// <summary>
        /// Nasobitel sily efektu
        /// </summary>
        public double EffectPower { get; private set; }

        public void Upgrade()
        {
            throw new NotImplementedException();
        }

    }
}