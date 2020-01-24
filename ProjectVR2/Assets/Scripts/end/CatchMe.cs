using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class CatchMe : MonoBehaviour
{
    public GameObject player;
    float timeCount = 0;
    public float getFarTime, maxDistance, minDistance;
    public float getFarSpeed, getCloseSpeed;
    public ChromaticAberrationAnim camanager;
    public CameraRenderTexture crt;
    Vector3 currentVec;
    bool one = true;
    float speed = 1;
    private void Update() {
        currentVec = transform.position - player.transform.position;
        timeCount += Time.deltaTime;
        if(getFarTime>timeCount){
            if(currentVec.magnitude < maxDistance){
                transform.position += Vector3.Scale(currentVec, new Vector3(1,0,1)).normalized * getFarSpeed * Time.deltaTime;
            }
            if(currentVec.magnitude < minDistance){
                transform.position += currentVec.normalized * (minDistance - currentVec.magnitude);
            }
        }else{
            if(currentVec.magnitude > minDistance){
                transform.position -= currentVec.normalized * getCloseSpeed * Time.deltaTime * speed;
            }else{
                if(one){
                    camanager.enabled = true;
                    crt.enabled = true;
                    player.GetComponent<MoveBasic>().enabled = false;
                    StartCoroutine(Fade());
                    one = false;
                }
            }
        }
        if(timeCount > getFarTime * 3){
            speed = 6f;
        }else if(timeCount > getFarTime * 2.5f){
            speed = 4f;
        }else if(timeCount > getFarTime * 2){
            speed = 3f;
        }else if(timeCount > getFarTime * 1.5){
            speed = 2f;
        }else if(timeCount > getFarTime * 1.3f){
            speed = 1.5f;
        }
    }
    public AudioClip clip;
    AudioSource audioSource;
    [Tooltip("Fade用のPlaneあててね")]    public GameObject fade;
    public string sceneName;
    public float fadeTime = 2.0f;
    IEnumerator Fade()//暗転
	{
        AudioSource[] audio = FindObjectsOfType<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(2f);
        GetComponent<RotateAroundPlayer>().enabled = false;
        GetComponent<Phase3Another>().enabled = false;
        Vector3 primaryPos = transform.position;
        Quaternion primaryRot = transform.rotation;
        float setPosTime = 3f;
        float timeCount = 0;
        while(timeCount < setPosTime){
            timeCount += Time.deltaTime;
            transform.position = Vector3.Lerp(primaryPos, player.transform.position, timeCount/setPosTime);
            transform.rotation = Quaternion.Lerp(primaryRot, player.transform.rotation, timeCount/setPosTime);
            yield return null;
        }
        Renderer fadeMat = fade.GetComponent<Renderer>();
		float elapsedTime = 0.0f;
        fade.SetActive(true);
        
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
            Color color = fadeMat.material.color;
            color.a = Mathf.Lerp(0,1,Mathf.Clamp01(elapsedTime / fadeTime));
            fadeMat.material.color = color;
            for(int i=0;i<audio.Length;i++){
                audio[i].volume = 1 - elapsedTime/fadeTime;
            }
			yield return new WaitForEndOfFrame();
		}
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
	}
}
