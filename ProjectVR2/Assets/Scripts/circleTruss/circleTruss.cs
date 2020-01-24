using System.Collections;
using UnityEngine;

public class circleTruss : MonoBehaviour
{//サークルトラスのパーツ
    public GameObject textFloor;
    public circleTrussManager ctm;
    float dis;
    float count = 0;
    float generateSpeed = 0.3f;//何秒で規定サイズになるか。
    float primaryScale;
    bool coroutineOn = false;
    private void Start() {
        primaryScale = transform.localScale.y;
        dis = Vector3.Distance(transform.position, ctm.priPos);
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }
    private void Update() {
        if(dis > ctm.currentRange){
            return;
        }
        count += Time.deltaTime;
        if(count < generateSpeed){
            transform.localScale = new Vector3(transform.localScale.x, primaryScale * Mathf.Clamp01(count/generateSpeed), transform.localScale.z);
        }
        if(count > ctm.destroyPose && !coroutineOn){
            coroutineOn = true;
            StartCoroutine("DestroyCoroutine");
        }
    }

    IEnumerator DestroyCoroutine(){
        float t = 0;
        float pose = 0.5f;
        float scale = transform.localScale.y;
        while(t < pose){
            t += Time.deltaTime;
            transform.localScale = new Vector3(transform.localScale.x, scale * (1 - Mathf.Clamp01(t/pose)), transform.localScale.z);
            yield return null;
        }
        GameObject f = Instantiate(textFloor, transform.position, Quaternion.identity);
        f.transform.localEulerAngles += new Vector3(-90,0,0);
        Destroy(gameObject);
    }
}
