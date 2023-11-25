using System.Collections;
using UnityEngine;


namespace xCVM.xCVMViewer
{
    /// <summary>
    /// 喜怒哀楽驚を循環させる
    /// </summary>
    public class xCVMAutoExpression : MonoBehaviour
    {
        [SerializeField]
        public xCVMInstance Controller;
        private void Reset()
        {
            Controller = GetComponent<xCVMInstance>();
        }

        Coroutine m_coroutine;

        [SerializeField]
        float m_wait = 0.5f;

        private void Awake()
        {
            if (Controller == null)
            {
                Controller = GetComponent<xCVMInstance>();
            }
        }

        IEnumerator RoutineNest(ExpressionPreset preset, float velocity, float wait)
        {
            for (var value = 0.0f; value <= 1.0f; value += velocity)
            {
                Controller.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(preset), value);
                yield return null;
            }
            Controller.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(preset), 1.0f);
            yield return new WaitForSeconds(wait);
            for (var value = 1.0f; value >= 0; value -= velocity)
            {
                Controller.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(preset), value);
                yield return null;
            }
            Controller.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(preset), 0);
            yield return new WaitForSeconds(wait * 2);
        }

        IEnumerator Routine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);

                var velocity = 0.01f;

                yield return RoutineNest(ExpressionPreset.happy, velocity, m_wait);
                yield return RoutineNest(ExpressionPreset.angry, velocity, m_wait);
                yield return RoutineNest(ExpressionPreset.sad, velocity, m_wait);
                yield return RoutineNest(ExpressionPreset.relaxed, velocity, m_wait);
                yield return RoutineNest(ExpressionPreset.surprised, velocity, m_wait);
            }
        }

        private void OnEnable()
        {
            m_coroutine = StartCoroutine(Routine());
        }

        private void OnDisable()
        {
            StopCoroutine(m_coroutine);
        }
    }
}
