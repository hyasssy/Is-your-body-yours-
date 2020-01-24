using UnityEngine;

public class ShowGuide : MonoBehaviour
{
    public Transform another;
    public Renderer anotherMesh;
    public GameObject arrow, arrow2;
    Renderer targetRenderer, mesh, mesh2;
    Vector3 primaryPosition;
    private void Start() {
        primaryPosition = transform.localPosition;
        targetRenderer = anotherMesh.GetComponent<Renderer>();
        mesh = arrow.GetComponent<Renderer>();
        mesh2 = arrow2.GetComponent<Renderer>();
    }
    private void Update() {
        if(targetRenderer.isVisible){
            mesh.enabled = false;
            mesh2.enabled = false;
            return;
        }else{
            mesh.enabled = true;
            mesh2.enabled = true;
        }
        transform.localPosition = primaryPosition;
        transform.LookAt(another);
        
        Color color = mesh.material.color;
        color.a = (Mathf.Sin(Time.time*1.5f)+1)/3;;
        mesh.material.color = color;
        mesh2.material.color = color;
    }
}