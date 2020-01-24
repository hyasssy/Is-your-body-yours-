using UnityEngine;

public class Deliver : MonoBehaviour
{
    [System.NonSerialized]public Vector3 playerPos,anotherPos;
    [System.NonSerialized]public Quaternion playerRot, anotherRot;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
