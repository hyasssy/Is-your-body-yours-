using UnityEngine;

public class GuideText : MonoBehaviour
{
    public GameObject textObj;
    TextMesh text;
    public string text1,text2;
    private void Start() {
        text = textObj.GetComponent<TextMesh>();
        text.text = text1;
    }
    float time = 0;
    
    private void Update() {
        time += Time.deltaTime;
        if(time < 5){
            text.text = text1;
        }else if(time<10){
            text.text = text2;
        }else{
            Destroy(textObj);
            this.enabled = false;
        }
        
    }
}
