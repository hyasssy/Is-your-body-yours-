using UnityEngine;

public class roomCollider : MonoBehaviour
{//部屋の範囲を制限
    public Transform player, center;
    public Vector3 minSize, maxSize;
    float minx, maxx, minz, maxz;
    private void Start() {
        minx = center.position.x + minSize.x;
        maxx = center.position.x + maxSize.x;
        minz = center.position.z + minSize.z;
        maxz = center.position.z + maxSize.z;
    }
    private void Update() {
        player.position = new Vector3(Mathf.Clamp(player.position.x, minx, maxx), player.position.y, Mathf.Clamp(player.position.z, minz, maxz));
    }
}
