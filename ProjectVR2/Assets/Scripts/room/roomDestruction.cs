using System.Collections.Generic;
using UnityEngine;

public class roomDestruction : MonoBehaviour
{
    public List<GameObject> roomWall = new List<GameObject>();
    public List<GameObject> words = new List<GameObject>();
    public SceneTimeManager stm;
    public Transform centerPoint;
    public float destroyTime = 15;
    Vector3[] vec = new Vector3[7];
    public float expandSpeed = 0.4f;
    public float growingSpeed = 0.3f;
    float tcount = 0;
    bool colliderOff = true;    
    private void Start() {
        for(int i=0;i<7;i++){
            vec[i] = roomWall[i].transform.position - centerPoint.position;
        }
    }
    private void Update() {
        if(stm.phase == 1){
            if(colliderOff){
                colliderOff = false;
                GetComponent<roomCollider>().enabled = false;
            }
            tcount += Time.deltaTime;
            for(int i=0;i<7;i++){
                roomWall[i].transform.position += vec[i] * expandSpeed * Mathf.Clamp01(tcount/2) * Time.deltaTime;
            }
            if(tcount < 2){
                for(int i=0;i<7;i++){
                    roomWall[i].transform.localScale *= growingSpeed;
                }
            }
            if(destroyTime > 0){
                destroyTime -= Time.deltaTime;
            }else{
                for(int i=0;i<words.Count;i++){
                    words[i].SetActive(true);
                    words[i].transform.parent = null;
                }
                stm.phase = 2;
                Destroy(gameObject);
            }
        }
    }
}
