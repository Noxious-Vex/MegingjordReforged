using Jotunn.Entities;
using Jotunn.Managers;

using MegingjordReforged.Source.Definitions;
using MegingjordReforged.Source.Registry;
using MegingjordReforged.Source.Utilities;

using UnityEngine;


namespace MegingjordReforged.Source.Managers
{
    public static class BeltPrefabManager
    {
        private const string BasePrefab = "BeltStrength";


        private static bool _registered;



        /// <summary>
        /// Registers all custom belt prefabs.
        ///
        /// This only handles:
        /// - Prefab cloning
        /// - Visual changes
        /// - Item metadata
        ///
        /// Recipes and runtime effects
        /// are handled separately.
        /// </summary>
        public static void RegisterBelts()
        {
            if (_registered)
            {
                ModLogger.LogDebug(
                    "Belts have already been registered."
                );

                return;
            }



            _registered = true;



            ModLogger.LogDebug(
                "Registering Megingjord Reforged belt prefabs..."
            );



            foreach (
                BeltDefinition belt
                in BeltRegistry.Belts.Values)
            {
                CreateBeltPrefab(
                    belt
                );
            }



            ModLogger.LogDebug(
                "Finished registering belt prefabs."
            );
        }



        private static void CreateBeltPrefab(
            BeltDefinition belt)
        {
            GameObject? prefab =
                PrefabManager.Instance.GetPrefab(
                    BasePrefab
                );



            if (prefab == null)
            {
                ModLogger.LogError(
                    $"Unable to locate vanilla prefab: {BasePrefab}"
                );

                return;
            }



            GameObject clonedBelt =
                PrefabManager.Instance.CreateClonedPrefab(
                    belt.PrefabName,
                    prefab
                );



            ModLogger.LogDebug(
                $"Created belt clone: {belt.PrefabName}"
            );



            ItemDrop? itemDrop =
                clonedBelt.GetComponent<ItemDrop>();



            if (itemDrop == null)
            {
                ModLogger.LogError(
                    $"Missing ItemDrop component on {belt.PrefabName}"
                );

                return;
            }



            /*
             * Apply item information.
             */

            itemDrop.m_itemData.m_shared.m_name =
                belt.DisplayName;


            itemDrop.m_itemData.m_shared.m_description =
                belt.Description;



            /*
             * Apply inventory icon.
             */

            Sprite? icon =
                BeltIconManager.LoadIcon(
                    belt.IconName
                );



            if (icon != null)
            {
                itemDrop.m_itemData.m_shared.m_icons[0] =
                    icon;


                ModLogger.LogDebug(
                    $"Applied icon: {belt.IconName}"
                );
            }



            /*
             * Apply world and equipped visuals.
             */

            ApplyBeltTextures(
                clonedBelt,
                belt.TextureName
            );



            FixEquipAttach(
                clonedBelt,
                belt.TextureName
            );



            /*
             * Assign runtime status effect.
             */

            StatusEffect? effect =
                GetStatusEffect(
                    belt
                );



            if (effect == null)
            {
                ModLogger.LogWarning(
                    $"No status effect assigned to {belt.PrefabName}"
                );
            }
            else
            {
                itemDrop.m_itemData.m_shared.m_equipStatusEffect =
                    effect;



                ModLogger.LogDebug(
                    $"Assigned status effect to {belt.PrefabName}"
                );
            }



            ItemManager.Instance.AddItem(
                new CustomItem(
                    clonedBelt,
                    true
                )
            );



            ModLogger.LogInfo(
                $"Registered belt prefab: {belt.PrefabName}"
            );
        }



        private static StatusEffect? GetStatusEffect(
            BeltDefinition belt)
        {
            return belt.Type switch
            {
                BeltType.BeltAedigjord =>
                    StatusEffectRegistry.Aedigjord,

                BeltType.BeltSeidgjord =>
                    StatusEffectRegistry.Seidgjord,

                BeltType.BeltSkadigjord =>
                    StatusEffectRegistry.Skadigjord,

                BeltType.BeltAlagjord =>
                    StatusEffectRegistry.Alagjord,

                BeltType.BeltFornmegingjord =>
                    StatusEffectRegistry.Fornmegingjord,

                _ =>
                    null
            };
        }



        private static void ApplyBeltTextures(
            GameObject beltObject,
            string textureName)
        {
            string[] paths =
            {
                "attach/belt1",
                "attach_skin/belt1"
            };



            foreach (string path in paths)
            {
                Transform? visual =
                    beltObject.transform.Find(
                        path
                    );



                if (visual == null)
                {
                    continue;
                }



                BeltModelManager.ApplyTexture(
                    visual.gameObject,
                    textureName
                );
            }
        }



        private static void FixEquipAttach(
            GameObject beltObject,
            string textureName)
        {
            Transform? attach =
                beltObject.transform.Find(
                    "attach"
                );



            if (attach == null)
            {
                ModLogger.LogWarning(
                    $"No attach object found for {beltObject.name}"
                );

                return;
            }



            Transform? beltVisual =
                attach.Find(
                    "belt1"
                );



            if (beltVisual == null)
            {
                ModLogger.LogWarning(
                    $"No belt visual found for {beltObject.name}"
                );

                return;
            }



            BeltModelManager.ApplyTexture(
                beltVisual.gameObject,
                textureName
            );
        }
    }
}