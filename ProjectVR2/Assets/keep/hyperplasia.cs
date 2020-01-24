using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyperplasia : MonoBehaviour
{
    public GameObject prefab;
    public int maxAmount = 500;
    public float destroySpeed = 0.7f;
    [HideInInspector] public float destroyRange = 0;
    [HideInInspector] public int amount = 0;
    [HideInInspector] public bool onDestroy = false;
    float delayCount = 0;
    private void Start() {
        Instantiate(prefab);
    }
    private void Update() {
        if(delayCount < 5){
            delayCount+=Time.deltaTime;
            return;
        }
        if(amount >= maxAmount){
            onDestroy = true;
            destroyRange += Time.deltaTime * destroySpeed;
        }
    }

}
