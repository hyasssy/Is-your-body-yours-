using UnityEngine;
using System.Collections;

public class EndManager : MonoBehaviour
{
    public float startPose = 5f, pose = 3f, displaytime = 5f;
    public GameObject ui;
    public textAnimation anim;
    public TextMesh text;
    bool b = true, a = true;
    void Update()
    {
        if(startPose > 0f){
            startPose -= Time.deltaTime;
            return;
        }else if(a){
            a = false;
            ui.SetActive(true);
        }
        if(pose > 0){
            pose -= Time.deltaTime;
        }else if(b){
            anim.on = true;
            b = false;
        }else if(anim.done){
            if(!coroutineOn){
                StartCoroutine(PoseCoroutine());
            }
            if(anim.tm.text.Length < 2){
                anim.enabled = false;
                text.text = "_end";
            }
        }
    }
    bool coroutineOn = false;
    IEnumerator PoseCoroutine(){
        coroutineOn = true;
        anim.enabled = false;
        yield return new WaitForSeconds(displaytime);
        anim.enabled = true;
    }
}

