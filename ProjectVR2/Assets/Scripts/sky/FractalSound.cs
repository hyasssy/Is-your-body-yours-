using System.Collections;
using UnityEngine;

public class FractalSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clip;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Coroutine());
    }
    IEnumerator Coroutine(){
        yield return new WaitForSeconds(7f);
        print("yes");
        audioSource.PlayOneShot(clip);
    }
}
