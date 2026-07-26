using ModLogger = MegingjordReforged.Source.Utilities.ModLogger;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace MegingjordReforged.Source.Managers
{
    public static class BeltModelManager
    {
        public static void ApplyTexture(
            GameObject beltObject,
            string textureName)
        {
            if (beltObject == null)
            {
                ModLogger.LogError(
                    "Cannot apply belt texture. Belt object is null."
                );

                return;
            }


            Texture2D? texture =
                LoadTexture(textureName);


            if (texture == null)
            {
                ModLogger.LogError(
                    $"Could not load belt texture: {textureName}"
                );

                return;
            }


            Renderer[] renderers =
                beltObject.GetComponentsInChildren<Renderer>(true);


            if (renderers.Length == 0)
            {
                ModLogger.LogError(
                    $"No renderers found on {beltObject.name}"
                );

                return;
            }


            ModLogger.LogDebug(
                $"Applying texture {textureName} to {beltObject.name} using {renderers.Length} renderer(s)."
            );


            foreach (Renderer renderer in renderers)
            {
                Material[] materials =
                    renderer.materials;


                foreach (Material material in materials)
                {
                    bool applied =
                        false;


                    if (material.HasProperty("_MainTex"))
                    {
                        material.SetTexture(
                            "_MainTex",
                            texture
                        );

                        applied = true;
                    }


                    if (material.HasProperty("_BaseMap"))
                    {
                        material.SetTexture(
                            "_BaseMap",
                            texture
                        );

                        applied = true;
                    }


                    if (applied)
                    {
                        ModLogger.LogDebug(
                            $"Applied texture {textureName} to material {material.name}."
                        );
                    }
                }
            }
        }



        private static Texture2D? LoadTexture(string textureName)
        {
            Assembly assembly =
                Assembly.GetExecutingAssembly();


            string resourceName =
                $"MegingjordReforged.Assets.Textures.{textureName}";


            ModLogger.LogDebug(
                $"Loading texture resource: {resourceName}"
            );


            using Stream? stream =
                assembly.GetManifestResourceStream(resourceName);


            if (stream == null)
            {
                ModLogger.LogError(
                    $"Could not find texture resource: {resourceName}"
                );

                return null;
            }


            byte[] data =
                new byte[stream.Length];


            stream.Read(
                data,
                0,
                data.Length
            );


            Texture2D texture =
                new Texture2D(
                    2,
                    2,
                    TextureFormat.RGBA32,
                    false
                );


            if (!texture.LoadImage(data))
            {
                ModLogger.LogError(
                    $"Failed loading texture: {textureName}"
                );

                return null;
            }


            texture.name =
                textureName;


            texture.wrapMode =
                TextureWrapMode.Repeat;


            texture.filterMode =
                FilterMode.Bilinear;


            ModLogger.LogDebug(
                $"Successfully loaded texture: {textureName}"
            );


            return texture;
        }
    }
}