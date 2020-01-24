using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float range = 0.2f;
    public float speed = 2f;
    private void Update() {
        transform.position += Vector3.up * range * Mathf.Sin(Time.time * speed) / 100;
    }
}
