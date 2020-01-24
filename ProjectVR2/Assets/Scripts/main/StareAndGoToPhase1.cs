using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareAndGoToPhase1 : MonoBehaviour
{
    //for raycast
    SceneTimeManager stm;
    public Transform eyes;
    public float rayRange = 2;
    float gazeCount = 0;
    public float staringLength = 5;
    public GameObject another;
    
    private void Start() {
        stm = GetComponent<SceneTimeManager>();
    }
    private void Update() {
        if(stm.phase == 0){
            Phase0();
        }
    }
    void Phase0(){
        Ray ray = new Ray(eyes.position, eyes.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,rayRange)){
            if(hit.collider.tag == "mirror"){
                gazeCount += Time.deltaTime;
            }else{
                gazeCount = 0;
            }
        }
        if(gazeCount > staringLength){
            another.SetActive(true);
        }
    }
    
}
