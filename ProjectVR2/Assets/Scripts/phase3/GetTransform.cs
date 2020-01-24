using UnityEngine;

public class GetTransform : MonoBehaviour
{
    public Transform player;
    public GameObject another;
    void Start()
    {
        another.SetActive(true);
        Deliver d = FindObjectOfType<Deliver>();
        player.position = d.playerPos;
        player.rotation = d.playerRot;
        another.transform.position = d.anotherPos;
        another.transform.rotation = d.anotherRot;
    }
}
