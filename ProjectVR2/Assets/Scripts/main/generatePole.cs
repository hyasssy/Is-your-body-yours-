using UnityEngine;
using System.Collections;

public class generatePole : MonoBehaviour
{//宇宙建築をニョキニョキ生やす（最初の一個を出すタイミングを管理する。
    //AutoConstructionをもったmanager object　がシーン上に必要
    public float range = 100;
    AutoConstruction autoConstruction;
    public GameObject prefab, structure;
    public float pose = 0.1f;
    public float minSize = 0.5f;//minimom
    public float maxSize = 3;
    public float generateTime = 0.3f;
    public float destroyCount = 10f;
    int count = 0;
    float primaryScale;
    Vector3 priPos;
    float t = 0;
    bool b = false;
    private void Start() {
        autoConstruction = FindObjectOfType<AutoConstruction>();
        transform.localEulerAngles = new Vector3(Random.Range(-110, 110),Random.Range(-180, 180),Random.Range(-110, 110));
        primaryScale = transform.localScale.y;
        //poleManager = FindObjectOfType<poleManager>();
        priPos = transform.localPosition - transform.up * primaryScale * 0.1f;//ちょい下げることでマチを作る。
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }
    private void Update() {
        t += Time.deltaTime;
        if(t > destroyCount){
            StartCoroutine("DestroyCoroutine");
        }
        if(b){
            return;
        }else{
            if(t<generateTime){
                transform.localScale = new Vector3(transform.localScale.x, primaryScale * Mathf.Clamp01(t/generateTime), transform.localScale.z);
                transform.localPosition = priPos + transform.up * transform.localScale.y;
            }
            if(pose<t){
                b = true;
                if((transform.position - autoConstruction.transform.position).magnitude > range){
                    return;
                }
                GameObject g = Instantiate(prefab, transform.position + transform.up * transform.localScale.y * 0.9f, Quaternion.identity);
                g.transform.localScale = new Vector3(g.transform.localScale.x, Random.Range(minSize, maxSize), g.transform.localScale.z);
                transform.parent = autoConstruction.transform;
                float f = Random.Range(0f,1f);
                if(f>0.97f){
                    Instantiate(structure, transform.position, Quaternion.identity);
                }
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
