using UnityEngine;

public class generatePipes : MonoBehaviour
{//パイプ（タバコ）をランダム生成。
    public SceneTimeManager stm;
    public GameObject pipeGeneratePoint;
    public Vector3 minSize, maxSize;
    public float generateDistance = 1.5f;
    Vector3 pos;
    public int amount = 100;
    int i = 0;
    public float generatePose = 0.1f;
    float count = 0;

    private void Update() {
        if(i < amount){
            if(count < generatePose){
                count += Time.deltaTime;
            }else{
                count = 0;
                pos = transform.position + new Vector3(Random.Range(minSize.x, maxSize.x), Random.Range(minSize.y, maxSize.y), Random.Range(minSize.z, maxSize.z));
                if(Vector3.Distance(pos, Camera.main.transform.position) < generateDistance){
                    return;
                }else{
                    Instantiate(pipeGeneratePoint, pos, Quaternion.identity);
                    i++;
                }
            }
        }else{
            stm.phase = 3;
            Destroy(gameObject);
        }
    }
}
