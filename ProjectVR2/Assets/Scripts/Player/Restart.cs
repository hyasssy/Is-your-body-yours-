using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{//右手のOne,Two,ThumbStick押し込み2秒でリセット読み込み。
    float resetCount = 0;
    public string restartScemeName;
    void Reset(){
        SceneManager.LoadScene(restartScemeName);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return)||OVRInput.Get(OVRInput.Button.SecondaryThumbstick) && OVRInput.Get(OVRInput.Button.One)){
            resetCount += Time.deltaTime;
        }else{
            if(resetCount > 0){
                resetCount -= Time.deltaTime;
            }
        }
        if(resetCount > 2){
            Reset();
        }
    }
}
