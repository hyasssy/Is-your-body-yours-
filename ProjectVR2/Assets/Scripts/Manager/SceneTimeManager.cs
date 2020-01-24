using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimeManager : MonoBehaviour
{
    [Tooltip("0:Start,1:ExpandRoom,2:FloatingPipeFace,3:AutoStrSky,4:GetMyself")]
    public int phase = 0;
    public GameObject skySwitchManager;//generateStructure, 
    bool p2 = false;
    bool p3 = false;
    public GameObject guideArrow;
    private void Update() {
        switch(phase){
            case 0://ちょっと待ってphase1に移行。もう一人の自分の存在を認識。
            break;
            case 1://部屋が離散して無重力。
            break;
            case 2://部屋がなくなったら2。ノイズみたいに空、顔がパチパチ入れ替わる。
            Case2();
            break;
            case 3://phase3シーンに
            Case3();
            break;
            default:break;
        }
    }


    void Case2(){
        if(!p2){
            p2 = true;
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            guideArrow.SetActive(true);
            skySwitchManager.SetActive(true);
        }
    }
    public string phase3SceneName;
    public GameObject deliver;
    [SerializeField]Transform player, another;
    void Case3(){
        if(!p3){
            p3 = true;
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
            Deliver d = deliver.GetComponent<Deliver>();
            d.playerPos = player.position;
            d.anotherPos = another.position;
            d.playerRot = player.rotation;
            d.anotherRot = another.rotation;
            SceneManager.LoadScene(phase3SceneName);
        }
    }
}