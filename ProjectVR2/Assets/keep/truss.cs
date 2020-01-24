using UnityEngine;
using System.Collections;

public class truss : MonoBehaviour
{//parent scriptがあたったものがシーン上に必要
//最初一本あって、そいつを軸にこのスクリプトでは次の一本を作る。
    circleTrussManager circleTrussManager;
    public GameObject prefab;
    public float range = 100;
    public float generateTime = 0.1f;
    public float destroyCount = 10f;
    float primaryScale;
    float t = 0;
    bool b = false;
    Vector3 priPos;
    private void Start() {
        priPos = transform.position;
        primaryScale = transform.localScale.y;
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        circleTrussManager = FindObjectOfType<circleTrussManager>();
    }
    private void Update() {
        t += Time.deltaTime;
        if(t > destroyCount){
            StartCoroutine("DestroyCoroutine");
        }
        if(t<generateTime){
            transform.localScale = new Vector3(transform.localScale.x, primaryScale * Mathf.Clamp01(t/generateTime), transform.localScale.z);
            transform.position = priPos + transform.up * primaryScale * Mathf.Clamp01(t/generateTime);
        }else{
            if(!b){
                b = true;//育ち終わったら一回呼び出す。
                if((transform.position - circleTrussManager.transform.position).magnitude > range){
                    return;
                }
                transform.localScale = new Vector3(transform.localScale.x, primaryScale, transform.localScale.z);
                transform.position = priPos + transform.up * primaryScale;
                GameObject g = Instantiate(prefab, transform.position + transform.up * primaryScale, transform.rotation);
                g.transform.eulerAngles += new Vector3(0,90,90);
                g.transform.parent = circleTrussManager.transform;
            }
            
        }
    }
    IEnumerator DestroyCoroutine(){
        float count = 0;
        float destroyPose = 0.5f;
        float scale = transform.localScale.y;
        while(count < destroyPose){
            count += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, scale * (1 - Mathf.Clamp01(count/destroyPose)), transform.localScale.z);
            yield return null;
        }
        Destroy(gameObject);
    }
}
