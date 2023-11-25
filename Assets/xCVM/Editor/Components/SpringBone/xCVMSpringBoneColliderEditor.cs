using UnityEditor;
using UnityEngine;

namespace xCVM
{
    [CustomEditor(typeof(xCVMSpringBoneCollider))]
    class xCVMSpringBoneColliderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (xCVMWindow.Active == target)
            {
                GUI.backgroundColor = Color.cyan;
                Repaint();
            }
            base.OnInspectorGUI();
        }
    }
}
