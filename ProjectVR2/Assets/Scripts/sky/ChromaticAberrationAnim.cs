using UnityEngine;
using UnityEngine.SceneManagement;

public class ChromaticAberrationAnim : MonoBehaviour
{
    #region Parameter
    public CameraRenderTexture cameraRenderTexture;
    [SerializeField] float firstPose = 0.5f;
    //[Range(0f, 1f)]float redX,redY,greenX,greenY,blueX,blueY;//0-1で遷移
    [Range(-0.1f, 0.1f)]public float[] intensity;
    [Range(-2,2)][SerializeField] private float[] timeScale;
    //[SerializeField] private float[] noiseScale;
    #endregion

    public Material material;
    
    private void Update() {
        if(firstPose > 0){
            firstPose -= Time.deltaTime;
            return;
        }
        //float rx = Noise.PerlinNoise(noiseScale[0] + timeScale[0]*Time.time);
        float ry = Noise.PerlinNoise(/*noiseScale[1] + */timeScale[1]*Time.time);
        float gx = Noise.PerlinNoise(/*noiseScale[2] + */timeScale[2]*Time.time);
        //float gy = Noise.PerlinNoise(noiseScale[3] + timeScale[3]*Time.time);
        float bx = Noise.PerlinNoise(/*noiseScale[4] + */timeScale[4]*Time.time);
        //float by = Noise.PerlinNoise(noiseScale[5] + timeScale[5]*Time.time);
        //material.SetFloat("_RedX", rx * intensity[0]);
        material.SetFloat("_RedY", ry * intensity[1]);
        material.SetFloat("_GreenX", gx * intensity[2]);
        //material.SetFloat("_GreenY", gy * intensity[3]);
        material.SetFloat("_BlueX", bx * intensity[4]);
        //material.SetFloat("_BlueY", by * intensity[5]);
    }
    void SceneUnloaded(Scene thisScene){

    }
}
