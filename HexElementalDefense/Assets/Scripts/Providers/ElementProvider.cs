using Assets.Scripts.GameObjects.Elements;

namespace Assets.Scripts.Providers
{
    /// <summary>
    /// Poskytuje defaultni instance elementu
    /// <remarks>Pomocna trida, zapouzdruje konstruktory kvuli Unity.</remarks>
    /// </summary>
    public static class ElementProvider
    {
        /// <summary>
        /// Vraci novy AirElement
        /// </summary>
        public static AirElement GetAirElement()
        {
            return new AirElement(1, GameConstants.ElementConstants.PowerEffect);
        }

        /// <summary>
        /// Vraci novy DarknessElement
        /// </summary>
        public static DarknessElement GetDarknessElement()
        {
            return new DarknessElement(1, GameConstants.ElementConstants.PowerEffect);
        }

        /// <summary>
        /// Vraci novy EarthElement
        /// </summary>
        public static EarthElement GetEarthElement()
        {
            return new EarthElement(1, GameConstants.ElementConstants.PowerEffect);
        }

        /// <summary>
        /// Vraci novy FireElement
        /// </summary>
        public static FireElement GetFireElement()
        {
            return new FireElement(1, GameConstants.ElementConstants.PowerEffect);
        }

        /// <summary>
        /// Vraci novy LightElement
        /// </summary>
        public static LightElement GetLightElement()
        {
            return new LightElement(1, GameConstants.ElementConstants.PowerEffect);
        }

        /// <summary>
        /// Vraci novy PureEnergyElement
        /// </summary>
        public static PureEnergyElement GetEnergyElement()
        {
            return new PureEnergyElement(1, GameConstants.ElementConstants.PowerEffect);
        }

        /// <summary>
        /// Vraci novy WaterElement
        /// </summary>
        public static WaterElement GetWaterElement()
        {
            return new WaterElement(1, GameConstants.ElementConstants.PowerEffect);
        }
    }
}