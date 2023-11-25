﻿using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace xCVM.FirstPersonSample
{
    public class xCVMCanvasManager : MonoBehaviour
    {
        [SerializeField]
        public Button LoadVRMButton;

        [SerializeField]
        public Button LoadBVHButton;

        private void Reset()
        {
            LoadVRMButton = GameObject.FindObjectsOfType<Button>().FirstOrDefault(x => x.name == "LoadVRM");
            LoadBVHButton = GameObject.FindObjectsOfType<Button>().FirstOrDefault(x => x.name == "LoadBVH");
        }
    }
}