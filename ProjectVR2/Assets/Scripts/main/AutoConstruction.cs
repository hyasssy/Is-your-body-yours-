using UnityEngine;
using System.Collections.Generic;

public class AutoConstruction : MonoBehaviour
{
    //generatePointの数だけフィールドに自動宇宙建築生成ポイントを配置してニョキニョキはやす。
    public GameObject root;
    public List<Transform> generatePoints = new List<Transform>();
    public float restructPose = 15;
    float t = 0;

    private void Start() {
        for(int i=0;i<generatePoints.Count;i++){
            Instantiate(root, generatePoints[i].position, Quaternion.identity);
        }
    }
    private void Update() {
        t += Time.deltaTime;
        if(restructPose < t){
            for(int i=0;i<generatePoints.Count;i++){
                Instantiate(root, generatePoints[i].position, Quaternion.identity);
            }
            t = 0;
        }
    }




    /*自動で中心動かして軌跡にいろいろ作って残してくスクリプトの残骸
    public GameObject polePrefab, cubePrefab;
    public float generatePose = 0.1f;
    public float moveSpeed = 2;
    public Vector3 moveRange, generateRange;
    Vector3 nextPoint, prePoint;
    float priDis,t,c;
    private void Start() {
        prePoint = transform.position;
        nextPoint = new Vector3(Random.Range(-moveRange.x, moveRange.x),Random.Range(-moveRange.y, moveRange.y), Random.Range(-moveRange.z, moveRange.z));
        priDis = Vector3.Distance(prePoint, nextPoint);
        t=0;c=0;
    }
    private void Update() {
        t += Time.deltaTime;
        float present = moveSpeed * t / priDis;
        if(present > 1){
            transform.position = Vector3.Slerp(prePoint, nextPoint, Mathf.Clamp01(present));
            t = 0;
            prePoint = transform.position;
            nextPoint = new Vector3(Random.Range(-moveRange.x, moveRange.x),Random.Range(-moveRange.y, moveRange.y), Random.Range(-moveRange.z, moveRange.z));
            priDis = Vector3.Distance(prePoint, nextPoint);
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
        }else{
            transform.position = Vector3.Slerp(prePoint, nextPoint, present);
        }
        

        c += Time.deltaTime;
        if(generatePose<c){
            c = 0;
            GameObject g = Instantiate(polePrefab, transform.position + new Vector3(Random.Range(-generateRange.x, generateRange.x),Random.Range(-generateRange.y, generateRange.y),Random.Range(-generateRange.z, generateRange.z)), Random.rotation);
            g.transform.localScale = new Vector3(g.transform.localScale.x, Random.Range(1, 4), g.transform.localScale.z);//サイズレンジ
            //g.transform.localPosition += Vector3.up * Random.Range(-g.transform.localScale.y, g.transform.localScale.y);
        }
        
    }*/
}
