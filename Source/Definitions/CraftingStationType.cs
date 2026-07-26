namespace MegingjordReforged.Source.Definitions
{
    /// <summary>
    /// Defines how a belt can be crafted.
    ///
    /// This determines whether a recipe is registered,
    /// and if so, which crafting station it belongs to.
    /// </summary>
    public enum CraftingStationType
    {
        /// <summary>
        /// Recipe is disabled entirely.
        /// The belt cannot be crafted.
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// No crafting station required.
        /// Craftable directly from the player's inventory.
        /// </summary>
        None,

        /// <summary>
        /// Crafted at the Workbench.
        /// </summary>
        Workbench,

        /// <summary>
        /// Crafted at the Forge.
        /// </summary>
        Forge,

        /// <summary>
        /// Crafted at the Stonecutter.
        /// </summary>
        Stonecutter,

        /// <summary>
        /// Crafted at the Artisan Table.
        /// </summary>
        ArtisanTable,

        /// <summary>
        /// Crafted at the Black Forge.
        /// </summary>
        BlackForge,

        /// <summary>
        /// Crafted at the Galdr Table.
        /// Default for Megingjord Reforged belts.
        /// </summary>
        GaldrTable
    }
}