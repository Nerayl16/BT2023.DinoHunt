// ExportPackage.cs
using UnityEngine;
using UnityEditor;
 
public class FullExport{
    [MenuItem ("Export/FullExport")]
    static void export()
    {
        AssetDatabase.ExportPackage (AssetDatabase.GetAllAssetPaths(),PlayerSettings.productName + ".unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies | ExportPackageOptions.IncludeLibraryAssets);
    }
}