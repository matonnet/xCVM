using UniGLTF;
using UnityEngine;
using System.Linq;
using UnityEditor;
using VRMShaders;
using System.Collections.Generic;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else
using UnityEditor.Experimental.AssetImporters;
#endif


namespace xCVM
{
    public class RemapEditorVrm : RemapEditorBase
    {
        public RemapEditorVrm(IEnumerable<SubAssetKey> keys, EditorMapGetterFunc getter, EditorMapSetterFunc setter) : base(keys, getter, setter)
        { }

        public void OnGUI(ScriptedImporter importer, GltfData data, UniGLTF.Extensions.VRMC_vrm.VRMC_vrm vrm)
        {
            if (CanExtract(importer))
            {
                if (GUILayout.Button("Extract Meta And Expressions ..."))
                {
                    Extract(importer, data);
                }
                EditorGUILayout.HelpBox("Extract subasset to external object and overwrite remap", MessageType.Info);
            }
            else
            {
                if (GUILayout.Button("Clear extraction"))
                {
                    ClearExternalObjects(importer, typeof(xCVMObject), typeof(xCVMExpression));
                }
                EditorGUILayout.HelpBox("Clear remap. All remap use subAsset", MessageType.Info);
            }

            DrawRemapGUI<xCVMObject>(importer.GetExternalObjectMap());
            DrawRemapGUI<xCVMExpression>(importer.GetExternalObjectMap());
        }

        /// <summary>
        /// 
        /// * xCVMObject
        /// * xCVMExpression[]
        /// 
        /// が Extract 対象となる
        /// 
        /// </summary>
        public static void Extract(ScriptedImporter importer, GltfData data)
        {
            if (string.IsNullOrEmpty(importer.assetPath))
            {
                return;
            }

            var path = GetAndCreateFolder(importer.assetPath, ".vrm1.Assets");

            var assets = AssetDatabase.LoadAllAssetsAtPath(importer.assetPath);
            var prefab = assets.First(x => x is GameObject) as GameObject;

            // expression を extract し置き換え map を作る
            var map = new Dictionary<xCVMExpression, xCVMExpression>();
            foreach (var asset in assets)
            {
                if (asset is xCVMExpression expression)
                {
                    // preview用のprefab
                    expression.Prefab = prefab;

                    var clone = ExtractSubAsset(asset, $"{path}/{asset.name}.asset", false);
                    map.Add(expression, clone as xCVMExpression);
                }
            }

            // vrmObject の expression を置き換える
            var vrmObject = AssetDatabase.LoadAllAssetsAtPath(importer.assetPath).First(x => x is xCVMObject) as xCVMObject;
            vrmObject.Expression.Replace(map);
            vrmObject.Prefab = prefab; // for FirstPerson Editor

            // extract
            ExtractSubAsset(vrmObject, $"{path}/{vrmObject.name}.asset", false);

            AssetDatabase.ImportAsset(importer.assetPath, ImportAssetOptions.ForceUpdate);
        }
    }
}
