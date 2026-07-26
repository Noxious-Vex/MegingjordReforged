namespace MegingjordReforged.Source.Config
{
    public class ConfigGeneralOptions
    {
        /// <summary>
        /// Master toggle for Megingjord Reforged.
        /// When disabled, the mod should not register any belts or recipes.
        /// </summary>
        public bool EnableMod { get; set; } = true;


        /// <summary>
        /// Enables server-side configuration synchronization.
        /// Default: Enabled.
        /// </summary>
        public bool EnableServerSync { get; set; } = true;
    }
}