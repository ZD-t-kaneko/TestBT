//------------------------------------------------------------------
// 実行(ビルド)日時をOnGUI()を用いて表示する
// 表示するシーンのオブジェクトにアタッチしておく
//------------------------------------------------------------------
using UnityEngine;
using System.Reflection;
using System;


[assembly: AssemblyVersion("1.0.*")]
public class DispVersion : MonoBehaviour
{
    public bool ShowVersionInformation = true;          // 表示フラグ

    bool flgInit = false;
    string strVersion;
    Rect position = new Rect(0, 0, 200, 20);            // 表示矩形(x,yは別途産出している)
    Color dispColor = Color.white;
 
    // バージョン情報の産出
    void Awake()
    {
        if (flgInit == true)
            return;
        flgInit = true;

        // 表示位置の産出(画面左下に表示する)
        position.x = 10f;
        position.y = Screen.height - position.height - 10f;

        // バージョン情報を文字列として取得しておく
        Assembly asm = Assembly.GetExecutingAssembly();
        System.Version ver = asm.GetName().Version;
        DateTime buildDateTime = new DateTime(2000, 1, 1, 0, 0, 0);
        buildDateTime = buildDateTime.AddDays(ver.Build);
        buildDateTime = buildDateTime.AddSeconds(ver.Revision * 2);
        strVersion = buildDateTime.ToString("yyyy/MM/dd HH:mm");
    }

    // バージョンを画面に表示する
    void OnGUI()
    { 
        if (!ShowVersionInformation) { 
            return; 
        }

        // バージョンを画面に表示する
        GUI.contentColor = Color.white;
        GUI.Label (position, string.Format("ver:{0}", strVersion)); 
    }

}
