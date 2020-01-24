using UnityEngine;

public class mirror : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(0,0, 4-player.position.z);
    }
}
