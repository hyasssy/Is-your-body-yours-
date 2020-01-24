using UnityEngine;
using System.Collections;

public class textAnimation : MonoBehaviour
{
    [TextArea(1,6)]
    public string passage1, passage2;
    string targetText;
    public TextMesh tm;
    [Tooltip("1 letter / speed second")] public float speed;
    public bool on = true;
    bool b = true;
    bool coroutineOn = false;
    [HideInInspector]    public bool done = false;

    private void Update() {
        if(!coroutineOn&&on){
            StartCoroutine(TextAnim(passage1));
            coroutineOn = true;
        }
    }
    
    IEnumerator TextAnim(string text){
        int letterCount = 0;
        while(true){
            yield return new WaitForSeconds(speed);
            tm.text += text[letterCount];
            letterCount++;
            if(letterCount >= text.Length){
                break;
            }
        }
        yield return new WaitForSeconds(5);
        while(true){
            yield return new WaitForSeconds(speed);
            tm.text = tm.text.Substring(1);
            letterCount--;
            if(tm.text.Length == 0){
                break;
            }
        }
        if(b){
            StartCoroutine(TextAnim(passage2));
        }else{
            done = true;
            yield break;
        }
        b = false;
    }
}
