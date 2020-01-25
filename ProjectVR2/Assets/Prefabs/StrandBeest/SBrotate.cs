using UnityEngine;

public class SBrotate : MonoBehaviour
{
    public Transform APoint;
    [Tooltip("1秒あたりの回転角度")]
    public float rotateSpeed = 75f;
    public float waitCount = 0;
    float count = 0;
    float priDis;
    Vector3 curVec;
    private void Start() {
        priDis = Vector3.Distance(APoint.position, transform.position);
    }
    private void LateUpdate() {
        if(count < waitCount){
            count += Time.deltaTime;
            return;
        }
        transform.RotateAround(APoint.position, Vector3.forward, rotateSpeed * Time.fixedDeltaTime);
        curVec = transform.position - APoint.position;
        transform.position -= curVec * (curVec.magnitude - priDis)/curVec.magnitude;
    }
}
