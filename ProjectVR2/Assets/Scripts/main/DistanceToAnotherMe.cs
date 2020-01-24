using UnityEngine;
using System.Collections;

using RootMotion.FinalIK;

public class DistanceToAnotherMe : MonoBehaviour
{
    public Transform player;
    public VRIK ik;
    Vector3 vec;
    float dis;
    public float getFarSpeed, getCloseSpeed;
    public float maxDistance = 10f;
    public SceneTimeManager tm;
    float count = 0f;
    public float accelerateSpeed = 6f, decreaseSpeed = 0.03f;
    public float intensity = 2f;
    public float minPower = 0.1f;//最低回転速度
    public float playTimeWithAnotherInRoom = 3f;
    float power;
    [Range(-1,1)]public float x = -1,y=0,z=1;
    private Vector3 lastPosition;
	private Quaternion lastRotation = Quaternion.identity;
    private void OnEnable() {
        StartCoroutine(RepresentSelf());
    }
    private void LateUpdate() {
        if(!start){
            return;
        }
        lastPosition = transform.position;
        lastRotation = transform.rotation;
        count += Time.deltaTime;
        if(count < accelerateSpeed){
            power = Mathf.Clamp01(count * count / accelerateSpeed / accelerateSpeed);
        }else{
            if(power > minPower){
                power -= Time.deltaTime * decreaseSpeed;
            }
        }
        Vector3 targetRotation = new Vector3(x,y,z) * power * intensity;
        transform.Rotate(targetRotation);

        vec = transform.position - player.position;
        dis = vec.magnitude;
        

        if(tm.phase < 3 && dis < maxDistance){
            transform.position += Vector3.Scale(vec.normalized, new Vector3(1,0,1)) * (maxDistance - dis) * Time.deltaTime * power * getFarSpeed;
        }else{
        }
        ik.solver.AddPlatformMotion (transform.position - lastPosition, transform.rotation * Quaternion.Inverse(lastRotation), transform.position);
    }

    float copyTime = 6f, slideSpeed = 0.4f;
    bool start = false;
    IEnumerator RepresentSelf(){
        transform.position = player.position;
        transform.rotation = player.rotation;
        float time = 0;
        while(time < copyTime){
            yield return null;
            time += Time.deltaTime;
            lastPosition = transform.position;
            lastRotation = transform.rotation;
            transform.position -= Vector3.right * Mathf.Sin(time/copyTime*Mathf.PI) * Time.deltaTime * slideSpeed;
            ik.solver.AddPlatformMotion (transform.position - lastPosition, transform.rotation * Quaternion.Inverse(lastRotation), transform.position);
        }
        yield return new WaitForSeconds(playTimeWithAnotherInRoom);
        tm.phase = 1;
        start = true;
    }
}
