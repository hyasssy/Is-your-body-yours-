using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDimention : MonoBehaviour
{
    float priScale;
    float tempScale = 0.1f;
    public float speed = 0.1f;
    private void Start() {
        priScale = transform.localScale.x;
        transform.localScale = Vector3.one * tempScale;
        StartCoroutine(coroutine());
    }
    public GameObject plane;
    IEnumerator coroutine(){
        float time = 0;
        plane.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        while(tempScale<priScale){
            yield return null;
            time += Time.deltaTime;
            tempScale += time * time /100 * speed;
            transform.localScale = Vector3.one * tempScale;
        }
    }
}
