using UnityEngine;
using RootMotion.FinalIK;

public class RotateAroundPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 targetRotation;
    public float rotatePower;
    Vector3 lastPosition;
    Quaternion lastRotation;
    public VRIK ik;
    private void Update() {
        lastPosition = transform.position;
        lastRotation = transform.rotation;
        transform.RotateAround(player.position, targetRotation, rotatePower);
        ik.solver.AddPlatformMotion (transform.position - lastPosition, transform.rotation * Quaternion.Inverse(lastRotation), transform.position);
    }
}
