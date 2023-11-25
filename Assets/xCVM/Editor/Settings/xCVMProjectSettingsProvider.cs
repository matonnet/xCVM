using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace xCVM.Settings
{
    internal sealed class xCVMProjectSettingsProvider : SettingsProvider
    {
        [SettingsProvider]
        public static SettingsProvider CreateProvider() => new xCVMProjectSettingsProvider();

        private xCVMProjectSettingsProvider() : base("Project/xCVM", SettingsScope.Project)
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            var asset = xCVMProjectEditorSettings.instance;
            asset.hideFlags &= ~HideFlags.NotEditable;
            var assetObject = new SerializedObject(asset);

            var contentElement = new VisualElement
            {
                style =
                {
                    paddingLeft = 8,
                    paddingRight = 2,
                    paddingTop = 2,
                    paddingBottom = 2
                }
            };
            rootElement.Add(contentElement);
            var title = new Label
            {
                text = "xCVM",
                style =
                {
                    fontSize = 19,
                    unityFontStyleAndWeight = FontStyle.Bold
                }
            };
            contentElement.Add(title);
            var propertyField = new PropertyField(assetObject.FindProperty("materialDescriptorGeneratorFactory"));
            propertyField.RegisterValueChangeCallback(_ => asset.Save());
            contentElement.Add(propertyField);

            contentElement.Bind(assetObject);
        }
    }
}