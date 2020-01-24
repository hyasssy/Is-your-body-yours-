using UnityEngine;

public class HideDuringPlay : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(false);
    }
}
