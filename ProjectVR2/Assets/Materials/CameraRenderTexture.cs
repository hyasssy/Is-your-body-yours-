using UnityEngine;

[ExecuteInEditMode]
public class CameraRenderTexture : MonoBehaviour
{
    public Material material;
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
