using UnityEngine;

public class CheckSwingingArm : MonoBehaviour
{
    //0.5秒（仮）ごとにチェックを設けて、ある閾値を超えたらスイッチオン、その間の加速度の平均が閾値を下回ったらオフ。
    [Tooltip("poseのフレーム数")]
    public Transform rightHand, leftHand;
    Vector3 prePosRight, prePosLeft;
    int count = 0;
    float sumGapValueRight=0, sumGapValueLeft=0;
    [Tooltip("1秒あたりの振り幅に換算した値。")]
    float onThreshhold = 0.42f;
    float offThreshhold = 0.3f;
    [HideInInspector]    public bool on = false;//腕振りチェック
    float time = 0f;
    public float checkTime = 0.04f;//この時間でサンプリングする。
    public int averageCount = 4;
    //public float threshHold = 0.4f;
    float rPower,lPower, sum, lastPower = 0;
    public float settingIntensity = 0.6f;
    [System.NonSerialized]public float power;//0.5-2
    
    private void Start() {
        prePosRight = rightHand.position;
        prePosLeft = leftHand.position;
    }

    private void FixedUpdate() {
        JudgeSwing();
        if(!OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && !OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)){
            on = false;
        }
        power = sum * sum;
        if(power > 3.7f){
            power = 3.7f;
        }
        power = (power * settingIntensity + lastPower)/2;//気持ちなだらかになってくれ
        lastPower = power;
    }
    void JudgeSwing(){
        if(count < averageCount){
            time += Time.deltaTime;
            if(time > checkTime){
                rPower = (prePosRight - rightHand.position).magnitude/time;//1秒あたりの移動量に換算
                lPower = (prePosLeft - leftHand.position).magnitude/time;
                sum = rPower + lPower;
                sumGapValueRight += rPower;
                sumGapValueLeft += lPower;
                time = 0;
                prePosRight = rightHand.position;
                prePosLeft = leftHand.position;
                count ++;
            }
        }else{
            float rAverage = sumGapValueRight / (count ++);
            float lAverage = sumGapValueLeft / (count ++);
            if(on){
                if(rAverage < offThreshhold || lAverage < offThreshhold){
                    on = false;
                }
            }else{
                if(rAverage > onThreshhold || lAverage > onThreshhold){
                    on = true;
                }
            }
            count = 0;
            sumGapValueRight = 0;
            sumGapValueLeft = 0;
        }
    }
}