using UnityEngine;
using VRMShaders;

namespace xCVM
{
    /// <summary>
    /// VRM関連の情報を保持するオブジェクト
    /// ScriptedImporter から Extract して
    /// Editor経由で Edit可能にするのが目的。
    /// ヒエラルキーに対する参照を保持できないので Humanoid, Spring, Constraint は含まず
    /// 下記の項目を保持することとした。
    /// シーンに出さずにアセットとして編集できる。
    /// 
    /// * Meta
    /// * Expressions(enum + custom list)
    /// * LookAt
    /// * FirstPerson
    /// 
    /// </summary>
    public class xCVMObject : PrefabRelatedScriptableObject
    {
        public static SubAssetKey SubAssetKey => new SubAssetKey(typeof(xCVMObject), "_vrm1_");

        [SerializeField]
        public xCVMObjectMeta Meta = new xCVMObjectMeta();

        [SerializeField]
        public xCVMObjectExpression Expression = new xCVMObjectExpression();

        [SerializeField]
        public xCVMObjectLookAt LookAt = new xCVMObjectLookAt();

        [SerializeField]
        public xCVMObjectFirstPerson FirstPerson = new xCVMObjectFirstPerson();

        void OnValidate()
        {
            if (LookAt != null)
            {
                LookAt.HorizontalInner.OnValidate();
                LookAt.HorizontalOuter.OnValidate();
                LookAt.VerticalUp.OnValidate();
                LookAt.VerticalDown.OnValidate();
            }
        }
    }
}
