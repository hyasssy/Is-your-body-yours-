using System.Collections;
using UnityEngine;

public class DoppelGenger : MonoBehaviour
{
    public Transform root;
    public int maxNumber = 30;
    public float pose = 0.5f;
    public GameObject prefab, another;
    private void Start() {
        StartCoroutine(Represent());
    }

    IEnumerator Represent(){
        yield return new WaitForSeconds(3.3f);
        another.SetActive(true);
        int n = 0;
        while(true){
            yield return new WaitForSeconds(pose);
            GameObject obj = Instantiate(prefab, root.position, root.rotation);
            n ++;
            obj.transform.localEulerAngles += Vector3.up * Random.Range(0,360);
            if(n > maxNumber){
                break;
            }
        }
    }
}
