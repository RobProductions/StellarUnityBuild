using UnityEditor;
using UnityEngine;

namespace SuperUnityBuild.BuildTool
{
    [CustomPropertyDrawer(typeof(BuildReleaseType))]
    public class BuildReleaseTypeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Limit valid characters.
            // TODO: This might not be necessary since name will need to be sanitized for different needs later (as an enum entry, pre-processor define, etc.)
            //char chr = Event.current.character;
            //if ((chr < 'a' || chr > 'z') && (chr < 'A' || chr > 'Z') && (chr < '0' || chr > '9') && chr != '-' && chr != '_' && chr != ' ')
            //{
            //    Event.current.character = '\0';
            //}

            EditorGUILayout.BeginHorizontal();
            bool show = property.isExpanded;
            UnityBuildGUIUtility.DropdownHeader(property.FindPropertyRelative("typeName").stringValue, ref show, UnityBuildGUIUtility.HeaderColorType.AltColor);
            property.isExpanded = show;
            
            BuildReleaseType[] types = BuildSettings.releaseTypeList.releaseTypes;

            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].typeName == property.FindPropertyRelative("typeName").stringValue)
                {
                    if(UnityBuildGUIUtility.MoveUpButton())
                    {
                        if(i - 1 >= 0)
                        {
                            var thisType = BuildSettings.releaseTypeList.releaseTypes[i];
                            ArrayUtility.RemoveAt(ref BuildSettings.releaseTypeList.releaseTypes, i);
                            ArrayUtility.Insert(ref BuildSettings.releaseTypeList.releaseTypes, i - 1, thisType);
                            i = i - 1;
                        }
                    }
                    if (UnityBuildGUIUtility.MoveDownButton())
                    {
                        if (i + 1 < BuildSettings.releaseTypeList.releaseTypes.Length)
                        {
                            var thisType = BuildSettings.releaseTypeList.releaseTypes[i];
                            ArrayUtility.RemoveAt(ref BuildSettings.releaseTypeList.releaseTypes, i);
                            ArrayUtility.Insert(ref BuildSettings.releaseTypeList.releaseTypes, i + 1, thisType);
                            i = i + 1;
                        }
                    }

                    if (UnityBuildGUIUtility.DeleteButton())
                    {
                        ArrayUtility.RemoveAt<BuildReleaseType>(ref BuildSettings.releaseTypeList.releaseTypes, i);
                        GUIUtility.keyboardControl = 0;

                        show = false;

                        break;
                    }

                }
            }


            EditorGUILayout.EndHorizontal();

            if (show)
            {
                EditorGUILayout.BeginVertical(UnityBuildGUIUtility.dropdownContentStyle);

                GUILayout.Label("Basic Info", UnityBuildGUIUtility.midHeaderStyle, GUILayout.ExpandWidth(true));
                SerializedProperty typeName = property.FindPropertyRelative("typeName");

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Type Name");
                typeName.stringValue = GUILayout.TextArea(typeName.stringValue.SanitizeFolderName());
                EditorGUILayout.EndHorizontal();

                GUILayout.Space(15);

                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Release Settings", UnityBuildGUIUtility.midHeaderStyle, GUILayout.ExpandWidth(true));
                GUILayout.Label("Sync w/ Project", UnityBuildGUIUtility.midHeaderStyle, GUILayout.Width(120f));
                EditorGUILayout.EndHorizontal();

                var productNameProperty = property.FindPropertyRelative("productName");
                var syncProductNameProperty = property.FindPropertyRelative("syncProductName");
                UnityBuildGUIUtility.PropertyWithSyncButton(syncProductNameProperty, productNameProperty, Application.productName);

                var companyProperty = property.FindPropertyRelative("companyName");
                var syncCompanyProperty = property.FindPropertyRelative("syncCompanyName");
                UnityBuildGUIUtility.PropertyWithSyncButton(syncCompanyProperty, companyProperty, Application.companyName);

                var bundleProperty = property.FindPropertyRelative("bundleIdentifier");
                var syncBundleProperty = property.FindPropertyRelative("syncBundleIdentifier");
                UnityBuildGUIUtility.PropertyWithSyncButton(syncBundleProperty, bundleProperty, Application.identifier);

                var syncAppNameProperty = property.FindPropertyRelative("syncAppBuildName");
                var appBuildNameProperty = property.FindPropertyRelative("appBuildName");

                UnityBuildGUIUtility.PropertyWithSyncButton(syncAppNameProperty, appBuildNameProperty, productNameProperty.stringValue);

                GUILayout.Space(15);
                GUILayout.Label("Build Options", UnityBuildGUIUtility.midHeaderStyle);

                EditorGUILayout.PropertyField(property.FindPropertyRelative("customDefines"));

                SerializedProperty buildOptions = property.FindPropertyRelative("buildOptions");

                bool enableHeadlessMode = ((BuildOptions)buildOptions.intValue & BuildOptions.EnableHeadlessMode) == BuildOptions.EnableHeadlessMode;
                bool developmentBuild = ((BuildOptions)buildOptions.intValue & BuildOptions.Development) == BuildOptions.Development;
                bool allowDebugging = ((BuildOptions)buildOptions.intValue & BuildOptions.AllowDebugging) == BuildOptions.AllowDebugging;

                enableHeadlessMode = EditorGUILayout.ToggleLeft(" Server Build", enableHeadlessMode);
                if (enableHeadlessMode) buildOptions.intValue |= (int)BuildOptions.EnableHeadlessMode;
                else buildOptions.intValue &= ~(int)BuildOptions.EnableHeadlessMode;

                developmentBuild = EditorGUILayout.ToggleLeft(" Development Build", developmentBuild);
                if (developmentBuild) buildOptions.intValue |= (int)BuildOptions.Development;
                else buildOptions.intValue &= ~(int)BuildOptions.Development;

                EditorGUI.BeginDisabledGroup(!developmentBuild);
                allowDebugging = EditorGUILayout.ToggleLeft(" Script Debugging", allowDebugging);
                EditorGUI.EndDisabledGroup();
                if (allowDebugging) buildOptions.intValue |= (int)BuildOptions.AllowDebugging;
                else buildOptions.intValue &= ~(int)BuildOptions.AllowDebugging;

                GUILayout.Space(15);
                buildOptions.intValue = (int)(BuildOptions)EditorGUILayout.EnumFlagsField("Advanced Options", (BuildOptions)buildOptions.intValue);

                EditorGUILayout.PropertyField(property.FindPropertyRelative("sceneList"));

                property.serializedObject.ApplyModifiedProperties();

                EditorGUILayout.EndVertical();
            }

            EditorGUI.EndProperty();
        }
    }
}
