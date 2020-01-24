using System.Collections;
using UnityEngine;

public class WaitAndPlay : MonoBehaviour
{//AudioSourceのあるオブジェに
    public AudioClip clip;
    public float pose = 5;
    AudioSource audioSource;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PoseAndPlay());
    }
    IEnumerator PoseAndPlay(){
        yield return new WaitForSeconds(pose);
        audioSource.PlayOneShot(clip);
    }
}
