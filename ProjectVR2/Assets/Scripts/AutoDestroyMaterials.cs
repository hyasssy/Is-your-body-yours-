using UnityEngine;

public class AutoDestroyMaterials : MonoBehaviour
{
    #region Parameters

    // 重複登録防止のためのルートフラグ
    [System.NonSerialized] public bool IsRoot = true;

    #endregion

    void Start(){
        if(IsRoot){
            // 配下のレンダラすべてに追加
            foreach(var r in this.GetComponentsInChildren<Renderer>()){
                r.gameObject.AddComponent<AutoDestroyMaterials>().IsRoot = false;
            }
        }
    }

    void OnDestroy(){
        // レンダラのマテリアルを破棄(パーティクルシステムのレンダラも含まれる)
        var thisRenderer = this.GetComponent<Renderer>();
        if(thisRenderer != null && thisRenderer.materials != null){
            foreach(var m in thisRenderer.materials){
                DestroyImmediate(m);
            }
        }
    }
}
