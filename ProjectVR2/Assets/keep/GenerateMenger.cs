using UnityEngine;

public class GenerateMenger : MonoBehaviour
{
    public GameObject prefab;
    public float delay = 0.2f;
    public float minSize = 0.05f;
    float count = 0;
    bool on = true;

    private void Update() {
        /*count += Time.deltaTime;
        if(count > 3){
            if(transform.localScale.x > 0.9f){
                Instantiate(prefab, new Vector3(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1)), Quaternion.identity);
            }
            Destroy(gameObject);
        }*/




        if(!on){
            return;
        }
        if(transform.localScale.x < minSize){
            return;
        }
        if(delay>count){
            count += Time.deltaTime;
        }else{
            GameObject[] children = new GameObject[20];
            for(int i=0;i<20;i++){
                children[i] = Instantiate(prefab, transform.position, transform.rotation);
                children[i].transform.localScale = transform.localScale/3;
            }

            children[0].transform.position += new Vector3(-1,1,1) * transform.localScale.x/3;
            children[1].transform.position += new Vector3(0,1,1) * transform.localScale.x/3;
            children[2].transform.position += new Vector3(1,1,1) * transform.localScale.x/3;
            children[3].transform.position += new Vector3(-1,0,1) * transform.localScale.x/3;
            children[4].transform.position += new Vector3(1,0,1) * transform.localScale.x/3;
            children[5].transform.position += new Vector3(-1,-1,1) * transform.localScale.x/3;
            children[6].transform.position += new Vector3(0,-1,1) * transform.localScale.x/3;
            children[7].transform.position += new Vector3(1,-1,1) * transform.localScale.x/3;
            children[8].transform.position += new Vector3(-1,1,0) * transform.localScale.x/3;
            children[9].transform.position += new Vector3(1,1,0) * transform.localScale.x/3;
            children[10].transform.position += new Vector3(-1,-1,0) * transform.localScale.x/3;
            children[11].transform.position += new Vector3(1,-1,0) * transform.localScale.x/3;
            children[12].transform.position += new Vector3(-1,1,-1) * transform.localScale.x/3;
            children[13].transform.position += new Vector3(0,1,-1) * transform.localScale.x/3;
            children[14].transform.position += new Vector3(1,1,-1) * transform.localScale.x/3;
            children[15].transform.position += new Vector3(-1,0,-1) * transform.localScale.x/3;
            children[16].transform.position += new Vector3(1,0,-1) * transform.localScale.x/3;
            children[17].transform.position += new Vector3(-1,-1,-1) * transform.localScale.x/3;
            children[18].transform.position += new Vector3(0,-1,-1) * transform.localScale.x/3;
            children[19].transform.position += new Vector3(1,-1,-1) * transform.localScale.x/3;
            on = false;
            Destroy(gameObject);
        }
    }
}
