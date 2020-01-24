using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    public float destroyTime;
    private void Update() {
        destroyTime -= Time.deltaTime;
        if(destroyTime<0){
            Destroy(gameObject);
        }
    }
}
