using System;
using UnityEngine;

namespace SuperUnityBuild.BuildTool
{
    [Serializable]
    public class BasicSettings
    {
        [FilePath(true, true, "Choose location for build output")]
        public string baseBuildFolder = "Builds";
        [Tooltip("Recognized tokens for the build path: $YEAR, $MONTH, $DAY, $TIME, $RELEASE_TYPE, $PLATFORM, $ARCHITECTURE, $VARIANTS, $DISTRIBUTION, $VERSION, $BUILD, $PRODUCT_NAME, $SCRIPTING_BACKEND")]
        public string buildPath = "$VERSION/$RELEASE_TYPE/$PLATFORM/$ARCHITECTURE/$SCRIPTING_BACKEND";
        public bool openFolderPostBuild = true;
        [Tooltip("The folder path for the " + BuildConstantsGenerator.FileName + " file which will be generated on build. Use the Configure Editor Environment or Generate Build Constants buttons on a selected configuration to generate it now.")]
        [FilePath(true, true, "Choose folder location for the " + BuildConstantsGenerator.FileName + " file")]
        public string constantsFileLocation = Constants.DefaultConstantsFilePath;
        [Tooltip("Whether to use const or readonly when generating fields in the " + BuildConstantsGenerator.FileName + " file")]
        public bool useConstKeyword = true;
    }
}
