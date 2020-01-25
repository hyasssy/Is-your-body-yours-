using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPosition : MonoBehaviour
{
    public Transform top, bottom;
    Vector3 gapVec;
    Vector3 centor;
    void Start()
    {
        gapVec = top.position - bottom.position;
        centor = top.position - gapVec / 2;
        transform.position = centor;
        float axis = Vector3.Angle(Vector3.up, gapVec);
        transform.eulerAngles = new Vector3(0,0,-axis);

    }
}
