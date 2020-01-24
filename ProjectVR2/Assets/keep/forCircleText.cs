using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forCircleText : MonoBehaviour
{
    public GameObject prefab;
    public int amount = 100;
    public float range = 10f;
    GameObject empty;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Generate();
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            Destroy(empty);
        }
    }
    void Generate(){
        empty = new GameObject("parent");
        int i = 0;
        while(i < amount){
            Vector3 place = new Vector3(Random.Range(-range,range), 0, Random.Range(-range,range));
            if(place.magnitude <= range){
                GameObject g = Instantiate(prefab, place, Quaternion.identity);
                g.transform.localEulerAngles += new Vector3(-90, 0, Random.Range(-180f, 180f));
                g.transform.parent = empty.transform;
                i++;
            }
        }
    }
}
