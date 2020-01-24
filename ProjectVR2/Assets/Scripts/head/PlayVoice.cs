using UnityEngine;
using System.Collections.Generic;

public class PlayVoice : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>();//ここからランダムに鳴る。
    AudioSource audioSource;
    public float RTmin = 1.0f, RTmax = 3.0f;
    float count = 0;
    bool b = false;
    float play = 0;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        count += Time.deltaTime;
        if(!b){
            b = true;
            if(play != 0){//最初騒がせない
                PlaySound();
            }
            play = Random.Range(RTmin, RTmax);
        }
        if(count>play){
            b = false;
            count = 0;
        }

    }
    void PlaySound(){
        audioSource.PlayOneShot(sounds[Random.Range(0,sounds.Count-1)]);
    }
}
