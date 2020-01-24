using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeWall : MonoBehaviour
{
    //バラバラだったキューブが集まって壁になるスクリプト
    public GameObject wallPrefab;
    public int prefabAmount;
    public Vector2 wallSaize;
    [HideInInspector]
    public bool onMaking = false;

    private void Start() {
        
    }
}
