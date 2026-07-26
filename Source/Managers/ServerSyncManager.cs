using HarmonyLib;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;

using MegingjordReforged.Source.Definitions;
using MegingjordReforged.Source.Items;
using MegingjordReforged.Source.Registry;
using MegingjordReforged.Source.Utilities;

using System.Collections;


namespace MegingjordReforged.Source.Managers
{
    /// <summary>
    /// Handles server-authoritative runtime configuration synchronization.
    ///
    /// The server configuration remains authoritative.
    ///
    /// Client configuration files are never modified.
    ///
    /// Received values are stored temporarily in
    /// RuntimeConfigOverride.
    /// </summary>
    public static class ServerSyncManager
    {
        private static bool Initialized;


        private static CustomRPC? SyncRPC;



        public static void Initialize()
        {
            if (Initialized)
            {
                return;
            }


            Initialized = true;



            if (!ConfigManager.Current.General.EnableServerSync)
            {
                ModLogger.LogDebug(
                    "Server synchronization disabled through configuration."
                );

                return;
            }



            ModLogger.LogDebug(
                "Initializing ServerSync Manager."
            );



            SyncRPC =
                NetworkManager.Instance.AddRPC(
                    "MegingjordServerSync",
                    ServerReceive,
                    ClientReceive
                );



            Harmony harmony =
                new Harmony(
                    "NoxiousVex.MegingjordReforged.ServerSync"
                );


            harmony.PatchAll(
                typeof(ServerSyncManager)
            );



            ModLogger.LogDebug(
                "ServerSync RPC registered."
            );
        }



        [HarmonyPatch(typeof(ZNet), "RPC_PeerInfo")]
        private static class RPC_PeerInfoPatch
        {
            private static void Postfix(
                ZNet __instance,
                ZRpc rpc)
            {
                if (!__instance.IsServer())
                {
                    return;
                }



                foreach (
                    ZNetPeer peer
                    in __instance.GetPeers())
                {
                    if (peer.m_rpc != rpc)
                    {
                        continue;
                    }



                    SendSynchronizationData(
                        peer
                    );


                    return;
                }
            }
        }



        private static void SendSynchronizationData(
            ZNetPeer peer)
        {
            if (SyncRPC == null)
            {
                return;
            }



            ServerSyncPackage package =
                ServerSyncDataProvider.CreatePackage();



            ZPackage zPackage =
                ServerSyncSerializer.Serialize(
                    package
                );



            SyncRPC.SendPackage(
                peer.m_uid,
                zPackage
            );



            ModLogger.LogDebug(
                $"ServerSync data sent to peer {peer.m_uid}."
            );
        }



        private static IEnumerator ServerReceive(
            long sender,
            ZPackage package)
        {
            ModLogger.LogWarning(
                $"Rejected ServerSync request from client {sender}."
            );


            yield break;
        }



        private static IEnumerator ClientReceive(
            long sender,
            ZPackage package)
        {
            ServerSyncPackage syncPackage =
                ServerSyncSerializer.Deserialize(
                    package
                );



            if (!ValidatePackage(
                    syncPackage))
            {
                ModLogger.LogWarning(
                    "Rejected incompatible ServerSync package."
                );

                yield break;
            }



            ApplyServerOverrides(
                syncPackage
            );



            StatusEffectRegistry.RefreshStatusEffects();


            BeltItemManager.RefreshRecipes();



            ModLogger.LogDebug(
                "Server synchronization data applied."
            );


            yield break;
        }



        private static bool ValidatePackage(
            ServerSyncPackage package)
        {
            if (package.SchemaVersion != VersionManager.SchemaVersion)
            {
                ModLogger.LogWarning(
                    $"Rejected ServerSync package. " +
                    $"Received schema {package.SchemaVersion}, " +
                    $"expected schema {VersionManager.SchemaVersion}."
                );

                return false;
            }



            if (package.Version != Plugin.ModVersion)
            {
                ModLogger.LogWarning(
                    $"ServerSync package version mismatch. " +
                    $"Received {package.Version}, " +
                    $"local version {Plugin.ModVersion}."
                );

                return false;
            }



            return true;
        }



        private static void ApplyServerOverrides(
            ServerSyncPackage package)
        {
            RuntimeConfigOverride.Clear();



            foreach (
                var entry
                in package.Values)
            {
                if (!IsKnownSyncKey(
                        entry.Key))
                {
                    ModLogger.LogWarning(
                        $"Ignoring unknown ServerSync key '{entry.Key}'."
                    );

                    continue;
                }



                RuntimeConfigOverride.Set(
                    entry.Key,
                    entry.Value
                );
            }
        }



        private static bool IsKnownSyncKey(
            string key)
        {
            foreach (
                ServerSyncDefinition definition
                in ServerSyncRegistry.SyncDefinitions)
            {
                if (definition.Identifier == key)
                {
                    return true;
                }
            }



            return false;
        }



        public static T GetValue<T>(
            string key,
            T localValue)
        {
            if (RuntimeConfigOverride.TryGet<T>(
                    key,
                    out T overrideValue))
            {
                return overrideValue;
            }



            return localValue;
        }



        public static void Shutdown()
        {
            Initialized = false;


            RuntimeConfigOverride.Clear();


            StatusEffectRegistry.RefreshStatusEffects();


            BeltItemManager.RefreshRecipes();



            ModLogger.LogDebug(
                "ServerSync Manager shutdown."
            );
        }
    }
}