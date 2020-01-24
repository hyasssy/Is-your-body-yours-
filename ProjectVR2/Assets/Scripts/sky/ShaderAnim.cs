using UnityEngine;
using System.Collections;

public class ShaderAnim : MonoBehaviour
{
    public float firstPose = 5;//パチパチ切り替わってる長さの調整。
    Material material;
    [System.NonSerialized] public Color[] colorSet;
    //public Color color1start, color1end;
    //public Color color2start, color2end;
    Color tempColor1;
    Color tempColor2;
    [Range(-1, 1)] public float cx;
    public float[] coefCX = {1,1};
    [Range(-1, 1)] public float cy;
    public float[] coefCY = {1,1};
    float scale = 4.5f;
    int maxIteration = 0;
    public float[] pose;
    public float scalePose, scaleSpeed = 0.015f, scalePower = 0.5f;
    public SceneTimeManager stm;
    
    private void Start() {
        material = GetComponent<Renderer>().material;
        StartCoroutine(Pose());
    }

    private void Update() {
        //tempColor1 = Color.Lerp(color1start, color1end, Mathf.Sin(Time.time));
        //tempColor2 = Color.Lerp(color2start, color2end, Mathf.Sin(Time.time));
        tempColor1 = Color.Lerp(colorSet[0], colorSet[1], Mathf.Sin(Time.time));
        tempColor2 = Color.Lerp(colorSet[2], colorSet[3], Mathf.Sin(Time.time));
        cx += Mathf.Sin(Time.time * coefCX[1]) * coefCX[0];
        cy += Mathf.Sin(Time.time * coefCY[1]) * coefCY[0];
        material.SetColor("_firstColor", tempColor1);
        material.SetColor("_secondColor", tempColor2);
        material.SetFloat("_Cx", cx);
        material.SetFloat("_Cy", cy);
        material.SetFloat("_Scale", scale);
    }
    IEnumerator IterationAnim(){//maxiteration0から20ぐらいに。scale 4.5 から0に
        
        for(int i = 0;i<pose.Length;i++){
            maxIteration++;
            material.SetInt("_MaxIteration", maxIteration);
            yield return new WaitForSeconds(pose[i]);
        }
        yield break;
    }
    
    IEnumerator ScaleAnim(){
        float count = 0;
        yield return new WaitForSeconds(scalePose);
        while(scale>0){
            yield return null;
            count += Time.deltaTime * scaleSpeed;
            scale-=count * count * scalePower;
        }
        scale = 0;
        stm.phase = 3;
    }
    IEnumerator Pose(){
        yield return　new WaitForSeconds(firstPose);
        StartCoroutine(IterationAnim());
        StartCoroutine(ScaleAnim());
    }
    
}
