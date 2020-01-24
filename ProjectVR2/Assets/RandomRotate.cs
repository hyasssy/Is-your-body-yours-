using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    float count = 0f;
    public float accelerateSpeed, decreaseSpeed;
    public float intensity = 1f;
    public float minPower = 0.2f;
    float power;
    [Range(-1,1)]public float x = -1,y=0,z=1;
    private void Update() {
        count += Time.deltaTime;
        if(count < accelerateSpeed){
            power = Mathf.Clamp01(count * count / accelerateSpeed / accelerateSpeed);
        }else{
            if(power > minPower){
                power -= Time.deltaTime * decreaseSpeed;
            }
        }
        Vector3 targetRotation = new Vector3(x,y,z) * power * intensity;
        transform.Rotate(targetRotation);
    }
}
