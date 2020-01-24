using System.Collections;
using UnityEngine;

public class PipePaintDissolve : MonoBehaviour
{
    public float pose = 4;
    Material m_Material;

    void Start () {
        m_Material = GetComponent<Renderer>().material;

        StartCoroutine(Animate());
    }
    IEnumerator Animate() {
        yield return new WaitForSeconds(pose);
        float duration = 5f;
        for(float t = 0;t<duration;t += Time.deltaTime){
            yield return null;
            m_Material.SetFloat("_CutOff", Mathf.Clamp01(t / duration));
        }

    }
}
