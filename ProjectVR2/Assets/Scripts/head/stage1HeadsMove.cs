using UnityEngine;

public class stage1HeadsMove : MonoBehaviour
{/*
最初同じ場所に全部出して、startで散らばす。最初の場所を起点に部屋のサイズ設定
頭prefabに当てる。
動き回ったり止まったりする。

余裕があったら加速度にする。ふわふわさす。
*/
    [Tooltip("Room Range")]public Vector3 maxR, minR;
    [Tooltip("他の頭をここに。")]
    SceneTimeManager stm;
    public GameObject[] heads;
    public GameObject kaoObjPrefab;
    Transform target;
    public float RTmin = 1f, RTmax = 5f;
    float time = 0;
    float count = 0;
    bool b = false;//動くのと止まるののカウント用 false:stop true:go
    public float rotateSpeed = 3.0f;
    Quaternion targetRotation;
    Vector3 randomPlace, temp, zeroPoint;
    bool go = false;
    float randompose, randomcount = 0;
    private void Start() {
        stm = FindObjectOfType<SceneTimeManager>();
        zeroPoint = transform.position;
        StopSet();

        randompose = Random.Range(1,5);
    }
    private void Update() {
        if(stm.phase == 1){
            go = true;
        }else{
            if(!go){
                return;
            }else{
                if(stm.phase == 3){
                    if(randomcount < randompose){
                        randomcount += Time.deltaTime;
                    }else{
                        Instantiate(kaoObjPrefab,transform.position,Quaternion.identity);
                        Destroy(gameObject);
                    }
                }
            }
        }
        //bがtrueの時動く　falseの時止まる　count が time を越した時bスイッチ、time とcountリセット、ターゲットセッティング
        //RorA R:wander, A:approach or stare
        if(!b){
            if(count < time){
                count += Time.deltaTime;
                Stare();
            }else{
                StartSet();
            }
        }
        if(b){
            if(count < time){
                count += Time.deltaTime;
                Move();
            }else{
                StopSet();
            }
        }
    }

    void StartSet(){
        randomPlace = zeroPoint + new Vector3(Random.Range(minR.x, maxR.x), Random.Range(minR.y, maxR.y), Random.Range(minR.z, maxR.z));
        time = Random.Range(RTmin, RTmax);
        count = 0;
        b = true;
        temp = transform.position;
    }

    void StopSet(){
        int n = Random.Range(0, heads.Length - 1);
        target = heads[n].transform;
        time = Random.Range(RTmin, RTmax);
        count = 0;
        b = false;
    }

    void Move(){
        float current = count/time;
        transform.position = Vector3.Lerp(temp, randomPlace, current);
        targetRotation = Quaternion.LookRotation (randomPlace - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    void Stare(){
        targetRotation = Quaternion.LookRotation (target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    void Clamp(){//ここまだ使わない
        var pos = transform.localPosition;
        pos.x = Mathf.Clamp(pos.x, minR.x, maxR.x);
        pos.y = Mathf.Clamp(pos.y, minR.y, maxR.y);
        pos.z = Mathf.Clamp(pos.z, minR.z, maxR.z);
        transform.localPosition = pos;
    }
}
