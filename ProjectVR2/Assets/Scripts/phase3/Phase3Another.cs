using UnityEngine;
using RootMotion.FinalIK;

public class Phase3Another : MonoBehaviour
{
    public Transform center;
    public Vector3 targetRotation;
    public float rotatePower;
    Vector3 lastPosition;
    Quaternion lastRotation;
    public VRIK ik;
    private void Update() {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
        transform.RotateAround(center.position, new Vector3(targetRotation.x*Mathf.Sin(Time.time/2),targetRotation.y, targetRotation.z), rotatePower);
        ik.solver.AddPlatformMotion (transform.position - lastPosition, transform.rotation * Quaternion.Inverse(lastRotation), transform.position);
        
    }
}
