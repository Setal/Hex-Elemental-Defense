using System;
using System.Timers;
using Assets.Scripts.GameObjects.Elements;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Towers
{
    /// <summary>
    /// Predek vsech vezi
    /// </summary>
    public abstract class TowerBase
    {
        protected TowerBase(int damage, int range, int attackSpeed, int level)
        {
            Damage = damage;
            Range = range;
            AttackSpeed = attackSpeed;
            _level = level;

            Range += (GameConstants.TowerConstants.RangePerLevelGain * (level-1));
            Damage += (GameConstants.TowerConstants.DamagePerLevelGain * (level - 1));

            _cooldownCounter = new Timer(GameConstants.TowerConstants.AttackSpeed);
            _cooldownCounter.Elapsed += OnCoolDownEnd;
        }

        /// <summary>
        /// Pusobene zraneni
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Dostrel
        /// </summary>
        public int Range { get; private set; }

        /// <summary>
        /// Rychlost strelby
        /// </summary>
        public int AttackSpeed { get; private set; }

        /// <summary>
        /// Vsazeny element
        /// <remarks>Muze byt null pokdu vez neobsahuje element. </remarks>
        /// </summary>
        private ElementBase _element;

        public ElementBase Element
        {
            get { return _element; }
            set
            {
                if (Element != value)
                {
                    Element = value;
                    StartCoolDown();
                }
            }
        }

        /// <summary>
        /// Casovac doby pred dalsim vystrelem
        /// </summary>
        private readonly Timer _cooldownCounter;

        /// <summary>
        /// Stavovy flag - vez nemuze strilet
        /// </summary>
        private bool _isOnCoolDown;

        /// <summary>
        /// Uroven veze
        /// </summary>
        private int _level;

        public bool IsAbleToFire()
        {
            return (Element != null);
        }

        /// <summary>
        /// Zablokuje strelbu a spusti odpocet do dalsiho vystrelu
        /// </summary>
        protected void StartCoolDown()
        {
            _isOnCoolDown = true;
            _cooldownCounter.Start();
        }

        /// <summary>
        /// Zavola se vzdy, kdyz skonci odpocet
        /// </summary>
        protected void OnCoolDownEnd(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _cooldownCounter.Stop();
            _isOnCoolDown = false;
        }

        /// <summary>
        /// Provede vystrel
        /// </summary>
        public abstract void Fire();

        /// <summary>
        /// Pocita cenu potrebnou k vylepseni veze na dalsi uroven
        /// </summary>
        /// <returns>Vrati cenu potrebnou pro upgrade do dalsi urovne</returns>
        public abstract int GetUpgradeCost();

        /// <summary>
        /// Provede vylepseni veze na dalsi uroven
        /// </summary>
        public void Upgrade()
        {
            _level++;
            Range += GameConstants.TowerConstants.RangePerLevelGain;
            Damage += GameConstants.TowerConstants.DamagePerLevelGain;
        }
    }
}