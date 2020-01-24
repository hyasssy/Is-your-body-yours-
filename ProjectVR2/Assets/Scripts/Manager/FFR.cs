using UnityEngine;

public class FFR : MonoBehaviour
{//軽量化配慮措置
    void Start()
    {
        if(gameObject.GetComponent<CheckVR>().onVR){
            OVRManager.fixedFoveatedRenderingLevel = OVRManager.FixedFoveatedRenderingLevel.High;
        }
    }
}
