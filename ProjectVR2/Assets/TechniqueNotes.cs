
    //別スクリプトの情報取得
    namespace note{/*スクリプト変数作成->Startで取得
    Ex
    TestScript ts//TestScript型の変数作成
    Start(){
        ts = FindObjectOfType<TestScript>();//これでscript取得までできてる
    }
    ts.変数で値取得変更できる。*publicとかreadonly設定を忘れないこと
    startで一発取得でいいならスクリプト型の変数は不要
    */}

    //回転系


    //UniStorm：リアルな天候変化＄40
    

    //オートムーブメモ
    namespace note{/*SwitchAnotherMe sam;
    float speed = 0.01f, rotateSpeed = 0.3f;
    bool start = false;
    float moveCount = 0, rotCount = 0, nextMove, nextRot;
    public Transform root;
    //public Transform player, head, right,left;
    private void Start() {
        sam = FindObjectOfType<SwitchAnotherMe>();
    }
    IEnumerator AutoMove(){
        float timeLength = Random.Range(1,5);
        float hor = Random.Range(-1,1), ver = Random.Range(-1,1);
        for(float f = 0; f <= timeLength; f += Time.deltaTime){
            transform.position += root.forward * ver * speed + root.right * hor *speed;
            yield return null; 
        }
        yield break;
    }

    IEnumerator AutoRot(){
        float timeLength = Random.Range(1,7);
        float verValue = Random.Range(-1,1);
        float rotValue = Random.Range(-1,1);
        for(float f = 0; f <= timeLength; f += Time.deltaTime){
            transform.eulerAngles -= root.right * verValue * rotateSpeed;
            transform.eulerAngles -= root.forward * rotValue * rotateSpeed;
            yield return null; 
        }
        yield break;
    }
    void LateUpdate()
    {
        if(sam.anotherOn){
            if(!start){
                start = true;
                GetComponent<Controller>().enabled = false;
                GetComponent<changeGravityDirection>().enabled = false;
                nextRot = Random.Range(1,7);
                nextMove = Random.Range(1,7);
            }
            moveCount += Time.deltaTime;
            rotCount += Time.deltaTime;
            if(rotCount > nextRot){
                rotCount = 0;
                nextRot = Random.Range(2,6);
                StartCoroutine("AutoRot");
            }
            if(moveCount > nextMove){
                moveCount = 0;
                nextMove = Random.Range(3,10);
                StartCoroutine("AutoMove");
            }
            if(transform.position.magnitude > 4){
                transform.position *= 0.999f;
            }
        }
    }

    オートムーブメモここまで
    */}


    //テキスト消しヒント
    namespace note{/*
public class DestroyIt : MonoBehaviour
{
    SwitchAnotherMe sam;
    TextMesh target;
    public Transform face, knob;
    Vector3 lastPos;
    float count = 0;
    bool start = false;
    void Start() {
        sam = FindObjectOfType<SwitchAnotherMe>();
        lastPos = face.position;
        target = GetComponent<TextMesh>();
    }
    void Update()
    {
        if(!start){
            count+=Time.deltaTime;
            if(count > 20){
                start = true;
                count = 0;
            }
        }else if(!sam.anotherOn){
            float lastDis = (knob.position - lastPos).magnitude;
            float tmpDis = (knob.position - face.position).magnitude;
            if(lastDis > tmpDis){
                target.text = "ドアに近づいている気がする\nGetting closer to the door";
            }else if(lastDis < tmpDis){
                target.text = "ドアから遠ざかっている気がする\nGetting far away from the door";
            }
            lastPos = face.position;
        }
        if(sam.anotherOn){
            target.text = "_";
            count += Time.deltaTime;
            if(count > 80){
                Destroy(gameObject);   
            }else if (count > 40){
                target.text = "trigger : Switch the view";
            }else if(count > 20){
                target.text = "自分のことをコントロールできていたのは\nいつまでだろう";
            }
        }
    }
}*/}
    //テキスト出すヒント
    namespace note{/*public class GuideText : MonoBehaviour
{
    TextMesh target;
    Vector3 lastPos;
    float count = 0;
    bool start = false;
    void Start() {
        sam = FindObjectOfType<SwitchAnotherMe>();
        lastPos = face.position;
        target = GetComponent<TextMesh>();
    }
    void Update()
    {
        if(!start){
            count+=Time.deltaTime;
            if(count > 20){
                start = true;
                count = 0;
            }
        }else if(!sam.anotherOn){
            float lastDis = (knob.position - lastPos).magnitude;
            float tmpDis = (knob.position - face.position).magnitude;
            if(lastDis > tmpDis){
                target.text = "ドアに近づいている気がする\nGetting closer to the door";
            }else if(lastDis < tmpDis){
                target.text = "ドアから遠ざかっている気がする\nGetting far away from the door";
            }
            lastPos = face.position;
        }
        if(sam.anotherOn){
            target.text = "_";
            count += Time.deltaTime;
            if(count > 80){
                Destroy(gameObject);   
            }else if (count > 40){
                target.text = "trigger : Switch the view";
            }else if(count > 20){
                target.text = "自分のことをコントロールできていたのは\nいつまでだろう";
            }
        }
    }
}*/}


    //自分の動き出す（もう一人自分作るとか動きコピるときのやり方）
    namespace note{/*public class targetTransform : MonoBehaviour
{
    //localPositionだせばそれでよかった・・・！まじか！
    public Transform head, right, left;
    //CenterEyeAnchor, RightHandAnchor, LeftHandAnchorをそれぞれアタッチ
}*/}


    //重力操作
    namespace note{/*using System.Collections.Generic;
using UnityEngine;

public class changeGravityDirection : MonoBehaviour
{
    //xとzで回転できればいい。
    public List<string> key;
    float rotateSpeed = 0.7f;
    float accelerateTime = 1f;
    float tu=0,td=0,tl=0,tr=0;
    float inputX,inputZ;
    Vector2 inputVec;
    float[] count = new float[2];
    bool onVR;
    SwitchVR svr;
    public Transform face;
    void Awake() {
        count[0]=0;count[1]=0;    
    }
    private void Start() {
        svr = FindObjectOfType<SwitchVR>();
        onVR = svr.onVR;
    }
    void Update()
    {
        if(!onVR){
            (tu,td,inputX) = Acceralate(key[0], key[2], tu, td, inputX);
            (tl,tr,inputZ) = Acceralate(key[1], key[3], tl, tr, inputZ);
            if(tu+td+tl+tr!=0){
                transform.eulerAngles -= face.right * inputX * rotateSpeed;
                transform.eulerAngles -= face.forward * inputZ * rotateSpeed;
            }
        }else{
            inputVec = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            //-1 <= count[] <= 1 countの絶対値とinputVecをかけて速度と方向を出す
            if(inputVec.y > 0.3f){
                if(count[0] < accelerateTime){
                    count[0] += Time.deltaTime;
                }
            }else if(inputVec.y < -0.3f){
                if(count[0] > -accelerateTime){
                    count[0] -= Time.deltaTime;
                }
            }else{
                if(count[0]>0){
                    count[0] -= Time.deltaTime;
                }else if(count[0]<0){
                    count[0] += Time.deltaTime;
                }
                if(Mathf.Abs(count[0])<=Time.deltaTime){
                    count[0] = 0;
                }
            }

            if(inputVec.x > 0.3f){
                if(count[1] < accelerateTime){
                    count[1] += Time.deltaTime;
                }
            }else if(inputVec.x < -0.3f){
                if(count[1] > -accelerateTime){
                    count[1] -= Time.deltaTime;
                }
            }else{
                if(count[1]>0){
                    count[1] -= Time.deltaTime;
                }else if(count[1]<0){
                    count[1] += Time.deltaTime;
                }
                if(Mathf.Abs(count[1])<=Time.deltaTime){
                    count[1] = 0;
                }
            }

            float verticalValue = inputVec.y * rotateSpeed * Mathf.Abs(count[0])/accelerateTime;
            float rotateValue = inputVec.x * rotateSpeed * Mathf.Abs(count[1])/accelerateTime;
            transform.eulerAngles -= face.right * verticalValue;
            transform.eulerAngles -= face.forward * rotateValue;
        }
    }

    private (float count1, float count2, float amount) Acceralate(string key1, string key2, float count1, float count2, float amount){
       if(Input.GetKey(key1) && Input.GetKey(key2)){
           if(count1 > 0){
               count1 -= Time.deltaTime;
           }else{
               count1 = 0;
           }
           if(count2 > 0){
               count2 -= Time.deltaTime;
           }else{
               count2 = 0;
           }
       }
       if(Input.GetKey(key1)){
           if(count1 < accelerateTime){
               count1 += Time.deltaTime;
           }
       } else {
           if(count1 > 0){
               count1 -= Time.deltaTime;
           }else{
               count1 = 0;
           }
       }
       if(Input.GetKey(key2)){
           if(count2 < accelerateTime){
               count2 += Time.deltaTime;
           }
       } else {
           if(count2 > 0){
               count2 -= Time.deltaTime;
           }else{
               count2 = 0;
           }
       }
       amount = count1 / accelerateTime - count2 / accelerateTime;
       float[] array = {count1, count2, amount};
       return (count1, count2, amount);
   }
}
重力操作ここまで
*/}






