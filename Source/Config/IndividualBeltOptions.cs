using MegingjordReforged.Source.Definitions;

namespace MegingjordReforged.Source.Config
{
    /// <summary>
    /// Contains configuration options for an individual Megingjord Reforged belt.
    ///
    /// Crafting availability is controlled entirely through CraftingStation.
    /// The belt prefab is always registered.
    /// </summary>
    public class IndividualBeltOptions
    {
        /// <summary>
        /// Determines how this belt can be crafted.
        ///
        /// Disabled:
        /// Recipe is not registered.
        ///
        /// None:
        /// Crafted directly from the player's inventory.
        ///
        /// Any crafting station:
        /// Recipe is registered using that station.
        /// </summary>
        public CraftingStationType CraftingStation { get; set; } =
            CraftingStationType.GaldrTable;



        /// <summary>
        /// Optional crafting station level override.
        ///
        /// 0 uses the belt definition default level.
        /// </summary>
        public int CraftingStationLevel { get; set; } =
            0;



        /// <summary>
        /// Optional custom crafting recipe override.
        ///
        /// Format:
        /// ItemPrefab:Amount,ItemPrefab:Amount
        ///
        /// Empty uses the default recipe defined by the belt.
        /// </summary>
        public string Recipe { get; set; } =
            string.Empty;



        /// <summary>
        /// Configurable gameplay effects for this belt.
        ///
        /// Only approved effects are exposed through configuration.
        /// </summary>
        public BeltEffectOptions Effects { get; set; } =
            new();
    }
}