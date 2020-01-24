using UnityEngine;

public class EndAnotherPrefab : MonoBehaviour
{
    Vector3 vec;
    private void Start() {
        vec = new Vector3(Random.Range(-0.5f,0.5f),Random.Range(-0.5f,0.5f),Random.Range(-0.5f,0.5f));
    }
    private void Update() {
        transform.position += vec * Time.deltaTime;
    }
}
