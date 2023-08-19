using System.Linq;
using UnityEditor;
using UnityEngine;
// using Shared.Sources.CustomTypes;

namespace Dre0Dru.EditorExtensions.Editor
{
    public static class AssetDatabaseUtils
    {
        public static string GetTypeName<T>()
        {
            return typeof(T).Name;
        }

        public static T FindFirstAsset<T>()
            where T : Object
        {
            var guids = FindAssetsGuids<T>();

            return LoadAsset<T>(guids.First());
        }

        public static T FindSingleAsset<T>()
            where T : Object
        {
            var guids = FindAssetsGuids<T>();

            return LoadAsset<T>(guids.Single());
        }
        
        public static T FindAsset<T>()
            where T : Object
        {
            var guids = FindAssetsGuids<T>();

            return LoadAsset<T>(guids.FirstOrDefault());
        }

        public static T LoadAsset<T>(string assetGuid)
            where T : Object
        {
            return AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(assetGuid));
        }

        public static string[] FindAssetsGuids<T>(params string[] folderPaths)
            where T : Object
        {
            return AssetDatabase.FindAssets($"t: {GetTypeName<T>()}", folderPaths);
        }

        public static T[] LoadAssets<T>()
            where T : Object
        {
            return FindAssetsGuids<T>().Select(LoadAsset<T>).ToArray();
        }
        
        public static T[] LoadAssetsAtPaths<T>(params string[] folderPaths)
            where T : Object
        {
            return folderPaths
                .SelectMany(folderPath => FindAssetsGuids<T>(folderPath))
                .Select(LoadAsset<T>).ToArray();
        }
        
        public static void SetDirtyAndSave(Object target)
        {
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssetIfDirty(target);
        }
    }
}
