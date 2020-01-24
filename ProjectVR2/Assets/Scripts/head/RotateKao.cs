using UnityEngine;

public class RotateKao : MonoBehaviour
{
    public float rotateSpeed = 30;
    public float destroyPose = 5;
    public GameObject codeText;
    private void Update() {
        Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, transform.up);
        if(destroyPose>0){
            destroyPose-=Time.deltaTime;
        }else{
            GameObject code = Instantiate(codeText, transform.position, Quaternion.identity);
            code.transform.LookAt(Camera.main.transform);
            Destroy(gameObject);
        }
    }
}
