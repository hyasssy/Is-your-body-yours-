using UnityEngine;

public class generateStructure : MonoBehaviour
{
    //サークルトラスマネージャーをワールドに配置するマネージャーオブジェクト
    public SceneTimeManager stm;
    public GameObject circleTruss;
    public float generatePose = 0.2f;
    public Vector3 min = new Vector3(-5f,-1f,-5f);
    public Vector3 max = new Vector3(5f,1f,5f);
    float count = 0;
    int i = 0;
    private void Update() {
        count += Time.deltaTime;
        if(count > generatePose){
            count = 0;
            Instantiate(circleTruss, transform.position + new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z)), Quaternion.identity);
            i++;
            if(stm.phase == 4){
                Destroy(gameObject);
            }
        }
    }
}