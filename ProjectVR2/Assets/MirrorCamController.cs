using UnityEngine;

public class MirrorCamController : MonoBehaviour
{
    Transform player;
    private void Start() {
        player = Camera.main.transform;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y,transform.position.z);
    }
}
