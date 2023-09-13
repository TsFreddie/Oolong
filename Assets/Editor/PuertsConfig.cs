using Puerts;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace PuertsConfig
{
    [Configure]
    public class PuertsConfig
    {
        [CodeOutputDirectory]
        public static string OutputDirectory
        {
            get
            {
                return Path.Combine(Application.dataPath, "Generated", "Puerts/");
            }
        }

        private static IEnumerable<Type> Typings
        {
            get
            {
                return new List<Type>()
                {
                    //仅生成ts接口, 不生成C#静态代码
                    typeof(List<int>),
                    typeof(IList<int>),
                    typeof(Dictionary<int, int>),
                    typeof(IDictionary<int, int>),
                    typeof(ICollection<int>),
                    typeof(HashSet<int>),
                    typeof(ISet<int>),
                    typeof(Addressables),
                    typeof(AsyncOperationHandle<Object>),
                    typeof(ArraySegment<byte>),
                };
            }
        }

        [Typing]
        public static IEnumerable<Type> DynamicTypings
        {
            get
            {
                // 在这里添加名字空间
                var namespaces = new List<string>()
                {
                    "UnityEngine",
                    "UnityEngine.UI",
                    "TMPro",
                    "UnityEngine.Networking",
                    "TSF.Oolong"
                };
                var unityTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                  where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                                  from type in assembly.GetExportedTypes()
                                  where type.Namespace != null && namespaces.Contains(type.Namespace) && !IsExcluded(type)
                                  select type);
                var customAssembles = new string[]
                {
                    "Unity.TextMeshPro",
                    "UnityEngine.UnityWebRequestModule",
                };
                var customTypes = (from assembly in customAssembles.Select(Assembly.Load)
                                   where !(assembly.ManifestModule is System.Reflection.Emit.ModuleBuilder)
                                   from type in assembly.GetExportedTypes()
                                   where type.Namespace == null ||
                                   (
                                       !type.Namespace.StartsWith("Puerts") &&
                                       !IsExcluded(type)
                                   )
                                   select type);
                return unityTypes
                    .Concat(customTypes)
                    .Concat(Typings)
                    .Concat(Bindings)
                    .Distinct();
            }
        }

        [BlittableCopy]
        public static IEnumerable<Type> Blittables
        {
            get
            {
                return new List<Type>()
                {
                    //打开这个可以优化Vector3的GC，但需要开启unsafe编译
                    typeof(Vector3), typeof(Vector2)
                };
            }
        }

        [Binding]
        public static IEnumerable<Type> Bindings
        {
            get
            {
                var types = new List<Type>()
                {
                    // Unity
                    typeof(GameObject),
                    typeof(Transform),
                    typeof(Rigidbody),
                    typeof(Rigidbody2D),
                    typeof(Vector3),
                    typeof(Vector2),

                    // // Mithril
                    // typeof(DocumentUtils),
                    // typeof(IOolongElement),
                    // typeof(ScreenCaptureRequester),
                    //
                    // // Mithril Type
                    // typeof(OolongButton),
                    // typeof(OolongContainer),
                    // typeof(OolongImage),
                    // typeof(OolongPanel),
                    // typeof(OolongText),
                    // typeof(OolongToggle),
                    // typeof(OolongSlider),
                    // typeof(OolongScrollView),
                    //
                    // // Mithril Element Type
                    // typeof(OolongElement<OolongButton>),
                    // typeof(OolongElement<OolongContainer>),
                    // typeof(OolongElement<OolongImage>),
                    // typeof(OolongElement<OolongPanel>),
                    // typeof(OolongElement<OolongText>),
                    // typeof(OolongElement<OolongToggle>),
                    // typeof(OolongElement<OolongSlider>),
                    // typeof(OolongElement<OolongScrollView>),

                    // System
                    typeof(ILoader),
                    typeof(Array),
                    typeof(IList),
                    typeof(ICollection),
                    typeof(IDictionary),
                };
                return types;
            }
        }

        private static bool IsExcluded(Type type)
        {
            if (type == null)
                return false;

            var assemblyName = Path.GetFileName(type.Assembly.Location);
            if (s_excludeAssemblies.Contains(assemblyName))
                return true;

            var fullname = type.FullName != null ? type.FullName.Replace("+", ".") : "";
            return s_excludeTypes.Contains(fullname) || IsExcluded(type.BaseType);
        }


        private static readonly List<string> s_excludeAssemblies = new List<string>
        {
            "UnityEditor.dll",
            "Assembly-CSharp-Editor.dll",
        };

        private static readonly List<string> s_excludeTypes = new List<string>
        {
            "UnityEngine.iPhone",
            "UnityEngine.iPhoneTouch",
            "UnityEngine.iPhoneKeyboard",
            "UnityEngine.iPhoneInput",
            "UnityEngine.iPhoneAccelerationEvent",
            "UnityEngine.iPhoneUtils",
            "UnityEngine.iPhoneSettings",
            "UnityEngine.AndroidInput",
            "UnityEngine.AndroidJavaProxy",
            "UnityEngine.BitStream",
            "UnityEngine.ADBannerView",
            "UnityEngine.ADInterstitialAd",
            "UnityEngine.RemoteNotification",
            "UnityEngine.LocalNotification",
            "UnityEngine.NotificationServices",
            "UnityEngine.MasterServer",
            "UnityEngine.Network",
            "UnityEngine.NetworkView",
            "UnityEngine.ParticleSystemRenderer",
            "UnityEngine.ParticleSystem.CollisionEvent",
            "UnityEngine.ProceduralPropertyDescription",
            "UnityEngine.ProceduralTexture",
            "UnityEngine.ProceduralMaterial",
            "UnityEngine.ProceduralSystemRenderer",
            "UnityEngine.TerrainData",
            "UnityEngine.HostData",
            "UnityEngine.RPC",
            "UnityEngine.AnimationInfo",
            "UnityEngine.UI.IMask",
            "UnityEngine.Caching",
            "UnityEngine.Handheld",
            "UnityEngine.MeshRenderer",
            "UnityEngine.UI.DefaultControls",
            "UnityEngine.AnimationClipPair",                      //Obsolete
            "UnityEngine.CacheIndex",                             //Obsolete
            "UnityEngine.SerializePrivateVariables",              //Obsolete
            "UnityEngine.Networking.NetworkTransport",            //Obsolete
            "UnityEngine.Networking.ChannelQOS",                  //Obsolete
            "UnityEngine.Networking.ConnectionConfig",            //Obsolete
            "UnityEngine.Networking.HostTopology",                //Obsolete
            "UnityEngine.Networking.GlobalConfig",                //Obsolete
            "UnityEngine.Networking.ConnectionSimulatorConfig",   //Obsolete
            "UnityEngine.Networking.DownloadHandlerMovieTexture", //Obsolete
            "AssetModificationProcessor",                         //Obsolete
            "AddressablesPlayerBuildProcessor",                   //Obsolete
            "UnityEngine.WWW",                                    //Obsolete
            "UnityEngine.EventSystems.TouchInputModule",          //Obsolete
            "UnityEngine.MovieTexture",                           //Obsolete[ERROR]
            "UnityEngine.NetworkPlayer",                          //Obsolete[ERROR]
            "UnityEngine.NetworkViewID",                          //Obsolete[ERROR]
            "UnityEngine.NetworkMessageInfo",                     //Obsolete[ERROR]
            "UnityEngine.UI.BaseVertexEffect",                    //Obsolete[ERROR]
            "UnityEngine.UI.IVertexModifier",                     //Obsolete[ERROR]
            //Windows Obsolete[ERROR]
            "UnityEngine.EventProvider",
            "UnityEngine.UI.GraphicRebuildTracker",
            "UnityEngine.GUI.GroupScope",
            "UnityEngine.GUI.ScrollViewScope",
            "UnityEngine.GUI.ClipScope",
            "UnityEngine.GUILayout.HorizontalScope",
            "UnityEngine.GUILayout.VerticalScope",
            "UnityEngine.GUILayout.AreaScope",
            "UnityEngine.GUILayout.ScrollViewScope",
            "UnityEngine.GUIElement",
            "UnityEngine.GUILayer",
            "UnityEngine.GUIText",
            "UnityEngine.GUITexture",
            "UnityEngine.ClusterInput",
            "UnityEngine.ClusterNetwork",
            "UnityEngine.ClusterSerialization",

            //System
            "System.Tuple",
            "System.Double",
            "System.Single",
            "System.ArgIterator",
            "System.SpanExtensions",
            "System.TypedReference",
            "System.StringBuilderExt",
            "System.IO.Stream",
            "System.Net.HttpListenerTimeoutManager",
            "System.Net.Sockets.SocketAsyncEventArgs",
            "System.Buffers.MemoryHandle",

            // FishNet Generated
            "FishNet.Runtime.GeneratedWriters___FN",
            "FishNet.Runtime.GeneratedReaders___FN",

            // Formatters
            "MessagePack",

            // Deprecated
            "Spine.Unity.Deprecated"
        };
    }
}
