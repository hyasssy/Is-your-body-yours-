using UnityEngine;

public class pipeManager : MonoBehaviour
{
    public GameObject pipeObj, pipePaint, code;
    [HideInInspector]
    public int phase = 0;//0:obj, 1:paint, 2:code and destroy
    bool phase1 = false;
    bool phase2 = false;
    
    void Start()
    {
        pipeObj.SetActive(true);
    }
    void Update()
    {
        if(phase == 1 && !phase1){
            pipePaint.SetActive(true);
            pipePaint.transform.LookAt(Camera.main.transform);
            pipePaint.transform.localEulerAngles += new Vector3(90,0,0);
            phase1 = true;
        }
        if(phase == 2 && !phase2){
            code.SetActive(true);
            code.transform.LookAt(Camera.main.transform);
            phase2 = true;
        }
    }
}
