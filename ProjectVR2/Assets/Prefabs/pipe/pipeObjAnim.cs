using System.Collections;
using UnityEngine;

public class pipeObjAnim : MonoBehaviour
{//destroycount + generateTime　+ 1秒で消滅。
    public float generateTime = 0.2f;
    public float destroyTime = 0.4f;
    public float destroyCount = 4;
    float count = 0;
    Vector3 priScale;
    Material pipeMaterial;
    Color color1;
    bool coroutineOn = false;
    public pipeManager pm;
    private void Start() {
        priScale = transform.localScale;
        transform.localScale = Vector3.zero;
        pipeMaterial = GetComponent<Renderer>().material;
        pipeMaterial.EnableKeyword("_EMISSION");
    }
    private void Update() {
        transform.Rotate(new Vector3((Mathf.Sin(Time.time)+1) * 60,(Mathf.Sin(Time.time + 1)+1) * 60,(Mathf.Sin(Time.time+2)+1) * 60) * Time.deltaTime / 3);
        count += Time.deltaTime;
        if(generateTime > count){
            transform.localScale = Vector3.Lerp(Vector3.zero, priScale, Mathf.Clamp01(count/generateTime));
        }
        if(count > destroyCount){
            if(!coroutineOn){
                StartCoroutine(DestroyCoroutine());
                coroutineOn = true;
            }
        }
    }
    IEnumerator DestroyCoroutine(){
        float elapsedTime = 0.0f;
		while (elapsedTime < destroyTime)
		{
			elapsedTime += Time.deltaTime;
            color1.r = Mathf.Lerp(Color.black.r,Color.white.r, Mathf.Clamp01(elapsedTime / destroyTime));
            color1.g = Mathf.Lerp(Color.black.g,Color.white.g, Mathf.Clamp01(elapsedTime / destroyTime));
            color1.b = Mathf.Lerp(Color.black.b,Color.white.b, Mathf.Clamp01(elapsedTime / destroyTime));
            pipeMaterial.SetColor("_EmissionColor", color1);

			yield return new WaitForEndOfFrame();
		}
        pm.phase = 1;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
