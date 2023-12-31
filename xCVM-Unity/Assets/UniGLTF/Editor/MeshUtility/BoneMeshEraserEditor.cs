using UniGLTF.M17N;
using UnityEditor;
using UnityEngine;

namespace UniGLTF.MeshUtility
{
    /// <summary>
    /// BoneMeshRemover 向けのエディタ。
    /// 
    /// SerializedProperty 経由で ユーザー定義 struct のフィールド
    /// public List<BoneMeshEraser.EraseBone> _eraseBones;
    /// を EditorGUILayout.PropertyField するための細工である。
    /// 
    /// SerializedObject は UnityEngine.Object から作成するので、
    /// UnityEngine.Object を継承したクラスのフィールドに ユーザー定義 struct を配置する。
    /// 持ち主の SerializedObject を経由して EditorGUILayout.PropertyField してる。
    /// </summary>
    [CustomEditor(typeof(MeshUtilityDialog), true)]
    class BoneMeshEraserEditor : Editor
    {
        MeshUtilityDialog _targetDialog;
        SerializedProperty _skinnedMesh;
        SerializedProperty _eraseBones;

        void OnEnable()
        {
            _targetDialog = target as MeshUtilityDialog;
            if (_targetDialog)
            {
                _skinnedMesh = serializedObject.FindProperty(nameof(MeshUtilityDialog._skinnedMeshRenderer));
                _eraseBones = serializedObject.FindProperty(nameof(MeshUtilityDialog._eraseBones));
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_skinnedMesh);
            EditorGUILayout.PropertyField(_eraseBones);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
