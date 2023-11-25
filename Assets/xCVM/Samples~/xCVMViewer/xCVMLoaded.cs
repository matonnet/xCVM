using System;
using UniGLTF;
using UniGLTF.Utils;
using UnityEngine;

namespace xCVM.xCVMViewer
{
    class Loaded : IDisposable
    {
        RuntimeGltfInstance m_instance;
        xCVMInstance m_controller;
        public xCVMRuntimeControlRig ControlRig => m_controller.Runtime.ControlRig;
        public xCVMRuntime Runtime => m_controller.Runtime;

        xCVMAIUEO m_lipSync;
        bool m_enableLipSyncValue;
        public bool EnableLipSyncValue
        {
            set
            {
                if (m_enableLipSyncValue == value) return;
                m_enableLipSyncValue = value;
                if (m_lipSync != null)
                {
                    m_lipSync.enabled = m_enableLipSyncValue;
                }
            }
        }

        xCVMAutoExpression m_autoExpression;
        bool m_enableAutoExpressionValue;
        public bool EnableAutoExpressionValue
        {
            set
            {
                if (m_enableAutoExpressionValue == value) return;
                m_enableAutoExpressionValue = value;
                if (m_autoExpression != null)
                {
                    m_autoExpression.enabled = m_enableAutoExpressionValue;
                }
            }
        }

        xCVMBlinker m_blink;
        bool m_enableBlinkValue;
        public bool EnableBlinkValue
        {
            set
            {
                if (m_blink == value) return;
                m_enableBlinkValue = value;
                if (m_blink != null)
                {
                    m_blink.enabled = m_enableBlinkValue;
                }
            }
        }

        public Loaded(RuntimeGltfInstance instance, Transform lookAtTarget)
        {
            m_instance = instance;

            m_controller = instance.GetComponent<xCVMInstance>();
            if (m_controller != null)
            {
                // VRM
                m_controller.UpdateType = xCVMInstance.UpdateTypes.LateUpdate; // after HumanPoseTransfer's setPose
                {
                    m_lipSync = instance.gameObject.AddComponent<xCVMAIUEO>();
                    m_blink = instance.gameObject.AddComponent<xCVMBlinker>();
                    m_autoExpression = instance.gameObject.AddComponent<xCVMAutoExpression>();

                    m_controller.LookAtTargetType = xCVMObjectLookAt.LookAtTargetTypes.SpecifiedTransform;
                    m_controller.LookAtTarget = lookAtTarget;
                }
            }

            var animation = instance.GetComponent<Animation>();
            if (animation && animation.clip != null)
            {
                // GLTF animation
                animation.Play(animation.clip.name);
            }
        }

        public void Dispose()
        {
            // destroy GameObject
            GameObject.Destroy(m_instance.gameObject);
        }
    }
}
