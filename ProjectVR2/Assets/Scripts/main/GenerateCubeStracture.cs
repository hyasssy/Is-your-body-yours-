using UnityEngine;

public class GenerateCubeStracture : MonoBehaviour
{//エヴァ構造自動生成
    public GameObject prefab;
    public float delay = 0.2f;
    public float minSize = 0.05f;
    public float pose = 5;
    float count = 0;
    bool on = true;

    private void Update() {
        count += Time.deltaTime;
        if(count > pose){
            if(transform.localScale.x > 0.9f){
                //Instantiate(prefab, new Vector3(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1)), Quaternion.identity);
            }
            Destroy(gameObject);
        }




        if(!on){
            return;
        }
        if(transform.localScale.x < minSize){
            return;
        }
        if(delay>count){
            //count += Time.deltaTime;
        }else{
            GameObject[] children = new GameObject[6];
            for(int i=0;i<6;i++){
                children[i] = Instantiate(prefab, transform.position, transform.rotation);
                children[i].transform.localScale = transform.localScale/2;
            }
            children[0].transform.position += Vector3.up * transform.localScale.x*3/4;
            children[1].transform.position -= Vector3.up * transform.localScale.x*3/4;
            children[2].transform.position += Vector3.right * transform.localScale.x*3/4;
            children[3].transform.position -= Vector3.right * transform.localScale.x*3/4;
            children[4].transform.position += Vector3.forward * transform.localScale.x*3/4;
            children[5].transform.position -= Vector3.forward * transform.localScale.x*3/4;
            on = false;
        }
    }
}
