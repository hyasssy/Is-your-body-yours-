using UnityEngine;

public class wallAnim : MonoBehaviour
{
//自動的にスケールいじってうねうねする。
    public float maxScale = 2f;
    public float minScale = 0.5f;
    float[] targetScale = new float[3];
    float[] nextScale = new float[3];
    float[] preScale = new float[3];
    public Vector2 timeRange = new Vector3(1f,3f);
    float[] time = new float[3];
    float[] pose = {0,0,0};
    float count = 0;
    float delayCount = 0;
    private void Start() {

        for(int i=0;i<3;i++){
            time[i] += Random.Range(timeRange.x, timeRange.y);
            nextScale[i] = Random.Range(minScale, maxScale);
            preScale[i] = 1f;
        }
        transform.localScale = Vector3.zero;
    }
    private void Update() {
        if(delayCount<2){
            delayCount+=Time.deltaTime;
            transform.localScale = Vector3.Slerp(Vector3.zero, Vector3.one, delayCount/2);
            return;
        }
        count += Time.deltaTime;
    
        for(int i=0;i<3;i++){
            if(count >= time[i]){
                pose[i] = count;
                time[i] += Random.Range(timeRange.x, timeRange.y);
                preScale[i] = nextScale[i];
                nextScale[i] = Random.Range(minScale, maxScale);
            }
            targetScale[i] = Mathf.Lerp(preScale[i], nextScale[i], (count-pose[i])/(time[i]-pose[i]));
        }
        transform.localScale = new Vector3(targetScale[0],targetScale[1], targetScale[2]);

    }


}
