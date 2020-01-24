using UnityEngine;

public class DestroyWord : MonoBehaviour
{
    roomWordManager rwm;
    public Transform manager;
    float dis;
    private void Start() {
        rwm = manager.GetComponent<roomWordManager>();
        dis = Vector3.Distance(manager.transform.position, transform.position);
    }
    private void Update() {
        if(dis < rwm.range){
            Destroy(gameObject);
        }
    }
}
