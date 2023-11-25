using System.IO;
using UnityEngine;

namespace xCVM
{
    public static class TestAsset
    {
        public static string AliciaPath
        {
            get
            {
                return Path.GetFullPath(Application.dataPath + "/../Tests/Models/Alicia_vrm-0.51/AliciaSolid_vrm-0.51.vrm")
                    .Replace("\\", "/");
            }
        }

        public static xCVMInstance LoadAlicia()
        {
            var task = xCVM.LoadPathAsync(AliciaPath, canLoadVrm0X: true);
            task.Wait();
            var instance = task.Result;

            return instance.GetComponent<xCVMInstance>();
        }
    }
}
