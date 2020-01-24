using UnityEngine;

public class poleManager : MonoBehaviour
{
    public GameObject prefab;
    [HideInInspector]public int amount = 0;
    public int maxamount = 500;
    [HideInInspector]public bool on = false;
    void Start()
    {
        Instantiate(prefab);
    }
}
