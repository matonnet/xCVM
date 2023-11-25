using UniGLTF.MeshUtility;
using UnityEditor;

namespace xCVM
{
    public static class xCVMTopMenu
    {
        private const string UserMenuPrefix = xCVMSpecVersion.MENU;
        private const string DevelopmentMenuPrefix = xCVMSpecVersion.MENU + "/Development";
        private const string ExperimentalMenuPrefix = xCVMSpecVersion.MENU + "/Experimental";


        [MenuItem(UserMenuPrefix + "/" + xCVMExportDialog.MENU_NAME, priority = 1)]
        private static void OpenExportDialog() => xCVMExportDialog.Open();

        [MenuItem(UserMenuPrefix + "/" + xCVMMeshUtilityDialog.MENU_NAME, priority = 2)]
        private static void OpenMeshUtility() => xCVMMeshUtilityDialog.OpenWindow();


        [MenuItem(ExperimentalMenuPrefix + "/" + VrmAnimationMenu.MENU_NAME, priority = 21)]
        private static void ConvertVrmAnimation() => VrmAnimationMenu.BvhToVrmAnimationMenu();

#if VRM_DEVELOP        
        [MenuItem(ExperimentalMenuPrefix + "/" + xCVMWindow.MENU_NAME, false, 22)]
        private static void OpenWindow() => xCVMWindow.Open();

        [MenuItem(DevelopmentMenuPrefix + "/Generate from JsonSchema", false, 100)]
        private static void Generate() => xCVMSerializerGenerator.Run(false);

        [MenuItem(DevelopmentMenuPrefix + "/Generate from JsonSchema(debug)", false, 101)]
        private static void Parse() => xCVMSerializerGenerator.Run(true);
#endif
    }
}
