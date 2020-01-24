using UnityEngine;

public class FootSound : MonoBehaviour
{
    public AudioClip[] sounds;
    AudioSource audioSource;
    CheckSwingingArm check;
    float count = 0;
    void Start()
    {
        check = GetComponent<CheckSwingingArm>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(check.on){
            count += Time.deltaTime;
            if(count > 0.5f){
                count = 0;
                int i = Random.Range(0,sounds.Length);
                audioSource.PlayOneShot(sounds[i]);
            }
        }
    }
}
