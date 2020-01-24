using UnityEngine;

public class MoveBasic : MonoBehaviour
{
    //キャラWASDで前後の動き＋回転
    //デバッグパーツWASDで前後左右、EFで上下    1:head 2:right 3:left Space : reset
    float moveSpeed = 0.8f;
    public float rotateSpeed = 1f;
    float count = 0;
    float accelerationTime = 2;
    public Transform root, head, right, left;
    bool onVR;
    bool b = true;

    [Tooltip("デバッグ時の最初の腕の位置を補正します。")]
    public Vector3 RHPos = new Vector3(0.3f, -0.57f, -0.013f), RHRot = new Vector3(37.684f, 31.013f, 54.033f);
    public Vector3 LHPos = new Vector3(-0.3f, -0.57f, -0.013f), LHRot = new Vector3(37.684f, -31.013f, -54.033f);
    public CheckSwingingArm csa;
    public bool onMainScene = false;


    private void Awake() {
        onVR = FindObjectOfType<CheckVR>().onVR;
    }
    private void Start() {
        if(!onVR){
            right.localPosition = RHPos;
            right.localEulerAngles = RHRot;
            left.localPosition = LHPos;
            left.localEulerAngles = LHRot;
        }
    }
    private void FixedUpdate() {
        if(onVR){
            moveToward(csa.on && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)||OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger));
        }else{
            moveCharaOnDebug();
            moveParts(head, "1");
            moveParts(right, "2");
            moveParts(left, "3");
            if(Input.GetKeyDown(KeyCode.Space)){
                head.localPosition = Vector3.zero;
                right.localPosition = RHPos;
                left.localPosition = LHPos;
            }
        }
    }
    void moveToward(bool b){
        if(b){
            if(count < accelerationTime){
                count += Time.fixedDeltaTime;
            }
        }else{
            if(count > Time.deltaTime){
                count -= Time.fixedDeltaTime;
            }else{
                count = 0;
            }
        }
        if(count>0){
            if(onMainScene){
                transform.localPosition += root.forward * moveSpeed * Time.fixedDeltaTime * count / accelerationTime * csa.power * 2 / 3;//もし上下に移動始めそうな場合はここチェック。
            }else{
                transform.localPosition += root.forward * moveSpeed * Time.fixedDeltaTime * count / accelerationTime * csa.power;
            }
        }
    }
    void moveCharaOnDebug(){//移動は前後のみ　左右で回転
        if(b){//他のパーツが動いてないかチェックする
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.localPosition += root.forward * v * moveSpeed * Time.fixedDeltaTime;
            transform.Rotate(0, h * rotateSpeed * Time.fixedDeltaTime, 0);
        }
    }
    void moveParts(Transform target, string key){
        if(Input.GetKey(key)){
            if(b){
                b = false;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            float y = 0;
            if(Input.GetKey(KeyCode.E)){
                y ++;
            }
            if(Input.GetKey(KeyCode.F)){
                y --;
            }
            target.localPosition += target.forward * z * moveSpeed/2 * Time.fixedDeltaTime + target.right * x * moveSpeed/2 * Time.fixedDeltaTime + target.up * y * moveSpeed/2 * Time.fixedDeltaTime;
        }else{
            if(!b){
                b = true;
            }
        }
    }
}
