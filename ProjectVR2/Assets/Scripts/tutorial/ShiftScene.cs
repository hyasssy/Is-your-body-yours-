using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class ShiftScene : MonoBehaviour
{
    float count = 0;
    public string sceneName;
    public float pose = 10f;
    bool coroutineOn = false;
    public float fadeTime = 2.0f;
    public TextMesh[] ui;
    public GameObject[] destroyUIs;
    Camera cam;
    public CheckSwingingArm csa;
    public TextMesh text;
    private void Start() {
        cam = Camera.main;
    }
    private void Update() {
        if(csa.on || Input.GetKey(KeyCode.C)){
            count += Time.deltaTime;
        }
        int i = Mathf.FloorToInt(count / pose * 100);
        i = Mathf.Clamp(i,0,100);
        text.text = i.ToString();
        if(count > pose && !coroutineOn){
            for(int n=0;n<destroyUIs.Length;n++){
                destroyUIs[n].SetActive(false);
            }
            StartCoroutine(Becoming());
            StartCoroutine(Fade());
            coroutineOn = true;
        }
    }
    public Transform another, player;
    IEnumerator Becoming(){
        float f = 0f;//time
        float approachTime = 5f;
        Vector3 priPos = another.position;
        while(f < approachTime){
            f += Time.deltaTime;
            another.position = Vector3.Lerp(priPos, player.position, Mathf.Sin(f / approachTime * Mathf.PI/2));
            yield return null;
        }
        another.position = player.position;
        yield break;
    }
    IEnumerator Fade()
	{
		float elapsedTime = 0.0f;
        Color bc = cam.backgroundColor;
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
            Color color = cam.backgroundColor;
            color.r = Mathf.Lerp(bc.r,Color.white.r, Mathf.Clamp01(elapsedTime / fadeTime));
            color.g = Mathf.Lerp(bc.g,Color.white.g, Mathf.Clamp01(elapsedTime / fadeTime));
            color.b = Mathf.Lerp(bc.b,Color.white.b, Mathf.Clamp01(elapsedTime / fadeTime));
            cam.backgroundColor = color;
            Color uiColor = ui[0].color;
            uiColor.a = Mathf.Lerp(1,0, Mathf.Clamp01(elapsedTime / fadeTime));
            for(int n=0;n<ui.Length;n++){
                ui[n].color = uiColor;
            }
			yield return new WaitForEndOfFrame();
		}
        SceneManager.LoadScene(sceneName);
	}
}
