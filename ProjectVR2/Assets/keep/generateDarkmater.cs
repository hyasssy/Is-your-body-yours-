using UnityEngine;

public class generateDarkmater : MonoBehaviour
{
    hyperplasia manager;
    public GameObject prefab;
    float pose, count;
    Vector2 poseRange = new Vector2(0.7f, 2);
    public Vector3 range = new Vector3(0.5f,0.3f,0.5f);
    bool on = true;
    int n = 0;
    float delayCount = 0;
    private void Start() {
        manager = FindObjectOfType<hyperplasia>();
        pose = Random.Range(poseRange.x, poseRange.y);
        count = Time.time;
    }
    private void Update() {
        float dis = Vector3.Distance(manager.transform.position, transform.position);
        if(dis < manager.destroyRange){
            if(delayCount<2){
                delayCount+=Time.deltaTime;
                transform.localScale = Vector3.Slerp(transform.localScale, Vector3.zero, delayCount/2);
            }else{
                Destroy(gameObject);
                manager.amount--;
            }
        }
        
            if(Time.time - count > pose){
                GameObject d = Instantiate(prefab, transform.position + new Vector3(Random.Range(-range.x, range.x),Random.Range(-range.y, range.y),Random.Range(-range.z, range.z)), Random.rotation);
                //d.transform.position += (d.transform.position - transform.position).normalized * Random.Range(0.5f, 1f);
                count = Time.time;
                pose = Random.Range(poseRange.x, poseRange.y);
                manager.amount++;
            }
    }
}
