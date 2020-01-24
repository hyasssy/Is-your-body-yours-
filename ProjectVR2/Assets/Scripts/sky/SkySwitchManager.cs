using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySwitchManager : MonoBehaviour
{//flashlengthの間空パチパチ切り替わる。
    public GameObject fractalSkyPrefab;
    //public List<Color> colors = new List<Color>();
    public Color[] colorSet1, colorSet2, colorSet3, colorSet4;
    public float firstPose = 5f, flashLength = 10f;
    //Color nextSolidColor;
    ShaderAnim anim;
    Renderer renderer;
    MeshRenderer mesh;
    private void Start() {
        anim = fractalSkyPrefab.GetComponent<ShaderAnim>();
        anim.colorSet = colorSet1;
        mesh = fractalSkyPrefab.GetComponent<MeshRenderer>();
        //renderer = fractalSkyPrefab.GetComponent<Renderer>();
        //fractalSkyPrefab.GetComponent<MeshRenderer>().enabled = true;
        //renderer.enabled = true;
        StartCoroutine(ShortNoise());
    }
    void SwitchSky(int i){
        switch(i){
            case 0 :
            mesh.enabled = false;
            
            break;
            case 1 :
            
            int n = Random.Range(0,4);
            switch(n){
                case 0:
                anim.colorSet = colorSet1;
                mesh.enabled = true;
                break;
                case 1:
                anim.colorSet = colorSet2;
                mesh.enabled = true;
                break;
                case 2:
                anim.colorSet = colorSet3;
                mesh.enabled = true;
                break;
                case 3:
                anim.colorSet = colorSet4;
                mesh.enabled = true;
                break;
                default:break;
            }
            break;
            default : break;
        }
    }


    IEnumerator ShortNoise(){
        yield return new WaitForSeconds(firstPose);
        SwitchSky(1);
        yield return new WaitForSeconds(0.3f);
        SwitchSky(0);
        yield return new WaitForSeconds(0.7f);
        SwitchSky(1);
        yield return new WaitForSeconds(0.4f);
        SwitchSky(0);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(RandomPose());
    }
    IEnumerator RandomPose(){
        float time = Time.time;
        while(true){
            yield return new WaitForSeconds(Random.Range(0f,2f));
            SwitchSky(Random.Range(0,2));
            if(Time.time-time > flashLength){
                anim.colorSet = colorSet1;
                mesh.enabled = true;
                yield break;
            }
        }
    }
}
