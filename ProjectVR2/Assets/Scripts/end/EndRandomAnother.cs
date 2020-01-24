using UnityEngine;

public class EndRandomAnother : MonoBehaviour
{
    public float rotateSpeed, speed;
    void Update()
    {
        transform.localEulerAngles += new Vector3(0,rotateSpeed,0) * Time.deltaTime;
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
