using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace Dre0Dru.EditorExtensions.Editor
{
    public static class FolderReferenceExtensions
    {
        public static string GetFolderPath(this FolderReference folderReference)
        {
            return AssetDatabase.GUIDToAssetPath(folderReference.GUID);
        }
        
        public static string[] GetFoldersPaths(this IEnumerable<FolderReference> folderReferences)
        {
            return folderReferences
                .Select(reference => reference.GetFolderPath())
                .ToArray();
        }
    }
}
