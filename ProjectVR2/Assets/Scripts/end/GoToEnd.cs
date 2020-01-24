using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToEnd : MonoBehaviour
{
    [Tooltip("Fade用のPlaneあててね")]    public GameObject fade;
    public string sceneName;
    bool coroutineOn = false;
    public float fadeTime = 2.0f;
    private void Start() {
        fade.SetActive(true);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()//暗転
	{
        Renderer fadeMat = fade.GetComponent<Renderer>();
		float elapsedTime = 0.0f;
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
            Color color = fadeMat.material.color;
            color.a = Mathf.Lerp(0,1,Mathf.Clamp01(elapsedTime / fadeTime));
            fadeMat.material.color = color;
			yield return new WaitForEndOfFrame();
		}
        SceneManager.LoadScene(sceneName);
	}
}
