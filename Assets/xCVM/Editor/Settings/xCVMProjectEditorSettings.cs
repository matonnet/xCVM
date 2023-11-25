using UnityEditor;
using UnityEngine;

namespace xCVM.Settings
{
    [FilePath("ProjectSettings/xCVMProjectEditorSettings.asset", FilePathAttribute.Location.ProjectFolder)]
    internal class xCVMProjectEditorSettings : ScriptableSingleton<xCVMProjectEditorSettings>
    {
        [SerializeField] private MaterialDescriptorGeneratorFactory materialDescriptorGeneratorFactory; 
        
        public MaterialDescriptorGeneratorFactory MaterialDescriptorGeneratorFactory => materialDescriptorGeneratorFactory;
        public void Save()
        {
            Save(true);
        }
    }
}