using System;
using UniGLTF;
using UnityEngine;
using UnityEngine.UI;

namespace xCVM.URPSample
{
    public class UrpSampleUI : MonoBehaviour
    {
        [SerializeField] private Button openModelButton;

        private xCVMInstance _loadedVrm;
        
        private void Start()
        {
            openModelButton.onClick.AddListener(OnOpenModelButtonClicked);
        }

        private async void OnOpenModelButtonClicked()
        {
            if (_loadedVrm)
            {
                Destroy(_loadedVrm.gameObject);
            }
            
#if UNITY_STANDALONE_WIN
            var path = FileDialogForWindows.FileDialog("open VRM", "vrm");
#elif UNITY_EDITOR
            var path = UnityEditor.EditorUtility.OpenFilePanel("Open VRM", "", "vrm");
#else
            var path = Application.dataPath + "/default.vrm";
#endif            
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                _loadedVrm = await xCVM.LoadPathAsync(path,
                    canLoadVrm0X: true,
                    showMeshes: false,
                    materialGenerator: new UrpxCVMMaterialDescriptorGenerator());
                if (_loadedVrm == null)
                {
                    return;
                }

                var instance = _loadedVrm.GetComponent<RuntimeGltfInstance>();
                instance.ShowMeshes();
                instance.EnableUpdateWhenOffscreen();
                
            }
            catch (OperationCanceledException)
            {
                // Do nothing
            }
        }
    }
}