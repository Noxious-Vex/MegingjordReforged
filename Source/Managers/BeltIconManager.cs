using System;
using System.IO;
using System.Reflection;

using UnityEngine;

using ModLogger = MegingjordReforged.Source.Utilities.ModLogger;

namespace MegingjordReforged.Source.Managers
{
    public static class BeltIconManager
    {
        public static Sprite? LoadIcon(string iconName)
        {
            if (string.IsNullOrEmpty(iconName))
            {
                ModLogger.LogWarning(
                    "Attempted to load an icon with an empty name."
                );

                return null;
            }


            try
            {
                Assembly assembly =
                    Assembly.GetExecutingAssembly();


                string resourceName =
                    $"MegingjordReforged.Assets.Icons.{iconName}";


                ModLogger.LogDebug(
                    $"Searching embedded icon resource: {resourceName}"
                );


                using Stream? stream =
                    assembly.GetManifestResourceStream(resourceName);


                if (stream == null)
                {
                    ModLogger.LogError(
                        $"Icon resource was not found: {resourceName}"
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
                        64,
                        64,
                        TextureFormat.RGBA32,
                        false
                    );


                if (!texture.LoadImage(data))
                {
                    ModLogger.LogError(
                        $"Failed converting icon resource into texture: {iconName}"
                    );

                    return null;
                }


                Sprite sprite =
                    Sprite.Create(
                        texture,
                        new Rect(
                            0,
                            0,
                            64,
                            64
                        ),
                        new Vector2(
                            0.5f,
                            0.5f
                        )
                    );


                ModLogger.LogDebug(
                    $"Created sprite instance for icon: {iconName}"
                );


                return sprite;
            }
            catch (Exception exception)
            {
                ModLogger.LogError(
                    $"Exception while loading icon '{iconName}': {exception}"
                );

                return null;
            }
        }
    }
}