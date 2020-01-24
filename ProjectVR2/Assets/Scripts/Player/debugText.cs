using UnityEngine;
using UnityEngine.UI;

public class debugText : MonoBehaviour
{
    //Application.logMessageReceived はログを出力した時に呼び出されるイベントハンドラ　引数は1.string ログの文字 2.string スタックとレース　3.ログのタイプ
    Text text;
    float time;

    private void Awake() {
        text = GetComponent<Text>();
        Application.logMessageReceived += OnLogMessage;//ここで多分コールバック関数を登録しているということなのだろう。
    }
    void OnDestroy(){
        Application.logMessageReceived += OnLogMessage;
    }
    void OnLogMessage(string i_logText, string i_stackTrace, LogType i_type){
        if(string.IsNullOrEmpty(i_logText)){
            return;
        }
        switch( i_type )
    {
        case LogType.Error:
        case LogType.Assert:
        case LogType.Exception:
            i_logText += System.Environment.NewLine + i_stackTrace;
            i_logText = string.Format( "<color=red>{0}</color>", i_logText );
            break;
        case LogType.Warning:
            i_logText += System.Environment.NewLine + i_stackTrace;
            i_logText = string.Format( "<color=yellow>{0}</color>", i_logText );
            break;
        default:
            break;
    }

        text.text += i_logText　+ System.Environment.NewLine;
        if(string.IsNullOrEmpty(i_stackTrace)){
            return;
        }
    }
    private void Update() {
        time += Time.deltaTime;
        if(time > 5){
            text.text = "";
            time = 0;
        }
    }
}
