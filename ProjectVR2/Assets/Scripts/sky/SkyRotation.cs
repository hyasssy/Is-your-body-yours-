using UnityEngine;

public class SkyRotation : MonoBehaviour
{
    [Range(0.01f,0.1f)]public float rotateSpeed = 0.015f;
    float rotationRepeatValue;
    Material sky;

    private void Start() {
        sky = RenderSettings.skybox;
    }

    void Update()
    {
        rotationRepeatValue = Mathf.Repeat(sky.GetFloat("_Rotation") + rotateSpeed , 360f);
        sky.SetFloat("_Rotation",rotationRepeatValue);
    }
}
