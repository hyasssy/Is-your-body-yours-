using UnityEngine;

public class LoadingAnim : MonoBehaviour
{
    TextMesh text;
    float time = 0;
    float pose = 0.7f;
    int i =0;
    [HideInInspector]    public string s;
    void Start()
    {
        text = GetComponent<TextMesh>();
        s = text.text;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(time >= pose){
            if(i < 3){
                text.text += ".";
                i++;
            }else{
                text.text = s;
                i=0;
            }
            time = 0;
        }
    }
}
