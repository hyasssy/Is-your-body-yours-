using UnityEngine;

public class pole : MonoBehaviour
{
    public float generateTime = 0.2f;
    public float destroyTime = 3;
    float primaryScale;
    float t = 0;
    float t2 = 0;
    void Start()
    {
        primaryScale = transform.localScale.y;
        transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
    }

    void Update()
    {
        if(t<generateTime){
            transform.localScale = new Vector3(transform.localScale.x, primaryScale*t/generateTime, transform.localScale.z);
        }
        
        if(t > destroyTime){
            t2 += Time.deltaTime;
            if(t2 <generateTime){
                transform.localScale = new Vector3(transform.localScale.x, primaryScale*(1 - t2/generateTime), transform.localScale.z);
            }else{
                Destroy(gameObject);
            }
        }else{
            t += Time.deltaTime;
        }
    }
}
