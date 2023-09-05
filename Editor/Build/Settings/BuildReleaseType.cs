using System;
using UnityEditor;
using UnityEngine.Serialization;

namespace SuperUnityBuild.BuildTool
{
    [Serializable]
    public class BuildReleaseType
    {
        public string typeName = string.Empty;
        [FormerlySerializedAs("bundleIndentifier")]
        public string bundleIdentifier = string.Empty;
        public string companyName = string.Empty;
        public string productName = string.Empty;
        public string appBuildName = string.Empty;

        public bool syncBundleIdentifier = true;
        public bool syncCompanyName = true;
        public bool syncProductName = true;
        [FormerlySerializedAs("syncAppNameWithProduct")]
        public bool syncAppBuildName = true;

        public BuildOptions buildOptions;
        public string customDefines = string.Empty;

        public SceneList sceneList = new SceneList();
    }
}
