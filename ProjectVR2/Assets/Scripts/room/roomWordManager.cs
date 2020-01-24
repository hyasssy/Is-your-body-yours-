using UnityEngine;

public class roomWordManager : MonoBehaviour
{
    [HideInInspector]public float range = 0;
    public float destroySpeed = 3f;
    private void Update() {
        range += Time.deltaTime * destroySpeed;
        if(range>90){
            Destroy(gameObject);
        }
    }
}
