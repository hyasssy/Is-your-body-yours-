using UnityEngine;

public class circleTrussManager : MonoBehaviour
{//サークルトラス生成の中心。マネージャーオブジェクト
    [HideInInspector]
    public float currentRange = 0f;
    public float generateSpeed = 2;
    public float destroyPose = 5;
    public float destroyRange = 50;
    [HideInInspector] public bool on = false;
    [HideInInspector] public Vector3 priPos;
    
    private void Awake() {
        priPos = transform.position;
    }
    private void Update() {
        currentRange += generateSpeed * Time.deltaTime;
        if(currentRange > destroyRange){
            Destroy(gameObject);
        }
    }
}
